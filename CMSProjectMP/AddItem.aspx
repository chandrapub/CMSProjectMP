<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="CMSProjectMP.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Add new Item</h3>
    <table cellspacing="15" class="itemTable">
        <%--<tr>
            <td style="width: 80px">
                <b>ItemID:</b>
            </td>
            <td>
                <asp:TextBox ID="txtItemId" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td style="width: 80px">
                <b>Item Name:</b>
            </td>
            <td>
                <asp:TextBox ID="txtItemName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Category Name:</b>
            </td>
            <td>
                <asp:TextBox ID="txtCategoryName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Price:</b>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Image:</b>
            </td>
            <td>
                <asp:TextBox ID="txtImage" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Discription:</b>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Width="300px"></asp:TextBox>
            </td>
            </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server" /> 
                <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" 
                    onclick="btnUploadImage_Click" CausesValidation="False" /> 
            </td>
            
        </tr>
        <tr>
            <td style="width: 80px">
                <b>SelectionID:</b>
            </td>
            <td>
                <asp:TextBox ID="txtSelectionId" runat="server" Width="330px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
