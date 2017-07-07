﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="piping.aspx.cs" Inherits="ptt_report.piping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft11 {
            background: #0c7fd2;
        }

        table {
            border-collapse: collapse;
        }
    </style>

    <asp:hiddenfield id="hddmas_rep_id" runat="server" />
    <asp:hiddenfield id="hddpiping_id" runat="server" />
    <asp:hiddenfield id="hddfile_path" runat="server" />



    <div class="bar_qr">
        Customer Type :
                   
                    <asp:label id="lbCustype" runat="server" text="-"></asp:label>
        <asp:button id="btnSaveVer" runat="server" text="Save Version" onclick="btnSaveVer_Click" class="btn" />
        <asp:button id="btnExport" runat="server" text="Export Report" onclick="btnExport_Click" class="btn" />
        <asp:button id="btnHistory" runat="server" text="History" onclick="btnHistory_Click" class="btn" />

    </div>
    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            <h3 class="barBlue">Piping
                <asp:button id="btnImport" runat="server" text="Import Data" onclick="btnImport_Click" class="btn btn-info" />
            </h3>
            <table>

                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>Quarterly Plan :</td>
                                <td>
                                    <table border="1">
                                        <tr>
                                            <td rowspan="5">
                                                <asp:label id="lbQuarter" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>Region</td>
                                            <td colspan="2">1</td>
                                            <td colspan="2">2</td>
                                            <td colspan="2">3</td>
                                            <td colspan="2">4</td>
                                            <td colspan="2">5</td>
                                            <td colspan="2">6</td>
                                            <td colspan="2">7</td>
                                            <td colspan="2">8</td>
                                            <td colspan="2">9</td>
                                            <td colspan="2">10</td>
                                        </tr>
                                        <tr>
                                            <td>Progress</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lbM1" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm111" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm112" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm121" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm122" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm131" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm132" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm141" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm142" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm151" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm152" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm161" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm162" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm171" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm172" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm181" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm182" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm191" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm192" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm101" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm102" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lbM2" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm211" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm212" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm221" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm222" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm231" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm232" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm241" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm242" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm251" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm252" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm261" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm262" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm271" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm272" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm281" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm282" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm291" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm292" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm201" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm202" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lbM3" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm311" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm312" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm321" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm322" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm331" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm332" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm341" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm342" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm351" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm352" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm361" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm362" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm371" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm372" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm381" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm382" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm391" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm392" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm301" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm302" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>Preventive maintenance PM :</td>
                                <td>
                                    <div>Wall Thickness Inspection</div>
                                    <asp:button id="btnCreate1" runat="server" text="Create" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Region</td>
                                            <td>Criteria</td>
                                            <td>Status</td>
                                            <td>Management</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:textbox id="txtRegion" runat="server"></asp:textbox>
                                            </td>
                                            <td>Avg
                                       
                                       
                                                <asp:textbox id="txtAVG" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtstation" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:button id="btnDel1" runat="server" text="Delete" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>Min
                                       
                               
                                                <asp:textbox id="txtmin" runat="server"></asp:textbox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>CorrRate(mm/yr)
                                       
                                        <br />
                                                <asp:textbox id="txtCorr" runat="server"></asp:textbox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div>Coating Inspection</div>
                                    <asp:button id="btnCreate2" runat="server" text="Create" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Region</td>
                                            <td>Criteria</td>
                                            <td>Station</td>
                                            <td>Management</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:textbox id="txtRegion2" runat="server"></asp:textbox>
                                            </td>
                                            <td>Coating condition / สภาพ Coating
                                       
                                        <br />
                                                <asp:textbox id="txtCoatingCondition" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtstation2" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:button id="btnDel2" runat="server" text="Delete" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>Corrosion condition / สภาพการเกิด Corrosion
                                       
                                        <br />
                                                <asp:textbox id="txtCorrosion" runat="server"></asp:textbox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div>Corrosion Under Pipe Support</div>
                                    <asp:button id="btnCreate3" runat="server" text="Create" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Region</td>
                                            <td>Criteria</td>
                                            <td>Station</td>
                                            <td>Management</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:textbox id="txtRegion3" runat="server"></asp:textbox>
                                            </td>
                                            <td>Pipe support condition / สภาพท่อใต้ Support
                                       
                                        <br />
                                                <asp:textbox id="txtPipeSup" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtstation3" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:button id="btnDel3" runat="server" text="Delete" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>Corrosion condition / สภาพการเกิด Corrosion
                                       
                                        <br />
                                                <asp:textbox id="txtCorrosion2" runat="server"></asp:textbox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div>Soil to Air Inspection</div>
                                    <asp:button id="btnCreate4" runat="server" text="Create" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Region</td>
                                            <td>Criteria</td>
                                            <td>Station</td>
                                            <td>Management</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:textbox id="txtRegion4" runat="server"></asp:textbox>
                                            </td>
                                            <td>Coating condition / สภาพ Coating
                                       
                                        <br />
                                                <asp:textbox id="txtCoating4" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtstation4" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:button id="btnDel4" runat="server" text="Delete" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>Corrosion condition / สภาพการเกิด Corrosion
                                       
                                        <br />
                                                <asp:textbox id="txtCorrosion4" runat="server"></asp:textbox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div>Corrosion Under Insulation</div>
                                    <asp:button id="btnCreate5" runat="server" text="Create" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Region</td>
                                            <td>Criteria</td>
                                            <td>Station</td>
                                            <td>Management</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:textbox id="txtRegion5" runat="server"></asp:textbox>
                                            </td>
                                            <td>Insulation condition / สภาพ Insulation
                                       
                                        <br />
                                                <asp:textbox id="txtInsulation" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtstation5" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:button id="btnDel5" runat="server" text="Delete" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>Corrosion condition / สภาพการเกิด Corrosion
                                       
                                        <br />
                                                <asp:textbox id="txtCorrosion5" runat="server"></asp:textbox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>Corrective maintenance CM :</td>
                                <td>
                                    <asp:button id="btnCreate6" runat="server" text="Create" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Region</td>
                                            <td>Inspection</td>
                                            <td>CM Station</td>
                                            <td>Date</td>
                                            <td>Management</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:textbox id="txtRegion6" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtInspection" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtCMStation" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtdate" runat="server"></asp:textbox>
                                            </td>
                                            <td>
                                                <asp:button id="btnDel6" runat="server" text="Delete" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>แผนงานในอนาคต :</td>
                                <td>
                                    <table>
                                        <tr>
                                            <td rowspan="5">
                                                <asp:label id="lbQuarter2" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>Region</td>
                                            <td colspan="2">1</td>
                                            <td colspan="2">2</td>
                                            <td colspan="2">3</td>
                                            <td colspan="2">4</td>
                                            <td colspan="2">5</td>
                                            <td colspan="2">6</td>
                                            <td colspan="2">7</td>
                                            <td colspan="2">8</td>
                                            <td colspan="2">9</td>
                                            <td colspan="2">10</td>
                                        </tr>
                                        <tr>
                                            <td>Progress</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                            <td>Plan</td>
                                            <td>Act</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lbM1_" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm111_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm112_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm121_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm122_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm131_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm132_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm141_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm142_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm151_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm152_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm161_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm162_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm171_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm172_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm181_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm182_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm191_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm192_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm101_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm102_" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lbM2_" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm211_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm212_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm221_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm222_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm231_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm232_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm241_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm242_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm251_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm252_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm261_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm262_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm271_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm272_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm281_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm282_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm291_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm292_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm201_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm202_" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:label id="lbM3_" runat="server" text="-"></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm311_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm312_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm321_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm322_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm331_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm332_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm341_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm342_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm351_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm352_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm361_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm362_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm371_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm372_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm381_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm382_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm391_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm392_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm301_" runat="server" text=""></asp:label>
                                            </td>
                                            <td>
                                                <asp:label id="lbm302_" runat="server" text=""></asp:label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>ความเห็น :</td>
                                <td>
                                    <asp:textbox id="txtComment" runat="server"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:button id="btnSave" runat="server" text="Save" onclick="btnSave_Click" />

                                    <asp:button id="btnApprove" runat="server" text="Approve Report" onclick="btnApprove_Click" cssclass="btn" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
