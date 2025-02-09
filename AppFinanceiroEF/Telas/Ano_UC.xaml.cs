using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas
{
    public partial class Ano_UC : UserControl
    {
        private static string _nomeDoMetodo = string.Empty;
        public Ano_UC()
        {
            InitializeComponent();
            CarregarDataGrid();
        }

        private void CarregarDataGrid()
        {
            try
            {               
                Ano_AD ano_AD = new();
                DtgDados.ItemsSource = ano_AD.SelecionarTodos().ToList();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtAno.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtAno.Text != "")
            {
                try
                {
                    Ano_AD ano_AD = new();
                    Ano ano = new()
                    {
                        AnoDoCadastro = Convert.ToInt32(TxtAno.Text)
                    };
                    ano_AD.Cadastrar(ano);


                    GerenciarMensagens.SucessoAoCadastrar(ano.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtAno.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtAno.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtAno.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtAno.Text != "")
            {
                try
                {
                    Ano_AD ano_AD = new();
                    Ano ano = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        AnoDoCadastro = Convert.ToInt32(TxtAno.Text)
                    };
                    ano_AD.Alterar(ano);

                    GerenciarMensagens.SucessoAoAlterar(ano.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtAno.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtAno.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtAno.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtAno.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens
                    .ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        Ano_AD ano_AD = new();
                        Ano ano = new()
                        {
                            Id = Convert.ToInt32(TxtId.Text)
                        };
                        ano_AD.Excluir(ano.Id);

                        GerenciarMensagens.SucessoAoExcluir(ano.Id);
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
            else if (TxtId.Text == "" && TxtAno.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtAno.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtAno.Focus();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Ano))
                    {
                        Ano ano = (Ano)DtgDados.SelectedItems[0];
                        TxtId.Text = ano.Id.ToString();
                        TxtAno.Text = ano.AnoDoCadastro.ToString();
                        TxtAno.Focus();
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }

        private void LimparEAtualizarDados()
        {
            TxtId.Text = "";
            TxtAno.Text = "";
            CarregarDataGrid();
        }
    }
}
