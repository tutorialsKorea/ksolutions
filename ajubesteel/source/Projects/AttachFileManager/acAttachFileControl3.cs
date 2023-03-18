using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Base;
using ControlManager;
using CodeHelperManager;
using BizManager;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using DevExpress.XtraGrid;
using System.Linq;

namespace AttachFileManager
{
    public sealed partial class acAttachFileControl3 : DevExpress.XtraEditors.XtraUserControl
    {

        private object[] _ShowKey = null;

        /// <summary>
        /// 파일보여주는키(여러개지정가능)
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object[] ShowKey
        {
            get { return _ShowKey; }
            set
            {
                _ShowKey = value;


                if (this._ShowKey.isNull() == false)
                {
                    this.RefreshFile();
                }
                else
                {

                    FileGridView.ClearRow();

                }

            }


        }



        private object _LinkKey = null;



        /// <summary>
        /// 연결키
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object LinkKey
        {
            get { return _LinkKey; }
            set
            {
                _LinkKey = value;

                this.SetStyle();
            }
        }

        private string _GubunCode;

        public string GubunCode
        {
            get { return _GubunCode; }
            set { _GubunCode = value; }
        }

        public enum emAttachLinkPermission
        {

            /// <summary>
            /// 다운로드만
            /// </summary>
            D,

            /// <summary>
            /// 업로드만
            /// </summary>
            U,

            /// <summary>
            /// 업로드,다운로드
            /// </summary>
            UD
        }

        private emAttachLinkPermission _AttachLinkPermission = emAttachLinkPermission.UD;

        [DefaultValue(emAttachLinkPermission.UD)]
        public emAttachLinkPermission AttachLinkPermission
        {
            get { return _AttachLinkPermission; }
            set
            {
                _AttachLinkPermission = value;

                this.SetStyle();
            }
        }


        private void SetStyle()
        {

            if (ControlManager.acInfo.IsRunTime == true)
            {

                if (this._ParentControl != null)
                {


                    if (this._LinkKey.isNull() == false)
                    {
                        FileGridView.ParentControl = this._ParentControl;

                        FileTransferGridView.ParentControl = this._ParentControl;

                        FileDelHistoryGridView.ParentControl = this._ParentControl;


                        switch (this._AttachLinkPermission)
                        {
                            case emAttachLinkPermission.D:

                                acBarSubItem1.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);

                                btnOpen.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
                                btnDownload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);


                                btnUpload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
                                btnDelete.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
                                btnRename.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);

                                FileGridControl.AllowDrop = false;


                                break;


                            case emAttachLinkPermission.U:

                                acBarSubItem1.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);

                                btnOpen.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
                                btnDownload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);

                                btnUpload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
                                btnDelete.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
                                btnRename.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);

                                FileGridControl.AllowDrop = true;


                                break;


                            case emAttachLinkPermission.UD:

                                acBarSubItem1.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);

                                btnOpen.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
                                btnDownload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);

                                btnUpload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
                                btnDelete.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
                                btnRename.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Always);

                                FileGridControl.AllowDrop = true;

                                break;
                        }
                    }
                    else
                    {
                        acBarSubItem1.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);

                        btnUpload.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
                        btnDelete.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
                        btnRename.SetVisibility(DevExpress.XtraBars.BarItemVisibility.Never);

                        FileGridControl.AllowDrop = false;
                    }
                }
                else
                {
                    this.Enabled = false;
                }
            }
        }

        public static string GetClassName()
        {
            return "acAttachFileControl3";
        }

        public static DataTable GetFileList(object linkKey)
        {
            if (linkKey.isNull()) return null;
            
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장코드
            paramTable.Columns.Add("LINK_KEY", typeof(String)); //부품코드

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LINK_KEY"] = linkKey;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(GetClassName(),"CTRL", "ATTACH_FILE_MASTER_SER3", paramSet, "RQSTDT", "RSLTDT");
            
            return resultSet.Tables["RSLTDT"];
        }


        protected override void OnLoad(EventArgs e)
        {
            this.SetStyle();

            if (ControlManager.acInfo.IsRunTime == true)
            {

                FileGridView.GridType = acGridView.emGridType.ATTACH_FILE_LIST;


                FileGridView.AddTextEdit("FILE_SEQ", "순서", "", false, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.QTY);
                FileGridView.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

                FileGridView.AddTextEdit("UPLOAD_MENU_NAME", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                FileGridView.AddLookUpEdit("ACC_LEVEL", "공개형태", "0S83T0JI", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "S009");

                if (!_GubunCode.isNullOrEmpty())
                    FileGridView.AddLookUpEdit("GUBUN", "구분", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, _GubunCode);

                FileGridView.AddTextEdit("FILE_NAME", "파일명", "0CYINE2L", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                FileGridView.AddTextEdit("O_FILE_NAME", "파일명", "0CYINE2L", true, DevExpress.Utils.HorzAlignment.Near, false, false, false, acGridView.emTextEditMask.NONE);

                FileGridView.AddTextEdit("FILE_SIZE", "파일크기", "SXQJXN0N", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.FILE_SIZE);


                FileGridView.AddDateEdit("REG_DATE", "올린 날짜", "89CL2L6E", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                FileGridView.AddTextEdit("REG_EMP", "올린 사용자코드", "AR6EX8P8", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                FileGridView.AddTextEdit("REG_EMP_NAME", "올린 사용자명", "HLFORF85", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                FileGridView.Columns["FILE_SEQ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                FileGridView.Columns["UPLOAD_MENU_NAME"].GroupIndex = 0;
                FileGridView.Columns["UPLOAD_MENU_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

                FileGridView.KeyColumn = new string[] { "FILE_ID" };
                FileGridView.OptionsView.ShowIndicator = true;

                FileTransferGridView.GridType = acGridView.emGridType.ATTACH_FILE_LIST;


                DataTable cmdData = new DataTable();

                cmdData.Columns.Add("CD_CODE");
                cmdData.Columns.Add("CD_NAME");

                DataRow cmdRow1 = cmdData.NewRow();
                cmdRow1["CD_CODE"] = "UPLOAD";
                cmdRow1["CD_NAME"] = acInfo.Resource.GetString("올리기", "5M2MC4RG");
                cmdData.Rows.Add(cmdRow1);

                DataRow cmdRow2 = cmdData.NewRow();
                cmdRow2["CD_CODE"] = "DOWNLOAD";
                cmdRow2["CD_NAME"] = acInfo.Resource.GetString("내려받기", "WEF7PSFW");
                cmdData.Rows.Add(cmdRow2);

                FileTransferGridView.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);

                FileTransferGridView.AddLookUpEdit("COMMAND", "형태", "5UEYPJUK", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, "CD_NAME", "CD_CODE", cmdData);

                FileTransferGridView.AddTextEdit("FILE_FULL_NAME", "파일명", "0CYINE2L", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);



                FileTransferGridView.AddTextEdit("FILE_SIZE", "파일크기", "SXQJXN0N", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.FILE_SIZE);


                FileTransferGridView.AddHidden("STATE", typeof(string));


                FileTransferGridView.AddProgressBar("PROGRESS", "", "", true, DevExpress.Utils.HorzAlignment.Center, false, true);

                FileTransferGridView.AddHidden("FILE_KEY", typeof(string));

                FileTransferGridView.AddHidden("FILE_ID", typeof(string));

                FileTransferGridView.AddHidden("NOW_FILE_SIZE", typeof(long));


                FileTransferGridView.AddHidden("TYPE", typeof(string));



                FileTransferGridView.AddHidden("OVERWRITE", typeof(string));

                FileTransferGridView.KeyColumn = new string[] { "FILE_KEY" };





                FileDelHistoryGridView.GridType = acGridView.emGridType.ATTACH_FILE_LIST;



                FileDelHistoryGridView.AddTextEdit("UPLOAD_MENU_NAME", "", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                FileDelHistoryGridView.AddTextEdit("FILE_NAME", "파일명", "0CYINE2L", true, DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);

                FileDelHistoryGridView.AddTextEdit("FILE_SIZE", "파일크기", "SXQJXN0N", true, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.FILE_SIZE);

                FileDelHistoryGridView.AddDateEdit("DEL_DATE", "삭제 날짜", "3H5M6AXN", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.LONG_DATE);

                FileDelHistoryGridView.AddTextEdit("DEL_EMP", "삭제한 사용자코드", "AZRA69BC", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                FileDelHistoryGridView.AddTextEdit("DEL_EMP_NAME", "삭제한 사용자명", "8J80XJEL", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);


                FileDelHistoryGridView.Columns["UPLOAD_MENU_NAME"].GroupIndex = 0;
                FileDelHistoryGridView.Columns["UPLOAD_MENU_NAME"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;


                //공개형태 

                DataTable accLevelDt = acInfo.StdCodes.GetCatTable("S009");

                foreach (DataRow row in accLevelDt.Rows)
                {
                    acBarButtonItem item = new acBarButtonItem();

                    item.Caption = row["CD_NAME"].ToString();
                    item.RefObject = row;
                    item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(AccLevelChange_ItemClick);
                    acBarSubItem1.AddItem(item);
                }

            }

            base.OnLoad(e);
        }


        private void AllAbortTransfer(object sender)
        {
            //파일전송 취소

            DataView fileTransferView = FileTransferGridView.GetDataSourceView();

            int fileTranferCnt = fileTransferView.Count;

            for (int i = 0; i < fileTranferCnt; i++)
            {

                this.FileTransferCancel(fileTransferView[0].Row);

            }

            FileTransferGridView.AcceptChanges();
        }



        /// <summary>
        /// 전송대기중인 파일이 있는지 확인후 물어본다.
        /// </summary>
        public bool Close()
        {
            if (this.IsQueueProgress == true)
            {
                acMessageBox.Show(this._ParentControl, "전송 대기중인 파일이 존재하여 닫을수 없습니다.", "2RQC4896", true, acMessageBox.emMessageBoxType.CONFIRM);

                return false;

            }

            return true;
        }



        private Control _ParentControl = null;

        public Control ParentControl
        {
            get { return _ParentControl; }

            set
            {

                _ParentControl = value;

                this.SetStyle();

            }
        }



        /// <summary>
        /// 큐가 진행중인지 반환한다.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsQueueProgress
        {

            get
            {

                DataView fileTransferView = FileTransferGridView.GetDataSourceView();


                int queueCnt = fileTransferView.Count;

                if (queueCnt != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }



        public acAttachFileControl3()
        {
            InitializeComponent();


            FileGridView.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(FileGridView_CustomDrawGroupRow);

            FileGridView.CustomColumnSort += new CustomColumnSortEventHandler(FileGridView_CustomColumnSort);


            FileGridView.MouseDown += new MouseEventHandler(FileGridView_MouseDown);

            FileGridView.MouseMove += new MouseEventHandler(FileGridView_MouseMove);
            FileGridView.EndSorting += new EventHandler(FileGridView_EndSorting);

            FileGridView.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(FileGridView_ShowGridMenuEx);

            FileGridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(FileGridView_FocusedColumnChanged);

            FileGridControl.Paint += new PaintEventHandler(FileGridControl_Paint);


            FileTransferGridView.ShowGridMenuEx += new acGridView.ShowGridMenuExHandler(FileTransferGridView_ShowGridMenuEx);


            FileGridControl.DragOver += new DragEventHandler(FileGridControl_DragOver);
            FileGridControl.DragDrop += new DragEventHandler(FileTransferGridControl_DragDrop);

            FileGridControl.DragEnter += new DragEventHandler(FileTransferGridControl_DragEnter);


            FileTransferGridControl.DragDrop += new DragEventHandler(FileTransferGridControl_DragDrop);

            FileTransferGridControl.DragEnter += new DragEventHandler(FileTransferGridControl_DragEnter);


            FileGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(FileGridView_CellValueChanged);


            FileDelHistoryGridView.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(FileDelHistoryGridView_CustomDrawGroupRow);

            FileDelHistoryGridView.CustomColumnSort += new CustomColumnSortEventHandler(FileDelHistoryGridView_CustomColumnSort);

        }

        void AccLevelChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FileGridView.EndEditor();

                acBarButtonItem item = e.Item as acBarButtonItem;

                DataRow linkRow = item.RefObject as DataRow;


                DataView selectedView = FileGridView.GetDataSourceView("SEL = '1'");

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("ACC_LEVEL", typeof(String)); //
                paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("FILE_ID", typeof(String)); //

                if (selectedView.Count == 0)
                {
                    //단일 선택

                    DataRow focusRow = FileGridView.GetFocusedDataRow();

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["ACC_LEVEL"] = linkRow["CD_CODE"];
                    paramRow["MDFY_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["FILE_ID"] = focusRow["FILE_ID"];
                    paramTable.Rows.Add(paramRow);
                }
                else
                {

                    //다중선택
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow paramRow = paramTable.NewRow();
                        paramRow["ACC_LEVEL"] = linkRow["CD_CODE"];
                        paramRow["MDFY_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["FILE_ID"] = selectedView[i]["FILE_ID"];
                        paramTable.Rows.Add(paramRow);
                    }
                }



                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this, BizManager.QBiz.emExecuteType.PROCESS,"CTRL",
                    "ATTACH_FILE_MASTER_UPD2", paramSet, "RQSTDT", "", QuickUPD2, QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }
        void QuickUPD2(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.RefreshFile();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void FileDelHistoryGridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            acGridView view = sender as acGridView;

            int val1 = 0;
            int val2 = 0;

            switch (e.Column.FieldName)
            {

                case "UPLOAD_MENU_NAME":

                    val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "UPLOAD_MENU_SEQ").toInt();
                    val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "UPLOAD_MENU_SEQ").toInt();


                    e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                    if (e.Result == 0)
                    {

                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }

                    break;

            }

        }


        void FileDelHistoryGridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);

        }


        void FileGridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            acGridView view = sender as acGridView;

            int val1 = 0;
            int val2 = 0;

            switch (e.Column.FieldName)
            {

                case "UPLOAD_MENU_NAME":

                    val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "UPLOAD_MENU_SEQ").toInt();
                    val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "UPLOAD_MENU_SEQ").toInt();


                    e.Result = val1 > val2 ? 1 : val1 == val2 ? 0 : -1;

                    if (e.Result == 0)
                    {

                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }

                    break;

            }

        }


        void FileGridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            GridGroupRowInfo info = e.Info as GridGroupRowInfo;

            info.GroupText = info.Column.RealColumnEdit.GetDisplayText(info.EditValue);

        }

        void FileGridControl_Paint(object sender, PaintEventArgs e)
        {
            if (acInfo.IsRunTime == true)
            {
                if (this.LinkKey.isNull() == true)
                {
                    string msg = acInfo.Resource.GetString("연결된 데이터가 없습니다.", "NQUO733L");

                    SizeF fSizef = e.Graphics.MeasureString(msg, DevExpress.Utils.AppearanceObject.DefaultFont);

                    Size fSize = fSizef.ToSize();

                    Point pt = acForm.GetCenterLocation(new Rectangle(0, 0, FileGridControl.Width, FileGridControl.Height), new Rectangle(0, 0, fSize.Width, fSize.Height));

                    e.Graphics.DrawString(msg, DevExpress.Utils.AppearanceObject.DefaultFont, Brushes.Black, pt);



                }
            }

        }



        void FileGridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

            if (e.PrevFocusedColumn != null)
            {

                if (e.PrevFocusedColumn.OptionsColumn.AllowEdit == true)
                {
                    if (e.PrevFocusedColumn.FieldName == "FILE_NAME")
                    {
                        e.PrevFocusedColumn.OptionsColumn.AllowEdit = false;
                    }


                }
            }


        }

        void FileGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DataRow focusRow = FileGridView.GetFocusedDataRow();

                switch (e.Column.FieldName)
                {

                    case "FILE_NAME":
                        {
                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("FILE_NAME", typeof(String)); //
                            paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("FILE_ID", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["FILE_NAME"] = e.Value;
                            paramRow["MDFY_EMP"] = acInfo.UserID;
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["FILE_ID"] = focusRow["FILE_ID"];
                            paramTable.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_UPD", paramSet, "RQSTDT", "");

                            e.Column.OptionsColumn.AllowEdit = false;
                        }
                        break;
                    case "GUBUN":
                        {
                            DataTable paramTable = new DataTable("RQSTDT");
                            paramTable.Columns.Add("GUBUN", typeof(String)); //
                            paramTable.Columns.Add("MDFY_EMP", typeof(String)); //
                            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTable.Columns.Add("FILE_ID", typeof(String)); //

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["GUBUN"] = e.Value;
                            paramRow["MDFY_EMP"] = acInfo.UserID;
                            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                            paramRow["FILE_ID"] = focusRow["FILE_ID"];
                            paramTable.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(paramTable);

                            BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_UPD4", paramSet, "RQSTDT", "");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
            

        }

        void FileTransferGridView_ShowGridMenuEx(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;

            if (e.MenuType == GridMenuType.User)
            {
                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu2.ShowPopup(view.GridControl.PointToScreen(e.Point));
            }
        }


        void FileGridView_ShowGridMenuEx(object sender, PopupMenuShowingEventArgs e)
        {
            acGridView view = sender as acGridView;


            if (e.MenuType == GridMenuType.User)
            {
                acBarSubItem1.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Never);

                btnOpen.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Never);

                btnDownload.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Never);

                btnDelete.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Never);

                btnRename.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Never);
            }
            else if (e.MenuType == GridMenuType.Row)
            {

                acBarSubItem1.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Always);

                btnOpen.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Always);

                btnDownload.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Always);

                btnDelete.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Always);

                btnRename.SetVisibility(true, DevExpress.XtraBars.BarItemVisibility.Always);
            }


            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));


            }
        }

        void FileGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (this._AttachLinkPermission == emAttachLinkPermission.D || this._AttachLinkPermission == emAttachLinkPermission.UD)
                {

                    GridHitInfo hitInfo = FileGridView.CalcHitInfo(e.Location);

                    if (hitInfo.HitTest == GridHitTest.RowCell || hitInfo.HitTest == GridHitTest.Row)
                    {
                        //파일열기

                        this.btnOpen_ItemClick(null, null);

                    }

                }

            }
            else
            {
                GridView view = sender as GridView;
                _downHitInfo = null;

                if (view != null)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                    if (Control.ModifierKeys != Keys.None)
                        return;
                    if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                        _downHitInfo = hitInfo;
                }
            }
        }



        void FileTransferGridControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        void FileTransferGridControl_DragDrop(object sender, DragEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;

            try
            {
                string[] dataFormats = e.Data.GetFormats();

                if (dataFormats.Any())
                {
                    //파일 업로드
                    if (dataFormats.Contains("FileDrop"))
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        Object data = e.Data.GetData(DataFormats.FileDrop);

                        if (data != null)
                        {

                            string[] fileNames = (string[])data;

                            DataTable dt = FileTransferGridView.NewTable();

                            BizManager.QThread qt = new BizManager.QThread(this, BizManager.QThread.emExecuteType.PROCESS);

                            qt.Execute(UploadAddFileList, new object[] { dt, fileNames });


                        }
                    }
                    else if (dataFormats.Contains("DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo"))
                    {
                        //그리드 로우 순서 변경

                        GridControl grid = (GridControl)sender;
                        
                        if (grid != null)
                        {
                            acGridView view = grid.MainView as acGridView;
                            view.EndEditor();
                            //ClearSorting(FileGridView);
                            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                            if (view != null)
                            {
                                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                                if (srcHitInfo != null)
                                {
                                    int sourceRow = srcHitInfo.RowHandle;
                                    int targetRow = hitInfo.RowHandle;
                                    MoveRow(FileGridView, sourceRow, targetRow);
                                    SetRowSeqAfterSort(FileGridView);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = saveCursor;
            }



        }

        private void SetRowSeqAfterSort(acGridView fileGridView)
        {
            try
            {
                fileGridView.BeginSort();

                DataView dv = fileGridView.GetDataSourceView();
                DataTable paramTable = dv.ToTable();
                paramTable.TableName = "RQSTDT";

                for (int i = 1; i < paramTable.Rows.Count; i++)
                {
                    paramTable.Rows[i - 1]["FILE_SEQ"] = i;
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(GetClassName(), "CTRL", "ATTACH_FILE_MASTER_UPD3", paramSet, "RQSTDT", "RSLTDT");
            }
            finally
            {
                fileGridView.EndSort();
            }
        }

        /// <summary>
        /// 다운로드파일 전송대기파일에 추가(내려받기후 열기)
        /// </summary>
        /// <param name="fileName"></param>
        private void DownloadAddOpenFile(string downloadFileName, DataRow fileRow)
        {
            try
            {
                DataRow newRow = FileTransferGridView.NewRow();

                newRow["SEL"] = "0";

                newRow["FILE_FULL_NAME"] = downloadFileName;

                newRow["FILE_SIZE"] = fileRow["FILE_SIZE"];

                newRow["FILE_KEY"] = System.Guid.NewGuid().ToString();

                newRow["FILE_ID"] = fileRow["FILE_ID"];

                newRow["NOW_FILE_SIZE"] = 0;

                newRow["COMMAND"] = "DOWNLOAD";

                newRow["STATE"] = "READY";

                newRow["TYPE"] = "OPEN";


                FileTransferGridView._AddRow(newRow);


                this.TransferFileStart();
            }

            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }



        /// <summary>
        /// 다운로드파일 전송대기파일에 추가
        /// </summary>
        /// <param name="fileName"></param>
        private void DownloadAddFile(string downloadFileName, DataRow fileRow)
        {


            DataRow newRow = FileTransferGridView.NewRow();

            newRow["SEL"] = "0";

            newRow["FILE_FULL_NAME"] = downloadFileName;

            newRow["FILE_SIZE"] = fileRow["FILE_SIZE"];

            newRow["FILE_KEY"] = System.Guid.NewGuid().ToString();

            newRow["FILE_ID"] = fileRow["FILE_ID"];

            newRow["NOW_FILE_SIZE"] = 0;

            newRow["COMMAND"] = "DOWNLOAD";

            newRow["STATE"] = "READY";

            newRow["TYPE"] = "NONE";

            FileTransferGridView._AddRow(newRow);


        }



        /// <summary>
        /// 첨부된 파일을 갱신한다.
        /// </summary>
        private void RefreshFile()
        {



            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LINK_KEY", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //

            List<object> linkeys = new List<object>(this._ShowKey);

            foreach (object linkey in linkeys)
            {
                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["LINK_KEY"] = linkey;
                paramRow["LANG"] = acInfo.Lang;
                paramTable.Rows.Add(paramRow);

            }

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            //BizRun.QBizRun.ExecuteService(
            //    this, QBiz.emExecuteType.NONE,"CTRL", "ATTACH_FILE_MASTER_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2",
            //    QuickRefresh,
            //    QuickException);


            DataSet dsResult = BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_SER", paramSet, "RQSTDT", "RSLTDT,RSLTDT2");

            FileGridView.GridControl.DataSource = dsResult.Tables["RSLTDT"];

            FileGridView.SetOldFocusRowHandle(false);

            FileDelHistoryGridView.GridControl.DataSource = dsResult.Tables["RSLTDT2"];

            FileGridView.BestFitColumns();

            FileGridView.ExpandAllGroups();

            FileDelHistoryGridView.BestFitColumns();

            FileDelHistoryGridView.ExpandAllGroups();
        }

        void QuickRefresh(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                FileGridView.GridControl.DataSource = e.result.Tables["RSLTDT"];

                FileGridView.SetOldFocusRowHandle(false);

                FileDelHistoryGridView.GridControl.DataSource = e.result.Tables["RSLTDT2"];

                FileGridView.BestFitColumns();

                FileGridView.ExpandAllGroups();

                FileDelHistoryGridView.BestFitColumns();

                FileDelHistoryGridView.ExpandAllGroups();

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }



        /// <summary>
        /// 전송대기파일목록에 있는 파일을 전송한다.
        /// </summary>
        private void TransferFileStart()
        {

            FileTransferGridView.AcceptChanges();

            DataView readyView = FileTransferGridView.GetDataSourceView("STATE = 'READY'");

            if (readyView.Count == 0)
            {
                return;
            }

            for (int i = 0; i < 1; i++)
            {
                DataRow row = readyView[i].Row;

                if (row["COMMAND"].Equals("UPLOAD"))
                {
                    //대기 큐에 명령이 업로드일때

                    ThreadPool.QueueUserWorkItem(new WaitCallback(UpLoadMasterThreadStarter), row);

                }
                else if (row["COMMAND"].Equals("DOWNLOAD"))
                {
                    //대기 큐에 명령이 다운로드일때

                    ThreadPool.QueueUserWorkItem(new WaitCallback(DownLoadMasterThreadStarter), row);

                }


            }



        }

        private void UpLoadMasterThreadStarter(object args)
        {
            DataRow row = args as DataRow;

            if (row["STATE"].EqualsEx("READY"))
            {

                if (row.RowState != DataRowState.Deleted &&
                    row.RowState != DataRowState.Detached)
                {

                    row.BeginEdit();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("FILE_KEY", typeof(String)); //
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("FILE_NAME", typeof(String)); //
                    paramTable.Columns.Add("FILE_SIZE", typeof(Decimal)); //
                    paramTable.Columns.Add("LINK_KEY", typeof(String)); //
                    paramTable.Columns.Add("REG_EMP", typeof(String)); //

                    paramTable.Columns.Add("UPLOAD_MENU", typeof(String)); //
                    paramTable.Columns.Add("UPLOAD_CLASS", typeof(String)); //

                    paramTable.Columns.Add("FILE_FULL_NAME", typeof(String)); //
                    FileInfo fInfo = new FileInfo((string)row["FILE_FULL_NAME"]);


                    DataRow paramRow = paramTable.NewRow();
                    paramRow["FILE_KEY"] = row["FILE_KEY"];


                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["FILE_NAME"] = fInfo.Name;
                    paramRow["FILE_SIZE"] = fInfo.Length;

                    paramRow["LINK_KEY"] = this._LinkKey;

                    paramRow["REG_EMP"] = acInfo.UserID;
                    paramRow["FILE_FULL_NAME"] = fInfo.FullName;

                    paramRow["UPLOAD_MENU"] = (BaseMenu.GetBaseControl(this._ParentControl) as IBase).MenuCode;
                    paramRow["UPLOAD_CLASS"] = this._ParentControl.Name;


                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    row["STATE"] = "PROGRESS";

                    BizRun.QBizRun.ExecuteService(
                    this, QBiz.emExecuteType.NONE, "CTRL","ATTACH_FILE_MASTER_INS_T", paramSet, "RQSTDT", "RSLTDT",
                    UpLoadMasterThreadCallBack,
                    QuickMasterException);

                }

            }



        }
        void UpLoadMasterThreadCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {

                Thread t = new Thread(new ParameterizedThreadStart(FtpUploadCallBack));

                t.Start(e.result);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        private Dictionary<string, acFTP> _FtpDic = new Dictionary<string, acFTP>();

        string getExtName(string filename)
        {

            string[] str = filename.Split('.');

            if (str.Length > 1)
            {
                string extname = str[str.Length - 1];
                return "." + extname;
            }
            else
            {
                return "";
            }
        }


        void FtpUploadCallBack(object args)
        {
            DataSet fileSet = args as DataSet;

            DataRow paramRow = fileSet.Tables["RQSTDT"].Rows[0];
            DataRow resultRow = fileSet.Tables["RSLTDT"].Rows[0];

            string dir = resultRow["REG_DATE"].ToString().Substring(0, 10);

            FileInfo fi = new FileInfo(paramRow["FILE_FULL_NAME"].ToString());

            //string remoteFullFileName = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, resultRow["FILE_ID"], paramRow["FILE_NAME"]);
            
            string extname = getExtName(paramRow["FILE_NAME"].ToString());

            string filename = resultRow["FILE_ID"].ToString() + extname;

            string remoteFullFileName = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename);

            acFTP acFtp1 = new acFTP();

            this._FtpDic.Add(paramRow["FILE_KEY"].ToString(), acFtp1);

            acFtp1.Progress += new FtpProgressEventHandler(acFtp1_Progress);

            acFtp1.FileID = resultRow["FILE_ID"].ToString();
            acFtp1.TransferKey = paramRow["FILE_KEY"].ToString();

            acFtp1.LinkData = paramRow.NewCopy();

            acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
            acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
            acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
            acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");


            acFtp1.FileType = FileType.Image;
            acFtp1.DoEvents = true;
            acFtp1.Passive = true;
            acFtp1.Restart = false;

            try
            {
                FtpFile ftpResult = acFtp1.Put(fi.FullName, remoteFullFileName);

                this.FtpUploadResult(acFtp1, ftpResult);
            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), acFtp1, ex);
            }

        }


        private delegate void FtpTransferExceptionDeleteInvoker(acFTP ftp, Exception ex);

        /// <summary>
        /// FTP전송 키 삭제
        /// </summary>
        /// <param name="key"></param>
        void FtpTransferExceptionDelete(acFTP ftp, Exception ex)
        {

            DataRow linkRow = ftp.LinkData as DataRow;

            if (this.IsDisposed == false)
            {
                DataRow row = FileTransferGridView.GetRow("FILE_KEY = '" + ftp.TransferKey + "'");

                if (row != null)
                {
                    FileTransferGridView.DeleteMappingRow(row);
                }
            }

            acMessageBox.Show(this._ParentControl, ex);
        }


        private delegate void FtpTransferPassInvoker(string ftpKey);

        void FtpTransferPass(string ftpKey)
        {
            this._FtpDic.Remove(ftpKey);

            if (this.IsDisposed == false)
            {
                DataRow row = FileTransferGridView.GetRow("FTP_KEY = '" + ftpKey + "'");

                if (row != null)
                {
                    FileTransferGridView.DeleteMappingRow(row);
                }

            }
        }

        private delegate void FtpProgressInvoker(object sender, FtpProgressEventArgs e);

        void acFtp1_Progress(object sender, FtpProgressEventArgs e)
        {
            this.Invoke(new FtpProgressInvoker(FtpProgress), sender, e);

        }

        void FtpProgress(object sender, FtpProgressEventArgs e)
        {
            acFTP ftp = sender as acFTP;

            DataRow row = FileTransferGridView.GetRow("FILE_KEY = '" + ftp.TransferKey + "'");

            if (row != null)
            {
                if (e.Length > 0)
                {

                    double per = (e.Position.toDouble() / e.Length.toDouble());
                    row["PROGRESS"] = Math.Floor(per * 100);

                    row.AcceptChanges();
                }
            }
        }

        private void FtpUploadResult(acFTP ftp, FtpFile file)
        {
            try
            {
                DataRow linkRow = ftp.LinkData as DataRow;

                if (file.Exception != null)
                {
                    //전송예외

                    this.Invoke(new FtpUploadCancelInvoker(FtpUploadCancel), ftp);

                    acMessageBox.Show(this._ParentControl, file.Exception);


                }
                else if (file.Count == -1)
                {
                    //중단
                    this.Invoke(new FtpUploadCancelInvoker(FtpUploadCancel), ftp);

                }
                else if (file.Position != file.Length)
                {
                    //전송취소

                    this.Invoke(new FtpUploadCancelInvoker(FtpUploadCancel), ftp);
                }
                else
                {
                    //전송 성공
                    this.Invoke(new FtpSuccessInvoker(FtpUploadSuccess), ftp, file);
                }

            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), ftp, ex);
            }
            finally
            {
                //if (ftp.Connected)
                //{
                //    try
                //    {
                ftp.Close();
                //    }
                //    catch
                //    {
                //        ftp.Abort();
                //    }
                //}


                if (this._FtpDic.ContainsKey(ftp.TransferKey))
                {
                    this._FtpDic.Remove(ftp.TransferKey);
                }
            }

        }

        private delegate void FtpUploadCancelInvoker(acFTP ftp);

        /// <summary>
        /// Upload중 취소
        /// </summary>
        /// <param name="ftp"></param>
        void FtpUploadCancel(acFTP ftp)
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("FILE_ID", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["FILE_ID"] = ftp.FileID;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, "CTRL", "ATTACH_FILE_MASTER_DEL2", paramSet, "RQSTDT", "");

            if (this.IsDisposed == false)
            {
                DataRow row = FileTransferGridView.GetRow("FILE_KEY = '" + ftp.TransferKey + "'");

                DataRow linkRow = ftp.LinkData as DataRow;

                string filename = linkRow["FILE_NAME"].ToString();
                string remoteFileName = ftp.FileID + getExtName(filename);
                string remoteFullPath = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, linkRow["REG_DATE"].ToString().Substring(0, 10), remoteFileName);
                ftp.Delete(remoteFullPath);

                if (row != null)
                {
                    FileTransferGridView.DeleteMappingRow(row);

                    //try
                    //{
                    //    ftp.Delete(sfile, false, false);
                    //    //string filename = "";
                    //    //string file = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, ftp.FileID,  filename);
                    //    //FtpFile[] ftpResult = ftp.Delete(file, true, false);
                    //    //ftp.Delete()
                    //    ////remoteFullFileName = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, resultRow["FILE_ID"], paramRow["FILE_NAME"]);
                    //    //string old_name = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, ds.Tables["RSLTDT"].Rows[0]["FILE_ID"].ToString(), ds.Tables["RSLTDT"].Rows[0]["FILE_NAME"].ToString());
                    //    //string new_name = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, ds.Tables["RSLTDT"].Rows[0]["FILE_ID"].ToString(), e.Value.ToString());

                    //    //ftp.Delete()
                    //    //ftp.Rename(old_name, new_name);

                    //}
                    //catch (Exception ex)
                    //{
                    //    this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), ftp, ex);
                    //}
                    //finally
                    //{
                    //    if (ftp.Connected)
                    //    {
                    //        try
                    //        {
                    //            ftp.Close();
                    //        }
                    //        catch
                    //        {
                    //            ftp.Abort();
                    //        }
                    //    }
                    //}
                    
                }

            }



        }

        private delegate void FtpDownloadCancelInvoker(string ftpKey);

        private void FtpDownloadResult(acFTP ftp, FtpFile file)
        {
            try
            {
                DataRow linkRow = ftp.LinkData as DataRow;

                if (file.Exception != null)
                {
                    //전송예외

                    this.Invoke(new FtpDownloadCancelInvoker(FtpDownloadCancel), ftp.TransferKey);


                    acMessageBox.Show(this._ParentControl, file.Exception);


                }
                else if (file.Count == -1)
                {
                    //중단
                    this.Invoke(new FtpDownloadCancelInvoker(FtpDownloadCancel), ftp.TransferKey);


                }
                else if (file.Position != file.Length)
                {
                    //전송취소는 파일삭제 

                    FileInfo fi = new FileInfo(file.LocalFileName);

                    fi.Delete();

                    this.Invoke(new FtpDownloadCancelInvoker(FtpDownloadCancel), ftp.TransferKey);

                }
                else
                {
                    //전송 성공

                    this.Invoke(new FtpSuccessInvoker(FtpDownloadSuccess), ftp, file);
                    

                }

            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), ftp, ex);
            }
            finally
            {

                //if (ftp.Connected)
                //{
                //    try
                //    {
                //        ftp.Close();
                //    }
                //    catch
                //    {
                //        ftp.Abort();
                //    }
                //}
                ftp.Close();

                if (this._FtpDic.ContainsKey(ftp.TransferKey))
                {
                    this._FtpDic.Remove(ftp.TransferKey);
                }
            }

        }

        /// <summary>
        /// FTP전송 키 삭제
        /// </summary>
        /// <param name="key"></param>
        void FtpDownloadCancel(string ftpKey)
        {



            if (this.IsDisposed == false)
            {
                DataRow row = FileTransferGridView.GetRow("FILE_KEY = '" + ftpKey + "'");

                if (row != null)
                {
                    FileTransferGridView.DeleteMappingRow(row);
                }

            }



        }



        private delegate void FtpSuccessInvoker(acFTP ftp, FtpFile file);


        void FtpUploadSuccess(acFTP ftp, FtpFile file)
        {

            try
            {
                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("FILE_ID", typeof(String)); //


                DataRow paramRow = paramTable.NewRow();
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["FILE_ID"] = ftp.FileID;
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                BizRun.QBizRun.ExecuteService(this,"CTRL", "ATTACH_FILE_MASTER_COMPLETE", paramSet, "RQSTDT", "");

                //ftp.LinkData
                DataRow linkRow = ftp.LinkData as DataRow;

                
                if (this.IsDisposed == false)
                {
                    DataRow row = FileTransferGridView.GetRow("FILE_KEY = '" + ftp.TransferKey + "'");

                    if (row != null)
                    {
                        FileTransferGridView.DeleteMappingRow(row);
                    }

                }

                this.TransferFileStart();

                this.RefreshFile();

                acTabControl1.SelectedTabPage = acTabPage1;

            }

            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }




        void FtpDownloadSuccess(acFTP ftp, FtpFile file)
        {
            try
            {

                DataRow linkRow = ftp.LinkData as DataRow;

                if (this.IsDisposed == false)
                {
                    DataRow row = FileTransferGridView.GetRow("FILE_KEY = '" + ftp.TransferKey + "'");

                    if (row != null)
                    {

                        FileTransferGridView.DeleteMappingRow(row);
                    }


                    //열기모드
                    if (linkRow["TYPE"].EqualsEx("OPEN"))
                    {
                        System.Diagnostics.Process.Start(file.LocalFileName);
                    }
                }

                this.TransferFileStart();

                //첨부목록으로 전환
                //this.acTabControl1.SelectedTabPage = acTabPage1;

            }

            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }

        private void DownLoadMasterThreadStarter(object args)
        {

            DataRow row = args as DataRow;

            if (row["STATE"].EqualsEx("READY"))
            {
                if (row.RowState != DataRowState.Deleted &&
                    row.RowState != DataRowState.Detached)
                {

                    row.BeginEdit();


                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("FILE_ID", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["FILE_ID"] = row["FILE_ID"];


                    paramTable.Rows.Add(paramRow);
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    row["STATE"] = "PROGRESS";
                
                    BizRun.QBizRun.ExecuteService(
                        this, QBiz.emExecuteType.NONE, "CTRL", 
                        "ATTACH_FILE_MASTER_SER2", paramSet, "RQSTDT", "RSLTDT", row,
                        DownLoadMasterThreadCallBack,
                        QuickMasterException);

                }
            }

        }

        void DownLoadMasterThreadCallBack(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {

            try
            {
                Thread t = new Thread(new ParameterizedThreadStart(FtpDownloadCallBack));

                t.Start(e);
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        void FtpDownloadCallBack(object args)
        {
            QBiz.ExcuteCompleteArgs e = args as BizManager.QBiz.ExcuteCompleteArgs;
            
            DataRow fileRow = e.parameter as DataRow;

            DataSet fileSet = e.result;

            DataRow resultRow = fileSet.Tables["RSLTDT"].Rows[0];

            //FileInfo fi = new FileInfo(fileRow["FILE_FULL_NAME"].ToString());

            acFTP acFtp1 = new acFTP();

            this._FtpDic.Add(fileRow["FILE_KEY"].ToString(), acFtp1);

            acFtp1.Progress += new FtpProgressEventHandler(acFtp1_Progress);

            acFtp1.FileID = resultRow["FILE_ID"].ToString();
            acFtp1.TransferKey = fileRow["FILE_KEY"].ToString();

            acFtp1.LinkData = fileRow.NewCopy();

            acFtp1.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
            acFtp1.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
            acFtp1.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
            acFtp1.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");


            acFtp1.FileType = FileType.Image;
            acFtp1.DoEvents = true;
            acFtp1.Passive = true;
            acFtp1.Restart = false;

            try
            {
                string dir = resultRow["REG_DATE"].ToString().Substring(0, 10);
                //string filename = resultRow["FILE_ID"].ToString() + "_" + resultRow["FILE_NAME"].ToString();
                
                string filename = resultRow["FILE_ID"].ToString()  + getExtName(resultRow["FILE_NAME"].ToString());

                //FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, resultRow["FILE_ID"], resultRow["FILE_NAME"]), fileRow["FILE_FULL_NAME"].ToString());
                FtpFile ftpResult = acFtp1.Get(string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, filename), fileRow["FILE_FULL_NAME"].ToString());

                this.FtpDownloadResult(acFtp1, ftpResult);

            }
            catch (Exception ex)
            {
                this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), acFtp1, ex);
            }

        }


        void QuickMasterException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            DataRow row = qBiz.RefData.Tables["RQSTDT"].Rows[0];

            DataRow keyRow = FileTransferGridView.GetRow("FILE_KEY = '" + row["FILE_KEY"] + "'");


            if (keyRow != null)
            {
                qBiz.Start();
            }
        }


        private delegate void TransferFileCancelInvoker(object args);


        void FileTransferCancel(object args)
        {

            DataRow keyRow = args as DataRow;

            if (keyRow != null)
            {

                if (keyRow["COMMAND"].EqualsEx("UPLOAD"))
                {
                    if (this._FtpDic.ContainsKey(keyRow["FILE_KEY"].ToString()))
                    {
                        this._FtpDic[keyRow["FILE_KEY"].ToString()].AbortTransfer();
                    }

                }
                else if (keyRow["COMMAND"].EqualsEx("DOWNLOAD"))
                {
                    if (this._FtpDic.ContainsKey(keyRow["FILE_KEY"].ToString()))
                    {
                        this._FtpDic[keyRow["FILE_KEY"].ToString()].AbortTransfer();
                    }
                }



                FileTransferGridView.DeleteMappingRow(keyRow);
            }
        }



        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {

            if (ex.ErrNumber == BizManager.BizException.CHECK_DEL_AUTH)
            {
                //해당 파일을 올린사용자만 삭제할수있음

                acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(this, "acMessageBoxGridConfirm1", acInfo.BizError.GetDesc(ex.ErrNumber), string.Empty, false, (this.ParentControl as IBase).Caption, ex.ParameterData);

                frm.View.GridType = acGridView.emGridType.FIXED;


                frm.View.AddTextEdit("FILE_NAME", "파일명", "0CYINE2L", true, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);

                frm.ShowDialog();

            }

            else if (ex.ErrNumber == BizManager.BizException.DATA_REFRESH)
            {
                //데이터 갱신

                acMessageBox.Show(this.ParentControl, ex);

                this.RefreshFile();

            }
            else
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }


        private void btnUpload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일올리기
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();


                dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.RestoreDirectory = true;
                dlg.Multiselect = true;


                if (dlg.ShowDialog() == DialogResult.OK)
                {


                    DataTable dt = FileTransferGridView.NewTable();

                    BizManager.QThread qt = new BizManager.QThread(this, BizManager.QThread.emExecuteType.PROCESS);

                    qt.Execute(UploadAddFileList, new object[] { dt, dlg.FileNames });

                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }




        }

        private void btnDownload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //내려받기
            try
            {

                FileGridView.EndEditor();


                DataView selectedView = FileGridView.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0)
                {
                    //단일 내려받기 큐추가

                    DataRow focusRow = FileGridView.GetFocusedDataRow();

                    SaveFileDialog dlg = new SaveFileDialog();

                    dlg.FileName = focusRow["FILE_NAME"].ToString();

                    dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    string extens = Path.GetExtension(dlg.FileName).Replace(".", string.Empty);


                    dlg.Filter = string.Format("{0}|*.{1}", extens, extens);

                    dlg.RestoreDirectory = true;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        this.DownloadAddFile(dlg.FileName, focusRow);

                        //전송큐화면으로 전환
                        acTabControl1.SelectedTabPage = acTabPage2;

                        this.TransferFileStart();
                    }

                }
                else
                {
                    //다중 내려받기 큐추가

                    FolderBrowserDialog dlg = new FolderBrowserDialog();

                    dlg.RootFolder = Environment.SpecialFolder.Desktop;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        DataTable dt = FileTransferGridView.NewTable();

                        BizManager.QThread qt = new BizManager.QThread(this, BizManager.QThread.emExecuteType.PROCESS);

                        qt.Execute(DownloadAddFileList, new object[] { dt, dlg.SelectedPath, selectedView });


                    }

                }

                acMessageBox.Show("모두 내려받았습니다.", "내려받기", acMessageBox.emMessageBoxType.CONFIRM);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }



        void DownloadAddFileList(object args)
        {

            object[] data = args as object[];

            DataTable nTable = data[0] as DataTable;

            string selectedPath = data[1] as string;

            DataView selectedView = data[2] as DataView;



            for (int i = 0; i < selectedView.Count; i++)
            {

                string fileName = string.Format(@"{0}\{1}", selectedPath, selectedView[i]["FILE_NAME"].ToString());
                
                DataRow newRow = nTable.NewRow();

                newRow["SEL"] = "0";

                newRow["FILE_FULL_NAME"] = fileName;

                newRow["FILE_SIZE"] = selectedView[i]["FILE_SIZE"];

                newRow["FILE_KEY"] = System.Guid.NewGuid().ToString();

                newRow["FILE_ID"] = selectedView[i]["FILE_ID"];

                newRow["NOW_FILE_SIZE"] = 0;

                newRow["COMMAND"] = "DOWNLOAD";

                newRow["STATE"] = "READY";

                newRow["TYPE"] = "NONE";

                nTable.Rows.Add(newRow);

            }

            this.BeginInvoke(new ControlManager.QThread.QThreadCompleateInvoker(DownloadAddFileListSuccess), nTable);


        }

        void DownloadAddFileListSuccess(object result)
        {
            //전송큐화면으로 전환

            try
            {
                DataTable data = result as DataTable;

                DataTable now = FileTransferGridView.GridControl.DataSource as DataTable;

                now.Load(new DataTableReader(data));

                acTabControl1.SelectedTabPage = acTabPage2;

                this.TransferFileStart();
            }

            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }


        void UploadAddFileList(object args)
        {

            object[] data = args as object[];

            DataTable nTable = data[0] as DataTable;

            string[] fileNames = data[1] as string[];

            string menuCode = (BaseMenu.GetBaseControl(this._ParentControl) as IBase).MenuCode;

            foreach (string fileName in fileNames)
            {
                FileInfo fInfo = new FileInfo(fileName);

                DataRow newRow = nTable.NewRow();

                newRow["SEL"] = "0";

                newRow["FILE_FULL_NAME"] = fInfo.FullName;

                newRow["FILE_SIZE"] = fInfo.Length;

                newRow["FILE_KEY"] = System.Guid.NewGuid().ToString();

                newRow["NOW_FILE_SIZE"] = 0;

                newRow["COMMAND"] = "UPLOAD";

                newRow["STATE"] = "READY";

                newRow["TYPE"] = "NONE";




                nTable.Rows.Add(newRow);

            }

            this.BeginInvoke(new ControlManager.QThread.QThreadCompleateInvoker(UploadAddFileListSuccess), nTable);


        }


        void UploadAddFileListSuccess(object result)
        {
            //전송큐화면으로 전환
            try
            {
                DataTable data = result as DataTable;

                DataTable now = FileTransferGridView.GridControl.DataSource as DataTable;

                now.Load(new DataTableReader(data));

                acTabControl1.SelectedTabPage = acTabPage2;

                this.TransferFileStart();
            }

            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }

        }





        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일 열기

            try
            {
                DataRow focusRow = FileGridView.GetFocusedDataRow();

                string fileDir = string.Format(@"{0}\{1}", acInfo.GetTempSystemDirectory(), focusRow["FILE_ID"]);

                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }


                string fileName = string.Format(@"{0}\{1}", fileDir, focusRow["FILE_NAME"]);

                DataRow fileRow = FileTransferGridView.GetRow("FILE_ID = '" + focusRow["FILE_ID"].ToString() + "' AND TYPE='OPEN'");

                if (fileRow != null)
                {
                    acMessageBox.Show(this.ParentControl, "이미 전송대기파일에 추가하였습니다. 잠시만 기다려주시기 바랍니다.", "3MF0QQWQ", true, acMessageBox.emMessageBoxType.CONFIRM);

                }
                else
                {
                    this.DownloadAddOpenFile(fileName, focusRow);
                }


            }
            catch (Exception ex)
            {

                acMessageBox.Show(this.ParentControl, ex);
            }

        }

        DataTable _delparamTable;

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //파일 삭제
            try
            {

                if (acMessageBox.Show(this.ParentControl, "정말 삭제하시겠습니까?", "TB43FSY3", true, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }

                FileGridView.EndEditor();

                DataView selectedView = FileGridView.GetDataSourceView("SEL = '1'");
                _delparamTable = new DataTable("RQSTDT");

                if (!_delparamTable.Columns.Contains("DEL_EMP")) _delparamTable.Columns.Add("DEL_EMP", typeof(String)); //
                if (!_delparamTable.Columns.Contains("PLT_CODE")) _delparamTable.Columns.Add("PLT_CODE", typeof(String)); //
                if (!_delparamTable.Columns.Contains("FILE_ID")) _delparamTable.Columns.Add("FILE_ID", typeof(String)); //
                if (!_delparamTable.Columns.Contains("FILE_NAME")) _delparamTable.Columns.Add("FILE_NAME", typeof(String));
                if (!_delparamTable.Columns.Contains("REG_DATE")) _delparamTable.Columns.Add("REG_DATE", typeof(String));
                if (!_delparamTable.Columns.Contains("CONF_SECTION")) _delparamTable.Columns.Add("CONF_SECTION", typeof(String));
                if (!_delparamTable.Columns.Contains("CONF_NAME")) _delparamTable.Columns.Add("CONF_NAME", typeof(String));

                if (selectedView.Count == 0)
                {
                    //단일삭제
                    DataRow focusRow = FileGridView.GetFocusedDataRow();

                    DataRow paramRow = _delparamTable.NewRow();
                    paramRow["DEL_EMP"] = acInfo.UserID;
                    paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow["FILE_ID"] = focusRow["FILE_ID"];
                    paramRow["FILE_NAME"] = focusRow["FILE_NAME"];
                    paramRow["REG_DATE"] = focusRow["REG_DATE"];
                    paramRow["CONF_SECTION"] = "SYS";
                    paramRow["CONF_NAME"] = "SYSTEM_GROUP";
                    _delparamTable.Rows.Add(paramRow);

                }
                else
                {
                    //다중삭제
                    for (int i = 0; i < selectedView.Count; i++)
                    {
                        DataRow paramRow = _delparamTable.NewRow();
                        paramRow["DEL_EMP"] = acInfo.UserID;
                        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                        paramRow["FILE_ID"] = selectedView[i]["FILE_ID"];
                        paramRow["FILE_NAME"] = selectedView[i]["FILE_NAME"];
                        paramRow["REG_DATE"] = selectedView[i]["REG_DATE"];
                        paramRow["CONF_SECTION"] = "SYS";
                        paramRow["CONF_NAME"] = "SYSTEM_GROUP";
                        _delparamTable.Rows.Add(paramRow);
                    }
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(_delparamTable);

                BizManager.BizRun.QBizRun.ExecuteService(
                    this, BizManager.QBiz.emExecuteType.NONE, "CTRL", "ATTACH_FILE_MASTER_DEL", paramSet, "RQSTDT", "",
                    QuickDel,
                    QuickException);

                
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }


        }

        void QuickDel(object sender, BizManager.QBiz qBiz, BizManager.QBiz.ExcuteCompleteArgs e)
        {
            try
            {

                //**********************물리적 파일 삭제*******************************//
                acFTP ftp = new acFTP();

                ftp.Server = acInfo.SysConfig.GetSysConfigByServer("FTP_ADDRESS");
                ftp.ServerPort = acInfo.SysConfig.GetSysConfigByServer("FTP_PORT").toInt();
                ftp.Username = acInfo.SysConfig.GetSysConfigByServer("FTP_USERID");
                ftp.Password = acInfo.SysConfig.GetSysConfigByServer("FTP_PASSWORD");

                ftp.FileType = FileType.Ascii;
                ftp.DoEvents = true;
                ftp.Passive = true;
                ftp.Restart = false;

                try
                {

                    foreach (DataRow dr in _delparamTable.Rows)
                    {
                        string dir = dr["REG_DATE"].ToString().Substring(0, 10);
                        string fileid = dr["FILE_ID"].ToString();
                        string file = fileid + getExtName(dr["FILE_NAME"].ToString());

                        string remotedir = string.Format(@"{0}\{1}\{2}", acInfo.PLT_CODE, dir, file);

   


                        FtpFile ftpResult = ftp.Delete(remotedir);

                        //foreach (FtpFile result in ftpResult)
                        //{
                        if (ftpResult.Exception != null)
                        {
                            acMessageBox.Show("해당 파일이 서버에 존재하지 않습니다.", "파일 삭제", acMessageBox.emMessageBoxType.CONFIRM);
                        }

                    }

                }
                catch (Exception ex)
                {
                    this.Invoke(new FtpTransferExceptionDeleteInvoker(FtpTransferExceptionDelete), ftp, ex);
                }
                finally
                {
                    //if (ftp.Connected)
                    //{
                    //    try
                    //    {
                            ftp.Close();
                    //    }
                    //    catch
                    //    {
                    //        ftp.Abort();
                    //    }
                    //}
                }
                //**********************물리적 파일 삭제*******************************//

                this.RefreshFile();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


        private void btnRename_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //이름 바꾸기
            try
            {
                DataRow focusRow = FileGridView.GetFocusedDataRow();

                DataTable paramTable = new DataTable("RQSTDT");
                paramTable.Columns.Add("REG_EMP", typeof(String)); //
                paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable.Columns.Add("FILE_ID", typeof(String)); //

                DataRow paramRow = paramTable.NewRow();
                paramRow["REG_EMP"] = acInfo.UserID;
                paramRow["PLT_CODE"] = acInfo.PLT_CODE;
                paramRow["FILE_ID"] = focusRow["FILE_ID"];
                paramTable.Rows.Add(paramRow);
                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                //권한 확인
                BizManager.BizRun.QBizRun.ExecuteService(this, BizManager.QBiz.emExecuteType.NONE,"CTRL",
                    "ATTACH_FILE_MASTER_SER4", paramSet, "RQSTDT", "", QuickUPD, QuickException);

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }

        void QuickUPD(object sender, BizManager.QBiz qBiz, BizManager.QBiz.ExcuteCompleteArgs e)
        {
            //파일 이름 변경
            try
            {
                FileGridView.Columns["FILE_NAME"].OptionsColumn.AllowEdit = true;

                FileGridView.FocusedColumn = FileGridView.Columns["FILE_NAME"];

                FileGridView.ShowEditor();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //전송 취소

            //큐에서 제거한다.

            try
            {
                FileTransferGridView.EndEditor();

                DataView selectedView = FileTransferGridView.GetDataSourceView("SEL = '1'");

                if (selectedView.Count == 0)
                {
                    //단일취소

                    DataRow focusRow = FileTransferGridView.GetFocusedDataRow();

                    this.FileTransferCancel(focusRow);

                }
                else
                {
                    //다중취소

                    int cnt = selectedView.Count;

                    for (int i = 0; i < cnt; i++)
                    {
                        this.FileTransferCancel(selectedView[0].Row);
                    }
                }


                FileTransferGridView.AcceptChanges();

                this.TransferFileStart();

                //첨부파일 목록으로 전환
                this.acTabControl1.SelectedTabPage = acTabPage1;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this.ParentControl, ex);
            }
        }


        #region 행 이동 및 정렬
        public void ClearSorting(GridView views)
        {
            bool changeSortColumn = false;
            for (int i = 0; i < views.SortInfo.Count; i++)
            {
                GridColumnSortInfo gc = views.SortInfo[i];
                if (gc.Column.FieldName != "FILE_SEQ")
                {
                    changeSortColumn = true;
                    break;
                }
            }
            if (changeSortColumn)
            {
                views.ClearSorting();
                views.Columns["FILE_SEQ"].SortOrder = ColumnSortOrder.Ascending;
            }
        }

        public void MoveRow(GridView views, int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow || sourceRow == targetRow + 1)
                return;
            DataRow row1 = views.GetDataRow(targetRow);
            DataRow row2 = views.GetDataRow(targetRow + 1);
            DataRow dragRow = views.GetDataRow(sourceRow);
            object val1 = row1["FILE_SEQ"];
            if (row2 == null)
                dragRow["FILE_SEQ"] = (decimal)val1 + 1;
            else
            {
                object val2 = row2["FILE_SEQ"];
                dragRow["FILE_SEQ"] = ((decimal)val1 + (decimal)val2) / 2;
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            GridView view = FileGridView;
            view.GridControl.Focus();
            int index = view.FocusedRowHandle;
            if (index <= 0) return;

            //ClearSorting(FileGridView);

            System.Data.DataRow row1 = view.GetDataRow(index);
            System.Data.DataRow row2 = view.GetDataRow(index - 1);
            object val1 = row1["FILE_SEQ"];
            object val2 = row2["FILE_SEQ"];
            row1["FILE_SEQ"] = val2;
            row2["FILE_SEQ"] = val1;

            view.FocusedRowHandle = index - 1;
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            GridView view = FileGridView;
            view.GridControl.Focus();
            int index = view.FocusedRowHandle;
            if (index >= view.DataRowCount - 1) return;

            //ClearSorting(FileGridView);
            System.Data.DataRow row1 = view.GetDataRow(index);
            System.Data.DataRow row2 = view.GetDataRow(index + 1);

            object val1 = row1["FILE_SEQ"];
            object val2 = row2["FILE_SEQ"];
            row1["FILE_SEQ"] = val2;
            row2["FILE_SEQ"] = val1;

            view.FocusedRowHandle = index + 1;
        }

        private GridHitInfo _downHitInfo = null;
      
        private void FileGridView_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && _downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(_downHitInfo.HitPoint.X - dragSize.Width / 2,
                    _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    if (view != null) view.GridControl.DoDragDrop(_downHitInfo, DragDropEffects.All);
                    _downHitInfo = null;
                }
            }
        }

        private void FileGridControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                if (sender is GridControl)
                {
                    GridControl grid = sender as GridControl;
                    if (grid.MainView is GridView)
                    {
                        GridView view = grid.MainView as GridView;
                        GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                        if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                            e.Effect = DragDropEffects.Move;
                        else
                            e.Effect = DragDropEffects.None;
                    }
                }
            }
        }

        private void FileGridView_EndSorting(object sender, EventArgs e)
        {
            GridView gv = sender as GridView;
            for (int rowIndex = 0; rowIndex < ((DataView)FileGridView.DataSource).Count; rowIndex++)
            {
                if (gv != null)
                {
                    DataRowView drv = (gv.DataSource as System.Data.DataView)[rowIndex];
                    if (!drv.isNullOrEmpty())
                    {
                        int rowHandle = gv.GetRowHandle(rowIndex);
                        drv["FILE_SEQ"] = rowHandle + 1;
                    }
                }
            }
        }
        #endregion

    }
}
