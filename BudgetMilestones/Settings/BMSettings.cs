// <copyright file="BMSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/BMSettings.cs
// Purpose: Budget, milestone, hotkey, demolition-cost, and Unlimited Money conversion settings.

namespace BudgetMilestones
{
    using System;
    using System.Collections.Generic;

    using BudgetMilestones.Systems;

    using Colossal.IO.AssetDatabase;

    using CS2Shared.RiverMochi;

    using Game;
    using Game.Input;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Settings;
    using Game.UI;
    using Game.UI.Widgets;

    using Unity.Entities;

    using UnityEngine;

    [FileLocation("ModsSettings/BudgetMilestones/BudgetMilestones")]
    [SettingsUITabOrder(kCityStart, kHotkeys, kAbout)]
    [SettingsUIGroupOrder(kCityStartGroup, kBudgetGroup, kSaveConversion, kHotkeyGroup, kAboutInfo, kAboutLinks, kAboutDiagnostics)]
    [SettingsUIShowGroupName(kCityStartGroup, kBudgetGroup, kSaveConversion, kAboutDiagnostics)]
    public sealed class BMSettings : ModSetting
    {
        internal static BMSettings Instance { get; set; } = null!;

        internal const string kCityStart = "CityStart";
        internal const string kHotkeys = "Hotkeys";
        internal const string kAbout = "About";

        internal const string kCityStartGroup = "CityStartSettings";
        internal const string kBudgetGroup = "Budget";
        internal const string kSaveConversion = "SaveConversion";
        internal const string kHotkeyGroup = "BudgetHotkeys";
        internal const string kAboutInfo = "AboutInfo";
        internal const string kAboutLinks = "AboutLinks";
        internal const string kAboutDiagnostics = "AboutDiagnostics";

        public const string AddMoneyAction = nameof(AddMoneyAction);
        public const string SubtractMoneyAction = nameof(SubtractMoneyAction);

        private const int kMilestoneTinyVillage = 0;
        private const string kAboutLinksRow = "AboutLinksRow";

        private const string kUrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string kUrlDiscord =
            "https://discord.gg/gwXgvtyhjc";

        private static readonly string[] s_Milestones =
        {
            "TinyVillage",
            "SmallVillage",
            "LargeVillage",
            "GrandVillage",
            "TinyTown",
            "BoomTown",
            "BusyTown",
            "BigTown",
            "GreatTown",
            "SmallCity",
            "BigCity",
            "LargeCity",
            "HugeCity",
            "GrandCity",
            "Metropolis",
            "ThrivingMetropolis",
            "FlourishingMetropolis",
            "ExpansiveMetropolis",
            "MassiveMetropolis",
            "Megalopolis",
        };

        public BMSettings(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        [SettingsUIDropdown(typeof(BMSettings), nameof(GetInitialMoneyItems))]
        [SettingsUISection(kCityStart, kCityStartGroup)]
        [SettingsUIDisableByCondition(typeof(BMSettings), nameof(IsInGame))]
        public int InitialMoney { get; set; }

        [SettingsUISection(kCityStart, kCityStartGroup)]
        [SettingsUIDisableByCondition(typeof(BMSettings), nameof(CannotEnableCustomMilestoneInGame))]
        public bool CustomMilestone { get; set; }

        [SettingsUIDropdown(typeof(BMSettings), nameof(GetMilestoneLevelItems))]
        [SettingsUISection(kCityStart, kCityStartGroup)]
        [SettingsUIDisableByCondition(typeof(BMSettings), nameof(GetMilestoneLevelStatus))]
        public int MilestoneLevel { get; set; }

        [SettingsUISection(kCityStart, kCityStartGroup)]
        public bool DisableMilestoneMoneyRewards { get; set; }

        [SettingsUISlider(min = 20000, max = 2000000, step = 20000, scalarMultiplier = 1, unit = Unit.kInteger)]
        [SettingsUISection(kCityStart, kBudgetGroup)]
        public int ManualMoneyAmount { get; set; }

        [SettingsUISection(kCityStart, kBudgetGroup)]
        public bool AutomaticAddMoney { get; set; }

        [SettingsUIDropdown(typeof(BMSettings), nameof(GetAutomaticAddMoneyThresholdItems))]
        [SettingsUISection(kCityStart, kBudgetGroup)]
        [SettingsUIDisableByCondition(typeof(BMSettings), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyThreshold { get; set; }

        [SettingsUIDropdown(typeof(BMSettings), nameof(GetAutomaticAddMoneyAmountItems))]
        [SettingsUISection(kCityStart, kBudgetGroup)]
        [SettingsUIDisableByCondition(typeof(BMSettings), nameof(EnsureAutomaticAddMoneyEnabled))]
        public int AutomaticAddMoneyAmount { get; set; }

        [SettingsUISlider(min = 0, max = 50, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kCityStart, kBudgetGroup)]
        public int NetworkDemolitionCostPercent { get; set; }

        [SettingsUISection(kCityStart, kSaveConversion)]
        public bool ConfirmUnlimitedMoneySaveConversion { get; set; }

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(kCityStart, kSaveConversion)]
        [SettingsUIDisableByCondition(typeof(BMSettings), nameof(CannotConvertUnlimitedMoneySave))]
        public bool ConvertUnlimitedMoneySave
        {
            set
            {
                if (!value)
                {
                    return;
                }

                CityFinanceSystem? financeSystem = GetCityFinanceSystem();
                if (financeSystem?.CanConvertUnlimitedMoneySave() == true)
                {
                    financeSystem.SetUnlimitedMoneyToLimitedMoney();
                }
            }
        }

        [SettingsUIKeyboardBinding(BindingKeyboard.LeftBracket, AddMoneyAction)]
        [SettingsUISection(kHotkeys, kHotkeyGroup)]
        public ProxyBinding AddMoneyKeyboardBinding { get; set; }

        [SettingsUIKeyboardBinding(BindingKeyboard.RightBracket, SubtractMoneyAction)]
        [SettingsUISection(kHotkeys, kHotkeyGroup)]
        public ProxyBinding SubtractMoneyKeyboardBinding { get; set; }

        [SettingsUISection(kAbout, kAboutInfo)]
        public string NameText => Mod.ModName;

        [SettingsUISection(kAbout, kAboutInfo)]
        public string VersionText =>
#if DEBUG
            Mod.ModVersion + " (DEBUG)";
#else
            Mod.ModVersion;
#endif

        [SettingsUIButtonGroup(kAboutLinksRow)]
        [SettingsUIButton]
        [SettingsUISection(kAbout, kAboutLinks)]
        public bool OpenParadox
        {
            set
            {
                if (value)
                {
                    TryOpenUrl(kUrlParadox);
                }
            }
        }

        [SettingsUIButtonGroup(kAboutLinksRow)]
        [SettingsUIButton]
        [SettingsUISection(kAbout, kAboutLinks)]
        public bool OpenDiscord
        {
            set
            {
                if (value)
                {
                    TryOpenUrl(kUrlDiscord);
                }
            }
        }

        [SettingsUIButton]
        [SettingsUISection(kAbout, kAboutDiagnostics)]
        public bool OpenLog
        {
            set
            {
                if (value)
                {
                    ShellOpen.OpenModLogOrLogsFolder();
                }
            }
        }

        private static bool IsInGame()
        {
            return GameManager.instance != null &&
                   GameManager.instance.gameMode == GameMode.Game;
        }

        private bool CannotEnableCustomMilestoneInGame()
        {
            return IsInGame() && !CustomMilestone;
        }

        public bool EnsureAutomaticAddMoneyEnabled()
        {
            return !AutomaticAddMoney;
        }

        private bool GetMilestoneLevelStatus()
        {
            return IsInGame() || !CustomMilestone;
        }

        private bool CannotConvertUnlimitedMoneySave()
        {
            return !ConfirmUnlimitedMoneySaveConversion ||
                   GetCityFinanceSystem()?.CanConvertUnlimitedMoneySave() != true;
        }

        private static CityFinanceSystem? GetCityFinanceSystem()
        {
            return World.DefaultGameObjectInjectionWorld?
                .GetExistingSystemManaged<CityFinanceSystem>();
        }

        private static void TryOpenUrl(string url)
        {
            try
            {
                Application.OpenURL(url);
            }
            catch (Exception ex)
            {
                LogUtils.WarnOnce(
                    "open-url-" + url,
                    () => $"Failed to open URL '{url}': {ex.GetType().Name}: {ex.Message}",
                    ex);
            }
        }

        public DropdownItem<int>[] GetAutomaticAddMoneyThresholdItems()
        {
            return new[]
            {
                CreateDropdownItem(10000),
                CreateDropdownItem(100000),
                CreateDropdownItem(1000000),
                CreateDropdownItem(10000000),
            };
        }

        public DropdownItem<int>[] GetAutomaticAddMoneyAmountItems()
        {
            return new[]
            {
                CreateDropdownItem(10000),
                CreateDropdownItem(100000),
                CreateDropdownItem(1000000),
                CreateDropdownItem(10000000),
                CreateDropdownItem(100000000),
            };
        }

        public DropdownItem<int>[] GetInitialMoneyItems()
        {
            return new[]
            {
                new DropdownItem<int>
                {
                    value = 0,
                    displayName = GetOptionLocaleID("GameDefault"),
                },
                CreateDropdownItem(100000),
                CreateDropdownItem(500000),
                CreateDropdownItem(5000000),
                CreateDropdownItem(10000000),
                CreateDropdownItem(100000000),
            };
        }

        private static DropdownItem<int>[] GetMilestoneLevelItems()
        {
            List<DropdownItem<int>> items = new();
            for (int i = 0; i < s_Milestones.Length; i++)
            {
                items.Add(
                    new DropdownItem<int>
                    {
                        value = i,
                        displayName = MilestoneDisplay.Get(i, s_Milestones[i]),
                    });
            }

            return items.ToArray();
        }

        private static DropdownItem<int> CreateDropdownItem(int value)
        {
            return new DropdownItem<int>
            {
                value = value,
                displayName = value.ToString("N0"),
            };
        }

        public override void SetDefaults()
        {
            ManualMoneyAmount = 40000;
            AutomaticAddMoney = false;
            AutomaticAddMoneyThreshold = 100000;
            AutomaticAddMoneyAmount = 10000;
            NetworkDemolitionCostPercent = 0;
            InitialMoney = 0;
            CustomMilestone = false;
            DisableMilestoneMoneyRewards = false;
            MilestoneLevel = kMilestoneTinyVillage;
            ConfirmUnlimitedMoneySaveConversion = false;
        }

        public void NormalizeLoadedSettings()
        {
            if (ManualMoneyAmount < 20000 || ManualMoneyAmount > 2000000)
            {
                ManualMoneyAmount = 40000;
            }

            MilestoneLevel = Math.Clamp(MilestoneLevel, 0, s_Milestones.Length - 1);
            NetworkDemolitionCostPercent = Math.Clamp(NetworkDemolitionCostPercent, 0, 50);

            if (InitialMoney < 0)
            {
                InitialMoney = 0;
            }
        }

        public void ResetInitialMoney()
        {
            InitialMoney = 0;
        }

        public string GetOptionLocaleID(string localeId)
        {
            return $"Options[{id}.{localeId}]";
        }
    }
}
