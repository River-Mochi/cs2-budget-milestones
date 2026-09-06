// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// Purpose: Brazilian Portuguese Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocalePT_BR(BMSettings setting)
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

                { m_Settings.GetOptionTabLocaleID(BMSettings.kCityStart), "Início da cidade" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kHotkeys), "Teclas" },
                { m_Settings.GetOptionTabLocaleID(BMSettings.kAbout), "Sobre" },

                { m_Settings.GetOptionGroupLocaleID(BMSettings.kCityStartGroup), "INÍCIO DA CIDADE" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kBudgetGroup), "ORÇAMENTO" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kSaveConversion), "CONVERTER DINHEIRO ILIMITADO" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(BMSettings.kAboutDiagnostics), "DIAGNÓSTICO" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.InitialMoney)),
                    "Define o saldo inicial da próxima cidade com <dinheiro limitado> que você carregar, nova ou existente.\n" +
                    "Depois de aplicar uma vez, volta ao padrão do jogo.\n" +
                    "<Se esta opção estiver cinza>, volte ao menu principal (ou reinicie o jogo) e abra as Opções de novo.\n" +
                    "Se escolher um marco inicial mais alto, as recompensas normais em dinheiro dos marcos serão adicionadas depois.\n" +
                    "Ative <Desativar dinheiro dos marcos> se não quiser esses bônus."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Padrão do jogo - não pular marcos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Marco inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Deixe em <Padrão do jogo - não pular marcos> para o progresso normal.\n" +
                    "Ou escolha um marco para desbloquear na próxima vez que uma cidade carregar.\n" +
                    "Se a cidade já estiver nesse marco ou além, nada acontece."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Desativar dinheiro dos marcos" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Remove só o <bônus em dinheiro> das recompensas de marcos.\n" +
                    "Desbloqueios e outras recompensas continuam funcionando.\n" +
                    "Vale para o marco inicial escolhido e os próximos marcos.\n" +
                    "A mudança é imediata, sem reiniciar.\n" +
                    "Ao DESATIVAR, os bônus futuros voltam; dinheiro já recebido ou pulado não muda."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Valor das teclas de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Este valor é usado pelas teclas Adicionar dinheiro e Subtrair dinheiro.\n" +
                    "<Padrão do mod = 40.000>\n" +
                    "Para dinheiro automático, ative Adicionar dinheiro automaticamente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Adicionar dinheiro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Quando ativado [ ✓ ], Budget + Milestones confere o saldo da cidade.\n" +
                    "- Se ficar <abaixo do limite>, adiciona o necessário para chegar ao limite.\n" +
                    "- Sempre adiciona pelo menos o valor automático escolhido."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Limite de dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Se Adicionar dinheiro automaticamente estiver ativo e o saldo cair abaixo deste valor,\n" +
                    "dinheiro é adicionado até chegar pelo menos a este limite."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Valor automático de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Valor mínimo adicionado sempre que o dinheiro automático dispara.\n" +
                    "Se precisar de mais para chegar ao limite, o mod adiciona o valor maior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Custo de demolição de redes" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Cobra uma porcentagem do custo de construção ao remover ruas, caminhos, trilhos, canos, cabos e outras redes.\n" +
                    "<0% = comportamento vanilla.> O reembolso normal do jogo para redes recém-construídas ou alteradas continua valendo.\n" +
                    "<Aviso: 50% pode acabar com o orçamento rápido.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Voltar ao padrão do jogo" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Restaura todas as <Configurações de início da cidade> para vanilla:\n" +
                    "dinheiro padrão, sem pular marcos, recompensas normais e 0% de custo de demolição.\n" +
                    "Não desfaz mudanças de marcos já aplicadas à cidade."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Tecla para <Adicionar dinheiro> dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Tecla para <Subtrair dinheiro> dentro da cidade. O saldo pode ficar abaixo de zero."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Conversor de Dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faça PRIMEIRO um backup da cidade>.\n" +
                    "Converte uma cidade iniciada com Dinheiro ilimitado para orçamento normal limitado.\n" +
                    "Ative para liberar o botão de conversão quando uma cidade com Dinheiro ilimitado estiver carregada.\n" +
                    "Budget + Milestones não consegue desfazer a conversão."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com a cidade carregada, converte o save para orçamento normal limitado.\n" +
                    "O botão só fica ativo se a cidade usa Dinheiro ilimitado e o conversor está LIGADO [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Salve PRIMEIRO um backup; Budget + Milestones não consegue desfazer isso.\n" +
                    "Tem certeza?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Nome exibido deste mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.VersionText)), "Versão atual do mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenParadox)), "Paradox Mods da Mochi" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenParadox)), "Abre a página da River-Mochi no Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenDiscord)), "Discord" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenDiscord)), "Abre o servidor de suporte no Discord." },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.OpenLog)), "Abrir log" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.OpenLog)),
                    "Abre </Logs/BudgetMilestones.log> se existir.\n" +
                    "Se não existir, abre a pasta Logs/."
                },
            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
