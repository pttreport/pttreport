<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage2.Master" AutoEventWireup="true" CodeBehind="permitappendixB.aspx.cs" Inherits="ptt_report.permitappendixB" %>



<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft07 {
            background: #0c7fd2;
        }

        .auto-style1 {
            height: 20px;
        }
        .info_executive_in input[type="submit"] {
            float:none;
        }
    </style>

    <table>
        <tr>
            <td></td>
        </tr>
    </table>

    <div class="bar_qr">
        Year: 2559  Permit: กท2310027
                   
       

        <asp:label id="lbCustype" runat="server" text="-"></asp:label>
        <asp:button id="btnSaveVer" runat="server" text="Save Version" class="btn" />
        <asp:button id="btnExport" runat="server" text="Export Report" class="btn" />
        <asp:button id="Button1" runat="server" text="History" class="btn" />

    </div>

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            <h3 class="barBlue">ภาคผนวก ข.
                
                <asp:button id="btnImport" runat="server" text="Import Data" onclick="btnImport_Click" class="btn btn-info" />

            </h3>
            <div class="info_executive">
                <h3>ผลการลาดตระเวนตรวจแนวท่อส่งก๊าซธรรมชาติ</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td class="auto-style1" style="text-align: right;" colspan="2">
                                <asp:button id="Button3" runat="server" text="Create" class="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1" colspan="2">
                                <table class="col6">
                                    <tr>
                                        <td>Route Code :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBRouteCode" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>
                                        <td>งานก่อสร้าง :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBBuildingWork" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>กัดเซาะ :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBScour" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>

                                        <td>ป้ายหาย / ติดตั้งใหม่ :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBLabel" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>Test Post หาย / ชำรุด :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBTestPost" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>
                                        <td>รุกล้ำ :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBTrespass" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>การรั่วไหลของก๊าซ :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBReflux" runat="server" backcolor="#99FF99"></asp:textbox>
                                        </td>
                                        <td>ผลรวมสิ่งผิดปกติ :</td>
                                        <td>
                                            <asp:textbox id="PermitAppendixBAbnormal" runat="server" backcolor="#CCCCCC"></asp:textbox>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td colspan="4" style="text-align:right">
                                            <asp:button id="Button2" runat="server" text="Delete" class="btn btn-danger" />
                                        </td>
                                    </tr>

                                </table>



                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">

                                <asp:textbox id="PermitCerfNumber" runat="server" columns="60"></asp:textbox>

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div>
                <asp:button id="PermitFormSaveSubmit" runat="server" text="Save" class="btn" onclick="PermitFormSaveSubmit_Click" />
            </div>

        </div>
    </div>

</asp:Content>
