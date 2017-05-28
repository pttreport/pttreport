<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="ilipig.aspx.cs" Inherits="ptt_report.ilipig" %>

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
                > ILI PIG
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>แผนงาน :</td>
                        <td>
                            <table>
                                <tr>
                                    <td>Routecode</td>
                                    <td>Dimeter</td>
                                    <td>Pipeline Section</td>
                                    <td>Number of pig</td>
                                    <td>Planning</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtRoutecode" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDimeter" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPipeline" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNumberOfPig" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPlanning" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>ผลการดำเนินงาน :</td>
                        <td>
                            <table>
                                <tr>
                                    <td>Routecode</td>
                                    <td>Pipeline Section</td>
                                    <td>Result</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtRoutecode2" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPipelineSection2" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtResult2" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>การดำเนินงานในอนาคต :</td>
                        <td>
                            <table>
                                <tr>
                                    <td>Routecode</td>
                                    <td>Dimeter</td>
                                    <td>Pipeline Section</td>
                                    <td>Number of pig</td>
                                    <td>Planning</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtF_Routecode" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtF_Dimeter" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtF_Pipeline" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtF_NumberOfPig" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtF_Planning" runat="server" BackColor="#99ff99"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>ปัญหาอุปสรรค (ถ้ามี)  :</td>
                        <td>
                            <asp:TextBox ID="txtProblem" runat="server" BackColor="#99ff99"></asp:TextBox>
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
