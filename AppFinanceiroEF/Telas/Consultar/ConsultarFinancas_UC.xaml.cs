using GerenciarDados.AcessarDados;
using GerenciarDados.Consultas;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;
using GerenciarDados.Relatorios;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas.Consultar
{
    public partial class ConsultarFinancas_UC : UserControl
    {
        public string _categoria, _subCategoria, _nomeDoMetodo = string.Empty;

        public ConsultarFinancas_UC()
        {
            InitializeComponent();
            CarregarComboBoxes();
        }

        private void CarregarComboBoxes()
        {
            try
            {
                //ComboBox de Nome de Filtros.
                FiltrarCategoria_AD filtroDeControle_AD = new();
                CbxNomeDeFiltros.ItemsSource = filtroDeControle_AD.SelecionarTodos()
                    .Where(fc => new[] { "Poupança", "Investimentos" }.Contains(fc.NomeDoFiltro));
                CbxNomeDeFiltros.DisplayMemberPath = "NomeDoFiltro";
                CbxNomeDeFiltros.SelectedValuePath = "Id";
                CbxNomeDeFiltros.SelectedIndex = -1;

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
            catch (Exception erro)
            {
                _nomeDoMetodo = "CarregarComboBoxes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
            ConsultasDeFinancas();
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categoria_AD categoria_AD = new();
            CbxCategoria.ItemsSource = categoria_AD
                .ObterCategoriasPorId(Convert.ToInt32(CbxNomeDeFiltros.SelectedValue));
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = -1;

        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubCategoria_AD subCategoria_AD = new();
            CbxSubCategoria.ItemsSource = subCategoria_AD
                .ObterSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = -1;
        }

        public void ConsultasDeFinancas()
        {
            try
            {
                if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas();

                    DtgValores.ItemsSource = RelatorioDePoupanca
                        .RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos(DateTime.Now.Year);
                    LblTitulo.Content = "Consulta do saldo total da Poupança, Receitas e Investimentos.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoria(CbxCategoria.Text);
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de todos os anos cadastrados, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                             .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaESubCategoria(CbxCategoria.Text, CbxSubCategoria.Text);
                    _categoria = CbxCategoria.Text;
                    _subCategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria} - {_subCategoria}, consulta de todos os anos cadastrados, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text && dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaSubCategoriaEMes(CbxCategoria.Text, CbxSubCategoria.Text, CbxMes.Text);
                    _categoria = CbxCategoria.Text;
                    _subCategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria} - {_subCategoria}, consulta de acordo com o mês selecionado, desde o ano de 2020.";
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
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

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
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaMesEAno(CbxCategoria.Text, CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorCategoriaEMes(CbxCategoria.Text, CbxMes.Text);
                    _categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {_categoria}, consulta de acordo com o mês selecionado, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorMesEAno(CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    LblTitulo.Content = "Consulta geral de Finanças, de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorMes(CbxMes.Text);
                    LblTitulo.Content = "Consulta geral de Finanças, de acordo com o mês selecionado, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ObterListaDeDespesas()
                            .Where(dp => dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorAno(Convert.ToInt32(CbxAno.Text));
                    LblTitulo.Content = "Consulta geral de Finanças, de acordo com o ano selecionado.";
                }
                else
                {
                    MessageBox.Show("Não foi possível fazer nenhum tipo de consulta de Finanças.", "Mensagem de Erro!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultasDeFinancas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
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
            ConsultasDeFinancas();
        }

        private void CbxCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeFinancas();
        }

        private void CbxSubCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeFinancas();
        }

        private void CbxMes_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeFinancas();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeFinancas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }
        private void LimparEAtualizarDados()
        {
            CbxNomeDeFiltros.Text = "";
            CbxCategoria.Text = "";
            CbxSubCategoria.Text = "";
            CbxMes.Text = "";
            CbxAno.Text = "";
            TxtPesquisar.Text = "";
            ConsultasDeFinancas();
        }
    }
}
