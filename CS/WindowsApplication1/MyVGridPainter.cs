using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Painters;
using DevExpress.XtraVerticalGrid.ViewInfo;
using System.Drawing;
using System.Reflection;

namespace WindowsApplication1 {
    public class MyVGridPainter : VGridPainter {
        public MyVGridPainter(PaintEventHelper eventHelper)
            : base(eventHelper) {
        }
        private Rectangle GetValueBoundsByRecordIndex(DevExpress.XtraVerticalGrid.ViewInfo.BaseRowViewInfo vInfo, int recordIndex) {
            Rectangle bounds = Rectangle.Empty;
            foreach(RowValueInfo valueInfo in vInfo.ValuesInfo) {
                if(valueInfo.RecordIndex == recordIndex) {
                    bounds = valueInfo.Bounds;
                    break;
                }
            }
            return bounds;
        }
        private Rectangle GetBoundsByRecordIndex(int recordIndex, DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo vi) {
            DevExpress.XtraVerticalGrid.ViewInfo.BaseRowViewInfo vInfo = vi.RowsViewInfo[0];
            if(vInfo == null)
                return Rectangle.Empty;
            Rectangle bounds = GetValueBoundsByRecordIndex(vInfo, recordIndex);
            if(vInfo.ValuesInfo.Count > recordIndex + 2)
                bounds.Width += GetValueBoundsByRecordIndex(vInfo, recordIndex + 1).Right - bounds.Right;
            else {
                bounds.Width += vi.RowsViewInfo[0].RowRect.Right - bounds.Right;
            }
            return bounds;
        }
        protected override void DrawRowValueCellCore(CustomDrawRowValueCellEventArgs e, DevExpress.XtraEditors.Drawing.BaseEditPainter pb, DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo bvi, DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo vi) {
            if(e.Row.VisibleIndex != 0) {
                base.DrawRowValueCellCore(e, pb, bvi, vi);
                return;
            }
            if(e.RecordIndex % 2 == 0 || vi.RowsViewInfo[0].ValuesInfo[0].RecordIndex == e.RecordIndex) {
                Rectangle bounds = GetBoundsByRecordIndex(e.RecordIndex, vi);
                bvi.Bounds = bounds;
                bvi.CalcViewInfo(e.Graphics);
                EventHelper.DrawnCell.Bounds = bounds;

                FieldInfo fi = typeof(RowValueInfo).GetField("DrawFocusFrame", BindingFlags.Instance | BindingFlags.NonPublic);
                fi.SetValue(EventHelper.DrawnCell, false);

                e.Appearance.Assign(vi.PaintAppearance.RowHeaderPanel);
                base.DrawRowValueCellCore(e, pb, bvi, vi);
                return;
            }
        }
        protected override void DrawLines(DevExpress.XtraVerticalGrid.ViewInfo.Lines LinesInfo, Rectangle client) {
            //base.DrawLines(LinesInfo, client);
        }
    }
}
