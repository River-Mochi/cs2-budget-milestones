// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleUK.cs
// Purpose: Ukrainian Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleUK : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleUK(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Старт міста" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Клавіші" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Про мод" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "НАЛАШТУВАННЯ СТАРТУ МІСТА" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "БЮДЖЕТ" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "КОНВЕРТАЦІЯ НЕОБМЕЖЕНИХ ГРОШЕЙ" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "ДІАГНОСТИКА" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Стартові гроші" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Задає стартовий баланс для наступного завантаженого міста з <обмеженими грошима> — нового або існуючого.\n" +
                    "Після одного застосування повертається до стандарту гри.\n" +
                    "<Якщо опція сіра>, вийди в головне меню (або перезапусти гру) й знову відкрий Налаштування.\n" +
                    "Якщо вибрати вищу стартову віху, звичайні грошові нагороди за віхи додадуться потім.\n" +
                    "Увімкни <Вимкнути гроші за віхи>, якщо ці бонуси не потрібні."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Стандарт гри" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Стандарт гри - не пропускати віхи" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Стартова віха" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Для звичайного прогресу залиш <Стандарт гри - не пропускати віхи>.\n" +
                    "Або вибери віху, яку буде відкрито при наступному завантаженні міста.\n" +
                    "Якщо місто вже досягло цієї віхи або пішло далі, нічого не зміниться."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Вимкнути гроші за віхи" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Прибирає лише <грошовий бонус> із нагород за віхи.\n" +
                    "Розблокування та інші нагороди залишаються.\n" +
                    "Діє на вибрану стартову віху й наступні.\n" +
                    "Зміна діє одразу, перезапуск не потрібен.\n" +
                    "Після вимкнення майбутні грошові нагороди повернуться; вже отримані або пропущені гроші не зміняться."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Сума для гарячих клавіш" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Ця сума використовується клавішами Додати гроші та Відняти гроші.\n" +
                    "<Стандарт мода = 40 000>\n" +
                    "Для автоматичних грошей увімкни Автододавання грошей."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Автододавання грошей" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Коли ввімкнено [ ✓ ], Budget + Milestones перевіряє баланс міста.\n" +
                    "- Якщо баланс <нижче порогу>, додає стільки, щоб дійти до порогу.\n" +
                    "- Завжди додає щонайменше вибрану автоматичну суму."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Поріг автододавання грошей" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Якщо автододавання ввімкнено й баланс падає нижче цього значення,\n" +
                    "гроші додаються щонайменше до цього порогу."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Автоматична сума" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Мінімальна сума, що додається при кожному спрацюванні.\n" +
                    "Якщо до порогу потрібно більше, додається більша сума."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Вартість знесення мереж" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Стягує відсоток від вартості будівництва при знесенні доріг, стежок, колій, труб, кабелів та інших мереж.\n" +
                    "<0% = vanilla.> Звичайне повернення грошей за нещодавно збудовані або змінені мережі лишається.\n" +
                    "<Увага: 50% може швидко з'їсти бюджет.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Скинути до стандарту гри" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Повертає всі <Налаштування старту міста> до vanilla:\n" +
                    "стандартні гроші, без пропуску віх, звичайні грошові нагороди та 0% вартості знесення.\n" +
                    "Не скасовує зміни віх, уже застосовані до міста."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Додати гроші" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Гаряча клавіша для <Додати гроші> в місті." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Додати гроші" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Відняти гроші" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Гаряча клавіша для <Відняти гроші> в місті. Баланс може бути нижче нуля."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Відняти гроші" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Конвертер Необмежених грошей" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Спочатку зроби резервну копію міста>.\n" +
                    "Перетворює місто, створене з Необмеженими грошима, на звичайний обмежений бюджет.\n" +
                    "Увімкни, щоб розблокувати кнопку конвертації в завантаженому місті з Необмеженими грошима.\n" +
                    "Budget + Milestones не може скасувати конвертацію."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Перетворити місто з Необмежених грошей на звичайне" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Для міст, створених з <Необмеженими грошима>.\n" +
                    "Коли місто завантажене, перетворює збереження на звичайний обмежений бюджет.\n" +
                    "Кнопка доступна лише якщо місто використовує Необмежені гроші й конвертер УВІМК. [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Перетворити це місто з Необмежених грошей на звичайні обмежені гроші?\n" +
                    "Спочатку збережи резервну копію; Budget + Milestones не може це скасувати.\n" +
                    "Точно?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Назва мода" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Назва цього мода в меню." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Версія" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Поточна версія мода." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods від Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Відкриває сторінку River-Mochi на Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Відкриває сервер підтримки Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Відкрити лог" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Відкриває </Logs/BudgetMilestones.log>, якщо файл є.\n" +
                    "Якщо ні, відкриває папку Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
