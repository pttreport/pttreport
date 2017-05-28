<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="externalcorrosion.aspx.cs" Inherits="ptt_report.externalcorrosion" %>

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
                    <th colspan="2">External Corrosion</th>
                </tr>

                <tr>
                    <td>ผลการดำเนินงาน : </td>
                    <td class="auto-style1">

                        <textarea cols="20" rows="2" runat="server" id="ECResult"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>P/S Potential Survey : </td>
                    <td class="auto-style1">

                        <asp:TextBox ID="ECPSPercent" runat="server"></asp:TextBox> %

                    </td>
                </tr>
                <tr>
                    <td>Bond Box Inspection : </td>
                    <td class="auto-style1">

                       <asp:TextBox ID="ECBBIPercent" runat="server"></asp:TextBox> %

                    </td>
                </tr>
                <tr>
                    <td>Rectifier Inspection : </td>
                    <td class="auto-style1">

                       <asp:TextBox ID="ECRIPercent" runat="server"></asp:TextBox> %

                    </td>
                </tr>
                <tr>
                    <td>Insulating Joint : <br /> or Flange Inspection </td>
                    <td class="auto-style1">

                       <asp:TextBox ID="ECIJPercent" runat="server"></asp:TextBox> %

                    </td>
                </tr>
                <tr>
                    <td>Cathodic Result: </td>
                    <td class="auto-style1">

                       <table border="1">
                           <tr>
                              <td colspan="5">
                                  <asp:Button ID="ECCRCreate" runat="server" Text="Create" />
                              </td>
                           </tr>
                           <tr>
                               <td>Month</td>
                               <td>InspectionType</td>
                               <td>Region</td>
                               <td>Progress</td>
                               <td>Manage</td>
                           </tr>
                           <tr>
                               <td><textarea id="ECCRMonthText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCRInspectionTypeText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCRRegionText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCRProgressText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCRManage1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                           </tr>
                       </table>

                    </td>
                </tr>

                <tr>
                    <td>CIPS/DCVG Survey Status: </td>
                    <td class="auto-style1">

                       <table border="1">
                           <tr>
                              <td colspan="5">
                                  <asp:Button ID="ECCDSSCreate" runat="server" Text="Create" />
                              </td>
                           </tr>
                           <tr>
                               <td>Route Code</td>
                               <td>Pipeline name</td>
                               <td>Status</td>
                               <td>Manage</td>
                           </tr>
                           <tr>
                               <td><textarea id="ECCDSSRouteCodeText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCDSSPipelineNameText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCDSSStatusText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCDSSManage1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                           </tr>
                       </table>

                    </td>
                </tr>

                <tr>
                    <td>External Corrosion Result : </td>
                    <td class="auto-style1">

                        <asp:FileUpload ID="ECECRFileUpload" runat="server" />

                    </td>
                </tr>

                <tr>
                    <td>Coating Defects Result : </td>
                    <td class="auto-style1">

                        <asp:FileUpload ID="ECCDRFileUpload" runat="server" />

                    </td>
                </tr>

                <tr>
                    <td>การดำเนินงานในอนาคต : </td>
                    <td class="auto-style1">

                       <textarea cols="20" rows="2" runat="server" id="ECFuturePlan"></textarea>

                    </td>
                </tr>

                <tr>
                    <td>CIPS/DCVG Survey Status: </td>
                    <td class="auto-style1">

                       <table border="1">
                           <tr>
                              <td colspan="5">
                                  <asp:Button ID="ECCDSS2Create" runat="server" Text="Create" />
                              </td>
                           </tr>
                           <tr>
                               <td>Activity</td>
                               <td>Progress</td>
                               <td>Estimate Plan</td>
                               <td>Manage</td>
                           </tr>
                           <tr>
                               <td><textarea id="ECCDSS2ActivityText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCDSS2ProgressText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCDSS2EstimatePlanText1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                               <td><textarea id="ECCDSS2Manage1" runat="server" aria-multiline="True" aria-multiselectable="False" draggable="false" cols="20" rows="2"></textarea></td>
                           </tr>
                       </table>

                    </td>
                </tr>

                <tr>
                    <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ECProblem"></textarea></td>
                </tr>
                <tr>
                    <td>ความเห็น : </td>
                    <td class="auto-style1"><textarea cols="20" rows="2" runat="server" id="ECFormFeedback"></textarea></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ECFormSaveSubmit" runat="server" Text="Save" OnClick="ECFormSaveSubmit_Click" /></td>
                    <td class="auto-style1"></td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>
