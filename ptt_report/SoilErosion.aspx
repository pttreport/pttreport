<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="soilerosion.aspx.cs" Inherits="ptt_report.soilerosion" %>

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
                    <th colspan="2">3rd party Interface > Soil Erosion</th>
                </tr>
                <tr>
                    <td>รายละเอียดงาน : </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="SEProjectDetail"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>แผนงาน: </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="SEWorkPlan"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>แผนงาน: </td>
                    <td class="auto-style1">

                        <table border="1">

                            <tr>
                                <td colspan="7">
                                    <asp:Button ID="SEWorkPlanAddNewPlan" runat="server" Text="Create" /></td>
                            </tr>
                            <tr>
                                <td>เขต</td>
                                <td>เส้นท่อ, ตำแหน่ง</td>
                                <td>ขุดซ่อมเนื่องจาก</td>
                                <td>Length (m)</td>
                                <td>%Actual</td>
                                <td>Plan/Status</td>
                                <td>Manage</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="SEWorkPlanDistrict" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="SEWorkPlanPipePosition" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="SEWorkPlanDigMaintance" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="SEWorkPlanLength" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="SEWorkPlanActual" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="SEWorkPlanStatus" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="SEWorkPlanDelete" runat="server" Text="Delete" /></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>ผลการดำเนินงาน : </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="SEResult"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>การดำเนินงานในอนาคต : </td>
                    <td class="auto-style1">

                       <textarea cols="20" rows="2" runat="server" id="SEFuturePlan"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="SEProblem"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="SEFormFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="SEFormSaveSubmit" runat="server" Text="Save" OnClick="SEFormSaveSubmit_Click" /></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
