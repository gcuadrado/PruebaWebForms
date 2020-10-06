using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaWebForms.Modelo
{
    public class ProductoFavorito
    {
        public double precioUnitario { get; }
        public string descripcion { get; }

        public ProductoFavorito( double precioUnitario, string descripcion)
        {
            this.precioUnitario = precioUnitario;
            this.descripcion = descripcion;
        }

       
    }
}