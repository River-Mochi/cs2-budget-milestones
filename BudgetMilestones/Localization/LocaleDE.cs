// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// Purpose: German Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleDE(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Stadtstart" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Tasten" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Info" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "STADTSTART" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BUDGET" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "UNBEGRENZTES GELD UMWANDELN" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSE" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Startgeld" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Legt das Startguthaben für die nächste geladene Stadt mit <begrenztem Geld> fest — neu oder vorhanden.\n" +
                    "Nach einmaliger Anwendung wird diese Option auf Spielstandard zurückgesetzt.\n" +
                    "<Ist die Option ausgegraut>, geh ins Hauptmenü (oder starte das Spiel neu) und öffne die Optionen erneut.\n" +
                    "Wählst du einen höheren Start-Meilenstein, kommen normale Meilenstein-Geldboni danach dazu.\n" +
                    "Aktiviere <Meilenstein-Geldboni deaktivieren>, wenn du diese Boni überspringen willst."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Spielstandard" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Spielstandard - keine Meilensteine überspringen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Start-Meilenstein" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Für normalen Fortschritt auf <Spielstandard - keine Meilensteine überspringen> lassen.\n" +
                    "Oder einen Meilenstein wählen, der beim nächsten Laden einer Stadt freigeschaltet wird.\n" +
                    "Ist die Stadt schon dort oder weiter, passiert nichts."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Meilenstein-Geldboni deaktivieren" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Entfernt nur den <Geldbonus> aus Meilenstein-Belohnungen.\n" +
                    "Freischaltungen und andere Belohnungen bleiben erhalten.\n" +
                    "Gilt für den gewählten Start-Meilenstein und spätere Meilensteine.\n" +
                    "Wirkt sofort - kein Neustart nötig.\n" +
                    "AUS stellt Geldboni für künftige Meilensteine wieder her; bereits erhaltenes oder übersprungenes Geld bleibt unverändert."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Hotkey-Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Dieser Betrag wird mit den Hotkeys Geld hinzufügen/abziehen genutzt.\n" +
                    "<Mod-Standard = 40.000>\n" +
                    "Für automatisches Geld: Automatisch Geld hinzufügen aktivieren."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Automatisch Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Wenn aktiviert [ ✓ ], prüft Budget + Milestones das Stadtguthaben.\n" +
                    "- Unter dem <Schwellenwert> wird genug Geld bis zum Schwellenwert hinzugefügt.\n" +
                    "- Mindestens der gewählte automatische Geldbetrag wird hinzugefügt."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Automatischer Geld-Schwellenwert" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Ist Automatisch Geld hinzufügen aktiv und das Guthaben liegt darunter,\n" +
                    "wird Geld bis mindestens zu diesem Wert hinzugefügt."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Automatischer Geldbetrag" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Mindestbetrag, der bei jeder automatischen Auslösung hinzugefügt wird.\n" +
                    "Ist mehr bis zum Schwellenwert nötig, wird der höhere Betrag genommen."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Netzwerk-Abrisskosten" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Berechnet beim Abriss von Straßen, Wegen, Schienen, Rohren, Kabeln usw. einen Anteil der Baukosten.\n" +
                    "<0% = Vanilla.> Normale Rückerstattungen für kürzlich gebaute oder geänderte Netze bleiben erhalten.\n" +
                    "<Warnung: 50% kann dein Budget schnell leeren.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Auf Spielstandard zurücksetzen" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Setzt alle <Stadtstart-Einstellungen> auf Vanilla zurück:\n" +
                    "Spielstandard-Geld, kein Meilenstein-Sprung, normale Geldboni und 0% Abrisskosten.\n" +
                    "Bereits angewendete Meilenstein-Änderungen werden nicht rückgängig gemacht."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Geld hinzufügen" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Hotkey zum <Geld hinzufügen> in der Stadt." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Geld hinzufügen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Geld abziehen" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Hotkey zum <Geld abziehen> in der Stadt. Das Guthaben kann unter null fallen."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Geld abziehen" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Unbegrenztes-Geld-Konverter" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Erst eine Sicherung der Stadt machen>.\n" +
                    "Wandelt eine Stadt mit Unbegrenztem Geld in normales begrenztes Budget um.\n" +
                    "Aktivieren, um den Umwandeln-Button in einer Unbegrenztes-Geld-Stadt freizuschalten.\n" +
                    "Budget + Milestones kann die Umwandlung nicht rückgängig machen."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Unbegrenztes Geld in normales Budget umwandeln" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Für Städte, die mit <Unbegrenztem Geld> gestartet wurden.\n" +
                    "Während die Stadt geladen ist, wird der Spielstand auf normales begrenztes Budget umgestellt.\n" +
                    "Der Button ist nur aktiv, wenn Unbegrenztes Geld genutzt wird und der Konverter EIN [ ✓ ] ist."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Diese Stadt von Unbegrenztem Geld auf normales begrenztes Budget umstellen?\n" +
                    "ZUERST eine Sicherung speichern; Budget + Milestones kann das nicht rückgängig machen.\n" +
                    "Sicher?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Mod-Name" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Anzeigename dieser Mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Aktuelle Mod-Version." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mochis Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Öffnet River-Mochis Paradox-Mods-Seite." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Öffnet den Discord-Supportserver." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Log öffnen" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Öffnet </Logs/BudgetMilestones.log>, falls vorhanden.\n" +
                    "Fehlt die Datei, wird stattdessen der Logs/-Ordner geöffnet."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
