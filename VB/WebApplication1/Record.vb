Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebApplication1
	Public Class Record
		Private id_Renamed As Integer
		Private categoryName_Renamed As String

		Private description_Renamed As String

		Public Sub New(ByVal id As Integer, ByVal categoryName As String, ByVal description As String)
			Me.id_Renamed = id
			Me.categoryName_Renamed = categoryName
			Me.description_Renamed = description
		End Sub
		Public ReadOnly Property Id() As Integer
			Get
				Return Me.id_Renamed
			End Get
		End Property
		Public ReadOnly Property CategoryName() As String
			Get
				Return categoryName_Renamed
			End Get
		End Property
		Public ReadOnly Property Description() As String
			Get
				Return description_Renamed
			End Get
		End Property

	End Class
End Namespace