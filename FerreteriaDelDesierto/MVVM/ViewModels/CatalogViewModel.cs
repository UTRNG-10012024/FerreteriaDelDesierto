using FerreteriaDelDesierto.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaDelDesierto.MVVM.ViewModels
{
    public class CatalogViewModel
    {
        public ObservableCollection<ProductModel> Products { get; set; }

        public CatalogViewModel()
        {
            Products = new ObservableCollection<ProductModel>
            {
                new ProductModel { Id = 1, Name = "Martillo", Description = "Martillo de acero", Price = 120, ImageUrl = "martillo.png" },
                new ProductModel { Id = 2, Name = "Destornillador", Description = "Destornillador plano", Price = 50, ImageUrl = "desarmador.png" },
                new ProductModel { Id = 3, Name = "Taladro", Description = "Taladro inalámbrico", Price = 950, ImageUrl = "descarga.png" }
            };
        }
    }
}