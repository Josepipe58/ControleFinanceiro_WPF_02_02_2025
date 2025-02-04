using AppFinanceiroEF.Telas.MenuIniciar;
using System.Windows;

namespace AppFinanceiroEF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new TelaPrincipal();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
