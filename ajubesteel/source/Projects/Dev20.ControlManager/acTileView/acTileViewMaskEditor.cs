using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace ControlManager
{
    public sealed partial class acTileViewMaskEdit : BaseMenuDialog
    {


        public override void BarCodeScanInput(string barcode)
        {


        }

        private acGridColumn _Column = null;

        public acGridColumn Column
        {
            get { return _Column; }
            set { _Column = value; }
        }


        public acTileViewMaskEdit(acGridColumn col)
        {
            InitializeComponent();

            _Column = col;

            #region 컨트롤 설정

            this.Text = col.Caption + " " + "마스크 설정";


            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.Custom);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.DateTime);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.None);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.Numeric);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.RegEx);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.Regular);
            comboBoxEdit1.Properties.Items.Add(DevExpress.XtraEditors.Mask.MaskType.Simple);



            if (_Column.ColumnEdit is RepositoryItemTextEdit)
            {
                RepositoryItemTextEdit item = (RepositoryItemTextEdit)_Column.ColumnEdit; ;

                comboBoxEdit1.EditValue = item.Mask.MaskType;
                acTextEdit1.EditValue = item.Mask.EditMask;

            }
            else if (_Column.ColumnEdit is RepositoryItemTimeEdit)
            {
                RepositoryItemTimeEdit item = (RepositoryItemTimeEdit)_Column.ColumnEdit;
                comboBoxEdit1.EditValue = item.Mask.MaskType;
                acTextEdit1.EditValue = item.Mask.EditMask;
            }
            else if (_Column.ColumnEdit is RepositoryItemDateEdit)
            {
                RepositoryItemDateEdit item = (RepositoryItemDateEdit)_Column.ColumnEdit;
                comboBoxEdit1.EditValue = item.Mask.MaskType;
                acTextEdit1.EditValue = item.Mask.EditMask;
            }
            else if (_Column.ColumnEdit is RepositoryItemMemoEdit)
            {
                RepositoryItemMemoEdit item = (RepositoryItemMemoEdit)_Column.ColumnEdit;
                comboBoxEdit1.EditValue = item.Mask.MaskType;
                acTextEdit1.EditValue = item.Mask.EditMask;
            }
            else if (_Column.ColumnEdit is RepositoryItemMemoExEdit)
            {
                RepositoryItemMemoExEdit item = (RepositoryItemMemoExEdit)_Column.ColumnEdit;
                comboBoxEdit1.EditValue = item.Mask.MaskType;
                acTextEdit1.EditValue = item.Mask.EditMask;
            }

            #endregion


            #region 이벤트 설정

            comboBoxEdit1.EditValueChanged += new EventHandler(comboBoxEdit1_EditValueChanged);
            acTextEdit1.EditValueChanged += new EventHandler(acTextEdit1_EditValueChanged);

            #endregion
        }

        void acTextEdit1_EditValueChanged(object sender, EventArgs e)
        {


            if (_Column.ColumnEdit is RepositoryItemTextEdit)
            {
                RepositoryItemTextEdit item = (RepositoryItemTextEdit)_Column.ColumnEdit; ;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }
            else if (_Column.ColumnEdit is RepositoryItemTimeEdit)
            {
                RepositoryItemTimeEdit item = (RepositoryItemTimeEdit)_Column.ColumnEdit;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }
            else if (_Column.ColumnEdit is RepositoryItemDateEdit)
            {
                RepositoryItemDateEdit item = (RepositoryItemDateEdit)_Column.ColumnEdit;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }
            else if (_Column.ColumnEdit is RepositoryItemMemoEdit)
            {
                RepositoryItemMemoEdit item = (RepositoryItemMemoEdit)_Column.ColumnEdit;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }
            else if (_Column.ColumnEdit is RepositoryItemMemoExEdit)
            {
                RepositoryItemMemoExEdit item = (RepositoryItemMemoExEdit)_Column.ColumnEdit;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }

            _Column.View.RefreshData();
        }

        void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (_Column.ColumnEdit is RepositoryItemTextEdit)
            {
                RepositoryItemTextEdit item = (RepositoryItemTextEdit)_Column.ColumnEdit;

                item.Mask.MaskType = (DevExpress.XtraEditors.Mask.MaskType)comboBoxEdit1.EditValue;

            }
            else if (_Column.ColumnEdit is RepositoryItemTimeEdit)
            {
                RepositoryItemTimeEdit item = (RepositoryItemTimeEdit)_Column.ColumnEdit;

                item.Mask.MaskType = (DevExpress.XtraEditors.Mask.MaskType)comboBoxEdit1.EditValue;

            }
            else if (_Column.ColumnEdit is RepositoryItemDateEdit)
            {
                RepositoryItemDateEdit item = (RepositoryItemDateEdit)_Column.ColumnEdit;

                item.Mask.MaskType = (DevExpress.XtraEditors.Mask.MaskType)comboBoxEdit1.EditValue;

            }
            else if (_Column.ColumnEdit is RepositoryItemMemoEdit)
            {
                RepositoryItemMemoEdit item = (RepositoryItemMemoEdit)_Column.ColumnEdit;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }
            else if (_Column.ColumnEdit is RepositoryItemMemoExEdit)
            {
                RepositoryItemMemoExEdit item = (RepositoryItemMemoExEdit)_Column.ColumnEdit;

                item.Mask.EditMask = (string)acTextEdit1.EditValue;
            }


            _Column.View.RefreshData();
        }


    }
}