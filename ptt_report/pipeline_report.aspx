<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="pipeline_report.aspx.cs" Inherits="ptt_report.pipeline_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn {
            width:80px;
            margin:2px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mini_head2">Pipeline Integrity Report
    </h3>
    <div class="serchRed">
        <table>
            <tr>
                <td>Year : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlyear" runat="server" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>Type : 
                </td>
                <td>
                    <asp:DropDownList ID="ddltype" runat="server" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>Permit : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlpermit" runat="server" OnSelectedIndexChanged="ddlpermit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" class="btn btn-gray" />
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
                <asp:BoundField DataField="type" HeaderText="Type" />
                <asp:BoundField DataField="permit" HeaderText="Permit" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="pipeline_status" HeaderText="Pipline" />
                <asp:BoundField DataField="internal_status" HeaderText="Internal corrosion control system" />
                <asp:BoundField DataField="last_maintenance_status" HeaderText="Latest maintenance activities" />
                <asp:BoundField DataField="external_corrosion_status" HeaderText="External Corrosion" />
                <asp:BoundField DataField="internal_corrosion_status" HeaderText="Internal Corrosion" />
                <asp:BoundField DataField="mechanical_status" HeaderText="Mechanical damage" />
                <asp:BoundField DataField="third_party_status" HeaderText="Third party interference " />
                <asp:BoundField DataField="loss_status" HeaderText="Loss of ground support " />
                <asp:BoundField DataField="pipeline_repair_status" HeaderText="Pipeline Repair History" />

                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>
                        <asp:HiddenField ID="hddrepid" runat="server" Value='<%# Eval("id") %>' />
                        <asp:HiddenField ID="hddyear" runat="server" Value='<%# Eval("year") %>' />
                        <asp:HiddenField ID="hddtype" runat="server" Value='<%# Eval("type") %>' />
                        <asp:HiddenField ID="hddpermit" runat="server" Value='<%# Eval("permit") %>' />

                        <asp:Button ID="btnEditPremit" runat="server" Text="Edit Premit" OnClick="btnEditPremit_Click" Visible="false" class="btn btn-info" />
                        <asp:Button ID="btnmanage" runat="server" Text="Manage" OnClick="btnmanage_Click" Visible="false" class="btn btn-info" />
                        <asp:Button ID="btndownload" runat="server" Text="Download" Visible="false" class="btn btn-info" />
                        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" Visible="false" class="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>



            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>
    </div>
</asp:Content>
