Imports System
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Painters

Namespace WindowsApplication1
	Public Class MyVGridControl
		Inherits VGridControl

		Public Sub New()

		End Sub

		Protected Overrides Function CreatePainterCore(ByVal eventHelper As PaintEventHelper) As VGridPainter
			Return New MyVGridPainter(eventHelper)
		End Function
	End Class
End Namespace
