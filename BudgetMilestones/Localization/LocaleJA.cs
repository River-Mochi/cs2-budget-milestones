// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Purpose: Japanese Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleJA(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "都市スタート" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "キー設定" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "情報" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "都市スタート設定" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "予算" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "無制限資金を通常化" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "診断" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "初期資金" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "次に読み込む<資金制限あり>の都市（新規・既存）の開始残高を設定します。\n" +
                    "1回適用すると、設定はゲーム標準に戻ります。\n" +
                    "<この項目がグレー表示なら>、メインメニューへ戻る（またはゲームを再起動する）→ オプションを開き直してください。\n" +
                    "高い開始マイルストーンを選ぶと、通常のマイルストーン資金報酬があとから加算されます。\n" +
                    "その資金ボーナスを不要にするなら<マイルストーン資金報酬を無効化>をONにしてください。"
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "ゲーム標準" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "ゲーム標準 - マイルストーンをスキップしない" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "開始マイルストーン" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "通常進行なら<ゲーム標準 - マイルストーンをスキップしない>のままにします。\n" +
                    "または次に都市を読み込んだときに解除するマイルストーンを選びます。\n" +
                    "都市がすでにその段階以上なら何も変わりません。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "マイルストーン資金報酬を無効化" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "マイルストーン報酬の<資金ボーナスだけ>を無効にします。\n" +
                    "アンロックや他の進行報酬はそのままです。\n" +
                    "選んだ開始マイルストーンと、その後のマイルストーンに効きます。\n" +
                    "変更はすぐ反映され、再起動は不要です。\n" +
                    "OFFにすると今後の資金報酬は戻ります。すでに受け取った/スキップした資金は変わりません。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "資金ホットキー額" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "資金追加/資金減額ホットキーで使う金額です。\n" +
                    "<Mod標準 = 40,000>\n" +
                    "自動で資金を足すなら「資金を自動追加」をONにします。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "資金を自動追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "ON [ ✓ ] の間、Budget + Milestones が都市の残高を確認します。\n" +
                    "- 残高が<しきい値未満>なら、しきい値まで補充します。\n" +
                    "- 最低でも選んだ自動追加額を追加します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "自動資金しきい値" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "資金を自動追加がONで残高がこの値を下回ると、\n" +
                    "少なくともこのしきい値まで資金を追加します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "自動追加額" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "自動追加が発動するたびに追加する最低額です。\n" +
                    "しきい値までにもっと必要なら、大きい方の金額を追加します。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "ネットワーク撤去費" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "道路、歩道、線路、パイプ、ケーブルなどを撤去すると、建設費に応じた費用がかかります。\n" +
                    "<0% = バニラ動作。> 最近建設・変更したネットワークへの通常の払い戻しはそのままです。\n" +
                    "<注意: 50% は予算がかなり減りやすくなります。>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "ゲーム標準に戻す" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "<都市スタート設定>をすべてバニラ動作に戻します:\n" +
                    "ゲーム標準の資金、マイルストーンスキップなし、通常の資金報酬、撤去費0%。\n" +
                    "すでに都市へ適用済みのマイルストーン変更は元に戻しません。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "資金追加" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "都市内で<資金追加>するホットキーです。" },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "資金追加" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "資金減額" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "都市内で<資金減額>するホットキーです。残高は0未満にもできます。"
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "資金減額" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "無制限資金コンバーター" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<先に都市のバックアップを作ってください>。\n" +
                    "無制限資金で始めた都市を通常の資金制限ありに変換します。\n" +
                    "ONにすると、無制限資金の都市を読み込んだ時に変換ボタンが使えます。\n" +
                    "Budget + Milestones では元に戻せません。"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "無制限資金の都市を通常モードへ変換" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "<無制限資金>で始めた都市向けです。\n" +
                    "その都市を読み込んでいる間に、通常の資金制限ありへ変換します。\n" +
                    "都市が無制限資金で、コンバーターがON [ ✓ ] の時だけボタンを押せます。"
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "この都市を無制限資金から通常の資金制限ありへ変換しますか？\n" +
                    "先にバックアップを保存してください。Budget + Milestones では元に戻せません。\n" +
                    "本当に実行しますか？"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Mod名" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "このModの表示名です。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "バージョン" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "現在のModバージョンです。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "MochiのParadox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "River-MochiのParadox Modsページを開きます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Discordサポートサーバーを開きます。" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "ログを開く" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "存在すれば </Logs/BudgetMilestones.log> を開きます。\n" +
                    "ログがなければ Logs/ フォルダーを開きます。"
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
