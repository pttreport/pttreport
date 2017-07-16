<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="t_p_rep.aspx.cs" Inherits="ptt_report.t_p_rep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn {
            width: 80px;
            margin: 2px 0px;
        }
    </style>

    <script src="Scripts/jquery.min.js" type="text/javascript"></script>

    <script src="Scripts/jquery.searchabledropdown-1.0.8.min.js" type="text/javascript"></script>

    <script type="text/javascript">
     $(document).ready(function () {
         $(".ddlpermit").searchable();
    });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mini_head2">ธ.พ. Report
    </h3>
    <div class="serchRed">
        <table style="width:100%">
            <tr>
                <td>Year : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlyear" runat="server" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>

                <td>Permit : 
                </td>
                <td>
                    <asp:DropDownList ID="ddlpermit" CssClass="ddlpermit" runat="server" OnSelectedIndexChanged="ddlpermit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" class="btn btn-gray" />
                </td>
                <td style="width:60%">
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
                <asp:BoundField DataField="permit" HeaderText="Permit" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="patrolling_status" HeaderText="Patrolling" />
                <asp:BoundField DataField="cp_status" HeaderText="CP" />
                <asp:BoundField DataField="ilipig_status" HeaderText="ILI PIG" />
                <asp:BoundField DataField="wall_thick_status" HeaderText="Wall thickness" />
                <asp:BoundField DataField="project_status" HeaderText="Project" />
                <asp:BoundField DataField="apendixB_status" HeaderText="ภาคผนวก  ข." />
                <asp:BoundField DataField="apendixD_status" HeaderText="ภาคผนวก  ง." />
                <asp:BoundField DataField="apendixH_status" HeaderText="ภาคผนวก  จ." />
                <asp:BoundField DataField="apendixI_status" HeaderText="ภาคผนวก  ฉ." />


                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>
                        <asp:HiddenField ID="hddrepid" runat="server" Value='<%# Eval("id") %>' />
                        <asp:HiddenField ID="hddyear" runat="server" Value='<%# Eval("year") %>' />
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
