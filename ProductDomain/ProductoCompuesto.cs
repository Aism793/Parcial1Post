using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoDomain
{
    public class ProductoCompuesto
    {
        
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public string Categoria { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Utilidad { get; private set; }
        public int Cantidad { get; protected set; }

        public ProductoCompuesto(string id, string nombre, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;

        }

        public string Vender(int cantidadProducto, decimal precio, List<ProductoSimple> productoSimples, string nombre, List<int> cantidadesDisminuir)
        {
            if (cantidadProducto < 0)
            {
                return "La cantidad a vender es incorrecta";
            }
            if (cantidadProducto > 0)
            {
                decimal total = 0;
                foreach (ProductoSimple p in ProductoSimple.Productos)
                {
                    if(Nombre.Equals("Perro sencillo"))
                    {
                        for ( int i = 0; i < productoSimples.Count(); i++)
                        {
                            if (productoSimples[i].Nombre.Equals(p.Nombre))
                            {
                                ProductoSimple.Disminuir(productoSimples[i].Nombre, cantidadesDisminuir[i]);
                                total = total + productoSimples[i].Costo;
                            }
                            
                        }
                        
                    }


                }
                return $"El costo total es {total * cantidadProducto} pesos";
            }
            throw new NotImplementedException();
        }
    }
}
