using FerreteriaDelDesierto.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace FerreteriaDelDesierto.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        private ObservableCollection<Producto> _productos;
        private ObservableCollection<Producto> _productosFiltrados;
        private ObservableCollection<Producto> _productosEnCarrito;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AgregarAlCarritoCommand { get; private set; }
        public ICommand HelpCommand { get; private set; }
        public MainViewModel()
        {
            
            Productos = new ObservableCollection<Producto>
            {
                new Producto { Id = "1", Nombre = "Martillo", Precio = 10, Imagen = "martillo.png", Categoria = "Herramientas" },
                new Producto { Id = "2", Nombre = "Taladro", Precio = 50, Imagen = "descarga.png", Categoria = "Herramientas" },
                new Producto { Id = "3", Nombre = "Destornillador", Precio = 50, Imagen = "desarmador.png", Categoria = "Herramientas" },
               
            };

            ProductosFiltrados = new ObservableCollection<Producto>(Productos);
            ProductosEnCarrito = new ObservableCollection<Producto>();
            AgregarAlCarritoCommand = new Command<Producto>(OnAgregarAlCarrito);
            HelpCommand = new Command(OnHelp);
        }

        public ObservableCollection<Producto> Productos
        {
            get => _productos;
            set
            {
                _productos = value;
                OnPropertyChanged(nameof(Productos));
            }
        }
        public async void OnHelp()
        {
            var url = "https://docs.microsoft.com/en-us/dotnet/maui/";
            await Launcher.OpenAsync(url); // Abre la URL en el navegador
        }


        public ObservableCollection<Producto> ProductosFiltrados
        {
            get => _productosFiltrados;
            set
            {
                _productosFiltrados = value;
                OnPropertyChanged(nameof(ProductosFiltrados));
            }
        }

        public ObservableCollection<Producto> ProductosEnCarrito
        {
            get => _productosEnCarrito;
            set
            {
                _productosEnCarrito = value;
                OnPropertyChanged(nameof(ProductosEnCarrito));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FiltrarProductos();
            }
        }

        private void FiltrarProductos()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                ProductosFiltrados = new ObservableCollection<Producto>(Productos);
            }
            else
            {
                var resultados = Productos.Where(p => p.Nombre.ToLower().Contains(SearchText.ToLower()));
                ProductosFiltrados = new ObservableCollection<Producto>(resultados);
            }
        }

        private void OnAgregarAlCarrito(Producto producto)
        {
            if (producto != null)
            {
                ProductosEnCarrito.Add(producto);
                System.Diagnostics.Debug.WriteLine($"Producto agregado al carrito: {producto.Nombre}"); // Mensaje de depuración
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
