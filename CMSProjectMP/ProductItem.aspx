<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite1.Master" AutoEventWireup="true" CodeBehind="ProductItem.aspx.cs" Inherits="CMSProjectMP.ProductItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Select a type:
    <asp:DropDownList ID="DropDownList1" runat="server" 
                      DataSourceID="sds_type" DataTextField="type" 
                      DataValueField="type" AutoPostBack="True" 
                      OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
        <asp:SqlDataSource ID="sds_type" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SportsShopDBConnectionString %>" 
            SelectCommand="SELECT [type] FROM [Item] ORDER BY [type]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
    </p>
    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
</asp:Content>

