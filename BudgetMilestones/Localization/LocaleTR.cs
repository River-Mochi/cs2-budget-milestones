// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// Purpose: Turkish Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleTR(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Şehir Başlangıcı" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Tuşlar" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Hakkında" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "ŞEHİR BAŞLANGIÇ AYARLARI" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "BÜTÇE" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "SINIRSIZ PARAYI DÖNÜŞTÜR" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "TANI" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Başlangıç Parası" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Bir sonraki yüklenen <sınırlı para> şehrinin başlangıç bakiyesini ayarlar; yeni veya mevcut olabilir.\n" +
                    "Bir kez uygulandıktan sonra oyun varsayılanına döner.\n" +
                    "<Bu seçenek griyse>, Ana Menüye dön (veya oyunu yeniden başlat), sonra Seçenekleri tekrar aç.\n" +
                    "Daha yüksek bir başlangıç kilometre taşı seçersen normal para ödülleri sonradan eklenir.\n" +
                    "Bu bonusları istemiyorsan <Kilometre Taşı Para Ödüllerini Kapat> seçeneğini aç."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Oyun Varsayılanı" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Oyun Varsayılanı - Kilometre Taşı Atlama Yok" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Başlangıç Kilometre Taşı" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Normal ilerleme için <Oyun Varsayılanı - Kilometre Taşı Atlama Yok> olarak bırak.\n" +
                    "Ya da sonraki şehir yüklemesinde açılacak bir kilometre taşı seç.\n" +
                    "Şehir zaten o seviyedeyse veya geçtiyse hiçbir şey olmaz."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Kilometre Taşı Para Ödüllerini Kapat" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Kilometre taşı ödüllerinden sadece <para bonusunu> kaldırır.\n" +
                    "Açılan içerikler ve diğer ödüller devam eder.\n" +
                    "Seçilen başlangıç kilometre taşına ve sonrakilere uygulanır.\n" +
                    "Anında etkili, yeniden başlatma gerekmez.\n" +
                    "KAPATINCA gelecekteki para ödülleri geri gelir; önceden alınan veya atlanan para değişmez."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Para Kısayolu Miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Para Ekle ve Para Çıkar kısayollarında bu miktar kullanılır.\n" +
                    "<Mod varsayılanı = 40.000>\n" +
                    "Otomatik para için Otomatik Para Ekle seçeneğini aç."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Otomatik Para Ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Açıkken [ ✓ ] Budget + Milestones şehir bakiyesini kontrol eder.\n" +
                    "- Bakiye <eşiğin altına> düşerse eşiğe kadar para ekler.\n" +
                    "- Her zaman en az seçilen otomatik miktarı ekler."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Otomatik Para Eşiği" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Otomatik Para Ekle açıkken bakiye bu değerin altına düşerse,\n" +
                    "en az bu eşiğe kadar para eklenir."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Otomatik Para Miktarı" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Otomatik para her çalıştığında eklenecek minimum miktar.\n" +
                    "Eşiğe ulaşmak için daha fazlası gerekiyorsa büyük olan miktar eklenir."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Ağ Yıkım Maliyeti" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Yol, patika, ray, boru, kablo ve diğer ağları kaldırırken yapım maliyetinin bir yüzdesini ücret olarak alır.\n" +
                    "<0% = vanilla davranışı.> Yeni yapılmış veya değiştirilmiş ağlar için oyunun normal iadesi devam eder.\n" +
                    "<Uyarı: 50% bütçeyi hızlı tüketebilir.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Oyun Varsayılanına Sıfırla" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Tüm <Şehir Başlangıç Ayarlarını> vanilla davranışına döndürür:\n" +
                    "oyun varsayılanı para, kilometre taşı atlama yok, normal para ödülleri ve 0% yıkım maliyeti.\n" +
                    "Şehre daha önce uygulanmış kilometre taşı değişikliklerini geri almaz."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Para Ekle" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Şehirde <Para Ekle> kısayolu." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Para Ekle" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Para Çıkar" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Şehirde <Para Çıkar> kısayolu. Bakiye sıfırın altına düşebilir."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Para Çıkar" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Sınırsız Para Dönüştürücü" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<ÖNCE şehrin yedeğini al>.\n" +
                    "Sınırsız Para ile başlayan bir şehri normal sınırlı bütçeye çevirir.\n" +
                    "Sınırsız Para şehri yüklüyken dönüştürme düğmesini açmak için etkinleştir.\n" +
                    "Budget + Milestones bu dönüşümü geri alamaz."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Sınırsız Para Şehrini Normale Çevir" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "<Sınırsız Para> ile başlayan şehirler için.\n" +
                    "Şehir yüklüyken kaydı normal sınırlı bütçeye dönüştürür.\n" +
                    "Düğme yalnızca şehir Sınırsız Para kullanıyorsa ve dönüştürücü AÇIK [ ✓ ] ise kullanılabilir."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Bu şehir Sınırsız Paradan normal sınırlı paraya dönüştürülsün mü?\n" +
                    "ÖNCE yedek kaydet; Budget + Milestones bunu geri alamaz.\n" +
                    "Emin misin?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Mod adı" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Bu modun görünen adı." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Sürüm" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Geçerli mod sürümü." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mochi'nin Paradox Modları" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "River-Mochi'nin Paradox Mods sayfasını açar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Discord destek sunucusunu açar." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Logu Aç" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Varsa </Logs/BudgetMilestones.log> dosyasını açar.\n" +
                    "Yoksa Logs/ klasörünü açar."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
