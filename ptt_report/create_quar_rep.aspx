<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="create_quar_rep.aspx.cs" Inherits="ptt_report.create_quar_rep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>year : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlyear" runat="server"></asp:DropDownList>
                </td>
                <td>Quarter : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlquarter" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnselect" runat="server" Text="Select" OnClick="btnselect_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divRep_listfull" runat="server" visible="false">
        <asp:Label ID="lbno" runat="server" Text="-" ForeColor="Red"></asp:Label>
        <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
    </div>
    <div id="divRep_list" runat="server" visible="false">
        <table>
            <tr>
                <td>Customer Type:
                </td>
                <td>
                    <asp:Label ID="lbrep1" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="lbrep2" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="lbrep3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
