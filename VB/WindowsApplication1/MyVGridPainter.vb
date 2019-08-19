Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Painters
Imports DevExpress.XtraVerticalGrid.ViewInfo
Imports System.Drawing
Imports System.Reflection

Namespace WindowsApplication1
	Public Class MyVGridPainter
		Inherits VGridPainter

		Public Sub New(ByVal eventHelper As PaintEventHelper)
			MyBase.New(eventHelper)
		End Sub
		Private Function GetValueBoundsByRecordIndex(ByVal vInfo As DevExpress.XtraVerticalGrid.ViewInfo.BaseRowViewInfo, ByVal recordIndex As Integer) As Rectangle
			Dim bounds As Rectangle = Rectangle.Empty
			For Each valueInfo As RowValueInfo In vInfo.ValuesInfo
				If valueInfo.RecordIndex = recordIndex Then
					bounds = valueInfo.Bounds
					Exit For
				End If
			Next valueInfo
			Return bounds
		End Function
		Private Function GetBoundsByRecordIndex(ByVal recordIndex As Integer, ByVal vi As DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo) As Rectangle
			Dim vInfo As DevExpress.XtraVerticalGrid.ViewInfo.BaseRowViewInfo = vi.RowsViewInfo(0)
			If vInfo Is Nothing Then
				Return Rectangle.Empty
			End If
			Dim bounds As Rectangle = GetValueBoundsByRecordIndex(vInfo, recordIndex)
			If vInfo.ValuesInfo.Count > recordIndex + 2 Then
				bounds.Width += GetValueBoundsByRecordIndex(vInfo, recordIndex + 1).Right - bounds.Right
			Else
				bounds.Width += vi.RowsViewInfo(0).RowRect.Right - bounds.Right
			End If
			Return bounds
		End Function
		Protected Overrides Sub DrawRowValueCellCore(ByVal e As CustomDrawRowValueCellEventArgs, ByVal pb As DevExpress.XtraEditors.Drawing.BaseEditPainter, ByVal bvi As DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo, ByVal vi As DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo)
			If e.Row.VisibleIndex <> 0 Then
				MyBase.DrawRowValueCellCore(e, pb, bvi, vi)
				Return
			End If
			If e.RecordIndex Mod 2 = 0 OrElse vi.RowsViewInfo(0).ValuesInfo(0).RecordIndex = e.RecordIndex Then
				Dim bounds As Rectangle = GetBoundsByRecordIndex(e.RecordIndex, vi)
				bvi.Bounds = bounds
				bvi.CalcViewInfo(e.Graphics)
				EventHelper.DrawnCell.Bounds = bounds

				Dim fi As FieldInfo = GetType(RowValueInfo).GetField("DrawFocusFrame", BindingFlags.Instance Or BindingFlags.NonPublic)
				fi.SetValue(EventHelper.DrawnCell, False)

				e.Appearance.Assign(vi.PaintAppearance.RowHeaderPanel)
				MyBase.DrawRowValueCellCore(e, pb, bvi, vi)
				Return
			End If
		End Sub
		Protected Overrides Sub DrawLines(ByVal LinesInfo As DevExpress.XtraVerticalGrid.ViewInfo.Lines, ByVal client As Rectangle)
			'base.DrawLines(LinesInfo, client);
		End Sub
	End Class
End Namespace
