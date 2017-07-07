<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuarterlyReport.aspx.cs" Inherits="ptt_report.QuarterlyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mini_head2">
        Quarterly Report
    </h3>
    <div class="serchRed">
        <table style="width:100%">
            <tr>
                <td style="width:4%">Year : 
                </td>
                <td style="width:6%">
                    <asp:DropDownList ID="ddlyear" runat="server" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td style="width:6%">Quarter : 
                </td>
                <td style="width:3%">
                    <asp:DropDownList ID="ddlquarter" runat="server" OnSelectedIndexChanged="ddlquarter_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td style="width:10%">Customer Type : 
                </td>
                <td style="width:10%">
                    <asp:DropDownList ID="ddlcustype" runat="server" OnSelectedIndexChanged="ddlcustype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td style="width:5%">Status : 
                </td>
                <td style="width:6%">
                    <asp:DropDownList ID="ddlstatus" runat="server" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td style="width:46%">
                </td>
                <td>
                    <asp:Button ID="btncreate" runat="server" Text="Create" OnClick="btncreate_Click" class="btn btn-gray" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridView_rep_list" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            OnPageIndexChanging="GridView_rep_list_PageIndexChanging" OnRowDataBound="GridView_rep_list_RowDataBound"
            ShowFooter="false" class="tb_red">
            <Columns>

                <asp:BoundField DataField="year" HeaderText="Year" />
                <asp:BoundField DataField="quarter" HeaderText="Quarter" />
                <asp:BoundField DataField="cus_type" HeaderText="Customer Type" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="exe_status" HeaderText="Executive summary" />
                <asp:BoundField DataField="pm_cm_status" HeaderText="PM & CM" />
                <asp:BoundField DataField="external_status" HeaderText="External Corrosion" />
                <asp:BoundField DataField="internal_status" HeaderText="Internal Corrosion" />
                <asp:BoundField DataField="piping" HeaderText="Piping" />
                <asp:BoundField DataField="offshore" HeaderText="Offshore" />
                <asp:BoundField DataField="other_pro" HeaderText="Other Projects" />

                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>
                        <asp:HiddenField ID="hddrepid" runat="server" Value='<%# Eval("id") %>' />
                        <asp:HiddenField ID="hddyear" runat="server" Value='<%# Eval("year") %>' />
                        <asp:HiddenField ID="hddquarter" runat="server" Value='<%# Eval("quarter") %>' />
                        <asp:HiddenField ID="hddcustype" runat="server" Value='<%# Eval("cus_type") %>' />

                        <asp:Button ID="btnmanage" runat="server" Text="Manage" OnClick="btnmanage_Click" Visible="false" CssClass="btn btn-info" />
                        <asp:Button ID="btndownload" runat="server" Text="Download"  Visible="false" CssClass="btn btn-info"/>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" Visible="false" CssClass="btn btn-danger"  />
                    </ItemTemplate>
                </asp:TemplateField>



            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"  FirstPageText="First" LastPageText="Last"/>
        </asp:GridView>
    </div>
</asp:Content>
