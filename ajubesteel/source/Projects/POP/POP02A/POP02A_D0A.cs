﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraEditors;
using BizManager;
using System.Linq;
using System.IO;

namespace POP
{
    public partial class POP02A_D0A : BaseMenuDialog
    {
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

        private object _LinkData = null;

        public object LinkData
        {
            get { return _LinkData; }
            set { _LinkData = value; }
        }


        public POP02A_D0A(object linkData)
        {
            InitializeComponent();

            _LinkData = linkData;

            acGridView1.AddTextEdit("PART_REV_ID", "Rev", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_DIVISION", "Division", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_FILE_NAME", "파일명", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_FILE_PATH", "파일경로", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("PART_PUID", "PUID", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

            acGridView1.AddTextEdit("IF_MSG", "비고", "", false, DevExpress.Utils.HorzAlignment.Center, false, false, false, acGridView.emTextEditMask.NONE);

        }

        public override void DialogInit()
        {

            
            base.DialogInit();
        }


        public override void DialogNew()
        {
            //새로만들기

            base.DialogNew();

        }

        public override void DialogOpen()
        {
            base.DialogOpen();

            acGridView1.GridControl.DataSource = this._LinkData;
            acGridView1.BestFitColumns();

        }    

        private void barItemFixedWindow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //창고정


            base.IsFixedWindow = ((ControlManager.acBarCheckItem)e.Item).Checked;
        }
        

        private void acBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barItemSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR");
            string id = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_ID");
            string pass = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_DIR_PW");
            string removePath = acInfo.SysConfig.GetSysConfigByMemory("DRAW_FILE_REMOVE_DIR");

            int iSeq = acGridView1.GetFocusedDataRow()["PART_FILE_PATH"].ToString().IndexOf(removePath) + removePath.Length;

            string replacePath = acGridView1.GetFocusedDataRow()["PART_FILE_PATH"].ToString().Substring(iSeq, acGridView1.GetFocusedDataRow()["PART_FILE_PATH"].ToString().Length - iSeq);

            string fullPath = path + replacePath;


            string strFileFullPath = path;
            string strFileFullName = fullPath;

            IFModule iFModule = new IFModule(path, id, pass);

            int ret = iFModule.NetWorkAccess();

            acMessageBox.Show(ret.ToString(), ret.ToString(), acMessageBox.emMessageBoxType.CONFIRM);

            //if (ret != 0)
            //{
            //    acMessageBox.Show("네트워크 연결 오류", "오류", acMessageBox.emMessageBoxType.CONFIRM);
            //    return;
            //}

            bool isExists = true;

            if (System.IO.Directory.Exists(strFileFullPath))
            {
                FileInfo fileInfo = new FileInfo(strFileFullName);

                if (fileInfo.Exists)
                {
                    System.Diagnostics.Process.Start(strFileFullName);
                }
                else
                {
                    isExists = false;
                }
            }
            else
            {
                isExists = false;
            }

            if (!isExists)
            {
                //acMessageBox.Show(this, "파일이 존재하지 않습니다.", "", false, acMessageBox.emMessageBoxType.CONFIRM);
                acAlert.Show(this, "파일이 존재하지 않습니다.", acAlertForm.enmType.Warning);
            }

            //System.Diagnostics.Process.Start(acGridView1.GetFocusedDataRow()["PART_FILE_PATH"].ToString());
        }
    }
}