using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace ControlManager
{
    public sealed partial class acBandGridViewFilterEditor : BaseMenuDialog
    {


        public override void BarCodeScanInput(string barcode)
        {


        }

        private acBandGridView _View = null;

        private string _FieldName = null;

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }

        Dictionary<string, object> _FilterList = new Dictionary<string, object>();


        public acBandGridViewFilterEditor(acBandGridView view, string fieldName)
        {
            InitializeComponent();

            _View = view;

            _FieldName = fieldName;


            this.Text = view.Columns[_FieldName].Caption + " - " + this.Text;


            DataTable data = _View.GridControl.DataSource as DataTable;


            foreach (DataRow row in data.Rows)
            {

                if (row.RowState == DataRowState.Deleted) continue;
                
                
                acBandedGridColumn col = (acBandedGridColumn)view.Columns[_FieldName];

                string value = string.Empty;

                if (col.EditorType == acBandGridView.emEditorType.DATE)
                {
                    RepositoryItemDateEdit dateEdit = (RepositoryItemDateEdit)col.ColumnEdit;

                    value = string.Format("{0:" + dateEdit.Mask.EditMask + "}", row[_FieldName]);

                }
                else if (col.EditorType == acBandGridView.emEditorType.LOOKUP_CODE)
                {
                    RepositoryItemLookUpEdit lookupEdit = (RepositoryItemLookUpEdit)col.ColumnEdit;

                    DataTable lookupData = (DataTable)lookupEdit.DataSource;


                    DataRow[] getDataRow = lookupData.Select("CD_CODE = '" + row[_FieldName].ToString() + "'");

                    if (getDataRow.Length != 0)
                    {
                        value = getDataRow[0]["CD_NAME"].ToString();
                    }


                }
                else if (col.EditorType == acBandGridView.emEditorType.TEXT)
                {
                    RepositoryItemTextEdit textEditor = (RepositoryItemTextEdit)col.ColumnEdit;

                    TextEdit editor = new TextEdit();

                    editor.Properties.Mask.EditMask = textEditor.Mask.EditMask;
                    editor.Properties.Mask.MaskType = textEditor.Mask.MaskType;

                    editor.Properties.Mask.UseMaskAsDisplayFormat = true;


                    editor.EditValue = row[_FieldName];


                    value = editor.Text;


                }


                if (!_FilterList.ContainsKey(value))
                {

                    _FilterList.Add(value, row[_FieldName]);

                    this.checkedListBoxControl1.Items.Add(value, false);


                }
            }

            #region 이벤트 설정

            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(checkedListBoxControl1_ItemCheck);

            this.QuickFindEditor.KeyDown += new KeyEventHandler(QuickFindEditor_KeyDown);

            #endregion

        }

        private int _FindKeyIdx = -1;

        void QuickFindEditor_KeyDown(object sender, KeyEventArgs e)
        {


            string findKey = QuickFindEditor.EditValue.toStringNull();

            if (!string.IsNullOrEmpty(findKey))
            {
                int cnt = 0;

                foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                {


                    if (_FilterList[item.Value.ToString()].ToString().Contains(findKey))
                    {

                        if (cnt > _FindKeyIdx)
                        {
                            checkedListBoxControl1.SelectedIndex = cnt;

                            _FindKeyIdx = cnt;

                            break;
                        }
                        
                    }

                    ++cnt;

                }

                if (checkedListBoxControl1.Items.Count == cnt)
                {
                    _FindKeyIdx = -1;
                }

            }


        }

        void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            string filterString = null;

            foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
            {

                if (item.CheckState == CheckState.Checked)
                {
                    string f = null;

                    if (_FilterList[item.Value.ToString()].Equals(DBNull.Value))
                    {
                        string value = "Is Null";

                        f = string.Format("[{0}] {1}", _FieldName, value);
                    }
                    else
                    {
                        string value = "'" + _FilterList[item.Value.ToString()].ToString() + "'";

                        f = string.Format("[{0}] = {1}", _FieldName, value);
                    }


                    if (!string.IsNullOrEmpty(filterString))
                    {
                        filterString += " OR ";
                    }


                    filterString += f;

                }

            }



            if (!string.IsNullOrEmpty(filterString))
            {
                //필터가 있으면 생성

                ColumnFilterInfo colFilterInfo = new ColumnFilterInfo(filterString);


                ViewColumnFilterInfo viewColFilter = new DevExpress.XtraGrid.Views.Base.ViewColumnFilterInfo(_View.Columns[_FieldName], colFilterInfo);


                _View.Columns[_FieldName].FilterInfo = colFilterInfo;
            }
            else
            {
                //필터가 없으면 초기화

                _View.ActiveFilter.Clear();
            }


        }
    }
}