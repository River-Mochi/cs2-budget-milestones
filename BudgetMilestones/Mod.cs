// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Purpose: Budget + Milestones entrypoint, settings, localization, systems, and logging.

namespace BudgetMilestones
{
    using System;
    using System.Reflection;

    using BudgetMilestones.Systems;

    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModName = "Budget + Milestones";
        public const string ModId = "BudgetMilestones";
        public const string ModTag = "[BM]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        internal static BMSettings? Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtils.Configure(ModId, s_Log);
            ShellOpen.Configure(s_Log, ModId, ModTag);

#if DEBUG
            LogUtils.Info($"{ModName} v{ModVersion} DEBUG loaded");
#else
            LogUtils.Info($"{ModName} v{ModVersion} loaded");
#endif

            if (GameManager.instance == null)
            {
                LogUtils.Warn($"{ModTag} GameManager.instance is null; {ModName} cannot initialize.");
                return;
            }

            BMSettings setting = new(this);
            Settings = BMSettings.Instance = setting;

            try
            {
                LocalizationManager? manager = GameManager.instance.localizationManager;
                if (manager != null)
                {
                    manager.AddSource("en-US", new LocaleEN(setting));
                   // manager.AddSource("fr-FR", new LocaleFR(setting));
                  //  manager.AddSource("es-ES", new LocaleES(setting));
                 //   manager.AddSource("de-DE", new LocaleDE(setting));
                //    manager.AddSource("it-IT", new LocaleIT(setting));
                //    manager.AddSource("ja-JP", new LocaleJA(setting));
                //    manager.AddSource("ko-KR", new LocaleKO(setting));
                //    manager.AddSource("pl-PL", new LocalePL(setting));
               //     manager.AddSource("pt-BR", new LocalePT_BR(setting));
               //     manager.AddSource("pt-PT", new LocalePT_PT(setting));
               //     manager.AddSource("zh-HANS", new LocaleZH_HANS(setting));
               //     manager.AddSource("zh-HANT", new LocaleZH_HANT(setting));
              //      manager.AddSource("th-TH", new LocaleTH(setting));
              //      manager.AddSource("vi-VN", new LocaleVI(setting));
              //      manager.AddSource("tr-TR", new LocaleTR(setting));
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error(
                    $"{ModTag} Localization registration failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            try
            {
                AssetDatabase.global.LoadSettings(
                    ModId,
                    setting,
                    new BMSettings(this));
            }
            catch (Exception ex)
            {
                LogUtils.Error(
                    $"{ModTag} Settings load failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            setting.NormalizeLoadedSettings();

            try
            {
                setting.RegisterInOptionsUI();
                setting.RegisterKeyBindings();
            }
            catch (Exception ex)
            {
                LogUtils.Error(
                    $"{ModTag} Settings registration failed: {ex.GetType().Name}: {ex.Message}",
                    ex);
            }

            updateSystem.UpdateAt<CityFinanceSystem>(SystemUpdatePhase.ModificationEnd);
            updateSystem.UpdateAt<MilestoneSystem>(SystemUpdatePhase.ModificationEnd);
        }

        public void OnDispose()
        {
            Settings?.UnregisterInOptionsUI();
            Settings = null;
        }
    }
}
