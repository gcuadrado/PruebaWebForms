using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaWebForms.Modelo
{
    public class ProductoCarrito
    {
        public int cantidad { get; set; }
        public double precioUnitario { get; }
        public double subtotal { get; set; }
        public string descripcion { get; }
        

        public ProductoCarrito(int cantidad, double precioUnitario, string descripcion)
        {
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            this.descripcion = descripcion;
            this.subtotal = cantidad * precioUnitario;
        }

        public void addUnidad()
        {
            this.cantidad++;
            this.subtotal = cantidad * precioUnitario;
        }
    }
}