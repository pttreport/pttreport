﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="otherProject.aspx.cs" Inherits="ptt_report.otherProject" %>

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
                <%--Multi other Project--%>
                <div id="divOther1" runat="server" visible="true">
                    <table>
                        <tr>
                            <td colspan="2">Other Project</td>
                        </tr>
                        <tr>
                            <td>ชื่อโครงการ :</td>
                            <td>
                                <asp:TextBox ID="txtProjectName1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectResult1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan_future1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                            <td>
                                <asp:TextBox ID="txtProject_problem1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox ID="txtremark1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnsave1" runat="server" Text="Save" OnClick="btnsave1_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div id="divOther2" runat="server" visible="false">
                    <table>
                        <tr>
                            <td colspan="2">Other Project</td>
                        </tr>
                        <tr>
                            <td>ชื่อโครงการ :</td>
                            <td>
                                <asp:TextBox ID="txtProjectName2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectResult2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan_future2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                            <td>
                                <asp:TextBox ID="txtProject_problem2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox ID="txtremark2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnsave2" runat="server" Text="Save" OnClick="btnsave2_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div id="divOther3" runat="server" visible="false">
                    <table>
                        <tr>
                            <td colspan="2">Other Project</td>
                        </tr>
                        <tr>
                            <td>ชื่อโครงการ :</td>
                            <td>
                                <asp:TextBox ID="txtProjectName3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectResult3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan_future3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                            <td>
                                <asp:TextBox ID="txtProject_problem3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox ID="txtremark3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnsave3" runat="server" Text="Save" OnClick="btnsave3_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div id="divOther4" runat="server" visible="false">
                    <table>
                        <tr>
                            <td colspan="2">Other Project</td>
                        </tr>
                        <tr>
                            <td>ชื่อโครงการ :</td>
                            <td>
                                <asp:TextBox ID="txtProjectName4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectResult4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan_future4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                            <td>
                                <asp:TextBox ID="txtProject_problem4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox ID="txtremark4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnsave4" runat="server" Text="Save" OnClick="btnsave4_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div id="divOther5" runat="server" visible="false">
                    <table>
                        <tr>
                            <td colspan="2">Other Project</td>
                        </tr>
                        <tr>
                            <td>ชื่อโครงการ :</td>
                            <td>
                                <asp:TextBox ID="txtProjectName5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน :</td>
                            <td>
                                <asp:TextBox ID="txtProjectResult5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต :</td>
                            <td>
                                <asp:TextBox ID="txtProjectPlan_future5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                            <td>
                                <asp:TextBox ID="txtProject_problem5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox ID="txtremark5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnsave5" runat="server" Text="Save" OnClick="btnsave5_Click" /></td>
                        </tr>
                    </table>
                </div>
                <asp:Button ID="btnAddOtherPro" runat="server" Text="Add Other Project" OnClick="btnAddOtherPro_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" />
            </td>
        </tr>

    </table>
</asp:Content>
