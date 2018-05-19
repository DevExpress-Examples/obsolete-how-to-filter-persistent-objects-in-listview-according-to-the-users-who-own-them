Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace DXExample.Module
	<DefaultClassOptions> _
	Public Class CustomUser
		Inherits User
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Association("Users-Resources")> _
		Public ReadOnly Property Resources() As XPCollection(Of UserResource)
			Get
				Return GetCollection(Of UserResource)("Resources")
			End Get
		End Property
	End Class

End Namespace
