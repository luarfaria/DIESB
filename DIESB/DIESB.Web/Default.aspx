<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DIESB.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        DIESB - Dados sobre ensino superior do Brasil
    </h2>
    <label>Estado:</label>
    <br />
    <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_Click"></asp:DropDownList>
    <br />
    Curso de nível superior: <asp:TextBox ID="txtCurso" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" />
</asp:Content>