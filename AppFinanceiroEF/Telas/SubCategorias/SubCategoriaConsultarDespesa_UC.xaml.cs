using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas.SubCategorias
{
    public partial class SubCategoriaConsultarDespesa_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public SubCategoriaConsultarDespesa_UC()
        {
            InitializeComponent();
            CarregarComboBox();
        }

        public void CarregarComboBox()
        {
            try
            {
                CategoriaConsultarDespesa_AD categoriaConsultarDespesa_AD = new();
                CbxCategoria.ItemsSource = categoriaConsultarDespesa_AD.SelecionarTodos();
                CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
                CbxCategoria.SelectedValuePath = "Id";
                CbxCategoria.SelectedIndex = 0;
                TxtSubCategoria.Focus();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarComboBox";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        private void CarregarDataGrid()
        {
            try
            {
                DtgDados.ItemsSource = SubCategoriaConsultarDespesa_AD.ObterSubCategorias();
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
                    SubCategoriaConsultarDespesa_AD subCategoriaConsultarDespesa_AD = new();
                    SubCategoriaConsultarDespesa subCategoriaConsultarDespesa = new();

                    subCategoriaConsultarDespesa.NomeDaSubCategoria = TxtSubCategoria.Text;
                    subCategoriaConsultarDespesa.CategoriaConsultarDespesaId = Convert.ToInt32(CbxCategoria.SelectedValue);

                    subCategoriaConsultarDespesa_AD.Cadastrar(subCategoriaConsultarDespesa);

                    GerenciarMensagens.SucessoAoCadastrar(subCategoriaConsultarDespesa.Id);
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
                    SubCategoriaConsultarDespesa_AD subCategoriaConsultarDespesa_AD = new();
                    SubCategoriaConsultarDespesa subCategoriaConsultarDespesa = new()
                    {
                        Id = Convert.ToInt32(TxtIdSubCategoria.Text),
                        NomeDaSubCategoria = TxtSubCategoria.Text,
                        CategoriaConsultarDespesaId = Convert.ToInt32(CbxCategoria.SelectedValue)
                    };
                    subCategoriaConsultarDespesa_AD.Alterar(subCategoriaConsultarDespesa);

                    GerenciarMensagens.SucessoAoAlterar(subCategoriaConsultarDespesa.Id);
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
                        SubCategoriaConsultarDespesa_AD subCategoriaConsultarDespesa_AD = new();
                        SubCategoriaConsultarDespesa subCategoriaConsultarDespesa = new()
                        {
                            Id = Convert.ToInt32(TxtIdSubCategoria.Text)
                        };
                        subCategoriaConsultarDespesa_AD.Excluir(subCategoriaConsultarDespesa.Id);

                        GerenciarMensagens.SucessoAoExcluir(subCategoriaConsultarDespesa.Id);
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
                if (DtgDados.SelectedItems[0].GetType() == typeof(SubCategoriaConsultarDespesa))
                {
                    SubCategoriaConsultarDespesa subCategoriaConsultarDespesa = (SubCategoriaConsultarDespesa)DtgDados.SelectedItems[0];

                    TxtIdSubCategoria.Text = subCategoriaConsultarDespesa.Id.ToString();
                    TxtSubCategoria.Text = subCategoriaConsultarDespesa.NomeDaSubCategoria.ToString();
                    TxtIdCategoria.Text = subCategoriaConsultarDespesa.CategoriaConsultarDespesaId.ToString();
                    CbxCategoria.Text = subCategoriaConsultarDespesa.NomeDaCategoria.ToString();                    
                    TxtSubCategoria.Focus();
                }
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = SubCategoriaConsultarDespesa_AD.ObterSubCategorias()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = SubCategoriaConsultarDespesa_AD.ObterSubCategorias();
            }
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
