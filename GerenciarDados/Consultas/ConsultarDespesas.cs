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
                using (var context = new Contexto())
                {
                    List<Despesa> listaDeDespesa = [];
                    var listaCombinada = context.TDespesa.Select(d => new
                    {
                        d.Id, d.NomeDaCategoria, d.NomeDaSubCategoria, d.Valor, d.Tipo, d.Data, d.Mes, d.Ano

                    }).Union(context.TPoupanca.Select(p => new
                    {
                        p.Id, p.NomeDaCategoria, p.NomeDaSubCategoria, p.Valor, p.Tipo, p.Data, p.Mes, p.Ano

                    })).Where(p => p.Tipo == "Despesa")
                        .ToList();
                    foreach (var item in listaCombinada)
                    {
                        Despesa despesa = new()
                        {
                            Id = item.Id,
                            NomeDaCategoria = item.NomeDaCategoria,
                            NomeDaSubCategoria = item.NomeDaSubCategoria,
                            Valor = item.Valor,
                            Tipo = item.Tipo,
                            Data = item.Data,
                            Mes = item.Mes,
                            Ano = item.Ano,
                        };
                        listaDeDespesa.Add(despesa);
                    }
                    return [.. listaDeDespesa];
                }
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterListaDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarDespesasGeraisDeTodosOsAnos()
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarDespesasGeraisDeTodosOsAnos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoria(string nomeDaCategoria)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaESubCategoria(string nomeDaCategoria, string nomeDaSubCategoria)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria 
                    && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Mairo").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria)
                    .Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaESubCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaEMes(string nomeDaCategoria, string nomeDaSubCategoria, string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                              contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                              && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                              contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                              && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaEMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaEAno(string nomeDaCategoria, string nomeDaSubCategoria, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaSubCategoriaMesEAno(string nomeDaCategoria, string nomeDaSubCategoria, string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                            && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                            && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.NomeDaSubCategoria == nomeDaSubCategoria
                    && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.NomeDaSubCategoria == nomeDaSubCategoria
                    && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaSubCategoriaMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaEMes(string nomeDaCategoria, string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaEMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaEAno(string nomeDaCategoria, int ano)
        {

            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorCategoriaMesEAno(string nomeDaCategoria, string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                            .Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.NomeDaCategoria == nomeDaCategoria && d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.NomeDaCategoria == nomeDaCategoria && p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano)
                    .Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorCategoriaMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorMes(string selecionarMes)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                            contexto.TDespesa.Where(d => d.Mes == selecionarMes).Select(d => d.Valor).Sum() +
                            contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorMes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorMesEAno(string selecionarMes, int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                switch (selecionarMes)
                {
                    case "Janeiro":
                        meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Fevereiro":
                        meses.Fevereiro =
                   contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Março":
                        meses.Marco =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Abril":
                        meses.Abril =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Maio":
                        meses.Maio =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Junho":
                        meses.Junho =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Julho":
                        meses.Julho =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Agôsto":
                        meses.Agosto =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Setembro":
                        meses.Setembro =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Outubro":
                        meses.Outubro =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Novembro":
                        meses.Novembro =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    case "Dezembro":
                        meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();
                        break;

                    default:
                        break;
                }
                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Mes == selecionarMes && d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == selecionarMes && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses ConsultarPorAno(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();

                meses.Janeiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Janeiro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Fevereiro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Fevereiro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Marco =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Março" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Abril =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Abril" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Maio =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Maio" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Junho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Junho" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Julho =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Julho" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Agosto =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Agôsto" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Setembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Setembro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Outubro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Outubro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Novembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Novembro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.Dezembro =
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Mes == "Dezembro" && p.Ano == ano).Select(p => p.Valor).Sum();

                meses.TotalAno =
                    contexto.TDespesa.Where(d => d.Ano == ano).Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Tipo == "Despesa" && p.Ano == ano).Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
