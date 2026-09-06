// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// Purpose: Italian Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleIT(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Avvio città" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Tasti" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Info" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "AVVIO CITTÀ" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BUDGET" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CONVERTI DENARO ILLIMITATO" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSTICA" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Denaro iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Imposta il saldo iniziale per la prossima città con <denaro limitato> caricata, nuova o esistente.\n" +
                    "Dopo un uso, torna al valore predefinito del gioco.\n" +
                    "<Se l'opzione è grigia>, torna al menu principale (o riavvia il gioco) e riapri Opzioni.\n" +
                    "Se scegli un traguardo iniziale più alto, dopo vengono aggiunte le normali ricompense in denaro dei traguardi.\n" +
                    "Attiva <Disattiva denaro dei traguardi> per saltare quei bonus."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Predefinito del gioco" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Predefinito - nessun traguardo saltato" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Traguardo iniziale" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Lascia <Predefinito - nessun traguardo saltato> per la progressione normale.\n" +
                    "Oppure scegli un traguardo da sbloccare al prossimo caricamento di una città.\n" +
                    "Se la città è già a quel traguardo o oltre, non succede nulla."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Disattiva denaro dei traguardi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Rimuove solo il <bonus in denaro> dalle ricompense dei traguardi.\n" +
                    "Sblocchi e altre ricompense restano attivi.\n" +
                    "Vale per il traguardo iniziale scelto e quelli successivi.\n" +
                    "Effetto immediato, nessun riavvio.\n" +
                    "DISATTIVANDO tornano i bonus futuri; il denaro già ricevuto o saltato non cambia."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Importo tasti denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Importo usato dai tasti Aggiungi denaro e Sottrai denaro.\n" +
                    "<Predefinito mod = 40.000>\n" +
                    "Per il denaro automatico, attiva Aggiungi denaro automaticamente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Aggiungi denaro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Quando attivo [ ✓ ], Budget + Milestones controlla il saldo della città.\n" +
                    "- Sotto la <soglia>, aggiunge abbastanza denaro per raggiungerla.\n" +
                    "- Aggiunge sempre almeno l'importo automatico scelto."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Soglia denaro automatica" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Se l'aggiunta automatica è attiva e il saldo scende sotto questo valore,\n" +
                    "viene aggiunto denaro fino ad almeno questa soglia."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Importo denaro automatico" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Importo minimo aggiunto ogni volta che scatta l'aggiunta automatica.\n" +
                    "Se serve di più per raggiungere la soglia, viene aggiunto l'importo maggiore."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Costo demolizione reti" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Aggiunge un costo basato sul prezzo di costruzione quando demolisci strade, sentieri, binari, tubi, cavi e altre reti.\n" +
                    "<0% = comportamento vanilla.> Il normale rimborso del gioco per reti recenti o modificate resta attivo.\n" +
                    "<Attenzione: 50% può svuotare il budget in fretta.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Ripristina valori del gioco" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Riporta tutte le <Impostazioni di avvio città> al comportamento vanilla:\n" +
                    "denaro predefinito, nessun salto di traguardi, ricompense normali e 0% costo demolizione.\n" +
                    "Non annulla i traguardi già applicati a una città."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Aggiungi denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Tasto per <Aggiungere denaro> nella città." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Aggiungi denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Sottrai denaro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Tasto per <Sottrarre denaro> nella città. Il saldo può andare sotto zero."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Sottrai denaro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Convertitore Denaro illimitato" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fai PRIMA un backup della città>.\n" +
                    "Converte una città iniziata con Denaro illimitato al normale budget limitato.\n" +
                    "Attivalo per sbloccare il pulsante di conversione quando è caricata una città con Denaro illimitato.\n" +
                    "Budget + Milestones non può annullare la conversione."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Converti città Denaro illimitato in normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Per città iniziate con <Denaro illimitato>.\n" +
                    "Con la città caricata, converte il salvataggio al normale budget limitato.\n" +
                    "Il pulsante è attivo solo se la città usa Denaro illimitato e il convertitore è ATTIVO [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Convertire questa città da Denaro illimitato a denaro limitato normale?\n" +
                    "Salva PRIMA un backup; Budget + Milestones non può annullarlo.\n" +
                    "Sei sicuro?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Nome mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Nome visualizzato della mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Versione" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Versione attuale della mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods di Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Apre la pagina Paradox Mods di River-Mochi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Apre il server di supporto Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Apri log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Apre </Logs/BudgetMilestones.log> se esiste.\n" +
                    "Se manca, apre la cartella Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
