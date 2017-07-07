<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.Master" AutoEventWireup="true" CodeBehind="soilerosion.aspx.cs" Inherits="ptt_report.soilerosion" %>



<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft04 {
            background: #0c7fd2;
        }
    </style>
    <div class="bar_qr">
        Customer Type :
                   
                    <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" CssClass="btn" OnClick="btnSaveVer_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export Report" CssClass="btn" OnClick="btnExport_Click" />
        <asp:Button ID="btnHistory" runat="server" Text="History" CssClass="btn" OnClick="btnHistory_Click" />

        <asp:HiddenField ID="hddsoil_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />

    </div>


    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            <h3 class="barBlue">Soil Erosion
                 <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" CssClass="btn btn-info" Visible="false" /></h3>
            <div class="info_executive">
                <h3>3rd party Interface > Soil Erosion</h3>
                <div class="info_executive_in">

                    <table>
                        <tr>
                            <td style="width: 165px;">รายละเอียดงาน : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtd1" TextMode="MultiLine" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน: </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtd2" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>แผนงาน: </td>
                            <td class="auto-style1">

                                <table class="table_da1">

                                    <tr>
                                        <td>
                                            <asp:Button ID="SEWorkPlanAddNewPlan" runat="server" Text="Create" CssClass="btn btn-info" OnClick="SEWorkPlanAddNewPlan_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView Width="100%" DataKeyNames="id" AutoGenerateColumns="false" utoGenerateColumns="false"
                                                runat="server" ID="gv" ShowFooter="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="เขต">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hddid" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:TextBox ID="txtd3" runat="server" Text='<%# Eval("d3") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="เส้นท่อ,ตำแหน่ง">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtd4" runat="server" Text='<%# Eval("d4") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ขุดซ่อมเนื่องจาก">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtd5" runat="server" Text='<%# Eval("d5") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Length(m)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtd6" runat="server" Text='<%# Eval("d6") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="% Actual">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtd7" runat="server" Text='<%# Eval("d7") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Plan/Status">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtd8" runat="server" Text='<%# Eval("d8") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Manage">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btndal" runat="server" Text="Delete" OnClick="btndal_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtd9" TextMode="MultiLine" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtd10" TextMode="MultiLine" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtd11" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtd12" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="auto-style1">
                                <asp:Button ID="SEFormSaveSubmit" runat="server" Text="Save" OnClick="SEFormSaveSubmit_Click" CssClass="btn" />
                                <asp:Button ID="btnApprove" runat="server" Text="Approve Report" OnClick="btnApprove_Click" CssClass="btn" />

                            </td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
