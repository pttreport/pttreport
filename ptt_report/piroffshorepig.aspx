<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPagePIR.Master" AutoEventWireup="true" CodeBehind="piroffshorepig.aspx.cs" Inherits="ptt_report.piroffshorepig" %>


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
                                
                            </td>
                            <td>
                                Design Presure: 
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>Station : </td>
                            <td>

                            </td>
                            <td>MAOP (PSI): </td>
                            <td>

                            </td>
                        </tr>

                        <tr>
                            <td>
                                Length (KM):
                            </td>
                            <td>

                            </td>
                            <td>
                                MAOP Design (PSI):
                            </td>
                            <td>

                            </td>
                        </tr>

                        <tr>
                            <td>
                                Wall Thickness (inches):
                            </td>
                            <td>

                            </td>
                            <td>
                                Original Location class:
                            </td>
                            <td>

                            </td>
                        </tr>

                        <tr>
                            <td>Material Spec. : </td>
                            <td>

                            </td>
                            <td>Design Life : </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>External Coathing : </td>
                            <td>

                            </td>
                            <td>Cathodic Protection :</td>
                            <td>

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
                            <td></td>
                        </tr>

                        <tr>
                            <td>Operating Temperature (oC): </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>Gas Flow rate (MMSCFD): </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td></td>
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
                            <td></td>
                            <td>CR used for Rem. Life (Need for 1st repair): </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>Prob. of Failure: </td>
                            <td></td>
                            <td>Assessment date: </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>Overall Integrity Status(Remaining life):</td>
                            <td></td>
                            <td>Remaining Life (Yrs): </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>Overall Integrity Status(Design life):</td>
                            <td></td>
                            <td>Inspection year: </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>Safe pressure B31G (PSI): </td>
                            <td></td>
                            <td>Burst pressure: </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ERF:</td>
                            <td></td>
                            <td> </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td class="auto-style1">ความเห็น</td>
                            <td class="auto-style1"></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td></td>
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

                            </td>
                            <td class="auto-style1">
                                Yes
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comment:
                            </td>
                            <td>
                                
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

                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comment:
                            </td>
                            <td>
                                
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

                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comment:
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
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
                            <td></td>
                        </tr>
                        <tr>
                            <td>Year of MFL PIG:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Year of GEO PIG:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
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

                            </td>
                            <td>
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
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

                            </td>
                            <td>
                                Within criteria
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                Under criteria
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

                            </td>
                            <td>
                                depth > 60% w.t.
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                40 % w.t. < depth < 60 %w.t.
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                20 % w.t. < depth < 40 %w.t.
                            </td>
                        </tr>
                        <tr>
                            <td>

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

                            </td>
                            <td>
                                < 0.13 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                0.13 – 0.2 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                0.21 – 0.38 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td>

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
                            <td>MFL PIG result :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
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

                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
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

                            </td>
                            <td>
                                &lt;7 lb/MMscfd</td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                &gt; 7 lb/MMscfd</td>
                        </tr>
                        
                        
                        <tr>
                            <td>
                                Internal corrosion defect by MFL PIG:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                depth > 60% w.t.
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                40 % w.t. < depth < 60 %w.t.
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                20 % w.t. < depth < 40 %w.t.
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                depth < 20 % w.t. 
                            </td>
                        </tr>


                        <tr>
                            <td>
                                Internal corrosion rate by PIG:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                < 0.13 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                0.13 – 0.2 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                0.21 – 0.38 mm / yr
                            </td>
                        </tr>
                        <tr>
                            <td>

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
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
                        </tr>

                    </table>
                </div>
            </div>



            <div class="info_executive">
                <h3>Mechanical damage</h3>
                
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

                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
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

                            </td>
                            <td>
                                yes</td>
                        </tr>
                        <tr>
                            <td> </td>
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

                            </td>
                            <td>
                                yes</td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No    
                            </td>
                        </tr>

                       

                        <tr>
                            <td>Detail :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>Manual Detail: </td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
                        </tr>

                    </table>
                </div>
            </div>



            <div class="info_executive">
                <h3>Free span Risk Assessment </h3>
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

                            </td>
                            <td class="auto-style1">
                                Low Risk
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                High Risk
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
                        </tr>

                    </table>
                </div>
            </div>




            <div class="info_executive">
                <h3>Leakage </h3>
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

                            </td>
                            <td class="auto-style1">
                                Yes
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                         <tr>
                            <td>
                               Leakage @ Subsea pipeline:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                N/A
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Leakage @ PLEM:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                N/A
                            </td>
                        </tr>


                        <tr>
                            <td>
                               Leakage @Launcher or Receiver:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                Yes
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1"> </td>
                            <td class="auto-style1">
                                No
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                N/A
                            </td>
                        </tr>


                        <tr>
                            <td>Detail :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
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

                            </td>
                            <td class="auto-style1">
                                Yes, see more in detail
                            </td>
                        </tr>
                        <tr>
                            <td> </td>
                            <td>
                                No
                            </td>
                        </tr>
                        <tr>
                            <td>Detail :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>save</td>
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
                            <td></td>
                        </tr>

                        <tr>
                            <td>ความเห็น :</td>
                            <td></td>
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
