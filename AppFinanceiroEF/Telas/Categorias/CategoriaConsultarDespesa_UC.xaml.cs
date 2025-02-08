using AcessarBancoDados.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas.Categorias
{
    public partial class CategoriaConsultarDespesa_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public CategoriaConsultarDespesa_UC()
        {
            InitializeComponent();
            CarregarDataGrid();
        }

        private void CarregarDataGrid()
        {
            try
            {
                CategoriaConsultarDespesa_AD categoriaConsultarDespesa_AD = new();
                DtgDados.ItemsSource = categoriaConsultarDespesa_AD.SelecionarTodos();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtCategoria.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtCategoria.Text != "")
            {
                try
                {
                    CategoriaConsultarDespesa_AD categoriaConsultarDespesa_AD = new();
                    CategoriaConsultarDespesa categoriaConsultarDespesa = new()
                    {
                        NomeDaCategoria = TxtCategoria.Text
                    };
                    categoriaConsultarDespesa_AD.Cadastrar(categoriaConsultarDespesa);

                    GerenciarMensagens.SucessoAoCadastrar(categoriaConsultarDespesa.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtCategoria.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtCategoria.Text != "")
            {
                try
                {
                    CategoriaConsultarDespesa_AD categoriaConsultarDespesa_AD = new();
                    CategoriaConsultarDespesa categoriaConsultarDespesa = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        NomeDaCategoria = TxtCategoria.Text
                    };
                    categoriaConsultarDespesa_AD.Alterar(categoriaConsultarDespesa);

                    GerenciarMensagens.SucessoAoAlterar(categoriaConsultarDespesa.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtCategoria.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtCategoria.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens
                    .ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        CategoriaConsultarDespesa_AD categoriaConsultarDespesa_AD = new();
                        CategoriaConsultarDespesa categoriaConsultarDespesa = new()
                        {
                            Id = Convert.ToInt32(TxtId.Text)
                        };
                        categoriaConsultarDespesa_AD.Excluir(categoriaConsultarDespesa.Id);

                        GerenciarMensagens.SucessoAoExcluir(categoriaConsultarDespesa.Id);
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
            else if (TxtId.Text == "" && TxtCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtCategoria.Focus();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(CategoriaConsultarDespesa))
                    {
                        CategoriaConsultarDespesa categoriaConsultarDespesa = (CategoriaConsultarDespesa)DtgDados.SelectedItems[0];
                        TxtId.Text = categoriaConsultarDespesa.Id.ToString();
                        TxtCategoria.Text = categoriaConsultarDespesa.NomeDaCategoria;
                        TxtCategoria.Focus();
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
            TxtCategoria.Text = "";
            CarregarDataGrid();
        }
    }
}
