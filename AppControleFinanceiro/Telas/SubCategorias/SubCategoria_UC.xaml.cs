﻿using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppControleFinanceiro.Telas.SubCategprias
{
    public partial class SubCategoria_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public SubCategoria_UC()
        {
            InitializeComponent();
            CarregarComboBox();
        }

        public void CarregarComboBox()
        {
            try
            {
                FiltrarCategoria_AD filtroDeControle_AD = new();
                CbxNomeDeFiltros.ItemsSource = filtroDeControle_AD.SelecionarTodos();
                CbxNomeDeFiltros.DisplayMemberPath = "NomeDoFiltro";
                CbxNomeDeFiltros.SelectedValuePath = "Id";
                CbxNomeDeFiltros.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarComboBox";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxCategoria.ItemsSource = Categoria_AD.ObterCategoriasPorId(Convert.ToInt32(CbxNomeDeFiltros.SelectedValue));
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = 0;
            TxtSubCategoria.Focus();
        }

        private void CarregarDataGrid()
        {
            try
            {

                if (CbxNomeDeFiltros.Text == "Despesa")
                {
                    DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Despesa");
                }
                else if (CbxNomeDeFiltros.Text == "Poupança")
                {
                    DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Poupança");
                }
                else if (CbxNomeDeFiltros.Text == "Receita")
                {
                    DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Receita");
                }
                else
                {
                    DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Investimento");
                }
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtSubCategoria.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdSubCategoria.Text == "" && TxtSubCategoria.Text != "" && TxtIdCategoria.Text == "")
            {
                try
                {
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoria subCategoria = new();

                    subCategoria.NomeDaSubCategoria = TxtSubCategoria.Text;
                    subCategoria.CategoriaId = Convert.ToInt32(CbxCategoria.SelectedValue);

                    subCategoria_AD.Cadastrar(subCategoria);

                    GerenciarMensagens.SucessoAoCadastrar(subCategoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtIdSubCategoria.Text != "" && TxtSubCategoria.Text != "" && TxtIdCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtSubCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtSubCategoria.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdSubCategoria.Text != "" && TxtSubCategoria.Text != "" && TxtIdCategoria.Text != "")
            {
                try
                {
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoria subCategoria = new()
                    {
                        Id = Convert.ToInt32(TxtIdSubCategoria.Text),
                        NomeDaSubCategoria = TxtSubCategoria.Text,
                        CategoriaId = Convert.ToInt32(CbxCategoria.SelectedValue)
                    };
                    subCategoria_AD.Alterar(subCategoria);

                    GerenciarMensagens.SucessoAoAlterar(subCategoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtIdSubCategoria.Text == "" && TxtSubCategoria.Text != "" && TxtIdCategoria.Text == "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtSubCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtSubCategoria.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdSubCategoria.Text != "" && TxtSubCategoria.Text != "" && TxtIdCategoria.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtIdSubCategoria.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        SubCategoria_AD subCategoria_AD = new();
                        SubCategoria subCategoria = new()
                        {
                            Id = Convert.ToInt32(TxtIdSubCategoria.Text)
                        };
                        subCategoria_AD.Excluir(subCategoria.Id);

                        GerenciarMensagens.SucessoAoExcluir(subCategoria.Id);
                        LimparEAtualizarDados();
                    }
                    catch (Exception ex)
                    {
                        _nomeDoMetodo = "BtnExcluir_Click";
                        GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                        return;
                    }
                }
                else
                {
                    LimparEAtualizarDados();
                    return;
                }
            }
            else if (TxtIdSubCategoria.Text == "" && TxtSubCategoria.Text != "" && TxtIdCategoria.Text == "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtSubCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtSubCategoria.Focus();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(SubCategoria))
                {
                    SubCategoria subCategoria = (SubCategoria)DtgDados.SelectedItems[0];

                    TxtIdSubCategoria.Text = subCategoria.Id.ToString();
                    TxtSubCategoria.Text = subCategoria.NomeDaSubCategoria.ToString();
                    TxtIdCategoria.Text = subCategoria.CategoriaId.ToString();
                    CbxCategoria.Text = subCategoria.NomeDaCategoria.ToString();
                    CbxNomeDeFiltros.Text = subCategoria.NomeDoFiltro.ToString();
                    TxtSubCategoria.Focus();
                }
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = SubCategoria_AD.ObterSubCategorias()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias();
            }
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {
            CarregarDataGrid();
        }

        private void CbxCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            CarregarDataGrid();
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            BtnAtualizar_Click(sender, e);
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CbxNomeDeFiltros.SelectedIndex = 0;
            CbxCategoria.SelectedIndex = 0;
            LimparEAtualizarDados();
        }

        private void LimparEAtualizarDados()
        {
            TxtIdCategoria.Text = "";
            TxtIdSubCategoria.Text = "";
            TxtSubCategoria.Text = "";
            TxtPesquisar.Text = "";
            CarregarDataGrid();
        }
    }
}
