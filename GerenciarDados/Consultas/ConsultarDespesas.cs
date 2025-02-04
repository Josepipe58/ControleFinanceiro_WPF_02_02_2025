using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Consultas
{
    public static class ConsultarDespesas
    {
        public static string _nomeDoMetodo = string.Empty;

        public static List<Despesa> ObterListaDeDespesas()
        {
            try
            {
                using Contexto contexto = new();
                var listaDeDespesas = contexto.TDespesa.Select(cd => new Despesa()
                {
                    Id = cd.Id,
                    NomeDaCategoria = cd.NomeDaCategoria,
                    NomeDaSubCategoria = cd.NomeDaSubCategoria,
                    Valor = cd.Valor,
                    Tipo = cd.Tipo,
                    Data = cd.Data.Date,
                    Mes = cd.Mes,
                    Ano = cd.Ano
                }).OrderByDescending(cd => cd.Id);

                return listaDeDespesas.ToList();
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ObterListaDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new List<Despesa>();
            }
        }

        public static ListaDeMeses ConsultarDespesasGeraisDeTodosOsAnos()
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.Mes == "Janeiro" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.Mes == "Fevereiro" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(cd => cd.Mes == "Março" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(cd => cd.Mes == "Abril" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(cd => cd.Mes == "Maio" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(cd => cd.Mes == "Junho" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(cd => cd.Mes == "Julho" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.Mes == "Agôsto" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.Mes == "Setembro" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.Mes == "Outubro" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.Mes == "Novembro" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.Mes == "Dezembro" && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarDespesasGeraisDeTodosOsAnos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoria(string nomeDaCategoria)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Março").Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaESubCategoria(string nomeDaCategoria, string nomeDaSubCategoria)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Março").Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria)
                    .Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaESubCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaEMes(string nomeDaCategoria, string nomeDaSubCategoria, string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                   contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                   && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                   contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                   && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaEMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaEAno(string nomeDaCategoria, string nomeDaSubCategoria, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Março").Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Ano == ano).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaMesEAno(string nomeDaCategoria, string nomeDaSubCategoria, string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                   contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                   && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.NomeDaSubCategoria == nomeDaSubCategoria
                    && cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaEMes(string nomeDaCategoria, string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaEMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaEAno(string nomeDaCategoria, int ano)
        {

            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaMesEAno(string nomeDaCategoria, string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                   contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                   .Select(cd => cd.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.NomeDaCategoria == nomeDaCategoria && cd.Mes == selecionarMes && cd.Ano == ano)
                    .Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorMes(string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                   contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorMesEAno(string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                   contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.Mes == selecionarMes && cd.Ano == ano).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses ConsultarPorAno(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();

                meses.Fevereiro =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();

                meses.Marco =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Março").Select(cd => cd.Valor).Sum();

                meses.Abril =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();

                meses.Maio =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();

                meses.Junho =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();

                meses.Julho =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();

                meses.Agosto =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();

                meses.Setembro =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();

                meses.Outubro =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();

                meses.Novembro =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();

                meses.Dezembro =
                    contexto.TDespesa.Where(cd => cd.Ano == ano && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();

                meses.TotalAno =
                    contexto.TDespesa.Where(cd => cd.Ano == ano).Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarPorEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }
    }
}
