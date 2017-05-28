<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reptmp.aspx.cs" Inherits="ptt_report.reptmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="ddlRepType" runat="server"></asp:DropDownList>
        <asp:Button ID="btnAddTmp" runat="server" Text="Add Template" OnClick="btnAddTmp_Click" />
    </div>
</asp:Content>