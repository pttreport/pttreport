﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="history_1.aspx.cs" Inherits="ptt_report.history_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent2" runat="server">
    HISTORY

    <asp:GridView ID="gridview_rep_tmp" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="false" >
        <Columns>

            <asp:BoundField DataField="last_update" HeaderText="Last Update" />
            <asp:BoundField DataField="filename" HeaderText="Doc file" />
            <asp:BoundField DataField="createid" HeaderText="Update By" />

            <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                    <asp:HiddenField ID="hddfile_path" Value='<%# Eval("uri") %>' runat="server" />
                    <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>
</asp:Content>
