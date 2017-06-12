<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.Master" AutoEventWireup="true" CodeBehind="externalcorrosion.aspx.cs" Inherits="ptt_report.externalcorrosion" %>



<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft00 {
            background: #0c7fd2;
        }
    </style>


    <div class="bar_qr">
        Customer Type :
                    <asp:label id="lbCustype" runat="server" text="-"></asp:label>
        <asp:button id="btnExport" runat="server" text="Export Report" class="btn" />
        <asp:button id="btnSaveVer" runat="server" text="Save Version" class="btn" />
        <asp:button id="btnHistory" runat="server" text="History" class="btn" />

        <asp:HiddenField ID="hddec_id" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />

    </div>
    <table>
        <tr>
            <td></td>
        </tr>
    </table>
    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            <h3 class="barBlue">External Corrosion
                 <asp:button id="btnImport" runat="server" text="Import Data" onclick="btnImport_Click" class="btn btn-info" />

            </h3>
            <div class="info_executive">
                <h3>External Corrosion</h3>
                <div class="info_executive_in">

                    <table>

                        

                        <tr>
                            <td style="width:200px;">ผลการดำเนินงาน : </td>
                            <td class="auto-style1">

                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="ECResultBox"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td>P/S Potential Survey : </td>
                            <td class="auto-style1">

                                <asp:textbox id="ECPSPercent" runat="server"></asp:textbox>
                                %

                            </td>
                        </tr>
                        <tr>
                            <td>Bond Box Inspection : </td>
                            <td class="auto-style1">

                                <asp:textbox id="ECBBIPercent" runat="server"></asp:textbox>
                                %

                            </td>
                        </tr>
                        <tr>
                            <td>Rectifier Inspection : </td>
                            <td class="auto-style1">

                                <asp:textbox id="ECRIPercent" runat="server"></asp:textbox>
                                %

                            </td>
                        </tr>
                        <tr>
                            <td>Insulating Joint :
                        <br />
                                or Flange Inspection </td>
                            <td class="auto-style1">

                                <asp:textbox id="ECIJPercent" runat="server"></asp:textbox>
                                %

                            </td>
                        </tr>
                        <tr>
                            <td>Cathodic Result: </td>
                            <td class="auto-style1">

                                <table class="table_da1">
                                    <tr>
                                        <td>
                                            <asp:button id="ECCRCreate" runat="server" text="Create" class="btn btn-info" OnClick="ECCRCreate_Click"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:GridView Width="100%" DataKeyNames="id" AutoGenerateColumns="false" 
                                                runat="server" ID="gvCathodic" ShowFooter="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Month">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HddCathodicId" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:TextBox ID="gvCathodicMonth" runat="server" Text='<%# Eval("month") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="InspectionType">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCathodicInspectionType" runat="server" Text='<%# Eval("inspectiontype") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Region">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCathodicRegion" runat="server" Text='<%# Eval("region") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Progress">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCathodicProgress" runat="server" Text='<%# Eval("progress") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Manage">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btndal" runat="server" Text="Delete" OnClick="btndal_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>
                                    
                                </table>

                            </td>
                        </tr>

                        <tr>
                            <td>CIPS/DCVG Survey Status: </td>
                            <td class="auto-style1">

                                <table class="table_da1">
                                    <tr>
                                        <td>
                                            <asp:button id="ECCDSSCreate" runat="server" text="Create" class="btn btn-info" OnClick="ECCDSSCreate_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:GridView Width="100%" DataKeyNames="id" AutoGenerateColumns="false"
                                                runat="server" ID="gvCIPSStatus" ShowFooter="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Route Code">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HddCIPSStatusId" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:TextBox ID="gvCIPSStatusRouteCode" runat="server" Text='<%# Eval("routecode") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pipeline name">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCIPSStatusPipeLineName" runat="server" Text='<%# Eval("pipelinename") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCIPSStatusStatus" runat="server" Text='<%# Eval("status") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Manage">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btndal" runat="server" Text="Delete" OnClick="btndal_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>

                        <tr>
                            <td>External Corrosion Result : </td>
                            <td class="auto-style1">

                                <asp:fileupload id="ECECRFileUpload" backcolor="#99ff99" runat="server" />

                            </td>
                        </tr>

                        <tr>
                            <td>Coating Defects Result : </td>
                            <td class="auto-style1">

                                <asp:fileupload id="ECCDRFileUpload" backcolor="#99ff99" runat="server" />

                            </td>
                        </tr>

                        <tr>
                            <td>การดำเนินงานในอนาคต : </td>
                            <td class="auto-style1">

                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="ECFuturePlanBox"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td>CIPS/DCVG Survey Status: </td>
                            <td class="auto-style1">

                                <table class="table_da1">
                                    <tr>
                                        <td>
                                            <asp:button id="ECCDSS2Create" runat="server" text="Create" class="btn btn-info" OnClick="ECCDSS2Create_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:GridView Width="100%" DataKeyNames="id" AutoGenerateColumns="false" 
                                                runat="server" ID="gvCIPSStatusActivity" ShowFooter="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Route Code">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HddCIPSStatusActivityId" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:TextBox ID="gvCIPSStatusActivityActivity" runat="server" Text='<%# Eval("activity") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pipeline name">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCIPSStatusActivityProgress" runat="server" Text='<%# Eval("progress") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCIPSStatusActivityEstimatePlan" runat="server" Text='<%# Eval("estimateplan") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Manage">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gvCIPSStatusActivityManage" runat="server" Text='<%# Eval("manage") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>

                        <tr>
                            <td>ปัญหาอุปสรรค (ถ้ามี) : </td>
                            <td class="auto-style1">
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="ECProblemBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="ECFormFeedbackBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td class="auto-style1"><asp:button id="ECFormSaveSubmit" runat="server" text="Save" onclick="ECFormSaveSubmit_Click" class="btn"/></td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
