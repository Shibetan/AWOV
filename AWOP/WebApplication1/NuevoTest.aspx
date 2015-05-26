<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="NuevoTest.aspx.cs" Inherits="WebApplication1.NuevoTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Instrucciones:

    <br />
    A continuación se presenta una lista de actividades comunes sobre las cuales puedes haber tenido ya alguna experiencia personal.
A medida que leas cada cuestión, piensa: ¿QUÉ TANTO ME AGRADA HACER ESTO?
Luego, selecciona un número de respuesta según se indica enseguida.
Si lo que expresa la cuestión te desagrada mucho, anota el número 1; en el caso que te desagrade un poco, anota el número 2; cuando te sea indiferente, anota el número 3; si te agrada algo, esto es, sólo en parte, escribe el número 4, y por último si lo que expresa la cuestión te agrada bastante, escribe el número 5.<br />
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/preferencias.png" />
    <br />
    <br />
    Antes de escribir cada número, procura recordar o imaginar en qué consiste la respectiva actividad. Es necesario que seas lo más sincero al contestar. Procura no equivocarte de cuadro, ni saltar ninguno de ellos; observa que se contesta de izquierda a derecha; cada cuadro tiene un número para indicar que ahí debe anotarse la respuesta a la cuestión del mismo número.<br />
    <br />
    <asp:Button ID="btnComenzar" runat="server" Text="Comenzar" OnClick="btnComenzar_Click" />
&nbsp;
</asp:Content>
