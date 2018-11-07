<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=B88D1754D700E49A"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=B88D1754D700E49A"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		&nbsp; &nbsp; &nbsp;&nbsp;
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
			KeyFieldName="CategoryID" DataSourceID="AccessDataSource1" Width="599px" ClientInstanceName="grid" OnCustomCallback="ASPxGridView1_CustomCallback">
			<Columns>
				<dxwgv:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
					<DataItemTemplate>
						<dxe:ASPxTextBox ID="txtBox" Width="100%" runat="server" Value='<%#Eval("CategoryName")%>'></dxe:ASPxTextBox>
					</DataItemTemplate>
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
					<DataItemTemplate>                
						<dxe:ASPxTextBox ID="txtBox" Width="100%" runat="server" Value='<%#Eval("Description")%>'></dxe:ASPxTextBox>                
					</DataItemTemplate>                        
				</dxwgv:GridViewDataTextColumn>
			</Columns>
		</dxwgv:ASPxGridView>
		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
			SelectCommand="SELECT * FROM [Categories]" 
			UpdateCommand="UPDATE [Categories] SET [CategoryName] = ?, [Description] = ? WHERE [CategoryID] = ?">
			<UpdateParameters>
				<asp:Parameter Name="CategoryName" Type="String" />
				<asp:Parameter Name="Description" Type="String" />
				<asp:Parameter Name="CategoryID" Type="Int32" />
			</UpdateParameters>
		</asp:AccessDataSource>
		&nbsp;&nbsp;&nbsp;
		<dxe:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" Text="Post Modifications"
			Width="217px">
			<ClientSideEvents Click="function(s, e) {
	grid.PerformCallback('post');
}" />
		</dxe:ASPxButton>
	</div>
	</form>
</body>
</html>