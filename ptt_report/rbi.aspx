<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="rbi.aspx.cs" Inherits="ptt_report.rbi" %>

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
            <td>ตรวจสภาพท่อ และถังความดันบนแท่น
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>แผนงาน :</td>
                        <td>
                            <asp:TextBox ID="txtplanwork" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ผลการดำเนินงาน :</td>
                        <td>
                            <asp:TextBox ID="txtplanresult" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>การดำเนินงานในอนาคต :</td>
                        <td>
                            <asp:TextBox ID="txtfuturePlan" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                        <td>
                            <asp:TextBox ID="txtproblem" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ความเห็น :</td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>งานซ่อมคืนสภาพท่อ และถังความดันบนแท่น
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>แผนงาน :</td>
                        <td>
                            <asp:TextBox ID="txtplanwork2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ผลการดำเนินงาน :</td>
                        <td>
                            <asp:TextBox ID="txtplanresult2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>การดำเนินงานในอนาคต :</td>
                        <td>
                            <asp:TextBox ID="txtfuturePlan2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                        <td>
                            <asp:TextBox ID="txtproblem2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ความเห็น :</td>
                        <td>
                            <asp:TextBox ID="txtRemark2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnsave2" runat="server" Text="Save" OnClick="btnsave2_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
