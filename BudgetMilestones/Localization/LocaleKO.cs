// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Purpose: Korean Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocaleKO(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "도시 시작" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "키 설정" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "정보" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "도시 시작 설정" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "예산" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "무제한 돈 변환" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "진단" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "시작 자금" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "다음에 불러올 <제한 자금> 도시(새 도시/기존 도시)의 시작 잔액을 정합니다.\n" +
                    "한 번 적용되면 게임 기본값으로 돌아갑니다.\n" +
                    "<이 옵션이 회색이면>, 메인 메뉴로 나가거나 게임을 재시작한 뒤 옵션을 다시 여세요.\n" +
                    "더 높은 시작 마일스톤을 고르면 일반 마일스톤 현금 보상이 나중에 추가됩니다.\n" +
                    "그 보너스를 빼려면 <마일스톤 현금 보상 끄기>를 켜세요."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "게임 기본값" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "게임 기본값 - 마일스톤 건너뛰지 않음" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "시작 마일스톤" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "일반 진행은 <게임 기본값 - 마일스톤 건너뛰지 않음>으로 두세요.\n" +
                    "또는 다음 도시 로드 때 해금할 마일스톤을 고르세요.\n" +
                    "도시가 이미 그 단계 이상이면 아무 일도 일어나지 않습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "마일스톤 현금 보상 끄기" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "마일스톤 보상에서 <현금 보너스만> 없앱니다.\n" +
                    "해금과 다른 진행 보상은 그대로 적용됩니다.\n" +
                    "선택한 시작 마일스톤과 이후 마일스톤에 적용됩니다.\n" +
                    "즉시 반영되며 재시작이 필요 없습니다.\n" +
                    "끄면 이후 현금 보상은 다시 생기지만, 이미 받은/건너뛴 돈은 바뀌지 않습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "돈 단축키 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "돈 추가/빼기 단축키에 쓰는 금액입니다.\n" +
                    "<모드 기본값 = 40,000>\n" +
                    "자동 돈 추가는 자동 돈 추가를 켜세요."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "자동 돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "켜짐 [ ✓ ]이면 Budget + Milestones가 도시 잔액을 확인합니다.\n" +
                    "- 잔액이 <기준값 아래>면 기준값까지 돈을 추가합니다.\n" +
                    "- 최소한 선택한 자동 금액만큼은 추가합니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "자동 돈 기준값" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "자동 돈 추가가 켜져 있고 잔액이 이 값보다 낮으면,\n" +
                    "최소 이 기준값까지 돈을 추가합니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "자동 추가 금액" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "자동 돈 추가가 발동할 때마다 넣는 최소 금액입니다.\n" +
                    "기준값까지 더 필요하면 더 큰 금액을 추가합니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "네트워크 철거 비용" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "도로, 보행로, 철도, 파이프, 케이블 등 네트워크 철거 시 건설비의 일부를 청구합니다.\n" +
                    "<0% = 바닐라 동작.> 최근 건설/수정한 네트워크의 기본 환불은 그대로 적용됩니다.\n" +
                    "<주의: 50%는 예산을 빠르게 줄일 수 있습니다.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "게임 기본값으로 초기화" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "모든 <도시 시작 설정>을 바닐라로 돌립니다:\n" +
                    "게임 기본 자금, 마일스톤 스킵 없음, 일반 현금 보상, 철거 비용 0%.\n" +
                    "이미 도시에 적용된 마일스톤 변경은 되돌리지 않습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "돈 추가" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "도시에서 <돈 추가>하는 단축키입니다." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "돈 추가" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "돈 빼기" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "도시에서 <돈 빼기>하는 단축키입니다. 잔액은 0 아래로 내려갈 수 있습니다."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "돈 빼기" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "무제한 돈 변환기" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<먼저 도시 백업을 만드세요>.\n" +
                    "무제한 돈으로 시작한 도시를 일반 제한 자금으로 바꿉니다.\n" +
                    "켜면 무제한 돈 도시가 로드됐을 때 변환 버튼을 사용할 수 있습니다.\n" +
                    "Budget + Milestones로는 되돌릴 수 없습니다."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "무제한 돈 도시를 일반 모드로 변환" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "<무제한 돈>으로 시작한 도시용입니다.\n" +
                    "도시가 로드된 상태에서 일반 제한 자금으로 변환합니다.\n" +
                    "도시가 무제한 돈이고 변환기가 켜짐 [ ✓ ]일 때만 버튼이 활성화됩니다."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "이 도시를 무제한 돈에서 일반 제한 자금으로 바꿀까요?\n" +
                    "먼저 백업을 저장하세요. Budget + Milestones로는 되돌릴 수 없습니다.\n" +
                    "계속할까요?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "모드 이름" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "이 모드의 표시 이름입니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "버전" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "현재 모드 버전입니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Mochi의 Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "River-Mochi의 Paradox Mods 페이지를 엽니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Discord 지원 서버를 엽니다." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "로그 열기" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "있으면 </Logs/BudgetMilestones.log>를 엽니다.\n" +
                    "없으면 Logs/ 폴더를 엽니다."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
