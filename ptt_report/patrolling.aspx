<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="patrolling.aspx.cs" Inherits="ptt_report.patrolling" %>

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
                    <th colspan="2">3rd party Interface > Patrolling</th>
                </tr>

                <tr>
                    <td>Ground Patrolling Result: </td>
                    <td class="auto-style1">
                        <asp:FileUpload ID="PatrollingUpload" runat="server" /> </td>
                </tr>
                <tr>
                    <td>Aerial Result : </td>
                    <td class="auto-style1"><textarea id="PatrollingAerialResult" rows="2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>หมายเหตุ : </td>
                    <td class="auto-style1"><textarea id="PatrollingNote" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="PatrollingProblem"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="PatrollingFormFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="PatrollingFormSaveSubmit" runat="server" Text="Save" OnClick="PatrollingFormSaveSubmit_Click1" /></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
