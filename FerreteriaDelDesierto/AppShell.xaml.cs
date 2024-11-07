using FerreteriaDelDesierto.MVVM.Views;

namespace FerreteriaDelDesierto
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("CatalogPage", typeof(CatalogPage));
        }

    }
}
