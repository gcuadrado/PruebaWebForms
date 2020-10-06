<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2">
            <h2>Cantidad</h2>
            <asp:TextBox ID="txtCantidad" Text="" runat="server" />
            <asp:RegularExpressionValidator ID="validadorCantidad" ControlToValidate="txtCantidad" runat="server"
      ErrorMessage="*La cantidad debe ser un número entero" Display="Dynamic" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
        </div>
        <div class="col-md-2">
            <h2>Precio</h2>
            <asp:TextBox ID="txtPrecio" Text="" runat="server" />
            <asp:RegularExpressionValidator ID="validadorPrecio" ControlToValidate="txtPrecio" runat="server"
      ErrorMessage="*El precio debe ser un número decimal" Display="Dynamic" ValidationExpression="[0-9]*[\.,\,]?[0-9]*"></asp:RegularExpressionValidator>
        </div>
        <div class="col-md-3">
            <h2>Producto</h2>
            <asp:TextBox ID="txtProducto" Text="Producto" runat="server" />
        </div>
        <div class="col-md-3">
            <h2>Tipo de producto</h2>
            <asp:DropDownList ID="seleccionProducto" OnSelectedIndexChanged="seleccionProducto_SelectedIndexChanged"
                AutoPostBack="true"
                runat="server">

                <asp:ListItem Selected="True" Value="favoritos"> Favoritos </asp:ListItem>
                <asp:ListItem Value="carrito"> Carrito </asp:ListItem>

            </asp:DropDownList>
        </div>
        <div class="col-md-2" style="margin-top: 50px">
            <asp:Button ID="btnAgregarProducto"
                Text="Agregar Producto"
                OnClick="btnAgregarProducto_Click"
                runat="server" />
        </div>
    </div>
    <div class="row mt-5" style="margin-top: 50px">
        <div class="col-md-6">
            <asp:ListView ID="listProductos" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("cantidad")%></td>
                        <td><%# Eval("descripcion")%></td>
                        <td><%# Eval("precioUnitario")%></td>
                        <td><%# Eval("subtotal")%></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <div class="table-responsive">
                    <table id="tbl1" border="1" runat="server" class="table">
                        <tr id="tr1" runat="server">
                            <td id="td1" runat="server">Cantidad</td>
                            <td id="td2" runat="server">Producto</td>
                            <td id="td3" runat="server">Precio Unitario</td>
                            <td id="td4" runat="server">Subtotal</td>
                        </tr>
                        <tr id="ItemPlaceholder" runat="server">
                        </tr>
                    </table>
                        </div>
                </LayoutTemplate>
            </asp:ListView>
            <h2 id="totalCarrito" runat="server"></h2>
        </div>
        <div class="col-md-6">
            <asp:ListView ID="listFavoritos" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("descripcion")%></td>
                        <td><%# Eval("precioUnitario")%></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <div class="table-responsive">
                    <table id="tbl1" border="1" runat="server" class="table">
                        <tr id="tr1" runat="server">
                            <td id="td2" runat="server">Producto</td>
                            <td id="td3" runat="server">Precio Unitario</td>
                        </tr>
                        <tr id="ItemPlaceholder" runat="server">
                        </tr>
                    </table>
                        </div>
                </LayoutTemplate>
            </asp:ListView>
        </div>

    </div>

</asp:Content>
