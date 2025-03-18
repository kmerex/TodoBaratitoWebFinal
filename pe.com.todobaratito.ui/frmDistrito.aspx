﻿<%@ Page Title="" Language="C#" MasterPageFile="~/plantillas/Site1.Master" AutoEventWireup="true" CodeBehind="frmDistrito.aspx.cs" Inherits="pe.com.todobaratito.ui.frmDistrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%--inicio de la tarjeta--%>
 <div class="card">
     <div class="card-header text-center">
         <asp:Label ID="Label1" runat="server" Text="MANTENIMIENTO DISTRITO" CssClass="fs-3 fw-bold"></asp:Label>
     </div>
     <div class="card-body">
         <div class="col-3">
             <asp:Label ID="Label2" runat="server" Text="Codigo:" CssClass="form-label"></asp:Label>
             <asp:TextBox ID="txtCod" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <div class="col-5">
             <asp:Label ID="Label3" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
             <asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <div class="col-3">
             <asp:Label ID="Label4" runat="server" Text="Estado:" CssClass="form-label"></asp:Label>
             <div class="mb-3">
                 <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" Text="Habilitado" />
             </div>
         </div>

         <div class="table-responsive">
    <asp:GridView ID="gvDistrito" runat="server" OnRowCommand="gvDistrito_RowCommand"
        AutoGenerateColumns="false" OnPageIndexChanging="gvDistrito_PageIndexChanging"
        CssClass="table table-striped table-hover table-bordered"
        HeaderStyle-CssClass="table-dark" AllowPaging="true" PageSize="10"
        PagerSettings-Visible="false">
        <%--crear columnas--%>
        <Columns>
            <asp:BoundField DataField="codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <%--estado trabaja con TemplateField--%>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado":"Deshabilitado" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" />
        </Columns>
    </asp:GridView>
              <%-- Paginación personalizada con Bootstrap --%>
             <div class="pagination-container">
                 <div class="d-flex justify-content-center mt-3">
                     <!-- Botón Anterior -->
                     <asp:Button ID="btnPrevious" runat="server" Text="Anterior" CssClass="btn btn-outline-secondary mx-1" OnClick="btnPrevious_Click" />

                     <!-- Números de página -->
                     <asp:Repeater ID="rptPager" runat="server">
                         <ItemTemplate>
                             <asp:LinkButton runat="server" CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                 CssClass='<%# Convert.ToInt32(Container.DataItem.ToString()) == gvDistrito.PageIndex + 1 ? "btn btn-outline-primary active mx-1" : "btn btn-outline-primary mx-1" %>'>
                     <%# Container.DataItem %>
                             </asp:LinkButton>
                         </ItemTemplate>
                     </asp:Repeater>

                     <!-- Botón Siguiente -->
                     <asp:Button ID="btnNext" runat="server" Text="Siguiente" CssClass="btn btn-outline-secondary mx-1" OnClick="btnNext_Click" />
                 </div>
             </div>
       </div>
     </div>    
     <div class="card-footer text-body-secondary text-center">


        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" CssClass="btn btn-dark" />
         <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn btn-primary" />
         <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" />
         <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
         <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
     </div>
 </div>
 <%--fin de la tarjeta--%>
</asp:Content>
