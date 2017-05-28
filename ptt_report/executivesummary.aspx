<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="executivesummary.aspx.cs" Inherits="ptt_report.executivesummary" %>

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
                    <th colspan="2">3rd party Interface</th>
                </tr>

                <tr>
                    <td>ความครบถ้วนตามแผนงาน Patrolling : </td>
                    <td class="auto-style1"><asp:TextBox ID="patrolingPercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="BasicAnalysis" rows="2" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="PatrollingObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="PatrollingFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="PatrollingFormSubmit" runat="server" Text="Save Patrolling Part" OnClick="PatrollingFormSubmit_Click" /></td>
                    <td class="auto-style1"></td>
                </tr>

                <tr>
                    <td>ความครบถ้วนตามแผนงาน ROV : </td>
                    <td class="auto-style1"><asp:TextBox ID="RovPercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="RovAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="RovObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="RovFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="RovFormSubmit" runat="server" Text="Save ROV Part" OnClick="RovFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>

                <tr>
                    <td>ความครบถ้วนตามแผนงาน งานขุดซ่อม : </td>
                    <td class="auto-style1"><asp:TextBox ID="DigPercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="DigAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="DigObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="DigFeedback"></textarea></td>
                </tr>
                <tr>
                    <td><asp:Button ID="DigFormSubmit" runat="server" Text="Save DA Part" OnClick="DigFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>

                <tr>
                    <td>งานแก้ไขจุดกัดเซาะ : </td>
                    <td class="auto-style1"><asp:TextBox ID="ErosionPercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="ErosionAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="ErosionObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ErosionFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ErosionFormSubmit" runat="server" Text="Save Erosion Part" OnClick="ErosionFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>

                <tr>
                    <td>การทรุดตัวของท่อ : </td>
                    <td class="auto-style1"><asp:TextBox ID="SubsidePercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="SubsideAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="SubsideObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="SubsideFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="SubsideFormSubmit" runat="server" Text="Save Subside Part" OnClick="SubsideFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

    <div id="externalCorotionForm" style="background-color: #FFFFFF">
        <div id="externalCorotionFormTable">
            <table>

                <tr>
                    <th colspan="2">External Corrosion</th>
                </tr>

                <tr>
                    <td>CP : </td>
                    <td class="auto-style1"><asp:TextBox ID="CPSystemPercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>CIPS / DCVG : </td>
                    <td class="auto-style1"><asp:TextBox ID="CIPSPercent" runat="server" Width="27px"></asp:TextBox> % เทียบแผนทั้งปี </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="ECAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="ECObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ECFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ECFormSubmit" runat="server" Text="Save EC Part" OnClick="ECFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

    <div id="internalCorotionForm" style="background-color: #FFFFFF">
        <div id="internalCorotionFormTable">
                        <table>

                <tr>
                    <th colspan="2">Internal Corrosion</th>
                </tr>

                <tr>
                    <td>Cleaning PIG : </td>
                    <td class="auto-style1"><asp:TextBox ID="ICCPIGPercent" runat="server" Width="27px"></asp:TextBox> % </td>
                </tr>
                <tr>
                    <td>ILI PIG : </td>
                    <td class="auto-style1"><asp:TextBox ID="ICILIPIGPercent" runat="server" Width="27px"></asp:TextBox> % </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="ICAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="ICObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ICFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ICFormSubmit" runat="server" Text="Save Internal Corrosion Part" OnClick="ICFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>
            </table>
        </div>
    </div>

    <div id="mtpgForm" style="background-color: #FFFFFF">
	    <div id="mtpgFormTable">
            <table>
                <tr>
                    <th colspan="2">งานบำรุงรักษาท่อภายในสถานีก๊าซ</th>
                </tr>
                <tr>
                    <td>ความครบถ้วนตามแผนงาน  : </td>
                    <td class="auto-style1"><asp:TextBox ID="MTPGPercent" runat="server" Width="27px"></asp:TextBox> % </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="MTPGAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="MTPGObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="MTPGFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="MTPGFormSubmit" runat="server" Text="Save DA Part" OnClick="MTPGFormSubmit_Click"/></td>
                    <td class="auto-style1"></td>
                </tr>
            </table>
	    </div>
    </div>

    <div id="OffShorePipeForm" style="background-color: #FFFFFF">
	    <div id="OffShorePipeFormTable">
            <table>
                <tr>
                    <th colspan="2">งานบำรุงรักษาท่อบนแท่นพักท่อก๊าซในทะเล</th>
                </tr>
                <tr>
                    <td>ความครบถ้วนตามแผนงาน  : </td>
                    <td class="auto-style1"><asp:TextBox ID="OffShorePipePercent" runat="server" Width="27px"></asp:TextBox> % </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="OffShorePipeAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="OffShorePipeObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="OffShorePipeFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="OffShorePipeFormSubmit" runat="server" Text="Save Offshore Part"/></td>
                    <td class="auto-style1"></td>
                </tr>
            </table>
	    </div>
    </div>

    <div id="OffShoreBaseForm" style="background-color: #FFFFFF">
	    <div id="OffShoreBaseFormTable">
            <table>
                <tr>
                    <th colspan="2">งานบำรุงรักษาโครงสร้างแท่นพักของท่อในทะเล</th>
                </tr>
                <tr>
                    <td>ความครบถ้วนตามแผนงาน  : </td>
                    <td class="auto-style1"><asp:TextBox ID="OffShoreBasePercent" runat="server" Width="27px"></asp:TextBox> % </td>
                </tr>
                <tr>
                    <td>ผลสรุปวิเคราะห์เบื้องต้น : </td>
                    <td class="auto-style1"><textarea id="OffShoreBaseAnalysis" runat="server" rows="2" aria-multiline="True" aria-multiselectable="False" draggable="false"></textarea></td>
                </tr>
                <tr>
                    <td>ประเด็นปัญหา / อุปสรรค์ : </td>
                    <td class="auto-style1"><textarea id="OffShoreBaseObstruction" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="OffShoreBaseFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="OffShoreBaseFormSubmit" runat="server" Text="Save Offshore Part"/></td>
                    <td class="auto-style1"></td>
                </tr>
            </table>
	    </div>
    </div>

    <div id="OtherProjectForm" style="background-color: #FFFFFF">
	    <div id="OtherProjectFormTable">

	        <asp:Table ID="OtherProjectList" runat="server" style="height: 22px">

            </asp:Table>

	    </div>
        <div id="OtherProjectAddButton">
            <asp:Button ID="AddOtherProject" runat="server" Text="Add Other Project" OnClick="AddOtherProject_Click"/>
        </div>
    </div>

</asp:Content>
