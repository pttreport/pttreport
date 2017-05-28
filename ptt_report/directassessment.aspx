<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="directassessment.aspx.cs" Inherits="ptt_report.directassessment" %>

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
                    <th colspan="2">3rd party Interface > Direct Assessment</th>
                </tr>

                <tr>
                    <td>แผนงาน: </td>
                    <td class="auto-style1">

                        <table border="1">
                            <tr>
                                <th>เขต</th>
                                <th>เส้นท่อ, ตำแหน่ง</th>
                                <th>ขุดซ่อมเนื่องจาก</th>
                                <th>Length (m)</th>
                                <th>% Actual</th>
                                <th>Plan / Status</th>
                            </tr>
                            <tr>
                                <td><textarea id="DADistrictPlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPipePositionPlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DADigPlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DALengthPlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAActualPlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPlanStatusPlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>
                            <tr>
                                <td><textarea id="DADistrictPlanText2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPipePositionPlanText2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DADigPlanText2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DALengthPlanText2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAActualPlanText2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPlanStatusPlanText2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>
                            <tr>
                                <td><textarea id="DADistrictPlanText3" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPipePositionPlanText3" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DADigPlanText3" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DALengthPlanText3" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAActualPlanText3" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPlanStatusPlanText3" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>   
                            <tr>
                                <td><textarea id="DADistrictPlanText4" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPipePositionPlanText4" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DADigPlanText4" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DALengthPlanText4" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAActualPlanText4" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPlanStatusPlanText4" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>
                            <tr>
                                <td><textarea id="DADistrictPlanText5" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPipePositionPlanText5" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DADigPlanText5" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DALengthPlanText5" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAActualPlanText5" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAPlanStatusPlanText5" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>


                        </table>

                    </td>
                </tr>
                <tr>
                    <td>ผลการดำเนินงาน : </td>
                    <td class="auto-style1">

                        <table border="1">
                            <tr>
                                <th>เขต</th>
                                <th>RC</th>
                                <th>จำนวนหลุม</th>
                                <th>หมายเหตุ</th>
                            </tr>
                            <tr>
                                <td><textarea id="DADistrictResultText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DARCResultText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAHoleResultText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DANoteResultText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>การดำเนินงานในอนาคต : </td>
                    <td class="auto-style1">

                        <table border="1">
                            <tr>
                                <th>เดือน</th>
                                <th>เขต</th>
                                <th>RC</th>
                                <th>จำนวนหลุม</th>
                                <th>หมายเหตุ</th>
                            </tr>
                            <tr>
                                <td><textarea id="DAMonthFutureText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DADistrictFutureText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DARCFutureText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DAHoleFutureText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                                <td><textarea id="DANoteFutureText" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="DAProblem"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="DAFormFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="DAFormSaveSubmit" runat="server" Text="Save" OnClick="DAFormSaveSubmit_Click" /></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
