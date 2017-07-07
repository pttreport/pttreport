<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage2.Master" AutoEventWireup="true" CodeBehind="permitappendixH.aspx.cs" Inherits="ptt_report.permitappendixH" %>



<asp:Content ID="es_form" ContentPlaceHolderID="ChildContent2" runat="server">
      <style>
        #menuleft09 {
            background: #0c7fd2;
        }
          .auto-style1 {
              height: 20px;
          }
          .info_executive_in input[type="submit"] {
            float:none;
        }
    </style>

   

    <div class="bar_qr">
        Year: 2559  Permit: กท2310027
                   
        <asp:Label ID="lbCustype" runat="server" Text="-"></asp:Label>
        <asp:Button ID="btnSaveVer" runat="server" Text="Save Version" class="btn" />
        <asp:Button ID="btnExport" runat="server" Text="Export Report" class="btn" />
        <asp:Button ID="Button1" runat="server" Text="History" class="btn" />
        
    </div>

    <div id="thirdPartyInterfaceForm" style="background-color: #FFFFFF">
        <div id="patrolFormTable">
             <h3 class="barBlue">
                 ภาคผนวก จ.
                 <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" class="btn btn-info" />
 
            </h3>
            <div class="info_executive">
                <h3>ผลการลาดตระเวนตรวจแนวท่อส่งก๊าซธรรมชาติ</h3>
                <div class="info_executive_in">
                    <table class="col6">
                        <tr>
                            <td class="auto-style1" colspan="2">
                                 <asp:Button ID="Button3" runat="server" Text="Create" CssClass="btn" />
                                        
                                <table>
                                    <tr>
                                        <td>RouteCode :</td>
                                        
                                        <td><asp:TextBox ID="PermitAppendixHRouteCode" runat="server" BackColor="#99FF99"></asp:TextBox></td>
                                        <td>2 nd half year :</td>
                                        <td><asp:FileUpload ID="FileUpload1" runat="server" BackColor="#99FF99" /></td>
                                    </tr>
                                    <tr>
                                        <td>1 st half yea :</td>
                                        <td><asp:FileUpload ID="FileUpload2" runat="server" BackColor="#99FF99" /></td>
                                        <td colspan="2"><asp:Button ID="Button2" runat="server" Text="Delete"  class="btn btn-danger" /></td>
                                     
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>ความเห็น : </td>
                            <td class="auto-style1">

                                <asp:TextBox ID="PermitCerfNumber" runat="server" Columns="60"></asp:TextBox>

                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div>
                <asp:Button ID="PermitFormSaveSubmit" runat="server" Text="Save" class="btn" OnClick="PermitFormSaveSubmit_Click" />
            </div>

        </div>
    </div>

</asp:Content>
