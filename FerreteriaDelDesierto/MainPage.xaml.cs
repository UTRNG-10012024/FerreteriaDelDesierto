using FerreteriaDelDesierto.MVVM.ViewModels;

namespace FerreteriaDelDesierto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(); // Vincula el contexto de datos
        }
    }
}
