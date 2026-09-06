// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Purpose: Vietnamese Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleVI(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Khởi đầu thành phố" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Phím tắt" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Giới thiệu" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "THIẾT LẬP KHỞI ĐẦU" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "NGÂN SÁCH" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CHUYỂN TIỀN VÔ HẠN" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "CHẨN ĐOÁN" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Tiền khởi đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Đặt số dư ban đầu cho thành phố <tiền giới hạn> sẽ tải tiếp theo, mới hoặc cũ.\n" +
                    "Sau khi áp dụng một lần, mục này trở về mặc định game.\n" +
                    "<Nếu mục này bị mờ>, hãy ra Menu chính (hoặc khởi động lại game) rồi mở Options lại.\n" +
                    "Nếu chọn Mốc khởi đầu cao hơn, tiền thưởng Mốc bình thường sẽ được cộng sau.\n" +
                    "Bật <Tắt tiền thưởng Mốc> nếu không muốn các khoản thưởng đó."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Mặc định game" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Mặc định game - không bỏ qua Mốc" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Mốc khởi đầu" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Giữ <Mặc định game - không bỏ qua Mốc> để chơi bình thường.\n" +
                    "Hoặc chọn một Mốc để mở khóa khi tải thành phố lần tới.\n" +
                    "Nếu thành phố đã đạt hoặc vượt Mốc đó thì không có gì thay đổi."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Tắt tiền thưởng Mốc" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Chỉ bỏ <tiền thưởng> khỏi phần thưởng Mốc.\n" +
                    "Mở khóa và các phần thưởng khác vẫn hoạt động.\n" +
                    "Áp dụng cho Mốc khởi đầu đã chọn và các Mốc sau đó.\n" +
                    "Có hiệu lực ngay, không cần khởi động lại.\n" +
                    "Khi TẮT, tiền thưởng Mốc tương lai trở lại; tiền đã nhận hoặc bỏ qua không đổi."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Số tiền phím tắt" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Số tiền này dùng cho phím Thêm tiền và Trừ tiền.\n" +
                    "<Mặc định mod = 40.000>\n" +
                    "Muốn tự động thêm tiền, bật Tự động thêm tiền."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Tự động thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Khi bật [ ✓ ], Budget + Milestones kiểm tra số dư thành phố.\n" +
                    "- Nếu thấp hơn <ngưỡng>, mod thêm đủ để đạt ngưỡng.\n" +
                    "- Luôn thêm ít nhất số tiền tự động đã chọn."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Ngưỡng tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Nếu Tự động thêm tiền đang bật và số dư xuống dưới giá trị này,\n" +
                    "tiền sẽ được thêm đến ít nhất ngưỡng này."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Số tiền tự động" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Số tối thiểu được thêm mỗi lần tự động kích hoạt.\n" +
                    "Nếu cần nhiều hơn để đạt ngưỡng, mod thêm số lớn hơn."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Chi phí phá mạng lưới" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Tính phí theo phần trăm chi phí xây dựng khi xóa đường, lối đi, đường ray, ống, cáp và các mạng khác.\n" +
                    "<0% = hành vi vanilla.> Hoàn tiền bình thường của game cho mạng vừa xây hoặc sửa vẫn giữ nguyên.\n" +
                    "<Cảnh báo: 50% có thể làm ngân sách tụt rất nhanh.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Đặt lại theo mặc định game" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Đưa toàn bộ <Thiết lập khởi đầu> về vanilla:\n" +
                    "tiền mặc định, không bỏ qua Mốc, tiền thưởng bình thường và 0% chi phí phá.\n" +
                    "Không hoàn tác thay đổi Mốc đã áp dụng cho thành phố."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Thêm tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Phím tắt để <Thêm tiền> trong thành phố." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Thêm tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Trừ tiền" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Phím tắt để <Trừ tiền> trong thành phố. Số dư có thể xuống dưới 0."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Trừ tiền" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Bộ chuyển Tiền vô hạn" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Hãy sao lưu thành phố TRƯỚC>.\n" +
                    "Chuyển thành phố bắt đầu với Tiền vô hạn sang ngân sách giới hạn bình thường.\n" +
                    "Bật mục này để mở nút chuyển khi đang tải thành phố Tiền vô hạn.\n" +
                    "Budget + Milestones không thể hoàn tác việc chuyển đổi."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Chuyển thành phố Tiền vô hạn về bình thường" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Dành cho thành phố bắt đầu với <Tiền vô hạn>.\n" +
                    "Khi thành phố đang tải, chuyển save sang ngân sách giới hạn bình thường.\n" +
                    "Nút chỉ hoạt động khi thành phố dùng Tiền vô hạn và bộ chuyển đang BẬT [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Chuyển thành phố này từ Tiền vô hạn sang tiền giới hạn bình thường?\n" +
                    "Hãy sao lưu TRƯỚC; Budget + Milestones không thể hoàn tác.\n" +
                    "Bạn chắc chứ?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Tên mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Tên hiển thị của mod này." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Phiên bản" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Phiên bản mod hiện tại." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods của Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Mở trang Paradox Mods của River-Mochi." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Mở máy chủ hỗ trợ Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Mở log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Mở </Logs/BudgetMilestones.log> nếu có.\n" +
                    "Nếu không có, mở thư mục Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
