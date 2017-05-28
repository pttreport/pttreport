<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="settlementsurvey.aspx.cs" Inherits="ptt_report.settlementsurvey" %>

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
                    <th colspan="2">3rd party Interface > Settlelment Survey</th>
                </tr>

                <tr>
                    <td>แผนงาน: </td>
                    <td class="auto-style1">

                        <table border="1">

                            <tr>
                                <td colspan="7">
                                    <asp:Button ID="SSWorkPlanAddNewPlan" runat="server" Text="Create" /></td>
                            </tr>
                            <tr>
                                <td>เขต</td>
                                <td>เส้นท่อ</td>
                                <td>สถานี</td>
                                <td>Action</td>
                                <td>Progress</td>
                                <td>Remark</td>
                                <td>Manage</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="SSWorkPlanDistrict" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="SSWorkPlanPipePosition" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="SSWorkPlanDigMaintance" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="SSWorkPlanLength" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="SSWorkPlanActual" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox ID="SSWorkPlanStatus" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="SSWorkPlanDelete" runat="server" Text="Delete" /></td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>ผลการดำเนินงาน : </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="SSResult"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>การดำเนินงานในอนาคต : </td>
                    <td class="auto-style1">

                       <textarea cols="20" rows="2" runat="server" id="SSFuturePlan"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="SSProblem"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="SSFormFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="SSFormSaveSubmit" runat="server" Text="Save" OnClick="SSFormSaveSubmit_Click" /></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
