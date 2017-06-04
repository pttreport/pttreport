﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.Master" AutoEventWireup="true" CodeBehind="directassessment.aspx.cs" Inherits="ptt_report.directassessment" %>


<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft03 {
            background: #0c7fd2;
        }
        
    </style>
    <div class="bar_qr">
        Customer Type :
                   
                    <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnExport" runat="server" Text="Export Report" CssClass="btn" />
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" CssClass="btn" />
        <asp:Button ID="btnHistory" runat="server" Text="History" CssClass="btn" />

    </div>

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">

            <h3 class="barBlue">Direct Assessment
                 <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" CssClass="btn btn-info" /></h3>
            <div class="info_executive">
                <h3>3rd party Interface > Direct Assessment</h3>
                <div class="info_executive_in">


                    <table>

                        <tr>
                            <td style="width: 165px;">แผนงาน: </td>
                            <td class="auto-style1">

                                <table class="table_da1">
                                    <tr>
                                        <th>เขต</th>
                                        <th>เส้นท่อ, ตำแหน่ง</th>
                                        <th>ขุดซ่อมเนื่องจาก</th>
                                        <th>Length (m)</th>
                                        <th>% Actual</th>
                                        <th>Plan / Status</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DADistrictPlanText1" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPipePositionPlanText1" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DADigPlanText1" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DALengthPlanText1" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAActualPlanText1" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPlanStatusPlanText1" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DADistrictPlanText2" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPipePositionPlanText2" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DADigPlanText2" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DALengthPlanText2" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAActualPlanText2" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPlanStatusPlanText2" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DADistrictPlanText3" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPipePositionPlanText3" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DADigPlanText3" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DALengthPlanText3" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAActualPlanText3" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPlanStatusPlanText3" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DADistrictPlanText4" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPipePositionPlanText4" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DADigPlanText4" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DALengthPlanText4" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAActualPlanText4" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPlanStatusPlanText4" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DADistrictPlanText5" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPipePositionPlanText5" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DADigPlanText5" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DALengthPlanText5" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAActualPlanText5" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAPlanStatusPlanText5" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>


                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>ผลการดำเนินงาน : </td>
                            <td class="auto-style1">

                                <table class="table_da2">
                                    <tr>
                                        <th>เขต</th>
                                        <th>RC</th>
                                        <th>จำนวนหลุม</th>
                                        <th>หมายเหตุ</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DADistrictResultText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DARCResultText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAHoleResultText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DANoteResultText" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>การดำเนินงานในอนาคต : </td>
                            <td class="auto-style1">

                                <table class="table_da3">
                                    <tr>
                                        <th>เดือน</th>
                                        <th>เขต</th>
                                        <th>RC</th>
                                        <th>จำนวนหลุม</th>
                                        <th>หมายเหตุ</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="DAMonthFutureText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DADistrictFutureText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DARCFutureText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DAHoleFutureText" BackColor="#99ff99" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="DANoteFutureText" BackColor="#99ff99" runat="server"></asp:TextBox></td>

                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="DAProblem" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="DAFormFeedback" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td class="auto-style1"><asp:Button ID="DAFormSaveSubmit" runat="server" Text="Save" OnClick="DAFormSaveSubmit_Click" CssClass="btn" /></td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
