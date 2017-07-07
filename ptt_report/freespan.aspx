<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.Master" AutoEventWireup="true" CodeBehind="freespan.aspx.cs" Inherits="ptt_report.freespan" %>



<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft07 {
            background: #0c7fd2;
        }
    </style>


    <div class="bar_qr">
        Customer Type :
        <asp:label id="lbCustype" runat="server" text="-"></asp:label>
        <asp:button id="btnSaveVer" runat="server" text="Save Version" class="btn" OnClick="btnSaveVer_Click" />
        <asp:button id="btnExport" runat="server" text="Export Report" class="btn" OnClick="btnExport_Click" />
        <asp:button id="btnHistory" runat="server" text="History" class="btn" />

        <asp:HiddenField ID="hddfreespan_id" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />

    </div>

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            <h3 class="barBlue">Free Span
                 
 
            </h3>
            <div class="info_executive">
                <h3>3rd party Interface > Free Span</h3>
                <div class="info_executive_in">
            <table>

                <tr>
                    <td>แผนงาน: </td>
                    <td class="auto-style1">

                        <asp:TextBox cols="20" TextMode="MultiLine" rows="2" runat="server" id="FSWorkPlanBox"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>ผลการดำเนินงาน : </td>
                    <td class="auto-style1">

                        <asp:TextBox cols="20" TextMode="MultiLine" rows="2" runat="server" id="FSResultBox"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>การดำเนินงานในอนาคต : </td>
                    <td class="auto-style1">

                        <asp:TextBox cols="20" TextMode="MultiLine" rows="2" runat="server" id="FSFuturePlanBox"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1">
                        <asp:TextBox cols="20" TextMode="MultiLine" rows="2" runat="server" id="FSProblemBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1">
                        <asp:TextBox cols="20" TextMode="MultiLine" rows="2" runat="server" id="FSFormFeedbackBox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td class="auto-style1"><asp:button id="FSFormSaveSubmit" runat="server" text="Save" onclick="FSFormSaveSubmit_Click"  class="btn"/>
                          <asp:Button ID="btnApprove" runat="server" Text="Approve Report" OnClick="btnApprove_Click1" CssClass="btn" />
                    </td>
                </tr>

            </table>
                    </div>
                </div>
        </div>
    </div>

</asp:Content>
