using GerenciarDados.Mensagens;
using GerenciarDados.AcessarDados;
using GerenciarDados.Consultas;
using GerenciarDados.Listas;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppControleFinanceiro.Telas.Consultar
{
    public partial class ConsultarDespesas_UC : UserControl
    {
        public string _categoria, _subCategoria, _nomeDoMetodo = string.Empty;

        public ConsultarDespesas_UC()
        {
            InitializeComponent();            
            CarregarComboBoxes();
        }

        private void CarregarComboBoxes()
        {
            try
            {
                //ComboBox de Consultar Categorias de Despesa.
                CategoriaConsultarDespesa_AD categoriaConsultarDespesa_AD = new();
                CbxCategoria.ItemsSource = categoriaConsultarDespesa_AD.SelecionarTodos();
                CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
                CbxCategoria.SelectedValuePath = "Id";
                CbxCategoria.SelectedIndex = -1;

                //Carregar ComboBox Ano.                
                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.SelecionarTodos().ToList();
                CbxAno.DisplayMemberPath = "AnoDoCadastro";
                CbxAno.SelectedValuePath = "Id";
                CbxAno.SelectedIndex = -1;

                //Carregar ComboBox Mês
                CbxMes.ItemsSource = ListaDeStringMeses.CarregarComboBoxDeMeses();
                CbxMes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarComboBoxes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            ConsultasDeDespesas();
        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxSubCategoria.ItemsSource = SubCategoriaConsultarDespesa_AD.ObterSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = -1;
        }

        public void ConsultasDeDespesas()
        {
            try
            {
                if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas();

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarDespesasGeraisDeTodosOsAnos();
                    LblTitulo.Content = "Consulta geral de Despesas, a partir do ano de 2025.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoria(CbxCategoria.Text);
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de todos os anos cadastrados, a partir do ano de 2025.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text
                    && dp.NomeDaSubCategoria == CbxSubCategoria.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaESubCategoria(CbxCategoria.Text, CbxSubCategoria.Text);
                    _categoria = CbxCategoria.Text;
                    _subCategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria} - {_subCategoria}, consulta de todos os anos cadastrados, a partir do ano de 2025.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text 
                    && dp.NomeDaSubCategoria == CbxSubCategoria.Text && dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaSubCategoriaEMes(CbxCategoria.Text, CbxSubCategoria.Text, CbxMes.Text);
                    _categoria = CbxCategoria.Text;
                    _subCategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria} - {_subCategoria}, consulta de acordo com o mês selecionado, a partir do ano de 2025.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text 
                    && dp.NomeDaSubCategoria == CbxSubCategoria.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaSubCategoriaEAno(CbxCategoria.Text, CbxSubCategoria.Text,
                        Convert.ToInt32(CbxAno.Text));
                    _categoria = CbxCategoria.Text;
                    _subCategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria} - {_subCategoria}, consulta de acordo com o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text 
                    && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaEAno(CbxCategoria.Text, Convert.ToInt32(CbxAno.Text));
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de acordo com o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text &&
                            dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaSubCategoriaMesEAno(CbxCategoria.Text, CbxSubCategoria.Text,
                        CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    _categoria = CbxCategoria.Text;
                    _subCategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria} - {_subCategoria}, consulta de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Mes == CbxMes.Text 
                    && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaMesEAno(CbxCategoria.Text, CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaEMes(CbxCategoria.Text, CbxMes.Text);
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de acordo com o mês selecionado, a partir do ano de 2025.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorMesEAno(CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    LblTitulo.Content = "Consulta geral de Despesas, de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorMes(CbxMes.Text);
                    LblTitulo.Content = "Consulta geral de Despesas, de acordo com o mês selecionado, a partir do ano de 2025.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas().Where(dp => dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorAno(Convert.ToInt32(CbxAno.Text));
                    LblTitulo.Content = "Consulta geral de Despesas, de acordo com o ano selecionado.";
                }
                else
                {
                    MessageBox.Show("Não foi possível fazer nenhum tipo de consulta de Despesas.", "Mensagem de Erro!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultasDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = ConsultarDespesas.ObterListaDeDespesas()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas();
            }
        }

        private void CbxNomeDeFiltros_DropDownClosed(object sender, EventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxSubCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxMes_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CbxCategoria.Text = "";
            CbxSubCategoria.Text = "";
            CbxMes.Text = "";
            CbxAno.Text = "";
            TxtPesquisar.Text = "";
            ConsultasDeDespesas();
        }
    }
}
