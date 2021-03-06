﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="CleaningPIG.aspx.cs" Inherits="ptt_report.CleaningPIG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft08 {
            background: #0c7fd2;
        }
    </style>
    <div class="bar_qr">
        Customer Type :
                   
       

        <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" class="btn" OnClick="btnSaveVer_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export Report" class="btn" OnClick="btnExport_Click" />
        <asp:Button ID="btnHistory" runat="server" Text="History" class="btn" OnClick="btnHistory_Click" />

        <asp:HiddenField ID="hddcp_id" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />

    </div>

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <h3 class="barBlue">Cleaning PIG
       
            <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" class="btn btn-info" />


        </h3>

        <div class="info_executive">
            <h3>
                <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click">Inaternal Corrosion</asp:LinkButton>
                > Cleaning PIG</h3>
            <div class="info_executive_in">

                <table>
                    <tr>
                        <td style="width: 165px;">แผนงาน :</td>
                        <td>
                            <asp:TextBox ID="txtworkplan" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <table class="table_da1">
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
                        <td style="vertical-align: top">ผลการดำเนินงาน :</td>
                        <td>
                            <asp:TextBox ID="txtResult_work" TextMode="MultiLine" runat="server" BackColor="#99ff99"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Pigging Result :</td>
                        <td>
                            <asp:Button ID="btnCreate" runat="server" Text="Create" class="btn btn-info" OnClick="btnCreate_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:GridView ID="gvPigResult" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                ShowFooter="false" PageSize="20">
                                <Columns>

                                    <asp:TemplateField HeaderText="Route Code">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hddpigresultid" runat="server" Value='<%# Eval("id") %>' />
                                            <asp:TextBox ID="txtGridRoute" runat="server" Text='<%# Eval("routecode") %>' BackColor="#99ff99"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Section - Length">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSelectLength" runat="server" Text='<%# Eval("sectionlength") %>' BackColor="#99ff99"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridStatus" runat="server" Text='<%# Eval("status") %>' TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Manage">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDEl1" runat="server" Text="Delete" OnClick="btnDEl1_Click" />
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
                            <table class="table_da1">
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
                            <asp:Button ID="btnCreate2" runat="server" Text="Create" class="btn btn-info" OnClick="btnCreate2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:GridView ID="gvReplan" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                ShowFooter="false" PageSize="20">
                                <Columns>

                                    <asp:TemplateField HeaderText="Route Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridRoute" Text='<%# Eval("routecode") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Re-Plan">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReplan" Text='<%# Eval("replan") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGridStatus" runat="server" Text='<%# Eval("detail") %>' TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Manage">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hddreplanid" runat="server" Value='<%# Eval("id") %>' />
                                            <asp:Button ID="btnDEl2" runat="server" Text="Delete" OnClick="btnDEl2_Click" />
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn" OnClick="btnSave_Click" />
                            <asp:Button ID="btnApprove" runat="server" Text="Approve Report" OnClick="btnApprove_Click" CssClass="btn" />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>
