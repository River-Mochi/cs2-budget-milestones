// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// Purpose: Spanish Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleES(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Inicio de ciudad" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Teclas" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Acerca de" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "INICIO DE CIUDAD" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "PRESUPUESTO" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CONVERTIR DINERO ILIMITADO" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNÓSTICO" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Dinero inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Define el saldo inicial de la próxima ciudad con <dinero limitado> que cargues, nueva o existente.\n" +
                    "Tras aplicarse una vez, vuelve al valor predeterminado del juego.\n" +
                    "<Si sale en gris>, vuelve al menú principal (o reinicia el juego) y abre Opciones otra vez.\n" +
                    "Si eliges un hito inicial más alto, después se suman las recompensas normales de dinero de los hitos.\n" +
                    "Activa <Desactivar dinero de hitos> si no quieres esos bonos."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Predeterminado del juego" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Predeterminado - no saltar hitos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Hito inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Déjalo en <Predeterminado - no saltar hitos> para el progreso normal.\n" +
                    "O elige un hito para desbloquearlo al cargar la próxima ciudad.\n" +
                    "Si la ciudad ya está en ese hito o más adelante, no pasa nada."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Desactivar dinero de hitos" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Quita solo el <bono de dinero> de las recompensas de hitos.\n" +
                    "Los desbloqueos y demás recompensas siguen funcionando.\n" +
                    "Afecta al hito inicial elegido y a los hitos futuros.\n" +
                    "El cambio es inmediato; no hace falta reiniciar.\n" +
                    "Al DESACTIVARLO vuelven los bonos de dinero futuros; el dinero ya recibido u omitido no cambia."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Cantidad de dinero del atajo" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Esta cantidad se usa con los atajos Añadir dinero y Restar dinero.\n" +
                    "<Predeterminado del mod = 40.000>\n" +
                    "Para dinero automático, activa Añadir dinero automáticamente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Añadir dinero automáticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Cuando está activado [ ✓ ], Budget + Milestones revisa el saldo de la ciudad.\n" +
                    "- Si baja del <límite>, añade lo necesario para llegar al límite.\n" +
                    "- Siempre añade al menos la cantidad automática elegida."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Límite de dinero automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Si Añadir dinero automáticamente está activo y el saldo baja de este valor,\n" +
                    "se añade dinero hasta llegar al menos a este límite."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Cantidad automática de dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Cantidad mínima añadida cada vez que se activa el dinero automático.\n" +
                    "Si hace falta más para llegar al límite, se añade la cantidad mayor."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Coste de demolición de redes" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Cobra un porcentaje del coste de construcción al demoler carreteras, caminos, vías, tuberías, cables y otras redes.\n" +
                    "<0% = comportamiento vanilla.> Se mantiene el reembolso normal del juego para redes recién construidas o modificadas.\n" +
                    "<Aviso: 50% puede vaciar tu presupuesto rápido.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Restablecer valores del juego" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Devuelve todos los <Ajustes de inicio de ciudad> al comportamiento vanilla:\n" +
                    "dinero predeterminado, sin saltar hitos, recompensas normales y 0% de coste de demolición.\n" +
                    "No deshace cambios de hitos ya aplicados a una ciudad."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Añadir dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Atajo para <Añadir dinero> dentro de la ciudad." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Añadir dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Restar dinero" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Atajo para <Restar dinero> dentro de la ciudad. El saldo puede bajar de cero."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Restar dinero" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinero ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Haz primero una copia de seguridad de la ciudad>.\n" +
                    "Convierte una ciudad iniciada con Dinero ilimitado a presupuesto normal limitado.\n" +
                    "Actívalo para desbloquear el botón de conversión cuando cargues una ciudad con Dinero ilimitado.\n" +
                    "Budget + Milestones no puede deshacer la conversión."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Convertir ciudad de Dinero ilimitado a normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Para ciudades iniciadas con <Dinero ilimitado>.\n" +
                    "Con la ciudad cargada, convierte la partida a presupuesto normal limitado.\n" +
                    "El botón solo se activa si la ciudad usa Dinero ilimitado y el conversor está ACTIVADO [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "¿Convertir esta ciudad de Dinero ilimitado a dinero limitado normal?\n" +
                    "Guarda una copia de seguridad PRIMERO; Budget + Milestones no puede deshacerlo.\n" +
                    "¿Seguro?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Nombre del mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Nombre mostrado de este mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Versión" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Versión actual del mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mods de Paradox de Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Abre la página de mods de River-Mochi en Paradox." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Abre el servidor de soporte de Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Abrir registro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Abre </Logs/BudgetMilestones.log> si existe.\n" +
                    "Si no existe, abre la carpeta Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
