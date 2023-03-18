using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using BizManager;
using System.Linq;

namespace STD
{
    public sealed partial class STD07A_D2A : BaseMenuDialog
    {
        string _mcCode;
        DataSet _paramSet;
        
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }


        public override void BarCodeScanInput(string barcode)
        {


        }

        public STD07A_D2A(string mcCode, DataSet paramSet)
        {
            InitializeComponent();

            this._mcCode = mcCode;
            this._paramSet = paramSet;
        }

        public override void DialogInit()
        {

            acGridView1.GridType = acGridView.emGridType.SEARCH;

            acGridView1.AddDateEdit("GIVE_DATE", "지급일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("GIVE_QTY", "지급수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddDateEdit("RTN_DATE", "반납일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("RTN_QTY", "반납수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);
            acGridView1.AddDateEdit("TDU_DATE", "폐기일", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddTextEdit("TDU_QTY", "폐기수량", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.QTY);

            acGridView1.Columns["GRID_ROW_SEQ"].Visible = false;
            base.DialogInit();
        }

        public override void DialogInitComplete()
        {
            base.DialogInitComplete();

            SetGridViewData();
        }


        public override void DialogNew()
        {
            base.DialogNew();
        }

        public override void DialogOpen()
        {
            base.DialogOpen();
        }

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창 고정

            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;

        }

        private void SetGridViewData()
        {
            //다 같은 공구
            var gRows = _paramSet.Tables["DT_GIVE"]
                                        .Select("GIVE_MC = '" + _mcCode + "'");
            DataTable dtGive = gRows.Any() ? gRows.CopyToDataTable() : _paramSet.Tables["DT_GIVE"].Copy().Clone();

            var rRows = _paramSet.Tables["DT_RETURN"]
                                          .AsEnumerable()
                                          .Where(w => dtGive.Select("GIVE_NO='" + w.Field<string>("GIVE_NO") + "' AND GIVE_SEQ = " + w.Field<int>("GIVE_SEQ") + "").Any());
            DataTable dtReturn = rRows.Any() ? rRows.CopyToDataTable() : _paramSet.Tables["DT_RETURN"].Copy().Clone();

            var dRows = _paramSet.Tables["DT_DISUSE"]
                                          .AsEnumerable()
                                          .Where(w => dtGive.Select("TL_LOT = '" + w.Field<string>("TL_LOT") + "'").Any());
            DataTable dtDisuse = dRows.Any() ? dRows.CopyToDataTable() : _paramSet.Tables["DT_DISUSE"].Copy().Clone();

            var vGive = dtGive.AsEnumerable().GroupBy(g => new { GIVE_DATE = g.Field<string>("GIVE_DATE") })
                                            .Select(r => new { GIVE_DATE = r.Key.GIVE_DATE, GIVE_QTY = r.Count() });
            var vReturn = dtReturn.AsEnumerable().GroupBy(g => new { RTN_DATE = g.Field<string>("RTN_DATE") })
                                            .Select(r => new { RTN_DATE = r.Key.RTN_DATE, RTN_QTY = r.Count() });
            var vDisuse = dtDisuse.AsEnumerable().GroupBy(g => new { TDU_DATE = g.Field<string>("TDU_DATE") })
                                            .Select(r => new { TDU_DATE = r.Key.TDU_DATE, TDU_QTY = r.Count() });

            DataTable result = new DataTable();
            result.Columns.Add("GIVE_DATE", typeof(string));
            result.Columns.Add("GIVE_QTY", typeof(string));
            result.Columns.Add("RTN_DATE", typeof(string));
            result.Columns.Add("RTN_QTY", typeof(string));
            result.Columns.Add("TDU_DATE", typeof(string));
            result.Columns.Add("TDU_QTY", typeof(string));

            int index = 0;
            int cntGive = vGive.Count();
            int cntRtn = vReturn.Count();
            int cntTdu = vDisuse.Count();

            while ((result.Rows.Count < cntGive)
                    || (result.Rows.Count < cntRtn)
                    || (result.Rows.Count < cntTdu))
            {
                DataRow resultRow = result.NewRow();

                if (index < cntGive)
                {
                    resultRow["GIVE_DATE"] = vGive.ElementAt(index).GIVE_DATE;
                    resultRow["GIVE_QTY"] = vGive.ElementAt(index).GIVE_QTY;
                }

                if (index < cntRtn)
                {
                    resultRow["RTN_DATE"] = vReturn.ElementAt(index).RTN_DATE;
                    resultRow["RTN_QTY"] = vReturn.ElementAt(index).RTN_QTY;
                }

                if (index < cntTdu)
                {
                    resultRow["TDU_DATE"] = vDisuse.ElementAt(index).TDU_DATE;
                    resultRow["TDU_QTY"] = vDisuse.ElementAt(index).TDU_QTY;
                }
                result.Rows.Add(resultRow);

                index++;
            }

            acGridView1.GridControl.DataSource = result;
        }
    }
}