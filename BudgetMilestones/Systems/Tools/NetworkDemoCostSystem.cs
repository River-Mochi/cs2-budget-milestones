// <copyright file="NetworkDemoCostSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/Tools/NetworkDemoCostSystem.cs
// Purpose: Charges an optional percentage of current construction cost when bulldozing network segments.

namespace BudgetMilestones.Systems
{
    using CS2Shared.RiverMochi;

    using Game;
    using Game.City;
    using Game.Common;
    using Game.Net;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Simulation;
    using Game.Tools;

    using Unity.Collections;
    using Unity.Entities;

    public partial class NetworkDemoCostSystem : GameSystemBase
    {
        private CitySystem m_CitySystem = null!;
        private ToolSystem m_ToolSystem = null!;
        private BulldozeToolSystem m_BulldozeToolSystem = null!;
        private EntityQuery m_DefinitionQuery;
        private bool m_WasApplying;
        private int m_PreviewCost;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CitySystem = World.GetOrCreateSystemManaged<CitySystem>();
            m_ToolSystem = World.GetOrCreateSystemManaged<ToolSystem>();
            m_BulldozeToolSystem = World.GetOrCreateSystemManaged<BulldozeToolSystem>();

            m_DefinitionQuery = SystemAPI.QueryBuilder()
                .WithAll<CreationDefinition>()
                .WithNone<Updated>()
                .Build();
        }

        protected override void OnUpdate()
        {
            if (GameManager.instance.gameMode != GameMode.Game ||
            BMSettings.Instance.NetworkDemolitionCostPercent <= 0 ||
            m_ToolSystem.activeTool != m_BulldozeToolSystem)
            {
                ResetPreview();
                return;
            }

            bool isApplying =
                m_ToolSystem.activeTool.applyMode == ApplyMode.Apply;

            if (!isApplying)
            {
                m_PreviewCost = CalculateCurrentNetworkDemolitionCost();
            }
            else if (!m_WasApplying)
            {
                int cost = m_PreviewCost;
                if (cost <= 0)
                {
                    cost = CalculateCurrentNetworkDemolitionCost();
                }

                ApplyDemolitionCost(cost);
            }

            m_WasApplying = isApplying;
        }

        private int CalculateCurrentNetworkDemolitionCost()
        {
            int percent = BMSettings.Instance.NetworkDemolitionCostPercent;
            if (percent <= 0)
            {
                return 0;
            }

            long fullConstructionCost = 0;

            NativeArray<CreationDefinition> definitions =
                m_DefinitionQuery.ToComponentDataArray<CreationDefinition>(
                    Allocator.Temp);

            try
            {
                for (int i = 0; i < definitions.Length; i++)
                {
                    CreationDefinition definition = definitions[i];

                    if (!definition.m_Flags.HasFlag(CreationFlags.Delete))
                    {
                        continue;
                    }

                    Entity original = definition.m_Original;
                    if (original == Entity.Null ||
                        !EntityManager.Exists(original) ||
                        !EntityManager.HasComponent<Curve>(original) ||
                        !EntityManager.HasComponent<Edge>(original) ||
                        !EntityManager.HasComponent<Composition>(original))
                    {
                        continue;
                    }

                    Curve curve =
                        EntityManager.GetComponentData<Curve>(original);

                    Edge edge =
                        EntityManager.GetComponentData<Edge>(original);

                    Composition composition =
                        EntityManager.GetComponentData<Composition>(original);

                    Entity compositionEntity = composition.m_Edge;
                    if (compositionEntity == Entity.Null ||
                        !EntityManager.Exists(compositionEntity) ||
                        !EntityManager.HasComponent<PlaceableNetComposition>(
                            compositionEntity))
                    {
                        continue;
                    }

                    PlaceableNetComposition placeableNet =
                        EntityManager.GetComponentData<PlaceableNetComposition>(
                            compositionEntity);

                    Elevation startElevation = default;
                    Elevation endElevation = default;

                    if (edge.m_Start != Entity.Null &&
                        EntityManager.Exists(edge.m_Start) &&
                        EntityManager.HasComponent<Elevation>(edge.m_Start))
                    {
                        startElevation =
                            EntityManager.GetComponentData<Elevation>(
                                edge.m_Start);
                    }

                    if (edge.m_End != Entity.Null &&
                        EntityManager.Exists(edge.m_End) &&
                        EntityManager.HasComponent<Elevation>(edge.m_End))
                    {
                        endElevation =
                            EntityManager.GetComponentData<Elevation>(
                                edge.m_End);
                    }

                    int constructionCost =
                        NetUtils.GetConstructionCost(
                            curve,
                            startElevation,
                            endElevation,
                            placeableNet);

                    if (constructionCost > 0)
                    {
                        fullConstructionCost += constructionCost;
                    }
                }
            }
            finally
            {
                definitions.Dispose();
            }

            if (fullConstructionCost <= 0)
            {
                return 0;
            }

            long demolitionCost =
                ((fullConstructionCost * percent) + 50L) / 100L;

            if (demolitionCost > int.MaxValue)
            {
                return int.MaxValue;
            }

            return (int)demolitionCost;
        }

        private void ApplyDemolitionCost(int cost)
        {
            if (cost <= 0)
            {
                return;
            }

            Entity city = m_CitySystem.City;
            if (city == Entity.Null ||
                !EntityManager.Exists(city) ||
                !EntityManager.HasComponent<PlayerMoney>(city))
            {
                return;
            }

            PlayerMoney playerMoney =
                EntityManager.GetComponentData<PlayerMoney>(city);

            if (playerMoney.m_Unlimited)
            {
                return;
            }

            int previousMoney = playerMoney.money;

            playerMoney.Subtract(cost);
            EntityManager.SetComponentData(city, playerMoney);

            LogUtils.Info(() =>
                $"Network demolition cost: {cost:N0} " +
                $"({BMSettings.Instance.NetworkDemolitionCostPercent}%). " +
                $"Money {previousMoney:N0} -> {playerMoney.money:N0}");
        }

        private void ResetPreview()
        {
            m_WasApplying = false;
            m_PreviewCost = 0;
        }
    }
}
