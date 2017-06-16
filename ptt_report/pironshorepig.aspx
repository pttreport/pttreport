<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPagePIR.Master" AutoEventWireup="true" CodeBehind="pironshorepig.aspx.cs" Inherits="ptt_report.pironshorepig" %>


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
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" CssClass="btn" OnClick="btnSaveVer_Click" />
        <asp:Button ID="btnHistory" runat="server" Text="History" CssClass="btn"  OnClick="btnHistory_Click"/>

        <asp:HiddenField ID="hddpironsp_id" runat="server" />
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
                                Length (KM):
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
                            <td>
                                Wall Thickness (inches):
                            </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox6"></asp:TextBox>
                            </td>
                            <td>
                                Original Location class:
                            </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox7"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Material Spec. : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox8"></asp:TextBox>
                            </td>
                            <td>Design Life : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>External Coathing : </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox10"></asp:TextBox>
                            </td>
                            <td>Cathodic Protection :</td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox11"></asp:TextBox>
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
                            <td>
                                <asp:TextBox runat="server" id="TextBox12"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Operating Temperature (oC): </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox13"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Gas Flow rate (MMSCFD): </td>
                            <td>
                                <asp:TextBox runat="server" id="TextBox14"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style1">ความเห็น</td>
                            <td class="auto-style1">
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox15"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Save" />
                            </td>
                        </tr>

                    </table>



                    <table>
                        <tr>
                            <th colspan="2">
                                INTEGRITY ASSESSMENT RESULTS
                            </th>
                        </tr>

                        <tr>
                            <td>Last ILI PIG:: </td>
                            <td><asp:TextBox runat="server" id="TextBox16"></asp:TextBox></td>
                            <td>CR used for Rem. Life (Need for 1st repair): </td>
                            <td><asp:TextBox runat="server" id="TextBox17"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Prob. of Failure: </td>
                            <td><asp:TextBox runat="server" id="TextBox18"></asp:TextBox></td>
                            <td>Assessment date: </td>
                            <td><asp:TextBox runat="server" id="TextBox19"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Overall Integrity Status(Remaining life):</td>
                            <td><asp:TextBox runat="server" id="TextBox20"></asp:TextBox></td>
                            <td>Remaining Life (Yrs): </td>
                            <td><asp:TextBox runat="server" id="TextBox21"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Overall Integrity Status(Design life):</td>
                            <td><asp:TextBox runat="server" id="TextBox22"></asp:TextBox></td>
                            <td>Inspection year: </td>
                            <td><asp:TextBox runat="server" id="TextBox23"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>Safe pressure B31G (PSI): </td>
                            <td><asp:TextBox runat="server" id="TextBox24"></asp:TextBox></td>
                            <td>Burst pressure: </td>
                            <td><asp:TextBox runat="server" id="TextBox25"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td>ERF:</td>
                            <td><asp:TextBox runat="server" id="TextBox26"></asp:TextBox></td>
                            <td> </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style1">ความเห็น</td>
                            <td class="auto-style1"><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox27" /></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button2" runat="server" Text="Save" /></td>
                        </tr>

                    </table>


                </div>
            
            </div>
        

            <div class="info_executive">
                <h3>Internal corrosion control system</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>
                                Corrosion Inhibitor:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="summaryLow" GroupName="ciiccs" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Yes
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton1" GroupName="ciiccs" runat="server" />
                            </td>
                            <td>
                                No
                            </td>
                        </tr>
                         <tr>
                            <td>
                               Corrosion Coupon:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton2" GroupName="cicc" runat="server" />
                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton3" GroupName="cicc" runat="server" />
                            </td>
                            <td>
                                No
                            </td>
                        </tr>

                        <tr>
                            <td>
                               Corrosion Probe:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton4" GroupName="cicp" runat="server" />
                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton5" GroupName="cicp" runat="server" />
                            </td>
                            <td>
                                No
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox28"></asp:TextBox>
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
                <h3>Latest maintainance activities</h3>
                <div class="info_executive_in">
                    <table>
                        <tr>
                            <td>Year of CIPS/DCVG:</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox29"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Year of MFL PIG:</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox30"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Year of GEO PIG:</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox31"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td><asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox32"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
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
                                <asp:RadioButton ID="RadioButton6" GroupName="ecrasum" runat="server" />
                            </td>
                            <td>
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton7" GroupName="ecrasum" runat="server" />
                            </td>
                            <td>
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
                                <asp:RadioButton ID="RadioButton8" GroupName="ecracp" runat="server" />
                            </td>
                            <td>
                                Within criteria
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton9" GroupName="ecracp" runat="server" />
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
                                <asp:RadioButton ID="RadioButton10" GroupName="ecranscp" runat="server" />
                            </td>
                            <td>
                                0
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton11" GroupName="ecranscp" runat="server" />
                            </td>
                            <td>
                                0-5
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton12" GroupName="ecranscp" runat="server" />
                            </td>
                            <td>
                                >5
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton13" GroupName="ecranscp" runat="server" />
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
                                <asp:RadioButton ID="RadioButton14" GroupName="cdsncd" runat="server" />
                            </td>
                            <td>
                                No coating defect
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton15" GroupName="cdsncd" runat="server" />
                            </td>
                            <td>
                                Minor (Category 1:1% < IR < 15%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton16" GroupName="cdsncd" runat="server" />
                            </td>
                            <td>
                                Moderate (Category 2: 16% < IR < 35%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton17" GroupName="cdsncd" runat="server" />
                            </td>
                            <td>
                                Major (Category 3: 36%< IR < 60%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton18" GroupName="cdsncd" runat="server" />
                            </td>
                            <td>
                                Severe (Category 4: 61%< IR < 100%)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton19" GroupName="cdsncd" runat="server" />
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
                                <asp:RadioButton ID="RadioButton20" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                No AC power line is within 1,000 ft of the pipeline
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton21" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                AC power line is nearby but preventive measures are taken
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton22" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                AC power line is nearby, no preventive action
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton23" GroupName="ac" runat="server" />
                            </td>
                            <td>
                                Unknown
                            </td>
                        </tr>
                        

                        <tr>
                            <td>
                                External corrosion defect by MFL PIG:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton24" GroupName="ecrdmp" runat="server" />
                            </td>
                            <td>
                                depth > 60% w.t.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton25" GroupName="ecrdmp" runat="server" />
                            </td>
                            <td>
                                40 % w.t. < depth < 60 %w.t.
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton26" GroupName="ecrdmp" runat="server" />
                            </td>
                            <td>
                                20 % w.t. < depth < 40 %w.t.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton27" GroupName="ecrdmp" runat="server" />
                            </td>
                            <td>
                                depth < 20 % w.t. 
                            </td>
                        </tr>


                        <tr>
                            <td>
                                External corrosion rate by PIG:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton28" GroupName="ecrp" runat="server" />
                            </td>
                            <td>
                                < 0.13 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton29" GroupName="ecrp" runat="server" />
                            </td>
                            <td>
                                0.13 – 0.2 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton30" GroupName="ecrp" runat="server" />
                            </td>
                            <td>
                                0.21 – 0.38 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton31" GroupName="ecrp" runat="server" />
                            </td>
                            <td>
                                > 0.38 mm/yr
                            </td>
                        </tr>


                        <tr>
                            <td>Detail :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox33"></asp:TextBox>
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
                                <asp:RadioButton ID="RadioButton32" GroupName="cdsncd" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton33" GroupName="cdsncd" runat="server" />
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
                                <asp:RadioButton ID="RadioButton34" GroupName="wcm" runat="server" />
                            </td>
                            <td>
                                &lt;7 lb/MMscfd</td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton35" GroupName="wcm" runat="server" />
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
                                <asp:RadioButton ID="RadioButton36" GroupName="dpu" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &gt; Dew Point</span></td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="RadioButton37" GroupName="dpu" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &lt; Dew Point (≤ 7 days per year)</span></td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="RadioButton38" GroupName="dpu" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Min Operating Temperature &lt; Dew Point (≤ 30 days per year)</span></td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="RadioButton39" GroupName="dpu" runat="server" />
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
                                 <asp:RadioButton ID="RadioButton40" GroupName="co2c" runat="server" />
                            </td>
                            <td>
                                <span style="color: rgb(0, 0, 0); font-family: arial, sans, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">CO2 %mol &lt;=2</span></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:RadioButton ID="RadioButton41" GroupName="co2c" runat="server" />
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
                                <asp:RadioButton ID="RadioButton42" GroupName="h2s" runat="server" />
                            </td>
                            <td class="auto-style1">
                               Partial pressure H2S <= 0.05
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton43" GroupName="h2s" runat="server" />
                            </td>
                            <td>
                                Partial pressure H2S > 0.05
                            </td>
                        </tr>
                        


                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox34"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox35"></asp:TextBox>
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
                                <asp:RadioButton ID="RadioButton44" GroupName="mdtsum" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton45" GroupName="mdtsum" runat="server" />
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
                                <asp:RadioButton ID="RadioButton46" GroupName="mdtccd" runat="server" />
                            </td>
                            <td>
                                yes</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton47" GroupName="mdtccd" runat="server" />
                            </td>
                            <td>
                                No    
                            </td>
                        </tr>

                        <tr>
                            <td>
                                Dent (Detected by GEO PIG):
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton48" GroupName="dent" runat="server" />
                            </td>
                            <td>
                                yes</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton49" GroupName="dent" runat="server" />
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
                                <asp:RadioButton ID="RadioButton50" GroupName="al" runat="server" />
                            </td>
                            <td>
                                High activity level
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton51" GroupName="al" runat="server" />
                            </td>
                            <td>
                                Medium activity level
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton52" GroupName="al" runat="server" />
                            </td>
                            <td>
                                Low activity level
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton53" GroupName="al" runat="server" />
                            </td>
                            <td>
                                Non
                            </td>
                        </tr>

                        <tr>
                            <td>
                                ROW condition:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton54" GroupName="row" runat="server" />
                            </td>
                            <td>
                                poor
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton55" GroupName="row" runat="server" />
                            </td>
                            <td>
                                average
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton56" GroupName="row" runat="server" />
                            </td>
                            <td>
                                good
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton57" GroupName="row" runat="server" />
                            </td>
                            <td>
                                excellent
                            </td>
                        </tr>

                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox36"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox37"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button6" runat="server" Text="Save"  /></td>
                        </tr>

                    </table>
                </div>
            </div>



            <div class="info_executive">
                <h3>Third party interference </h3>
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
                                <asp:RadioButton ID="RadioButton58" GroupName="tpisum" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton59" GroupName="tpisum" runat="server" />
                            </td>
                            <td>
                                High Risk
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox38"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox39"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td> <asp:Button ID="Button7" runat="server" Text="Save" OnClick="Button1_Click" /></td>
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
                                <asp:RadioButton ID="RadioButton60" GroupName="lgssum" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Yes
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton61" GroupName="lgssum" runat="server" />
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
                                <asp:RadioButton ID="RadioButton62" GroupName="eps" runat="server" />
                            </td>
                            <td>
                                All buried
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton63" GroupName="eps" runat="server" />
                            </td>
                            <td>
                                Some Areas Exposed
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton64" GroupName="eps" runat="server" />
                            </td>
                            <td>
                                Many Areas Exposed
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton65" GroupName="eps" runat="server" />
                            </td>
                            <td>
                                All Areas Exposed
                            </td>
                        </tr>


                        <tr>
                            <td>
                               Flooding susceptibility:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton66" GroupName="fs" runat="server" />
                            </td>
                            <td>
                                Never
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton67" GroupName="fs" runat="server" />
                            </td>
                            <td>
                                possible
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton68" GroupName="fs" runat="server" />
                            </td>
                            <td>
                                yes
                            </td>
                        </tr>


                        <tr>
                            <td>
                               Soil stability:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton69" GroupName="ss" runat="server" />
                            </td>
                            <td>
                                Stable
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton70" GroupName="ss" runat="server" />
                            </td>
                            <td>
                                Land movement possible
                            </td>
                        </tr>
                        <tr>
                            <td> 
                                <asp:RadioButton ID="RadioButton71" GroupName="ss" runat="server" />
                            </td>
                            <td>
                                Measure strain increase
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton72" GroupName="ss" runat="server" />
                            </td>
                            <td>
                                Land movement record
                            </td>
                        </tr>


                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox40"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox41"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button8" runat="server" Text="Save" OnClick="Button1_Click" /></td>
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
                                <asp:RadioButton ID="RadioButton73" GroupName="prhsum" runat="server" />
                            </td>
                            <td class="auto-style1">
                                Yes, see more in detail
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RadioButton74" GroupName="prhsum" runat="server" />
                            </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox42"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox43"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button10" runat="server" Text="Save" OnClick="Button1_Click" /></td>
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
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox44"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td>
                                <asp:TextBox cols="20" rows="2" TextMode="MultiLine" runat="server" id="TextBox45"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button9" runat="server" Text="Save" OnClick="Button1_Click" /></td>
                        </tr>

                    </table>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
