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

            Dictionary<string, string> entries = new()
            {
                { m_Settings.GetSettingsLocaleID(), title },

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "City Start" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Key Bindings" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "About" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "CITY START SETTINGS" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BUDGET" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CONVERT UNLIMITED SAVE" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSTICS" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Initial Start Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Sets the starting balance for the next loaded <limited-money> city — new or existing.\n" +
                    "After it applies once, this setting resets to Game Default.\n" +
                    "If you choose a higher Starting Milestone, normal milestone cash rewards are added afterward, so the final balance will be higher.\n" +
                    "Enable <Disable Milestone Money Rewards> if you want to skip those cash bonuses."
                },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Game Default" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Game Default - No Milestone Skip" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Starting Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Leave this at <Game Default - No Milestone Skip> for normal progression.\n" +
                    "Or pick a milestone to unlock when the next city loads.\n" +
                    "If the city is already at or past the selected milestone, nothing happens."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Disable Milestone Money Rewards" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Removes the <cash bonus only> from milestone rewards.\n" +
                    "Milestone unlocks and other progression rewards still apply.\n" +
                    "Affects the selected starting milestone and milestones reached later.\n" +
                    "Changes take effect immediately - no restart needed.\n" +
                    "Turning this OFF restores cash rewards for future milestones; money already received or skipped is not changed."
                },

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

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Network Demolition Cost" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Adds a demolition charge based on the network's construction cost when removing roads, paths, rail, pipes, cables, and other networks.\n" +
                    "<0% = vanilla behavior.> The game's normal refund for recently built or modified networks still applies.\n" +
                    "<Warning: 50% can drain your budget faster.>"
                },


                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Reset to Game Defaults" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Resets all <City Start Settings> to vanilla behavior:\n" +
                    "Game Default money, no milestone skip, normal milestone cash rewards, and 0% network demolition cost.\n" +
                    "Does not undo milestone changes already applied to a city."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Add Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Hotkey to <Add Money> inside the city." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Add Money" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Subtract Money" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Hotkey to <Subtract Money> when in the city. Balance can go below zero."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Subtract Money" },


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

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Mod name" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Display name of this mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Current mod version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Open River-Mochi's Paradox Mods page." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Open the Discord support server." },

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
