<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rov.aspx.cs" Inherits="ptt_report.rov" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 474px;
        }
        #TextArea1 {
            width: 459px;
        }
        #BasicAnalysis {
            width: 445px;
        }
        </style>
</asp:Content>

<asp:Content ID="es_form" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            patrolForm
            <table>

                <tr>
                    <th colspan="2">3rd party Interface > ROV</th>
                </tr>

                <tr>
                    <td>แผนงาน: </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="ROVWorkPlan"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>ผลการดำเนินงาน : </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="ROVResult"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>การดำเนินงานในอนาคต : </td>
                    <td class="auto-style1">

                       <textarea cols="20" rows="2" runat="server" id="ROVFuturePlan"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ROVProblem"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ROVFormFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ROVFormSaveSubmit" runat="server" Text="Save" OnClick="ROVFormSaveSubmit_Click" /></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
