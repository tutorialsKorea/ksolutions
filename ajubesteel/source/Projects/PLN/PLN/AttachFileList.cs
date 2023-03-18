using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;

using BizManager;
using AttachFileManager;

namespace PLN
{
    public partial class AttachFileList : BaseMenuDialog
    {

        private DataRow _row = null;
        private object _LinkKey = null;
        private object[] _ShowKey = null;

        public acPOPAttachFileControl.emAttachLinkPermission AttachLinkPermission { 
            get => acPOPAttachFileControl1.AttachLinkPermission; 
            set => acPOPAttachFileControl1.AttachLinkPermission = value; }

        public AttachFileList(TreeListNode node)
        {
            InitializeComponent();

            
            this.acPOPAttachFileControl1.AttachLinkPermission = AttachFileManager.acPOPAttachFileControl.emAttachLinkPermission.D;

            this.acPOPAttachFileControl1.Enabled = true;

            _LinkKey = node["PART_CODE"];
            _ShowKey = new object[] { node["PART_CODE"] };
        }

        public AttachFileList(DataRow row, string columnName)
        {

            InitializeComponent();

            _row = row;

            this.acPOPAttachFileControl1.AttachLinkPermission = AttachFileManager.acPOPAttachFileControl.emAttachLinkPermission.D;

            this.acPOPAttachFileControl1.Enabled = true;

            _LinkKey = _row[columnName];
            _ShowKey = new object[] { _row[columnName] };

        }

        public AttachFileList(DataRow row)
        {

            InitializeComponent();

            _row = row;

            this.acPOPAttachFileControl1.AttachLinkPermission = AttachFileManager.acPOPAttachFileControl.emAttachLinkPermission.D;

            this.acPOPAttachFileControl1.Enabled = true;

            _LinkKey = _row["WO_NO"];
            _ShowKey = new object[] { _row["WO_NO"] };
        }
        public AttachFileList(string linkKey)
        {
            InitializeComponent();


            this.acPOPAttachFileControl1.AttachLinkPermission = AttachFileManager.acPOPAttachFileControl.emAttachLinkPermission.UD;

            this.acPOPAttachFileControl1.Enabled = true;

            _LinkKey = linkKey;
            _ShowKey = new object[] { linkKey };
        }
        public override void DialogInitComplete()
        {
            this.acPOPAttachFileControl1.LinkKey = _LinkKey;
            this.acPOPAttachFileControl1.ShowKey = _ShowKey;
        }

        private void OK()
        {

            this.DialogResult = DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //확인
            this.OK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OK();
        }
        
    }
}

