namespace GerenciarDados.Listas
{
    public class ListaDeTipos
    {
        public static List<string> ListaDeTiposDeDespesa()
        {
            var listaDetipos = new List<string>()
            {
                "Despesa",
            };
            return listaDetipos;
        }

        public static List<string> ListaDeTiposDePoupanca()
        {
            var listaDetipos = new List<string>()
            {
                "Crédito",
                "Despesa",
                "Débito",
                "Receita",
                "Carteira",
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
    }
}
