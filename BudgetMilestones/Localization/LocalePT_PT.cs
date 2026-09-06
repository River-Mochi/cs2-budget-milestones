// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_PT.cs
// Purpose: European Portuguese Options UI localization for Budget + Milestones.

namespace BudgetMilestones
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly BMSettings m_Settings;

        public LocalePT_PT(BMSettings setting)
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
                    "Define o saldo inicial da próxima cidade com <dinheiro limitado> que carregares, nova ou existente.\n" +
                    "Depois de ser aplicado uma vez, volta ao padrão do jogo.\n" +
                    "<Se esta opção estiver a cinzento>, volta ao menu principal (ou reinicia o jogo) e abre as Opções novamente.\n" +
                    "Se escolheres um marco inicial mais alto, as recompensas normais em dinheiro dos marcos são adicionadas depois.\n" +
                    "Ativa <Desativar dinheiro dos marcos> se não quiseres esses bónus."
                },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                { m_Settings.GetOptionLocaleID("NoExtraMilestone"), "Padrão do jogo - não saltar marcos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.MilestoneLevel)), "Marco inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.MilestoneLevel)),
                    "Deixa em <Padrão do jogo - não saltar marcos> para a progressão normal.\n" +
                    "Ou escolhe um marco para desbloquear da próxima vez que uma cidade for carregada.\n" +
                    "Se a cidade já estiver nesse marco ou mais avançada, nada acontece."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)), "Desativar dinheiro dos marcos" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.DisableMilestoneMoneyRewards)),
                    "Remove apenas o <bónus em dinheiro> das recompensas dos marcos.\n" +
                    "Desbloqueios e outras recompensas continuam a funcionar.\n" +
                    "Aplica-se ao marco inicial escolhido e aos marcos seguintes.\n" +
                    "A alteração é imediata, sem reiniciar.\n" +
                    "Ao DESATIVAR, os bónus futuros voltam; dinheiro já recebido ou ignorado não muda."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ManualMoneyAmount)), "Valor das teclas de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ManualMoneyAmount)),
                    "Este valor é usado pelas teclas Adicionar dinheiro e Subtrair dinheiro.\n" +
                    "<Padrão do mod = 40 000>\n" +
                    "Para dinheiro automático, ativa Adicionar dinheiro automaticamente."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoney)), "Adicionar dinheiro automaticamente" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoney)),
                    "Quando ativado [ ✓ ], Budget + Milestones verifica o saldo da cidade.\n" +
                    "- Se ficar <abaixo do limite>, adiciona o necessário para chegar ao limite.\n" +
                    "- Adiciona sempre pelo menos o valor automático escolhido."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)), "Limite de dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyThreshold)),
                    "Se Adicionar dinheiro automaticamente estiver ativo e o saldo cair abaixo deste valor,\n" +
                    "é adicionado dinheiro até chegar pelo menos a este limite."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)), "Valor automático de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AutomaticAddMoneyAmount)),
                    "Valor mínimo adicionado sempre que o dinheiro automático é acionado.\n" +
                    "Se for preciso mais para chegar ao limite, é adicionado o valor maior."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)), "Custo de demolição de redes" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NetworkDemolitionCostPercent)),
                    "Cobra uma percentagem do custo de construção ao remover estradas, caminhos, carris, tubos, cabos e outras redes.\n" +
                    "<0% = comportamento vanilla.> O reembolso normal do jogo para redes recém-construídas ou alteradas continua a aplicar-se.\n" +
                    "<Aviso: 50% pode esvaziar o orçamento depressa.>"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)), "Repor padrão do jogo" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ResetCityStartToGameDefaults)),
                    "Repõe todas as <Definições de início da cidade> para vanilla:\n" +
                    "dinheiro padrão, sem saltar marcos, recompensas normais e 0% de custo de demolição.\n" +
                    "Não desfaz alterações de marcos já aplicadas à cidade."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.AddMoneyKeyboardBinding)), "Tecla para <Adicionar dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(BMSettings.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.SubtractMoneyKeyboardBinding)),
                    "Tecla para <Subtrair dinheiro> na cidade. O saldo pode ficar abaixo de zero."
                },

                { m_Settings.GetBindingKeyLocaleID(BMSettings.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)), "Conversor de Dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faz PRIMEIRO uma cópia de segurança da cidade>.\n" +
                    "Converte uma cidade iniciada com Dinheiro ilimitado para orçamento normal limitado.\n" +
                    "Ativa para desbloquear o botão de conversão quando uma cidade com Dinheiro ilimitado estiver carregada.\n" +
                    "Budget + Milestones não consegue desfazer a conversão."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)), "Converter cidade de Dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Com a cidade carregada, converte a gravação para orçamento normal limitado.\n" +
                    "O botão só fica ativo se a cidade usa Dinheiro ilimitado e o conversor está LIGADO [ ✓ ]."
                },

                { m_Settings.GetOptionWarningLocaleID(nameof(BMSettings.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Guarda PRIMEIRO uma cópia de segurança; Budget + Milestones não consegue desfazer isto.\n" +
                    "Tens a certeza?"
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(BMSettings.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(BMSettings.NameText)), "Nome apresentado deste mod." },

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
