namespace GerenciarDados.Listas
{
    public class ListaDeTipos
    {
        public static List<string> ListaDeTiposDePoupanca()
        {
            var listaDetipos = new List<string>()
            {
                "Crédito",
                "Despesa",
                "Débito",
                "Receita",               
                "Saldo Anterior"

            };
            return listaDetipos;
        }

        public static List<string> ListaDeTiposDeInvestimento()
        {
            var listaDetipos = new List<string>()
            {
               "Crédito",
               "Débito",
               "Saldo Anterior",
               "Saldo Inicial"
            };
            return listaDetipos;
        }

        public static List<string> ListaDeTiposDeReceita()
        {
            var listaDetipos = new List<string>()
            {
                "Crédito",
                "Receita",
                "Carteira",
                "Saldo Anterior"
            };
            return listaDetipos;
        }
    }
}
