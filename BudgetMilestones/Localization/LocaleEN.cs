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

                // Tabs
                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "City Start" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Key Bindings" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "About" },

                // Groups
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "CITY START SETTINGS" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BUDGET" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CONVERT UNLIMITED SAVE" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSTICS" },

                // City Start
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
                    "- If you forgot and loaded a city, restart the game and pick the milestone before entering a city.\n" +
                    "- The mod cannot undo milestone changes already saved into a city; use an earlier save if needed."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Pick a milestone level to unlock on the next city load.\n" +
                    "This is <only adjustable outside a loaded city>, and only after Milestone Selector is enabled [ ✓ ].\n" +
                    "If the city is already at or past the selected milestone, nothing happens."
                },

                // Budget
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Money Hotkey Amount" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Use this amount with the Add Money and Subtract Money hotkeys.\n" +
                    "<Mod default = 40,000>\n" +
                    "For automated money, enable Automatic Add Money."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Automatic Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "When enabled [ ✓ ], Budget + Milestones checks the city balance while a city is loaded.\n" +
                    "- If the balance is <below the threshold>, it adds enough to reach the threshold.\n" +
                    "- It always adds at least the selected Automatic Money Amount."
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

                // Key Bindings
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Hotkey to <Add Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Hotkey to <Subtract Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Subtract Money" },

                // Unlimited Money Converter
                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Unlimited Money Converter" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Make a Backup of city FIRST>.\n" +
                    "Converts a city that started as Unlimited Money to normal limited-money budgeting.\n" +
                    "Enabling this unlocks the conversion button when an Unlimited Money city is loaded.\n" +
                    "Budget + Milestones cannot undo this conversion."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Convert Unlimited Money Save City to Normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "For cities started with <Unlimited Money>.\n" +
                    "While that city is loaded, this converts the save to normal limited-money budgeting.\n" +
                    "The button is disabled unless the loaded city uses Unlimited Money and Unlimited Money Converter is ON [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Convert this city from Unlimited Money to normal limited money?\n" +
                    "Save a backup FIRST; Budget + Milestones cannot undo this.\n" +
                    "Are you sure?"
                },

                // About
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
