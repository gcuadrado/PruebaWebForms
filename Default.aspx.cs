using PruebaWebForms.Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaWebForms
{
    public partial class _Default : Page
    {
        private List<ProductoCarrito> carrito;
        private List<ProductoFavorito> favoritos;
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<ProductoCarrito>)Session["carrito"];
            favoritos = (List<ProductoFavorito>)Session["favoritos"];

            if (carrito == null)
            {
                carrito = new List<ProductoCarrito>();
                Session["carrito"] = carrito;

            }
            if (favoritos == null)
            {
                favoritos = new List<ProductoFavorito>();
                Session["favoritos"] = favoritos;
            }

            if (seleccionProducto.SelectedValue == "favoritos")
            {
                txtCantidad.Text = "";
                txtCantidad.Enabled = false;
            }
            double? total = (double?)Session["total"];
            if (total.HasValue)
            {
                totalCarrito.InnerText = "Total Carrito: " + total + "€";
            }

        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int? cantidad = int.TryParse(txtCantidad.Text, out int intOutParameter) ? intOutParameter : (int?)null;
            string precioText = txtPrecio.Text.Replace(",", ".");
            double? precioUnitario = double.TryParse(precioText, NumberStyles.Any,CultureInfo.InvariantCulture, out double precioOutParameter) ? precioOutParameter : (double?)null;
            string descripcion = txtProducto.Text;

            if (seleccionProducto.SelectedValue == "carrito")
            {
                if (cantidad.HasValue && precioUnitario.HasValue && descripcion != "")
                {
                    addProductoCarrito(cantidad, precioUnitario, descripcion);
                }

            }
            else if (seleccionProducto.SelectedValue == "favoritos")
            {
                if (precioUnitario.HasValue && descripcion != "")
                {
                    addProductoFavorito(precioUnitario, descripcion);
                }
            }

        }

        private void addProductoFavorito(double? precioUnitario, string descripcion)
        {
            var productoFavoritos = new ProductoFavorito(precioUnitario.Value, descripcion);
            this.favoritos.Add(productoFavoritos);
            listFavoritos.DataSource = this.favoritos;
            listFavoritos.DataBind();

            
        }

        private void addProductoCarrito(int? cantidad, double? precioUnitario, string descripcion)
        {
            var productoCarrito = new ProductoCarrito(cantidad.Value, precioUnitario.Value, descripcion);
            this.carrito.Add(productoCarrito);
            listProductos.DataSource = this.carrito;
            listProductos.DataBind();

            double total = this.carrito.Sum(c => c.subtotal);
            Session["total"] = total;
            totalCarrito.InnerText = "Total Carrito: " + total + "€";
        }

        protected void seleccionProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seleccionProducto.SelectedValue == "favoritos")
            {
                txtCantidad.Text = "";
                txtCantidad.Enabled = false;
            }
            else
            {
                txtCantidad.Enabled = true;
            }
        }
    }
}