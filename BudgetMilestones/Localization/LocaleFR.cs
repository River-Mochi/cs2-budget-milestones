// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// Purpose: French Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleFR(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Début de ville" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Raccourcis" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "À propos" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "DÉBUT DE VILLE" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BUDGET" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CONVERTIR ARGENT ILLIMITÉ" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNOSTIC" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Argent de départ" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Définit le solde de départ de la prochaine ville en <argent limité> chargée, nouvelle ou existante.\n" +
                    "Après une utilisation, ce réglage revient au défaut du jeu.\n" +
                    "<Si l'option est grisée>, retourne au menu principal (ou redémarre le jeu), puis rouvre les Options.\n" +
                    "Avec un jalon de départ plus élevé, les récompenses d'argent normales des jalons s'ajoutent ensuite.\n" +
                    "Active <Désactiver l'argent des jalons> pour ignorer ces bonus."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Défaut du jeu" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Défaut du jeu - aucun jalon sauté" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Jalon de départ" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Laisse <Défaut du jeu - aucun jalon sauté> pour la progression normale.\n" +
                    "Ou choisis un jalon à débloquer au prochain chargement d'une ville.\n" +
                    "Si la ville a déjà atteint ou dépassé ce jalon, rien ne change."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Désactiver l'argent des jalons" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Retire seulement le <bonus d'argent> des récompenses de jalon.\n" +
                    "Les déblocages et autres récompenses restent actifs.\n" +
                    "S'applique au jalon de départ choisi et aux jalons suivants.\n" +
                    "Effet immédiat, pas besoin de redémarrer.\n" +
                    "DÉSACTIVER rétablit l'argent des futurs jalons ; l'argent déjà reçu ou ignoré ne change pas."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Montant des raccourcis argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Montant utilisé par les raccourcis Ajouter et Retirer de l'argent.\n" +
                    "<Défaut du mod = 40 000>\n" +
                    "Pour l'argent automatique, active Ajout automatique d'argent."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Ajout automatique d'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Quand activé [ ✓ ], Budget + Milestones vérifie le solde de la ville.\n" +
                    "- Sous le <seuil>, il ajoute assez pour atteindre le seuil.\n" +
                    "- Il ajoute toujours au moins le montant automatique choisi."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Seuil d'argent automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Si l'ajout automatique est actif et que le solde passe sous cette valeur,\n" +
                    "de l'argent est ajouté jusqu'à atteindre au moins ce seuil."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Montant automatique" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Montant minimum ajouté à chaque déclenchement automatique.\n" +
                    "S'il faut plus pour atteindre le seuil, le montant le plus élevé est ajouté."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Coût de démolition des réseaux" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Ajoute un coût basé sur le prix de construction pour démolir routes, chemins, rails, tuyaux, câbles et autres réseaux.\n" +
                    "<0% = comportement vanilla.> Le remboursement normal du jeu pour les réseaux récents ou modifiés reste actif.\n" +
                    "<Attention : 50% peut vider ton budget vite.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Réinitialiser aux valeurs du jeu" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Remet tous les <Réglages de début de ville> en vanilla :\n" +
                    "argent par défaut, aucun jalon sauté, récompenses normales et 0% de coût de démolition.\n" +
                    "N'annule pas les changements de jalons déjà appliqués à une ville."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Ajouter de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Raccourci pour <Ajouter de l'argent> dans la ville." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Ajouter de l'argent" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Retirer de l'argent" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Raccourci pour <Retirer de l'argent> dans la ville. Le solde peut passer sous zéro."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Retirer de l'argent" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Convertisseur Argent illimité" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Fais d'abord une sauvegarde de la ville>.\n" +
                    "Convertit une ville commencée avec Argent illimité vers un budget normal limité.\n" +
                    "Active ceci pour débloquer le bouton de conversion quand une ville Argent illimité est chargée.\n" +
                    "Budget + Milestones ne peut pas annuler la conversion."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Convertir la ville Argent illimité en normale" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Pour les villes commencées avec <Argent illimité>.\n" +
                    "Quand la ville est chargée, convertit la sauvegarde vers un budget normal limité.\n" +
                    "Le bouton est actif seulement si la ville utilise Argent illimité et si le convertisseur est ACTIVÉ [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Convertir cette ville d'Argent illimité vers l'argent limité normal ?\n" +
                    "Sauvegarde d'abord ; Budget + Milestones ne peut pas annuler cette action.\n" +
                    "Tu confirmes ?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Nom du mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Nom affiché de ce mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Version" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Version actuelle du mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mods Paradox de Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Ouvre la page Paradox Mods de River-Mochi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Ouvre le serveur d'aide Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Ouvrir le log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Ouvre </Logs/BudgetMilestones.log> s'il existe.\n" +
                    "Sinon, ouvre le dossier Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
