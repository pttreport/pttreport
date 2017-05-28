<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="CleaningPIG.aspx.cs" Inherits="ptt_report.CleaningPIG" %>

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
                > Cleaning PIG
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>แผนงาน :</td>
                        <td>
                            <asp:TextBox ID="txtworkplan" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
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
                            <asp:TextBox ID="txtResult_work" runat="server" BackColor="#99ff99"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Pigging Result :</td>
                        <td>
                            <asp:Button ID="btnCreate" runat="server" Text="Create" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:GridView ID="GridView_rep_list" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                ShowFooter="false" PageSize="20">
                                <Columns>

                                    <asp:TemplateField HeaderText="Route Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridRoute" runat="server" BackColor="#99ff99"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Section - Length">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSelectLength" runat="server" BackColor="#99ff99"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridStatus" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Manage">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hddrepid" runat="server" Value='<%# Eval("id") %>' />
                                            <asp:Button ID="btnDEl" runat="server" Text="Delete" OnClick="btnDEl_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>หมายเหตุ :</td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
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
                        <td>Re-Plan :</td>
                        <td>
                            <asp:Button ID="btnCreate2" runat="server" Text="Create" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                ShowFooter="false" PageSize="20">
                                <Columns>

                                    <asp:TemplateField HeaderText="Route Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridRoute" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Re-Plan">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSelectLength" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridStatus" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Manage">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hddrepid" runat="server" Value='<%# Eval("id") %>' />
                                            <asp:Button ID="btnDEl" runat="server" Text="Delete" OnClick="btnDEl_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
