using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Utils.Paint;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;
using DevExpress.Utils.Drawing;

namespace ControlManager
{
    public class acAdvBandPaintHelper : GridPainter
    {
        AdvBandedGridView _View;
        GridBand[] _Bands;
        public acAdvBandPaintHelper(AdvBandedGridView view, GridBand[] bands)
            : base(view)
        {
            _View = view;
            _Bands = bands;
            _View.GridControl.Paint += new PaintEventHandler(GridControl_Paint);
            _View.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(_View_CustomDrawColumnHeader);
            _View.CustomDrawBandHeader += new BandHeaderCustomDrawEventHandler(_View_CustomDrawBandHeader);
        }

        void _View_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
        {
            if (_Bands.Contains(e.Band))
                e.Handled = true;
        }

        void _View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (((e.Column is BandedGridColumn)) && (_Bands.Contains((e.Column as BandedGridColumn).OwnerBand)))
                e.Handled = true;
        }

        void GridControl_Paint(object sender, PaintEventArgs e)
        {
            foreach (GridBand band in _Bands)
                foreach (BandedGridColumn column in band.Columns)
                    DrawColumnHeader(new GraphicsCache(e.Graphics), column);
        }

        public void DrawColumnHeader(GraphicsCache cache, GridColumn column)
        {
            AdvBandedGridViewInfo viewInfo = _View.GetViewInfo() as AdvBandedGridViewInfo;

            GridColumnInfoArgs colInfo = viewInfo.ColumnsInfo[column];
            GridBandInfoArgs bandInfo = getBandInfo(viewInfo.BandsInfo,(column as BandedGridColumn).OwnerBand);
            if (colInfo == null || bandInfo == null)
                return;
            colInfo.Cache = cache;

            int top = bandInfo.Bounds.Top;
            Rectangle rect = colInfo.Bounds;
            int delta = rect.Top - top;
            rect.Y = top;
            rect.Height += delta;
            colInfo.Bounds = rect;
            colInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            ElementsPainter.Column.CalcObjectBounds(colInfo);
            ElementsPainter.Column.DrawObject(colInfo);
        }
        GridBandInfoArgs getBandInfo(GridBandInfoCollection bands, GridBand band)
        {
            GridBandInfoArgs info = bands[band];
            if (info != null)
                return info;
            else
                foreach (GridBandInfoArgs bandInfo in bands)
                {
                    if (bandInfo.Children != null)
                    {
                        info = getBandInfo(bandInfo.Children, band);
                        if (info != null)
                            return info;
                    }
                }
            return null;
        }
    }
}
