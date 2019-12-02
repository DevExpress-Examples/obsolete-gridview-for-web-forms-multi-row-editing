<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E324.Default" %>

<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="CategoryID" 
                DataSourceID="AccessDataSource1" Width="599px" ClientInstanceName="grid" 
                OnCustomCallback="ASPxGridView1_CustomCallback">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
                        <DataItemTemplate>
                            <dx:ASPxTextBox ID="txtBox" Width="100%" runat="server" Value='<%# Eval("CategoryName")%>'></dx:ASPxTextBox>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
                        <DataItemTemplate>                
                            <dx:ASPxTextBox ID="txtBox" Width="100%" runat="server" Value='<%# Eval("Description")%>'></dx:ASPxTextBox>                
                        </DataItemTemplate>                        
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT * FROM [Categories]" 
            UpdateCommand="UPDATE [Categories] SET [CategoryName] = ?, [Description] = ? WHERE [CategoryID] = ?">
            <UpdateParameters>
                <asp:Parameter Name="CategoryName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
        
        <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" Text="Post Modifications"
            Width="217px">
            <ClientSideEvents Click="function(s, e) {
	grid.PerformCallback('post');
}" />
        </dx:ASPxButton>
        </div>
    </form>
</body>
</html>
