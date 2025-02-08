using AcessarBancoDados.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas.Categorias
{
    public partial class Categoria_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public Categoria_UC()
        {
            InitializeComponent();
            ComboBoxDeFiltrosDeControle();
        }

        public void ComboBoxDeFiltrosDeControle()
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
                _nomeDoMetodo = "ComboBoxDeFiltrosDeControle";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        private void CarregarDataGrid()
        {
            try
            {
                if (CbxNomeDeFiltros.Text == "Despesa")
                {
                    DtgDados.ItemsSource = Categoria_AD.ObterCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Despesa");
                }
                else if (CbxNomeDeFiltros.Text == "Poupança")
                {
                    DtgDados.ItemsSource = Categoria_AD.ObterCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Poupança");
                }
                else if (CbxNomeDeFiltros.Text == "Receita")
                {
                    DtgDados.ItemsSource = Categoria_AD.ObterCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Receita");
                }
                else
                {
                    DtgDados.ItemsSource = Categoria_AD.ObterCategorias()
                        .Where(sc => sc.NomeDoFiltro == "Investimento");
                }
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
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        NomeDaCategoria = TxtCategoria.Text,
                        FiltrarCategoriaId = Convert.ToInt32(CbxNomeDeFiltros.SelectedValue)
                    };
                    categoria_AD.Cadastrar(categoria);

                    GerenciarMensagens.SucessoAoCadastrar(categoria.Id);
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
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        NomeDaCategoria = TxtCategoria.Text,
                        FiltrarCategoriaId = Convert.ToInt32(CbxNomeDeFiltros.SelectedValue)
                    };
                    categoria_AD.Alterar(categoria);

                    GerenciarMensagens.SucessoAoAlterar(categoria.Id);
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
                        Categoria_AD categoria_AD = new();
                        Categoria categoria = new()
                        {
                            Id = Convert.ToInt32(TxtId.Text)
                        };
                        categoria_AD.Excluir(categoria.Id);

                        GerenciarMensagens.SucessoAoExcluir(categoria.Id);
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
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Categoria))
                    {
                        Categoria categoria = (Categoria)DtgDados.SelectedItems[0];
                        TxtId.Text = categoria.Id.ToString();
                        TxtCategoria.Text = categoria.NomeDaCategoria;
                        CbxNomeDeFiltros.Text = categoria.NomeDoFiltro;
                        TxtCategoria.Focus();
                    }
                }
            }
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {
            CarregarDataGrid();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CbxNomeDeFiltros.SelectedIndex = 0;
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
