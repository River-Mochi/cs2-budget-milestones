// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Purpose: Traditional Chinese Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleZH_HANT(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "城市開局" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "按鍵" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "關於" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "城市開局設定" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "預算" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "轉換無限金錢存檔" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "診斷" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "初始資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "設定下次載入的<有限資金>城市起始餘額，新城或舊城都可以。\n" +
                    "套用一次後，此選項會自動恢復為遊戲預設。\n" +
                    "<如果此選項是灰色>，請回到主選單（或重啟遊戲），再重新開啟選項。\n" +
                    "如果選擇更高的起始里程碑，正常的里程碑現金獎勵之後仍會加上。\n" +
                    "如果不想要這些現金獎勵，請開啟<關閉里程碑現金獎勵>。"
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "遊戲預設" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "遊戲預設 - 不跳過里程碑" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "起始里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "正常遊玩請保持<遊戲預設 - 不跳過里程碑>。\n" +
                    "也可以選一個里程碑，在下次載入城市時直接解鎖。\n" +
                    "如果城市已經達到或超過所選里程碑，就不會有變化。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "關閉里程碑現金獎勵" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "只移除里程碑獎勵中的<現金獎勵>。\n" +
                    "解鎖內容和其他進度獎勵仍然正常生效。\n" +
                    "會影響所選起始里程碑與之後達到的里程碑。\n" +
                    "修改立即生效，不需要重啟。\n" +
                    "關閉此選項後，未來的現金獎勵會恢復；已經拿到或跳過的錢不會改變。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "資金快捷鍵金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "「增加資金」和「減少資金」快捷鍵會使用這個金額。\n" +
                    "<模組預設 = 40,000>\n" +
                    "要自動加錢，請開啟「自動增加資金」。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "自動增加資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "開啟 [ ✓ ] 後，Budget + Milestones 會檢查城市餘額。\n" +
                    "- 如果餘額<低於門檻>，會補足到門檻。\n" +
                    "- 每次至少會增加所選的自動金額。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "自動資金門檻" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "開啟自動增加資金後，如果餘額低於此數值，\n" +
                    "會自動加錢直到至少達到這個門檻。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "自動增加金額" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "每次自動加錢觸發時至少增加的金額。\n" +
                    "如果到達門檻需要更多資金，會增加較大的那個金額。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "網路拆除費用" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "拆除道路、步道、軌道、管線、電纜等網路時，按建造成本的一定比例收費。\n" +
                    "<0% = 原版行為。> 最近新建或修改的網路仍會保留遊戲原本的退款。\n" +
                    "<警告：50% 會很快消耗預算。>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "恢復遊戲預設" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "把所有<城市開局設定>恢復為原版行為：\n" +
                    "遊戲預設資金、不跳過里程碑、正常現金獎勵、網路拆除費用 0%。\n" +
                    "不會撤銷已經套用到城市的里程碑變更。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "增加資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "在城市中使用<增加資金>的快捷鍵。" },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "增加資金" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "減少資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "在城市中使用<減少資金>的快捷鍵。餘額可以低於 0。"
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "減少資金" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "無限金錢轉換器" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<請先備份城市>。\n" +
                    "把以無限金錢開始的城市轉換成一般有限預算模式。\n" +
                    "開啟後，載入無限金錢城市時會解鎖轉換按鈕。\n" +
                    "Budget + Milestones 無法撤銷這次轉換。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "把無限金錢城市轉換成一般模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "適用於以<無限金錢>開始的城市。\n" +
                    "載入該城市後，可把存檔轉換成一般有限預算模式。\n" +
                    "只有城市正在使用無限金錢，而且轉換器已開啟 [ ✓ ] 時按鈕才可用。"
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "要把這個城市從無限金錢轉換成一般有限資金嗎？\n" +
                    "請先儲存備份；Budget + Milestones 無法撤銷。\n" +
                    "確定嗎？"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "模組名稱" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "這個模組的顯示名稱。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "目前模組版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mochi 的 Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "開啟 River-Mochi 的 Paradox Mods 頁面。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "開啟 Discord 支援伺服器。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "開啟日誌" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "如果存在，開啟 </Logs/BudgetMilestones.log>。\n" +
                    "如果沒有日誌檔，則開啟 Logs/ 資料夾。"
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
