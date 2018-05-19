Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Data.Filtering

Namespace DXExample.Module
	Partial Public Class FilterResourcesByOwnersController
		Inherits ViewController
		Public Sub New()
			TargetObjectType = GetType(UserResource)
			TargetViewType = ViewType.ListView
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			Dim adminRole As Role = View.ObjectSpace.Session.FindObject(Of Role)(New BinaryOperator("Name", "Administrators"))
			If (CType(SecuritySystem.CurrentUser, CustomUser)).Roles.Lookup(adminRole.Oid) Is Nothing Then
				CType(View, ListView).CollectionSource.Criteria("ByUsers") = CriteriaOperator.Parse("Owners[Oid = ?] OR Owners.Count = 0", SecuritySystem.CurrentUserId)
			End If
		End Sub
	End Class
End Namespace
