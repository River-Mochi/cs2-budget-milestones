// <copyright file="MilestoneSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/City/MilestoneSystem.cs
// Purpose: Applies the custom milestone setting and optional milestone cash-reward suppression.

namespace BudgetMilestones.Systems
{
    using System.Collections.Generic;

    using Colossal.Serialization.Entities;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.City;
    using Game.Common;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Simulation;

    using Unity.Collections;
    using Unity.Entities;
    using Unity.Mathematics;

    public partial class MilestoneSystem : GameSystemBase
    {
        private readonly Dictionary<int, int> m_OriginalMoneyRewards = new();

        private EntityArchetype m_UnlockEventArchetype;
        private EntityQuery m_MilestoneLevelGroup;
        private EntityQuery m_MilestoneGroup;
        private CitySystem m_CitySystem = null!;
        private bool m_HasCachedMoneyRewards;
        private bool m_AppliedDisableMoneyRewards;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CitySystem =
                World.GetOrCreateSystemManaged<CitySystem>();

            m_UnlockEventArchetype =
                EntityManager.CreateArchetype(
                    new ComponentType[]
                    {
                        ComponentType.ReadWrite<Event>(),
                        ComponentType.ReadWrite<Unlock>(),
                    });

            m_MilestoneLevelGroup =
                GetEntityQuery(
                    new ComponentType[]
                    {
                        ComponentType.ReadWrite<MilestoneLevel>(),
                    });

            m_MilestoneGroup =
                GetEntityQuery(
                    new ComponentType[]
                    {
                        ComponentType.ReadOnly<MilestoneData>(),
                    });

            RequireForUpdate(m_MilestoneLevelGroup);
            RequireForUpdate(m_MilestoneGroup);
        }

        protected override void OnDestroy()
        {
            RestoreMilestoneMoneyRewards();
            base.OnDestroy();
        }

        protected override void OnGameLoaded(
            Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);

            // If this world already had cached values, restore them before taking a fresh
            // snapshot for the newly loaded city.
            RestoreMilestoneMoneyRewards();
            CacheMilestoneMoneyRewards();
            ApplyMilestoneMoneyRewardSetting(force: true);

            if (GameManager.instance.gameMode == GameMode.Game)
            {
                ApplyConfiguredMilestone();
            }
        }

        protected override void OnUpdate()
        {
            if (GameManager.instance.gameMode != GameMode.Game || !m_HasCachedMoneyRewards)
            {
                return;
            }

            ApplyMilestoneMoneyRewardSetting(force: false);
        }

        private void CacheMilestoneMoneyRewards()
        {
            m_OriginalMoneyRewards.Clear();

            NativeArray<MilestoneData> milestoneData =
                m_MilestoneGroup.ToComponentDataArray<MilestoneData>(
                    Allocator.Temp);

            try
            {
                for (int i = 0; i < milestoneData.Length; i++)
                {
                    MilestoneData milestone = milestoneData[i];
                    m_OriginalMoneyRewards[milestone.m_Index] = milestone.m_Reward;
                }

                m_HasCachedMoneyRewards = milestoneData.Length > 0;
            }
            finally
            {
                milestoneData.Dispose();
            }
        }

        private void ApplyMilestoneMoneyRewardSetting(bool force)
        {
            if (!m_HasCachedMoneyRewards)
            {
                return;
            }

            bool disable = BMSettings.Instance.DisableMilestoneMoneyRewards;
            if (!force && disable == m_AppliedDisableMoneyRewards)
            {
                return;
            }

            NativeArray<Entity> milestoneEntities =
                m_MilestoneGroup.ToEntityArray(Allocator.Temp);

            NativeArray<MilestoneData> milestoneData =
                m_MilestoneGroup.ToComponentDataArray<MilestoneData>(
                    Allocator.Temp);

            try
            {
                for (int i = 0; i < milestoneData.Length; i++)
                {
                    MilestoneData milestone = milestoneData[i];
                    if (!m_OriginalMoneyRewards.TryGetValue(
                            milestone.m_Index,
                            out int originalReward))
                    {
                        continue;
                    }

                    int desiredReward = disable ? 0 : originalReward;
                    if (milestone.m_Reward == desiredReward)
                    {
                        continue;
                    }

                    milestone.m_Reward = desiredReward;
                    EntityManager.SetComponentData(
                        milestoneEntities[i],
                        milestone);

                    if (!EntityManager.HasComponent<BatchesUpdated>(
                            milestoneEntities[i]))
                    {
                        EntityManager.AddComponent<BatchesUpdated>(
                            milestoneEntities[i]);
                    }
                }
            }
            finally
            {
                milestoneEntities.Dispose();
                milestoneData.Dispose();
            }

            m_AppliedDisableMoneyRewards = disable;

            LogUtils.Info(() =>
                disable
                    ? "Milestone money rewards disabled."
                    : "Milestone money rewards restored.");
        }

        private void RestoreMilestoneMoneyRewards()
        {
            if (!m_HasCachedMoneyRewards)
            {
                return;
            }

            NativeArray<Entity> milestoneEntities =
                m_MilestoneGroup.ToEntityArray(Allocator.Temp);

            NativeArray<MilestoneData> milestoneData =
                m_MilestoneGroup.ToComponentDataArray<MilestoneData>(
                    Allocator.Temp);

            try
            {
                for (int i = 0; i < milestoneData.Length; i++)
                {
                    MilestoneData milestone = milestoneData[i];
                    if (!m_OriginalMoneyRewards.TryGetValue(
                            milestone.m_Index,
                            out int originalReward) ||
                        milestone.m_Reward == originalReward)
                    {
                        continue;
                    }

                    milestone.m_Reward = originalReward;
                    EntityManager.SetComponentData(
                        milestoneEntities[i],
                        milestone);

                    if (!EntityManager.HasComponent<BatchesUpdated>(
                            milestoneEntities[i]))
                    {
                        EntityManager.AddComponent<BatchesUpdated>(
                            milestoneEntities[i]);
                    }
                }
            }
            finally
            {
                milestoneEntities.Dispose();
                milestoneData.Dispose();
            }

            m_OriginalMoneyRewards.Clear();
            m_HasCachedMoneyRewards = false;
            m_AppliedDisableMoneyRewards = false;
        }

        private void ApplyConfiguredMilestone()
        {
            if (BMSettings.Instance.MilestoneLevel < 0)
            {
                return;
            }

            NativeArray<Entity> milestoneEntities =
                m_MilestoneGroup.ToEntityArray(
                    Allocator.TempJob);

            NativeArray<MilestoneData> milestoneData =
                m_MilestoneGroup.ToComponentDataArray<MilestoneData>(
                    Allocator.TempJob);

            try
            {
                MilestoneLevel milestoneLevel =
                    m_MilestoneLevelGroup
                        .GetSingleton<MilestoneLevel>();

                if (!TryGetTargetMilestone(
                        milestoneEntities,
                        milestoneLevel,
                        out int targetMilestone))
                {
                    return;
                }

                PlayerMoney playerMoney =
                    EntityManager.GetComponentData<PlayerMoney>(
                        m_CitySystem.City);

                Creditworthiness creditworthiness =
                    EntityManager.GetComponentData<Creditworthiness>(
                        m_CitySystem.City);

                DevTreePoints devTreePoints =
                    EntityManager.GetComponentData<DevTreePoints>(
                        m_CitySystem.City);

                XP xp =
                    EntityManager.GetComponentData<XP>(
                        m_CitySystem.City);

                for (int i = milestoneLevel.m_AchievedMilestone;
                     i < targetMilestone;
                     i++)
                {
                    QueueMilestoneUnlock(
                        milestoneEntities[i]);

                    milestoneLevel.m_AchievedMilestone =
                        math.max(
                            milestoneLevel.m_AchievedMilestone,
                            milestoneData[i].m_Index);

                    ApplyMilestoneRewards(
                        milestoneData[i],
                        ref playerMoney,
                        ref creditworthiness,
                        ref devTreePoints,
                        ref xp);
                }

                m_MilestoneLevelGroup.SetSingleton(
                    milestoneLevel);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    playerMoney);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    creditworthiness);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    devTreePoints);

                EntityManager.SetComponentData(
                    m_CitySystem.City,
                    xp);

                LogUtils.Info(
                    () =>
                        $"Unlock level " +
                        $"{BMSettings.Instance.MilestoneLevel + 1} " +
                        "Milestone");
            }
            finally
            {
                if (milestoneEntities.IsCreated)
                {
                    milestoneEntities.Dispose();
                }

                if (milestoneData.IsCreated)
                {
                    milestoneData.Dispose();
                }
            }
        }

        private static bool TryGetTargetMilestone(
            NativeArray<Entity> milestoneEntities,
            MilestoneLevel currentMilestone,
            out int targetMilestone)
        {
            targetMilestone =
                math.min(
                    BMSettings.Instance.MilestoneLevel + 1,
                    milestoneEntities.Length);

            return
                currentMilestone.m_AchievedMilestone <
                targetMilestone;
        }

        private void QueueMilestoneUnlock(
            Entity milestoneEntity)
        {
            Entity entity =
                EntityManager.CreateEntity(
                    m_UnlockEventArchetype);

            EntityManager.SetComponentData(
                entity,
                new Unlock(milestoneEntity));
        }

        private static void ApplyMilestoneRewards(
            MilestoneData milestoneData,
            ref PlayerMoney playerMoney,
            ref Creditworthiness creditworthiness,
            ref DevTreePoints devTreePoints,
            ref XP xp)
        {
            // m_Reward is zero while Disable Milestone Money Rewards is enabled.
            playerMoney.Add(
                milestoneData.m_Reward);

            creditworthiness.m_Amount +=
                milestoneData.m_LoanLimit;

            devTreePoints.m_Points +=
                milestoneData.m_DevTreePoints;

            xp.m_XP =
                milestoneData.m_XpRequried;
        }
    }
}
