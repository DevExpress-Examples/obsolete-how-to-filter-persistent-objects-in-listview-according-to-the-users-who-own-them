Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace DXExample.Module
	<DefaultClassOptions> _
	Public Class UserResource
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _ResourceName As String
		Public Property ResourceName() As String
			Get
				Return _ResourceName
			End Get
			Set(ByVal value As String)
				SetPropertyValue("ResourceName", _ResourceName, value)
			End Set
		End Property
		<Association("Users-Resources")> _
		Public ReadOnly Property Owners() As XPCollection(Of CustomUser)
			Get
				Return GetCollection(Of CustomUser)("Owners")
			End Get
		End Property
	End Class

End Namespace
