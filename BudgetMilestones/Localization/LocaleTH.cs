// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTH.cs
// Purpose: Thai Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleTH : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleTH(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "เริ่มเมือง" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "ปุ่มลัด" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "เกี่ยวกับ" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "ตั้งค่าเริ่มเมือง" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "งบประมาณ" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "แปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "การวินิจฉัย" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "เงินเริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "กำหนดยอดเงินเริ่มต้นของเมืองแบบ <เงินจำกัด> ที่จะโหลดครั้งถัดไป ทั้งเมืองใหม่หรือเมืองเดิม\n" +
                    "ใช้แล้ว 1 ครั้ง ค่านี้จะกลับเป็นค่าเริ่มต้นของเกม\n" +
                    "<ถ้าตัวเลือกเป็นสีเทา> ให้ออกไปเมนูหลัก (หรือรีสตาร์ตเกม) แล้วเปิด Options ใหม่\n" +
                    "ถ้าเลือก Milestone เริ่มต้นที่สูงขึ้น เงินรางวัล Milestone ปกติจะถูกเพิ่มทีหลัง\n" +
                    "เปิด <ปิดเงินรางวัล Milestone> ถ้าไม่ต้องการโบนัสเงินเหล่านั้น"
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "ค่าเริ่มต้นของเกม" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "ค่าเริ่มต้นของเกม - ไม่ข้าม Milestone" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Milestone เริ่มต้น" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "ถ้าต้องการเล่นปกติ ให้ใช้ <ค่าเริ่มต้นของเกม - ไม่ข้าม Milestone>\n" +
                    "หรือเลือก Milestone ที่จะปลดล็อกเมื่อโหลดเมืองครั้งถัดไป\n" +
                    "ถ้าเมืองถึงหรือผ่าน Milestone นั้นแล้ว จะไม่มีอะไรเปลี่ยน"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "ปิดเงินรางวัล Milestone" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "เอาออกเฉพาะ <โบนัสเงิน> จากรางวัล Milestone\n" +
                    "การปลดล็อกและรางวัลอื่นยังทำงานตามปกติ\n" +
                    "มีผลกับ Milestone เริ่มต้นที่เลือกและ Milestone ต่อๆ ไป\n" +
                    "เปลี่ยนแล้วมีผลทันที ไม่ต้องรีสตาร์ต\n" +
                    "เมื่อปิดตัวเลือกนี้ เงินรางวัลในอนาคตจะกลับมา แต่เงินที่ได้หรือข้ามไปแล้วจะไม่เปลี่ยน"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "จำนวนเงินของปุ่มลัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "จำนวนนี้ใช้กับปุ่มลัด เพิ่มเงิน และ ลดเงิน\n" +
                    "<ค่าเริ่มต้นของม็อด = 40,000>\n" +
                    "ถ้าต้องการเติมเงินอัตโนมัติ ให้เปิด เติมเงินอัตโนมัติ"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "เติมเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "เมื่อเปิด [ ✓ ] Budget + Milestones จะเช็กยอดเงินของเมือง\n" +
                    "- ถ้าต่ำกว่า <ค่ากำหนด> จะเติมให้ถึงค่ากำหนด\n" +
                    "- จะเติมอย่างน้อยตามจำนวนอัตโนมัติที่เลือกไว้"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "ค่ากำหนดเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "ถ้าเปิด เติมเงินอัตโนมัติ และยอดเงินต่ำกว่าค่านี้\n" +
                    "ระบบจะเติมเงินจนถึงอย่างน้อยค่ากำหนดนี้"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "จำนวนเงินอัตโนมัติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "จำนวนขั้นต่ำที่เติมทุกครั้งเมื่อระบบอัตโนมัติทำงาน\n" +
                    "ถ้าต้องใช้มากกว่านี้เพื่อถึงค่ากำหนด จะเติมจำนวนที่มากกว่า"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "ค่ารื้อเครือข่าย" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "คิดค่ารื้อเป็นเปอร์เซ็นต์จากค่าก่อสร้างเมื่อรื้อถนน ทางเดิน ราง ท่อ สายไฟ และเครือข่ายอื่นๆ\n" +
                    "<0% = แบบ vanilla> เงินคืนปกติของเกมสำหรับเครือข่ายที่เพิ่งสร้างหรือแก้ไขยังคงใช้ได้\n" +
                    "<คำเตือน: 50% อาจทำให้งบหายเร็วมาก>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "รีเซ็ตเป็นค่าเกม" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "คืนค่า <การตั้งค่าเริ่มเมือง> ทั้งหมดเป็นแบบ vanilla:\n" +
                    "เงินค่าเกม ไม่ข้าม Milestone รางวัลเงินปกติ และค่ารื้อ 0%\n" +
                    "ไม่ย้อน Milestone ที่เปลี่ยนไปแล้วในเมือง"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "เพิ่มเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "ปุ่มลัดสำหรับ <เพิ่มเงิน> ในเมือง" },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "เพิ่มเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "ลดเงิน" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "ปุ่มลัดสำหรับ <ลดเงิน> ในเมือง ยอดเงินติดลบได้"
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "ลดเงิน" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "ตัวแปลงเงินไม่จำกัด" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<สำรองเซฟเมืองก่อน>.\n" +
                    "แปลงเมืองที่เริ่มด้วย เงินไม่จำกัด ให้เป็นงบแบบจำกัดปกติ\n" +
                    "เปิดตัวเลือกนี้เพื่อใช้ปุ่มแปลงเมื่อโหลดเมืองเงินไม่จำกัด\n" +
                    "Budget + Milestones ย้อนการแปลงนี้ไม่ได้"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "แปลงเมืองเงินไม่จำกัดเป็นปกติ" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "สำหรับเมืองที่เริ่มด้วย <เงินไม่จำกัด>\n" +
                    "เมื่อโหลดเมืองนั้นอยู่ จะเปลี่ยนเซฟเป็นงบแบบจำกัดปกติ\n" +
                    "ปุ่มจะใช้ได้เมื่อเมืองใช้เงินไม่จำกัดและตัวแปลงเปิดอยู่ [ ✓ ] เท่านั้น"
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "แปลงเมืองนี้จากเงินไม่จำกัดเป็นเงินจำกัดปกติหรือไม่?\n" +
                    "สำรองเซฟก่อน; Budget + Milestones ย้อนกลับไม่ได้\n" +
                    "แน่ใจหรือไม่?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "ชื่อม็อด" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "ชื่อที่แสดงของม็อดนี้" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "เวอร์ชัน" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "เวอร์ชันปัจจุบันของม็อด" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods ของ Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "เปิดหน้า Paradox Mods ของ River-Mochi" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "เปิดเซิร์ฟเวอร์ช่วยเหลือ Discord" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "เปิด Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "เปิด </Logs/BudgetMilestones.log> ถ้ามีไฟล์\n" +
                    "ถ้าไม่มี จะเปิดโฟลเดอร์ Logs/ แทน"
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
