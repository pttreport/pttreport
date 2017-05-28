<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="ChemicalThreatment.aspx.cs" Inherits="ptt_report.ChemicalThreatment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <table>
        <tr>
            <td>
                <div>
                    Customer Type :
                    <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
                    <asp:Button ID="btnExport" runat="server" Text="Export Report" />
                    <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" />
                    <asp:Button ID="btnHistory" runat="server" Text="History" />
                    <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click">Inaternal Corrosion</asp:LinkButton>
                > Chemical Treatment
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>Detail :</td>
                        <td>
                            <asp:TextBox ID="txtdetail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ความเห็น :</td>
                        <td>
                            <asp:TextBox ID="txtComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
