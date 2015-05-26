<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Recuerde:</p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/preferencias.png" />
    </p>

    <%
        int i = 0;
        if (dtActividades != null) { 
            foreach (System.Data.DataRow row in dtActividades.Rows)
            {
                i++;
    %>

        <div class="Actividad"> <% = row["numeroPregunta"].ToString() +" "+ row["descripcion"].ToString() %>
        <asp:DropDownList runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
        </div>
   
    <% }
        }%>
    <asp:Button ID="btnVerResultados" runat="server" Text="Ver mis resultados" OnClick="Button1_Click" />
</asp:Content>
