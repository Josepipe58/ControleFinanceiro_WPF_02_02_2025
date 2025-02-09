using AppControleFinanceiro.Telas;
using AppControleFinanceiro.Telas.Categorias;
using AppControleFinanceiro.Telas.Consultar;
using AppControleFinanceiro.Telas.Menus;
using AppControleFinanceiro.Telas.Relatorios;
using AppControleFinanceiro.Telas.SubCategorias;
using AppControleFinanceiro.Telas.SubCategprias;
using System.Windows.Input;

namespace AppControleFinanceiro.Comandos
{
    public partial class ComandosDaTelaPrincipal//Comandos Gerais
    {
        private object _selecionarControleDeUsuario;

        public object SelecionarControleDeUsuario
        {
            get => _selecionarControleDeUsuario;
            set
            {
                _selecionarControleDeUsuario = value;
                OnPropertyChanged(nameof(SelecionarControleDeUsuario));
            }
        }

        #region | Comandos de Voltar Para o Menu De Consultas e Relatórios |

        private void VoltarParaMenuDeConsultasERelatorios()
        {
            SelecionarControleDeUsuario = new RelatoriosEConsultas_UC();
        }

        private ICommand _comandoVoltarParaMenuDeRelatoriosEConsultas;
        public ICommand ComandoVoltarParaMenuDeRelatoriosEConsultas
        {
            get
            {
                if (_comandoVoltarParaMenuDeRelatoriosEConsultas == null)
                {
                    _comandoVoltarParaMenuDeRelatoriosEConsultas =
                        new RelayCommand(param => VoltarParaMenuDeConsultasERelatorios());
                }
                return _comandoVoltarParaMenuDeRelatoriosEConsultas;
            }
        }

        private void VoltarParaMenuDeCategoriasESubCategorias()
        {
            SelecionarControleDeUsuario = new CategoriasESubCategorias_UC();
        }

        private ICommand _comandoVoltarParaMenuDeCategoriasESubCategorias;
        public ICommand ComandoVoltarParaMenuDeCategoriasESubCategorias
        {
            get
            {
                if (_comandoVoltarParaMenuDeCategoriasESubCategorias == null)
                {
                    _comandoVoltarParaMenuDeCategoriasESubCategorias =
                        new RelayCommand(param => VoltarParaMenuDeCategoriasESubCategorias());
                }
                return _comandoVoltarParaMenuDeCategoriasESubCategorias;
            }
        }

        #endregion

        #region | Comandos de Categorias e SubCategorias |

        public void CategoriaComando()
        {
            SelecionarControleDeUsuario = new Categoria_UC();
        }

        private ICommand _comandoDaCategoria;
        public ICommand ComandoDaCategoria
        {
            get
            {
                if (_comandoDaCategoria == null)
                {
                    _comandoDaCategoria = new RelayCommand(param => CategoriaComando());
                }
                return _comandoDaCategoria;
            }
        }

        public void SubCategoriaComando()
        {
            SelecionarControleDeUsuario = new SubCategoria_UC();
        }

        private ICommand _comandoDaSubCategoria;
        public ICommand ComandoDaSubCategoria
        {
            get
            {
                if (_comandoDaSubCategoria == null)
                {
                    _comandoDaSubCategoria = new RelayCommand(param => SubCategoriaComando());
                }
                return _comandoDaSubCategoria;
            }
        }

        public void ConsultarCategoriasDeDespesasComando()
        {
            SelecionarControleDeUsuario = new CategoriaConsultarDespesa_UC();
        }

        private ICommand _comandoDeConsultarCategoriasDeDespesas;
        public ICommand ComandoDeConsultarCategoriasDeDespesas
        {
            get
            {
                if (_comandoDeConsultarCategoriasDeDespesas == null)
                {
                    _comandoDeConsultarCategoriasDeDespesas = new RelayCommand(param => ConsultarCategoriasDeDespesasComando());
                }
                return _comandoDeConsultarCategoriasDeDespesas;
            }
        }

        public void ConsultarSubCategoriasDeDespesasComando()
        {
            SelecionarControleDeUsuario = new SubCategoriaConsultarDespesa_UC();
        }

        private ICommand _comandoDeConsultarSubCategoriasDeDespesas;
        public ICommand ComandoDeConsultarSubCategoriasDeDespesas
        {
            get
            {
                if (_comandoDeConsultarSubCategoriasDeDespesas == null)
                {
                    _comandoDeConsultarSubCategoriasDeDespesas = new RelayCommand(param => ConsultarSubCategoriasDeDespesasComando());
                }
                return _comandoDeConsultarSubCategoriasDeDespesas;
            }
        }
        #endregion

        #region | Relatórios de Despesas, Poupanças, Investimentos e Receitas |

        public void RelatorioDeDespesas()
        {
            SelecionarControleDeUsuario = new RelatorioDeDespesas_UC();
        }

        private ICommand _comandoDoRelatorioDeDespesas;
        public ICommand ComandoDoRelatorioDeDespesas
        {
            get
            {
                if (_comandoDoRelatorioDeDespesas == null)
                {
                    _comandoDoRelatorioDeDespesas = new RelayCommand(param => RelatorioDeDespesas());
                }
                return _comandoDoRelatorioDeDespesas;
            }
        }

        public void RelatorioDaPoupanca()
        {
            SelecionarControleDeUsuario = new RelatorioDePoupanca_UC();
        }

        private ICommand _comandoDoRelatorioDaPoupanca;
        public ICommand ComandoDoRelatorioDaPoupanca
        {
            get
            {
                if (_comandoDoRelatorioDaPoupanca == null)
                {
                    _comandoDoRelatorioDaPoupanca = new RelayCommand(param => RelatorioDaPoupanca());
                }
                return _comandoDoRelatorioDaPoupanca;
            }
        }

        public void RelatorioDeInvestimentos()
        {
            SelecionarControleDeUsuario = new RelatorioDeInvestimentos_UC();
        }

        private ICommand _comandoDoRelatorioDeInvestimentos;
        public ICommand ComandoDoRelatorioDeInvestimentos
        {
            get
            {
                if (_comandoDoRelatorioDeInvestimentos == null)
                {
                    _comandoDoRelatorioDeInvestimentos = new RelayCommand(param => RelatorioDeInvestimentos());
                }
                return _comandoDoRelatorioDeInvestimentos;
            }
        }

        public void RelatorioDeReceitas()
        {
            SelecionarControleDeUsuario = new RelatorioDeReceitas_UC();
        }

        private ICommand _comandoDoRelatorioDeReceitas;
        public ICommand ComandoDoRelatorioDeReceitas
        {
            get
            {
                if (_comandoDoRelatorioDeReceitas == null)
                {
                    _comandoDoRelatorioDeReceitas = new RelayCommand(param => RelatorioDeReceitas());
                }
                return _comandoDoRelatorioDeReceitas;
            }
        }
        #endregion

        #region | Consultas de Despesas e Finanças |

        public void ConsultarDespesas()
        {
            SelecionarControleDeUsuario = new ConsultarDespesas_UC();
        }

        private ICommand _comandoDeConsultarDespesas;
        public ICommand ComandoDeConsultarDespesas
        {
            get
            {
                if (_comandoDeConsultarDespesas == null)
                {
                    _comandoDeConsultarDespesas = new RelayCommand(param => ConsultarDespesas());
                }
                return _comandoDeConsultarDespesas;
            }
        }

        public void ConsultarFinancas()
        {
            SelecionarControleDeUsuario = new ConsultarFinancas_UC();
        }

        private ICommand _comandoDeConsultarFinancas;
        public ICommand ComandoDeConsultarFinancas
        {
            get
            {
                if (_comandoDeConsultarFinancas == null)
                {
                    _comandoDeConsultarFinancas = new RelayCommand(param => ConsultarFinancas());
                }
                return _comandoDeConsultarFinancas;
            }
        }
        #endregion
    }
}
