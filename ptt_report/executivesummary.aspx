<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.Master" AutoEventWireup="true" CodeBehind="executivesummary.aspx.cs" Inherits="ptt_report.executivesummary" %>



<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft01 {
            background:#0c7fd2;
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
            <h3 class="barBlue">Executive summary
                <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" CssClass="btn btn-info" /></h3>


            <div class="info_executive">
                <h3>3rd party Interface</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>ความครบถ้วนตามแผนงาน Patrolling : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="patrolingPercent" BackColor="#99ff99" runat="server" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="BasicAnalysis" rows="2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="PatrollingObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="PatrollingFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="PatrollingFormSubmit" runat="server" Text="Save Patrolling Part" OnClick="PatrollingFormSubmit_Click" class="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>ความครบถ้วนตามแผนงาน ROV : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="RovPercent" runat="server" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="RovAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="RovObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="RovFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="RovFormSubmit" runat="server" Text="Save ROV Part" OnClick="RovFormSubmit_Click" class="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>


                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>ความครบถ้วนตามแผนงาน งานขุดซ่อม : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="DigPercent" BackColor="#99ff99" runat="server" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปและวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="DigAnalysis" BackColor="#99ff99" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="DigObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="DigFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="DigFormSubmit" runat="server" Text="Save DA Part" OnClick="DigFormSubmit_Click" class="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>งานแก้ไขจุดกัดเซาะ : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="ErosionPercent" runat="server" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="ErosionAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="ErosionObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="ErosionFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="ErosionFormSubmit" runat="server" Text="Save Erosion Part" OnClick="ErosionFormSubmit_Click" class="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>
                <div class="info_executive_in">

                    <table>
                        <tr>
                            <td>การทรุดตัวของท่อ : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="SubsidePercent" runat="server" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="SubsideAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="SubsideObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="SubsideFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="SubsideFormSubmit" runat="server" Text="Save Subside Part" OnClick="SubsideFormSubmit_Click" class="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>

                    </table>
                </div>





            </div>

        </div>
    </div>


    <div id="externalCorotionForm" style="background-color: #FFFFFF">
        <div id="externalCorotionFormTable">


            <div class="info_executive">
                <h3>External Corrosion</h3>

                <div class="info_executive_in">
                    <table>



                        <tr>
                            <td>CP system : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="CPSystemPercent" BackColor="#99ff99" runat="server" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>CIPS / DCVG : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="CIPSPercent" runat="server" BackColor="#99ff99" Width="27px"></asp:TextBox>
                                % เทียบแผนทั้งปี </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="ECAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="ECObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="ECFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="ECFormSubmit" runat="server" Text="Save EC Part" OnClick="ECFormSubmit_Click" CssClass="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="internalCorotionForm" style="background-color: #FFFFFF">
        <div id="internalCorotionFormTable">

            <div class="info_executive">
                <h3>Internal Corrosion</h3>

                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>Cleaning PIG : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="ICCPIGPercent" BackColor="#99ff99" runat="server" Width="27px"></asp:TextBox>
                                % </td>
                        </tr>
                        <tr>
                            <td>ILI PIG : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="ICILIPIGPercent" BackColor="#99ff99" runat="server" Width="27px"></asp:TextBox>
                                % </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="ICAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="ICObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="ICFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="ICFormSubmit" runat="server" Text="Save Internal Corrosion Part" OnClick="ICFormSubmit_Click" CssClass="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="mtpgForm" style="background-color: #FFFFFF">
        <div id="mtpgFormTable">
            <div class="info_executive">
                <h3>งานบำรุงรักษาท่อภายในสถานีก๊าซ</h3>
                <div class="info_executive_in">
                    <table>

                        <tr>
                            <td>ความครบถ้วนตามแผนงาน  : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="MTPGPercent" BackColor="#99ff99" runat="server" Width="27px"></asp:TextBox>
                                % </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="MTPGAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="MTPGObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="MTPGFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="MTPGFormSubmit" runat="server" Text="Save DA Part" OnClick="MTPGFormSubmit_Click" CssClass="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="OffShorePipeForm" style="background-color: #FFFFFF">
        <div id="OffShorePipeFormTable">
            <div class="info_executive">
                <h3>งานบำรุงรักษาท่อบนแท่นพักท่อก๊าซในทะเล</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <th colspan="2"></th>
                        </tr>
                        <tr>
                            <td>ความครบถ้วนตามแผนงาน  : </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="OffShorePipePercent" runat="server" Width="27px"></asp:TextBox>
                                % </td>
                        </tr>
                        <tr>
                            <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                            <td class="auto-style1">
                                <textarea id="OffShorePipeAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                        </tr>
                        <tr>
                            <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                            <td class="auto-style1">
                                <textarea id="OffShorePipeObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <textarea cols="20" rows="2" runat="server" id="OffShorePipeFeedback"></textarea></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="OffShorePipeFormSubmit" runat="server" Text="Save Offshore Part" CssClass="btn" /></td>
                            <td class="auto-style1"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="OffShoreBaseForm" style="background-color: #FFFFFF">
        <div id="OffShoreBaseFormTable">
            <div id="OffShorePipeFormTable">
                <div class="info_executive">
                    <h3>งานบำรุงรักษาโครงสร้างแท่นพักของท่อในทะเล</h3>
                    <div class="info_executive_in">
                        <table>

                            <tr>
                                <td>ความครบถ้วนตามแผนงาน  : </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="OffShoreBasePercent" runat="server" Width="27px"></asp:TextBox>
                                    % </td>
                            </tr>
                            <tr>
                                <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                                <td class="auto-style1">
                                    <textarea id="OffShoreBaseAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                            </tr>
                            <tr>
                                <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                                <td class="auto-style1">
                                    <textarea id="OffShoreBaseObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                            </tr>
                            <tr>
                                <td>ความเห็น : </td>
                                <td class="auto-style1">
                                    <textarea cols="20" rows="2" runat="server" id="OffShoreBaseFeedback"></textarea></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="OffShoreBaseFormSubmit" runat="server" Text="Save Offshore Part" CssClass="btn" /></td>
                                <td class="auto-style1"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="OtherProjectForm" style="background-color: #FFFFFF">
        <div id="OtherProjectFormTable">
            <div class="info_executive">

                <div class="info_executive_in">
                    <asp:Table ID="OtherProjectList" runat="server" Style="height: 22px">
                    </asp:Table>
                </div>
            </div>

        </div>
        <div id="OtherProjectAddButton">
            <asp:Button ID="AddOtherProject" runat="server" Text="Add Other Project" OnClick="AddOtherProject_Click" CssClass="btn" />
        </div>
    </div>
</asp:Content>
