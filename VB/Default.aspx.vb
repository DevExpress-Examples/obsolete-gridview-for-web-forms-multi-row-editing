Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace E324
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Private list As New List(Of Record)()
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim start As Integer = ASPxGridView1.PageIndex * ASPxGridView1.SettingsPager.PageSize
			Dim [end] As Integer = (ASPxGridView1.PageIndex + 1) * ASPxGridView1.SettingsPager.PageSize
			Dim column1 As GridViewDataColumn = TryCast(ASPxGridView1.Columns("CategoryName"), GridViewDataColumn)
			Dim column2 As GridViewDataColumn = TryCast(ASPxGridView1.Columns("Description"), GridViewDataColumn)
			For i As Integer = start To [end] - 1
				Dim txtBox1 As ASPxTextBox = CType(ASPxGridView1.FindRowCellTemplateControl(i, column1, "txtBox"), ASPxTextBox)
				Dim txtBox2 As ASPxTextBox = CType(ASPxGridView1.FindRowCellTemplateControl(i, column2, "txtBox"), ASPxTextBox)
				If txtBox1 Is Nothing OrElse txtBox2 Is Nothing Then
					Continue For
				End If
'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim id_Renamed As Integer = Convert.ToInt32(ASPxGridView1.GetRowValues(i, ASPxGridView1.KeyFieldName))
				list.Add(New Record(id_Renamed, txtBox1.Text, txtBox2.Text))
			Next i
		End Sub

		Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs)
			If e.Parameters = "post" Then
				For i As Integer = 0 To list.Count - 1
					AccessDataSource1.UpdateParameters("CategoryName").DefaultValue = list(i).CategoryName
					AccessDataSource1.UpdateParameters("Description").DefaultValue = list(i).Description
					AccessDataSource1.UpdateParameters("CategoryID").DefaultValue = list(i).Id.ToString()
					'AccessDataSource1.Update();  //Uncomment this line to update data!
				Next i
				ASPxGridView1.DataBind()
			End If
		End Sub
	End Class
End Namespace