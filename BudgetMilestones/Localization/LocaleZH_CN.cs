// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Purpose: Simplified Chinese Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleZH_CN(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "城市开局" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "按键" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "关于" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "城市开局设置" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "预算" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "转换无限金钱存档" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "诊断" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "初始资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "设置下次载入的<有限资金>城市的起始余额，新城或旧城都可以。\n" +
                    "应用一次后，此选项会自动恢复为游戏默认。\n" +
                    "<如果此选项是灰色>，请返回主菜单（或重启游戏），再重新打开选项。\n" +
                    "如果选择更高的起始里程碑，正常的里程碑现金奖励会在之后继续加上。\n" +
                    "如果不想要这些现金奖励，请开启<关闭里程碑现金奖励>。"
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "游戏默认" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "游戏默认 - 不跳过里程碑" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "起始里程碑" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "正常游玩请保持<游戏默认 - 不跳过里程碑>。\n" +
                    "也可以选择一个里程碑，在下次载入城市时直接解锁。\n" +
                    "如果城市已经达到或超过所选里程碑，则不会有变化。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "关闭里程碑现金奖励" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "只移除里程碑奖励中的<现金奖励>。\n" +
                    "解锁内容和其他进度奖励仍然正常生效。\n" +
                    "会影响所选起始里程碑和之后达到的里程碑。\n" +
                    "修改立即生效，不需要重启。\n" +
                    "关闭此选项后，未来的现金奖励会恢复；已经获得或跳过的钱不会改变。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "资金快捷键金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "“增加资金”和“减少资金”快捷键会使用这个金额。\n" +
                    "<模组默认 = 40,000>\n" +
                    "需要自动加钱时，请开启“自动增加资金”。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "自动增加资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "开启 [ ✓ ] 后，Budget + Milestones 会检查城市余额。\n" +
                    "- 如果余额<低于阈值>，会补足到阈值。\n" +
                    "- 每次至少会增加所选的自动金额。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "自动资金阈值" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "开启自动增加资金后，如果余额低于此数值，\n" +
                    "会自动加钱，直到至少达到这个阈值。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "自动增加金额" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "每次自动加钱触发时至少增加的金额。\n" +
                    "如果达到阈值需要更多资金，则会增加较大的那个金额。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "网络拆除费用" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "拆除道路、步道、轨道、管道、电缆等网络时，按建造成本的一定比例收费。\n" +
                    "<0% = 原版行为。> 最近新建或修改的网络仍会保留游戏原本的退款。\n" +
                    "<警告：50% 会很快消耗预算。>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "恢复游戏默认" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "把所有<城市开局设置>恢复为原版行为：\n" +
                    "游戏默认资金、不跳过里程碑、正常现金奖励、网络拆除费用 0%。\n" +
                    "不会撤销已经应用到城市的里程碑变化。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "增加资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "在城市中使用<增加资金>的快捷键。" },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "增加资金" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "减少资金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "在城市中使用<减少资金>的快捷键。余额可以低于 0。"
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "减少资金" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "无限金钱转换器" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<请先备份城市>。\n" +
                    "把以无限金钱开始的城市转换成普通有限预算模式。\n" +
                    "开启后，载入无限金钱城市时会解锁转换按钮。\n" +
                    "Budget + Milestones 无法撤销这次转换。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "把无限金钱城市转换为普通模式" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "适用于以<无限金钱>开始的城市。\n" +
                    "载入该城市后，可把存档转换成普通有限预算模式。\n" +
                    "只有城市正在使用无限金钱并且转换器已开启 [ ✓ ] 时，按钮才可用。"
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "要把这个城市从无限金钱转换成普通有限资金吗？\n" +
                    "请先保存备份；Budget + Milestones 无法撤销。\n" +
                    "确定吗？"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "模组名称" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "此模组的显示名称。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "版本" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "当前模组版本。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mochi 的 Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "打开 River-Mochi 的 Paradox Mods 页面。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "打开 Discord 支持服务器。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "打开日志" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "如果存在，则打开 </Logs/BudgetMilestones.log>。\n" +
                    "如果没有日志文件，则打开 Logs/ 文件夹。"
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
