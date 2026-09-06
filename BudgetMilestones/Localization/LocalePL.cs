// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// Purpose: Polish Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocalePL(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Start miasta" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Klawisze" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "O modzie" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "USTAWIENIA STARTU MIASTA" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BUDŻET" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "KONWERSJA NIELIMITOWANYCH PIENIĘDZY" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSTYKA" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Pieniądze na start" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Ustawia saldo startowe dla następnego wczytanego miasta z <ograniczonymi pieniędzmi> — nowego lub istniejącego.\n" +
                    "Po jednorazowym użyciu wraca do ustawień gry.\n" +
                    "<Jeśli opcja jest wyszarzona>, wróć do menu głównego (albo uruchom grę ponownie) i otwórz Opcje jeszcze raz.\n" +
                    "Przy wyższym kamieniu milowym na start normalne nagrody pieniężne z kamieni milowych zostaną dodane później.\n" +
                    "Włącz <Wyłącz nagrody pieniężne za kamienie milowe>, jeśli nie chcesz tych bonusów."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Ustawienia gry" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Ustawienia gry - bez pomijania kamieni milowych" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Kamień milowy na start" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Dla normalnego postępu zostaw <Ustawienia gry - bez pomijania kamieni milowych>.\n" +
                    "Albo wybierz kamień milowy do odblokowania przy następnym wczytaniu miasta.\n" +
                    "Jeśli miasto już go osiągnęło lub jest dalej, nic się nie stanie."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Wyłącz nagrody pieniężne za kamienie milowe" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Usuwa tylko <bonus pieniężny> z nagród za kamienie milowe.\n" +
                    "Odblokowania i inne nagrody nadal działają.\n" +
                    "Dotyczy wybranego kamienia milowego na start i kolejnych.\n" +
                    "Zmiana działa od razu, bez restartu.\n" +
                    "Po wyłączeniu przyszłe nagrody pieniężne wracają; już otrzymane lub pominięte pieniądze się nie zmienią."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Kwota skrótu pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Ta kwota jest używana przez skróty Dodaj pieniądze i Odejmij pieniądze.\n" +
                    "<Domyślnie w modzie = 40 000>\n" +
                    "Do automatycznego dodawania włącz Automatyczne dodawanie pieniędzy."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Automatyczne dodawanie pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Po włączeniu [ ✓ ] Budget + Milestones sprawdza saldo miasta.\n" +
                    "- Gdy saldo spadnie <poniżej progu>, doda tyle, by dojść do progu.\n" +
                    "- Zawsze doda co najmniej wybraną kwotę automatyczną."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Próg automatycznych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Jeśli automatyczne dodawanie jest włączone i saldo spadnie poniżej tej wartości,\n" +
                    "pieniądze zostaną dodane co najmniej do tego progu."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Automatyczna kwota pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Minimalna kwota dodawana przy każdym automatycznym uruchomieniu.\n" +
                    "Jeśli do progu potrzeba więcej, mod doda większą kwotę."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Koszt wyburzania sieci" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Naliczany procent kosztu budowy przy usuwaniu dróg, ścieżek, torów, rur, kabli i innych sieci.\n" +
                    "<0% = zachowanie vanilla.> Normalny zwrot gry za niedawno zbudowane lub zmienione sieci nadal działa.\n" +
                    "<Uwaga: 50% może szybko zjeść budżet.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Przywróć ustawienia gry" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Przywraca wszystkie <Ustawienia startu miasta> do vanilla:\n" +
                    "standardowe pieniądze, bez pomijania kamieni milowych, normalne nagrody i 0% kosztu wyburzania.\n" +
                    "Nie cofa zmian kamieni milowych już zastosowanych w mieście."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Dodaj pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Skrót do <Dodawania pieniędzy> w mieście." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Dodaj pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Odejmij pieniądze" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Skrót do <Odejmowania pieniędzy> w mieście. Saldo może spaść poniżej zera."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Odejmij pieniądze" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Konwerter nielimitowanych pieniędzy" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Najpierw zrób kopię zapasową miasta>.\n" +
                    "Zmienia miasto rozpoczęte z Nielimitowanymi pieniędzmi na normalny ograniczony budżet.\n" +
                    "Włącz, aby odblokować przycisk konwersji po wczytaniu takiego miasta.\n" +
                    "Budget + Milestones nie może cofnąć tej konwersji."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Zmień miasto z Nielimitowanych pieniędzy na normalne" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Dla miast rozpoczętych z <Nielimitowanymi pieniędzmi>.\n" +
                    "Po wczytaniu miasta zmienia zapis na normalny ograniczony budżet.\n" +
                    "Przycisk działa tylko, gdy miasto używa Nielimitowanych pieniędzy i konwerter jest WŁ. [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Zmienić to miasto z Nielimitowanych pieniędzy na normalny ograniczony budżet?\n" +
                    "Najpierw zapisz kopię; Budget + Milestones nie może tego cofnąć.\n" +
                    "Na pewno?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Nazwa moda" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Wyświetlana nazwa tego moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Wersja" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Aktualna wersja moda." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods Mochiego" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Otwiera stronę River-Mochi na Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Otwiera serwer pomocy na Discordzie." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Otwórz log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Otwiera </Logs/BudgetMilestones.log>, jeśli istnieje.\n" +
                    "Jeśli nie, otwiera folder Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
