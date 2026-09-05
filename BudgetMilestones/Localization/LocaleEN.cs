// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// Purpose: English Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleEN(BMSettings setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += " (" + Mod.ModVersion + ")";
            }

            Dictionary<string, string> entries = new()
            {
                { m_Settings.GetSettingsLocaleID(), title },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kMainTab), "Budget + Milestones" },

                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Key Bindings" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "About" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "CITY START SETTINGS" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "Money" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "Convert Unlimited Save" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSTICS" },

                // --------------------------------------------------------------------
                // City Start
                // --------------------------------------------------------------------

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Initial Start Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Sets the balance for the next loaded <limited-money> city — new or existing.\n" +
                    "After it applies once, this setting resets to Game Default.\n" +
                    "This is grayed out once a city is already loaded.\n" +
                    "Set it before loading or starting the city. Afterward, use <Money Hotkey Amount> if needed."
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.CustomMilestone)), "Milestone Selector" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.CustomMilestone)),
                    "Enable <before loading or starting a city> to unlock a chosen milestone immediately after the city loads.\n" +
                    "- Cannot be turned ON after a city is loaded, but it can be turned OFF if it was left enabled by mistake.\n" +
                    "- If you forgot and loaded a city, just restart the game, and pick milestone before entering a city.\n" +
                    "- Mod cannot undo milestone changes already saved into a city; use an earlier save if needed."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Pick a milestone level to unlock on the next city load.\n" +
                    "This is <only adjustable outside a loaded city>, and only after [Milestone Selector] is enabled [ ✓ ].\n" +
                    "If the city is already at or past the milestone selected, then nothing will happen.\n" +
                    "A change only happens if the milestone selected here is higher than what the city has."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Money Hotkey Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Use this amount with the Add Money and Subtract Money hotkeys.\n" +
                    "<Mod default = 40,000>\n" +
                    "This does nothing unless you use the hotkey to add/subtract money (in the city).\n" +
                    "For automated money, enable the Automatic Add Money option."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Hotkey to <Add Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Hotkey to <Subtract Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Subtract Money" },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "When enabled [ ✓ ], Budget + Milestones checks the city balance while a city is loaded.\n" +
                    "- If the balance is <below the threshold>, it adds enough to reach the threshold.\n" +
                    "- It always adds at least the selected Automatic Money Amount.\n" +
                    "- Manual money hotkeys (<[> or <]>) are recommended when you only need money occasionally."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Automatic Money Threshold" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "If Automatic Add Money is enabled and the city balance falls below this value,\n" +
                    "money is added until the city reaches at least this threshold."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Automatic Money Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Minimum amount added each time Automatic Add Money triggers.\n" +
                    "If more is needed to reach the threshold, Budget + Milestones adds the larger amount."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Unlimited Money Converter" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Make a Backup of city FIRST>.\n" +
                    "Converts a city that started as Unlimited Money to a normal city with regular money challenges.\n" +
                    "Enabling this unlocks the <[Convert Unlimited Money Save]> button when the loaded city is <Unlimited Money> type.\n" +
                    "Budget + Milestones cannot undo this conversion.\n" +
                    "If you have normal cities, do not worry about this; it is not needed."
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Convert Unlimited Money Save City to Normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "For cities started with <Unlimited Money>.\n" +
                    "While that city is loaded, this converts the save to normal limited-money budgeting so the city has regular money challenges again.\n" +
                    "Button is <disabled/greyed-out> unless the loaded city is an <Unlimited Money> type\n" +
                    "and <Unlimited Money Converter> is ON [ ✓ ].\n" +
                    "Make a backup save, and use at your own risk; Budget + Milestones cannot undo this conversion."
                },
                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Convert this city from Unlimited Money to normal limited money?\n" +
                    "Save a backup FIRST; Budget + Milestones cannot undo this.\n" +
                    "Are you sure?"
                },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Mod name" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Display name of this mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Current mod version." },
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Opens </Logs/BudgetMilestones.log> if it exists.\n" +
                    "If the log file is missing, opens the Logs/ folder instead."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
