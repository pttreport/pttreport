<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="otherProject.aspx.cs" Inherits="ptt_report.otherProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft14 {
            background: #0c7fd2;
        }

        input[type="text" i] {
            width: 100%;
        }
    </style>

    <div class="bar_qr">
        Customer Type :
                   
       

        <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" class="btn" OnClick="btnSaveVer_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export Report" class="btn" OnClick="btnExport_Click" />
        <asp:Button ID="btnHistory" runat="server" Text="History" class="btn" OnClick="btnHistory_Click" />

        <asp:HiddenField ID="hddop_id" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />

    </div>
    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <h3 class="barBlue">Other Project
        </h3>
        <asp:GridView ID="gvPigResult" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            ShowFooter="false" >
            <Columns>

                <asp:TemplateField HeaderText="Other Project">
                    <ItemTemplate>
                        <asp:HiddenField ID="hddother_sub_id" runat="server" Value='<%# Eval("id") %>' />
                        <asp:HiddenField ID="hddotherorderNumber" runat="server" Value='<%# Eval("ordernumber") %>' />

                        <div id="divOther1" runat="server" visible="true">
                            <div class="info_executive">
                                <div class="info_executive_in">
                                    <table>
                                        <tr>
                                            <td colspan="2">Other Project</td>
                                        </tr>
                                        <tr>
                                            <td>ชื่อโครงการ :</td>
                                            <td>
                                                <asp:HiddenField ID="op1" runat="server" />
                                                <asp:TextBox ID="txtProjectName1" runat="server"  Text='<%# Eval("projectname") %>' ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>แผนงาน :</td>
                                            <td>
                                                <asp:TextBox ID="txtProjectPlan1" runat="server"  Text='<%# Eval("planwork") %>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ผลการดำเนินงาน :</td>
                                            <td>
                                                <asp:TextBox ID="txtProjectResult1" runat="server"  Text='<%# Eval("workresult") %>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>การดำเนินงานในอนาคต :</td>
                                            <td>
                                                <asp:TextBox ID="txtProjectPlan_future1" runat="server" Text='<%# Eval("futureplan") %>' ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ปัญหาอุปสรรค (ถ้ามี) :</td>
                                            <td>
                                                <asp:TextBox ID="txtProject_problem1" runat="server"  Text='<%# Eval("problem") %>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ความเห็น :</td>
                                            <td>
                                                <asp:TextBox ID="txtremark1" runat="server"  Text='<%# Eval("opinion") %>'></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="btnsave1" runat="server" Text="Save" OnClick="btnsave1_Click" />
                                                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



        <asp:Button ID="btnAddOtherPro" runat="server" Text="Add Other Project" OnClick="btnAddOtherPro_Click" />
         <asp:Button ID="btnApprove" runat="server" Text="Approve Report" OnClick="btnApprove_Click" CssClass="btn" />
    </div>

</asp:Content>
