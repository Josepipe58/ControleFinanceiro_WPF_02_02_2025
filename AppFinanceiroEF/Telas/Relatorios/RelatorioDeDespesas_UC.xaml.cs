﻿using GerenciarDados.Mensagens;
using GerenciarDados.AcessarDados;
using GerenciarDados.Relatorios;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas.Relatorios
{
    public partial class RelatorioDeDespesas_UC : UserControl
    {
        private static string _nomeDoMetodo = string.Empty;

        public RelatorioDeDespesas_UC()
        {
            InitializeComponent();
            CarregarComboBoxAno();
        }

        public void CarregarComboBoxAno()
        {
            try
            {
                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.SelecionarTodos().ToList();
                CbxAno.DisplayMemberPath = "AnoDoCadastro";
                CbxAno.SelectedValuePath = "Id";
                CbxAno.SelectedIndex = 0;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "CarregarComboBoxAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
            RelatoriosDeDespesas();
        }

        public void RelatoriosDeDespesas()
        {
            try
            {
                //Carregar DataGrid das Despesas Gerais.
                DtgDespGeral.ItemsSource = RelatorioDeDespesas.RelatorioDeDespesasGerais(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas Normais.
                DtgDespNormal.ItemsSource = RelatorioDeDespesas.RelatorioDeDespesasNormais(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas de Caridade.
                DtgDespCaridade.ItemsSource = RelatorioDeDespesas.RelatorioDeDespesasDeCaridade(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas Extras.
                DtgDespExtra.ItemsSource = RelatorioDeDespesas.RelatorioDeDespesasExtras(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas da Neusa.
                DtgDespNeusa.ItemsSource = RelatorioDeDespesas.RelatorioDeDespesasDaNeusa(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatoriosDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDeDespesas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
