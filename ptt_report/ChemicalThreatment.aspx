<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="ChemicalThreatment.aspx.cs" Inherits="ptt_report.ChemicalThreatment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft10 {
            background: #0c7fd2;
        }
        #ContentPlaceHolder1_ChildContent2_txtdetail,
        #ContentPlaceHolder1_ChildContent2_txtComment {
            width:100%;
        }
    </style>
    <div class="bar_qr">
        Customer Type :
                   
        <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" class="btn" OnClick="btnSaveVer_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export Report" class="btn" OnClick="btnExport_Click" />
        <asp:Button ID="btnHistory" runat="server" Text="History" class="btn" OnClick="btnHistory_Click" />

        <asp:HiddenField ID="hddct_id" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />
        
    </div>
    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <h3 class="barBlue">Chemical Treatment


        </h3>

        <div class="info_executive">
            <h3>
                <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click">Inaternal Corrosion</asp:LinkButton>
                > Chemical Treatment</h3>
            <div class="info_executive_in">

                <table>
                    <tr>
                        <td>Detail :</td>
                        <td>
                            <asp:TextBox ID="txtdetail" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ความเห็น :</td>
                        <td>
                            <asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn" OnClick="btnSave_Click" />
                            <asp:Button ID="btnApprove" runat="server" Text="Approve Report" OnClick="btnApprove_Click" CssClass="btn" />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
