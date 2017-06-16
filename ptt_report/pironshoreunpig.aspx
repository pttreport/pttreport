<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPagePIR.Master" AutoEventWireup="true" CodeBehind="pironshoreunpig.aspx.cs" Inherits="ptt_report.pironshoreunpig" %>


<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
    <style>
        #menuleft02 {
            background: #0c7fd2;
        }
        .auto-style1 {
            height: 20px;
        }
    </style>
    <div class="bar_qr">
        Customer Type :
                   
        <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnExport" runat="server" Text="Export Report" CssClass="btn" OnClick="btnExport_Click" />
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" CssClass="btn" />
        <asp:Button ID="btnHistory" runat="server" Text="History" CssClass="btn"  OnClick="btnHistory_Click"/>

        <asp:HiddenField ID="hddpironsu_id" runat="server" />
        <asp:HiddenField ID="hddfile_path" runat="server" />
        <asp:HiddenField ID="hddmas_rep_id" runat="server" />

    </div>

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
            <h3 class="barBlue">
                 <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" CssClass="btn btn-info" /></h3>
            <div class="info_executive">
                <h3>PIPELINE</h3>
                <div class="info_executive_in">
                    <table>
                        <asp:HiddenField ID="pipeline_id" runat="server" />
                        <tr>
                            <td>Startup year: </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox1"></asp:TextBox>
                            </td>
                            <td>
                                Design Presure: 
                            </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Station : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox3"></asp:TextBox>
                            </td>
                            <td>MAOP (PSI): </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox4"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                Wall Thickness (inches):
                            </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox5"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>

                        <tr>
                            <td>Material Spec. : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox6"></asp:TextBox>
                            </td>
                            <td>Design Life : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>External Coathing : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox8"></asp:TextBox>
                            </td>
                            <td>Cathodic Protection :</td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox9"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                
                
                    <table>
                        <tr>
                            <th colspan="2">
                                PIPELINE OPERATING DATA
                            </th>
                        </tr>

                        <tr>
                            <td>Operating presure (psig): </td>
                            <td><asp:TextBox runat="server" id="TextBox10"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Operating Temperature (oC): </td>
                            <td><asp:TextBox runat="server" id="TextBox11"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Gas Flow rate (MMSCFD): </td>
                            <td><asp:TextBox runat="server" id="TextBox12"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>ความเห็น</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox13"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>

                                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                                
                            </td>
                        </tr>

                    </table>


                </div>
            </div>
        
        
            <div class="info_executive">
                <h3>External Corrosion Risk Assessment</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>
                                Summary result
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="summaryLow" GroupName="sumecra" runat="server" />

                            </td>
                            <td>
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"> 
                                <asp:RadioButton ID="summaryHigh" GroupName="sumecra" runat="server" />
                            </td>
                            <td class="auto-style1">
                                High Risk
                            </td>
                        </tr>
                         <tr>
                            <td>
                                CP level:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cp1" GroupName="cp" runat="server" />
                            </td>
                            <td>
                                Within criteria
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="cp2" GroupName="cp" runat="server" />
                            </td>
                            <td>
                                Under criteria
                            </td>
                        </tr>
                         <tr>
                            <td>
                                No. of Stray current point:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="nscp1" GroupName="nscp" runat="server" />
                            </td>
                            <td>
                                0
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="nscp2" GroupName="nscp" runat="server" />
                            </td>
                            <td>
                                0-5
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="nscp3" GroupName="nscp" runat="server" />
                            </td>
                            <td>
                                >5
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="nscp4" GroupName="nscp" runat="server" />
                            </td>
                            <td>
                                Unknow
                            </td>
                        </tr>


                        <tr>
                            <td>
                                Coating defect survey:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cds1" GroupName="cds" runat="server" />
                            </td>
                            <td>
                                No coating defect
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cds2" GroupName="cds" runat="server" />
                            </td>
                            <td>
                                Minor (Category 1:1% < IR < 15%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cds3" GroupName="cds" runat="server" />
                            </td>
                            <td>
                                Moderate (Category 2: 16% < IR < 35%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cds4" GroupName="cds" runat="server" />
                            </td>
                            <td>
                                Major (Category 3: 36%< IR < 60%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cds5" GroupName="cds" runat="server" />
                            </td>
                            <td>
                                Severe (Category 4: 61%< IR < 100%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="cds6" GroupName="cds" runat="server" />
                            </td>
                            <td>
                                Unknown
                            </td>
                        </tr>



                        <tr>
                            <td>
                                AC interference:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="ac1" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                No AC power line is within 1,000 ft of the pipeline
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="ac2" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                AC power line is nearby but preventive measures are taken
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="ac3" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                AC power line is nearby, no preventive action
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="ac4" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                Unknown
                            </td>
                        </tr>
                        


                        <tr>
                            <td>Detail :</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="ecraDetail"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="ecraOpinion"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button2" runat="server" Text="Save" /></td>
                        </tr>

                    </table>
                </div>
            </div>

            <div class="info_executive">
                <h3>Internal Corrosion Risk Assessment</h3>
                                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>
                                Summary result
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="lowicra" GroupName="sumicra" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="highicra" GroupName="sumicra" runat="server" />
                            </td>
                            <td>
                                High Risk
                            </td>
                        </tr>
                         <tr>
                            <td>
                                Water content monitor:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="lessseven" GroupName="wcmicra" runat="server" />
                            </td>
                            <td>
                                &lt;7 lb/MMscfd</td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="moreseven" GroupName="wcmicra" runat="server" />
                            </td>
                            <td>
                                &gt; 7 lb/MMscfd</td>
                        </tr>
                         <tr>
                            <td>
                                Dew Point Upset:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="dewicra1" GroupName="dewicra" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &gt; Dew Point</span></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="dewicra2" GroupName="dewicra" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &lt; Dew Point (≤ 7 days per year)</span></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="dewicra3" GroupName="dewicra" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &lt; Dew Point (≤ 30 days per year)</span></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="dewicra4" GroupName="dewicra" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &lt; Dew Point (&gt; 30 days per year)<br />
                                </span>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">CO2 content:</span>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="co1" GroupName="coicra" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">CO2 %mol &lt;=2</span></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="co2" GroupName="coicra" runat="server" />
                            </td>
                            <td class="auto-style1">
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">CO2 %mol &gt;2</span></td>
                        </tr>



                        <tr>
                            <td>
                                H2S content:
                            </td>
                            <td>


                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="h2s1" GroupName="h2sicra" runat="server" />
                            </td>
                            <td class="auto-style1">
                               Partial pressure H2S <= 0.05
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="h2s2" GroupName="h2sicra" runat="server" />
                            </td>
                            <td>
                                Partial pressure H2S > 0.05
                            </td>
                        </tr>
                        


                        <tr>
                            <td>Detail :</td>
                            <td>

                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="icradetail" />

                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>

                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="icraopinion"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button3" runat="server" Text="Save" /></td>
                        </tr>

                    </table>
                </div>
            </div>



            <div class="info_executive">
                <h3>Mechanical damage / Third party interference</h3>
                
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>
                                Summary result
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="md1" GroupName="summd" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="md2" GroupName="summd" runat="server" />
                            </td>
                            <td>
                                High Risk
                            </td>
                        </tr>
                         <tr>
                            <td>
                                Concrete coating damage:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="ccdyes" GroupName="ccdmd" runat="server" />
                            </td>
                            <td>
                                yes</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="ccdno" GroupName="ccdmd" runat="server" />
                            </td>
                            <td>
                                No    
                            </td>
                        </tr>
                         <tr>
                            <td>
                                Activity Level:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="al1" GroupName="almd" runat="server" />
                            </td>
                            <td>
                                High activity level
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="al2" GroupName="almd" runat="server" />
                            </td>
                            <td>
                                Medium activity level
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="al3" GroupName="almd" runat="server" />
                            </td>
                            <td>
                                Low activity level
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td>

                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="detailmd"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>

                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="opinionmd"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button4" runat="server" Text="Save" /></td>
                        </tr>

                    </table>
                </div>

            </div>

            <div class="info_executive">
                <h3>Loss of ground support</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>
                                Summary result
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="lgsyes" GroupName="sumlgs" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Yes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="lgsno" GroupName="sumlgs" runat="server" />
                            </td>
                            <td>
                                No
                            </td>
                        </tr>
                         <tr>
                            <td>
                               Exposed pipeline section:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="eps1" GroupName="epslgs" runat="server" />
                            </td>
                            <td>
                                All buried
                                
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="eps2" GroupName="epslgs" runat="server" />
                            </td>
                            <td>
                                Some Areas Exposed
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="eps3" GroupName="epslgs" runat="server" />
                            </td>
                            <td>
                                Many Areas Exposed
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="eps4" GroupName="epslgs" runat="server" />
                            </td>
                            <td>
                                All Areas Exposed
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="detaillgs"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="opinionlgs"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button5" runat="server" Text="Save" /></td>
                        </tr>

                    </table>
                </div>
            </div>

            <div class="info_executive">
                <h3>Pipeline Repair History</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>
                                Summary result
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="prhyes" GroupName="sumprh" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Yes, see more in detail
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="prhno" GroupName="sumprh" runat="server" />
                            </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox14"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox15"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button6" runat="server" Text="Save" /></td>
                        </tr>

                    </table>
                </div>
            </div>

            <div class="info_executive">
                <h3>Recommendation</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox17"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox16"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
