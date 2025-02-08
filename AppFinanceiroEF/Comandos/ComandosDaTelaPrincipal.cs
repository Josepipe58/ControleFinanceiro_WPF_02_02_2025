using AppFinanceiroEF.Telas;
using AppFinanceiroEF.Telas.Menus;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace AppFinanceiroEF.Comandos
{
    public partial class ComandosDaTelaPrincipal : RelayCommand
    {
        private static string _nomeDoMetodo = string.Empty;
        private CollectionViewSource MenuItemsCollection { get; set; }
        public ICollectionView SourceCollection => MenuItemsCollection.View;

        public ComandosDaTelaPrincipal()
        {
            ObservableCollection<ListaDeItemsDoMenu> menuItems =
            [
                new ListaDeItemsDoMenu{ MenuName = "Página Inicial" },
                new ListaDeItemsDoMenu{ MenuName = "Despesas" },
                new ListaDeItemsDoMenu{ MenuName = "Poupança" },
                new ListaDeItemsDoMenu{ MenuName = "Investimentos" },
                new ListaDeItemsDoMenu{ MenuName = "Receitas" },
                new ListaDeItemsDoMenu{ MenuName = "Categorias e SubCategorias" },
                new ListaDeItemsDoMenu{ MenuName = "Anos" },
                new ListaDeItemsDoMenu{ MenuName = "Aposentadoria" },
                new ListaDeItemsDoMenu{ MenuName = "Relatórios e Consultas" },
            ];

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };

            // Configura a página de inicialização.
            SelecionarControleDeUsuario = new PaginaInicial_UC();
        }

        private void ExibirPaginaInicial()
        {
            SelecionarControleDeUsuario = new PaginaInicial_UC();
        }

        private ICommand _comandoVoltarPaginaInicial;
        public ICommand ComandoVoltarPaginaInicial
        {
            get
            {
                if (_comandoVoltarPaginaInicial == null)
                {
                    _comandoVoltarPaginaInicial ??= new RelayCommand(param => ExibirPaginaInicial());
                }
                return _comandoVoltarPaginaInicial;
            }
        }

        private ICommand _comandoDoMenu;
        public ICommand ComandoDoMenu
        {
            get
            {
                _comandoDoMenu ??= new RelayCommand(param => MenuDoMenuInicial(param));
                return _comandoDoMenu;
            }
        }

        public void MenuDoMenuInicial(object parameter)
        {
            try
            {
                SelecionarControleDeUsuario = parameter switch
                {
                    "Página Inicial" => new PaginaInicial_UC(),
                    "Despesas" => new Despesa_UC(),
                    "Poupança" => new Poupanca_UC(),
                    "Investimentos" => new Investimento_UC(),
                    "Receitas" => new Receita_UC(),
                    "Categorias e SubCategorias" => new CategoriasESubCategorias_UC(),
                    "Anos" => new Ano_UC(),
                    "Aposentadoria" => new Aposentadoria_UC(),
                    "Relatórios e Consultas" => new RelatoriosEConsultas_UC(),
                    _ => new PaginaInicial_UC()
                };
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "MenuDoMenuInicial";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        public static void AbrirBancoDeDados()
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft SQL Server Management Studio 19\\Common7\\IDE\\Ssms.exe");
        }

        private ICommand _comandoAbrirBancoDeDados;
        public ICommand ComandoAbrirBancoDeDados
        {
            get
            {
                _comandoAbrirBancoDeDados ??= new RelayCommand(param => AbrirBancoDeDados());
                return _comandoAbrirBancoDeDados;
            }
        }

        public static void SairDoAplicativo()
        {
            Application.Current.MainWindow.Close();
        }

        private ICommand _comandoSairDoAplicativo;
        public ICommand ComandoSairDoAplicativo
        {
            get
            {
                _comandoSairDoAplicativo ??= new RelayCommand(param => SairDoAplicativo());
                return _comandoSairDoAplicativo;
            }
        }
    }
}
