using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Reflection;
using System.IO;
using System.Net;
using BizManager;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Customization;
using System.Drawing;

namespace ControlManager
{

    public class ParameterYesNoDialogResult
    {
        public DialogResult DialogResult = DialogResult.None;

        public object Parameter = null;


    }

    public class acMessageBox
    {
        public enum emBoxType
        {
            WINDEFAULT,
            FLYACTION
        }

        public enum emMessageBoxType
        {

            /// <summary>
            /// 확인
            /// </summary>
            CONFIRM,

            /// <summary>
            /// 예 OR 아니오
            /// </summary>
            YESNO,

            YESNOCAN,

        }
        public static string GetClassName()
        {
            return "acMessageBox";
        }


        public static void ShowBarCode(Control barCodeInputControl, string barCode)
        {
            acMessageBoxBarcode barcode = new acMessageBoxBarcode(barCodeInputControl, barCode);

            barcode.Text = acInfo.Resource.GetString("바코드 스캔", "59ACSW88");

            barcode.StartPosition = FormStartPosition.CenterScreen;

            barcode.Show();
        }





        public static ParameterYesNoDialogResult ShowParameterYesNo(Control parent, string text, string resourceID, bool useResouceID, string parameterCaption)
        {

            acMessageBoxParameterYesNo yesNoParam = new acMessageBoxParameterYesNo(parent, text, (BaseMenu.GetBaseControl(parent) as IBase).Caption, parameterCaption);

            SetLocation(parent, yesNoParam);

            DialogResult dlgResult = yesNoParam.ShowDialog();


            return new ParameterYesNoDialogResult { DialogResult = dlgResult, Parameter = yesNoParam.Parameter };


        }

        private static void SetLocation(Control parent, DevExpress.XtraEditors.XtraForm form)
        {
            System.Drawing.Point parentPt = System.Drawing.Point.Empty;

            if (parent is BaseMenu)
            {

                form.StartPosition = FormStartPosition.Manual;

                parentPt = parent.PointToScreen(parent.Location);

            }
            else if (parent is BaseMenuDialog)
            {
                parentPt = parent.Location;
            }
            else
            {
                form.StartPosition = FormStartPosition.CenterParent;
            }

            System.Drawing.Rectangle parentRect = new System.Drawing.Rectangle(parentPt.X, parentPt.Y, parent.Width, parent.Height);

            form.Location = acForm.GetCenterLocation(parentRect, form.Bounds);
        }


        public static DialogResult Show(Control parent, string text, string resourceID, bool useResouceID, emMessageBoxType messageType,emBoxType boxType = emBoxType.WINDEFAULT)
        {
            Control baseCtrl = BaseMenu.GetBaseControl(parent);

            string msg = null;

            string caption = null;

            if (baseCtrl != null)
            {
                caption = (baseCtrl as IBase).Caption;
            }
            else
            {
                if (!string.IsNullOrEmpty(parent.Text))
                {
                    caption = parent.Text;
                }
                else
                {
                    caption = acInfo.SystemName;
                }
            }

            if (useResouceID == true)
            {
                msg = acInfo.Resource.GetString(text, resourceID);
            }
            else
            {
                msg = text;

            }

            switch (boxType)
            {
                case emBoxType.WINDEFAULT:
                    {
                        switch (messageType)
                        {

                            case emMessageBoxType.CONFIRM:
                                {


                                    acMessageBoxConfirm confirm = new acMessageBoxConfirm(msg, caption);
                                    confirm.TopMost = true;
                                    //SetLocation(parent, confirm);

                                    return confirm.ShowDialog();
                                }

                            case emMessageBoxType.YESNO:
                                {

                                    acMessageBoxYesNo yesNo = new acMessageBoxYesNo(msg, caption);
                                    yesNo.TopMost = true;
                                    //SetLocation(parent, yesNo);

                                    return yesNo.ShowDialog();

                                }
                            case emMessageBoxType.YESNOCAN:
                                {

                                    acMessageBoxYesNoCan yesNoCan = new acMessageBoxYesNoCan(msg, caption);
                                    yesNoCan.TopMost = true;
                                    //SetLocation(parent, yesNo);

                                    return yesNoCan.ShowDialog();

                                }
                        }
                        break;
                    }
                case emBoxType.FLYACTION:
                    {
                        DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction action = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction() { Caption = "TEST", Description = msg };
                        Predicate<DialogResult> predicate = canCloseFunc;

                        switch (messageType)
                        {

                            case emMessageBoxType.CONFIRM:
                                {
                                    DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "확인", Result = System.Windows.Forms.DialogResult.OK };//, Image = Resource.dialog_apply_x22};
                                    action.Commands.Add(command1);
                                    break;
                                }

                            case emMessageBoxType.YESNO:
                                {

                                    DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "예", Result = System.Windows.Forms.DialogResult.Yes };//, Image = Resource.dialog_yes_x22 };
                                    DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "아니오", Result = System.Windows.Forms.DialogResult.No };//, Image = Resource.dialog_no_x22 };
                                    action.Commands.Add(command1);
                                    action.Commands.Add(command2);
                                    break;
                                }
                            case emMessageBoxType.YESNOCAN:
                                {
                                    DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "예", Result = System.Windows.Forms.DialogResult.Yes };//, Image = Resource.dialog_yes_x22 };
                                    DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "아니오", Result = System.Windows.Forms.DialogResult.No };//, Image = Resource.dialog_no_x22 };
                                    DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command3 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "취소", Result = System.Windows.Forms.DialogResult.Cancel };//, Image = Resource.cancel_x16 };
                                    action.Commands.Add(command1);
                                    action.Commands.Add(command2);
                                    action.Commands.Add(command3);
                                    break;
                                }
                        }
                        
                        FlyoutProperties properties = new FlyoutProperties();
                        //properties.Orientation = Orientation.Horizontal;
                        //properties.ButtonSize = new Size(100, 60);
                        properties.Style = FlyoutStyle.MessageBox;
                        return FlyoutDialog.Show(parent.FindForm(), action, properties, predicate);
                    }
            }
            return DialogResult.No;
        }

        /// <summary>
        /// 메시지를 표시합니다.
        /// </summary>
        /// <param name="text">메시지</param>
        /// <param name="caption">메시지창 캡션</param>
        /// <param name="messageType">메시지형태</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, emMessageBoxType messageType)
        {

            switch (messageType)
            {

                case emMessageBoxType.CONFIRM:


                    acMessageBoxConfirm confirm = new acMessageBoxConfirm(text, caption);


                    confirm.StartPosition = FormStartPosition.CenterParent;

                    return confirm.ShowDialog();


                case emMessageBoxType.YESNO:


                    acMessageBoxYesNo yesNo = new acMessageBoxYesNo(text, caption);



                    yesNo.StartPosition = FormStartPosition.CenterParent;

                    return yesNo.ShowDialog();

                case emMessageBoxType.YESNOCAN:


                    acMessageBoxYesNoCan yesNoCan = new acMessageBoxYesNoCan(text, caption);



                    yesNoCan.StartPosition = FormStartPosition.CenterParent;

                    return yesNoCan.ShowDialog();

            }


            return DialogResult.No;

        }

        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }

        public static void ShowEx2(Control parent, Exception ex)
        {
            acMessageBoxError2 msg = new acMessageBoxError2(parent, ex);

            msg.ShowDialog();
        }


        public static void Show(Control parent, Exception ex)
        {

            string caption = null;

            IBase b = parent as IBase;

            if (b != null)
            {
                caption = b.Caption;
            }
            else
            {

                Control ctrl = BaseMenu.GetTopParentControl(parent);

                if (ctrl != null)
                {

                    caption = ctrl.Text;
                }
                else
                {
                    if (!string.IsNullOrEmpty(parent.Text))
                    {
                        caption = parent.Text;
                    }

                    else
                    {
                        caption = acInfo.SystemName;
                    }

                }
            }

            if (ex is BizException)
            {
                BizException bizEx = ex as BizException;

                if (acInfo.BizError != null)
                {

                    if (bizEx.ErrNumber > 0)
                    {

                        if (bizEx.ParameterDic.Count == 0)
                        {
                            acMessageBox.Show(acInfo.BizError.GetDesc(bizEx.ErrNumber), caption, acMessageBox.emMessageBoxType.CONFIRM);

                        }
                        else
                        {
                            acMessageBoxGridConfirm frm = new acMessageBoxGridConfirm(parent, "acMessageBoxGridConfirm", acInfo.BizError.GetDesc(bizEx.ErrNumber), string.Empty, false, caption, bizEx.ParameterData);

                            frm.View.GridType = ControlManager.acGridView.emGridType.FIXED;

                            foreach (DataColumn col in bizEx.ParameterData.Columns)
                            {
                                frm.View.AddTextEdit(col.ColumnName, col.ColumnName, string.Empty, false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
                            }

                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        if (ex.InnerException is OutOfMemoryException)
                        {

                            acMessageBox.Show(acInfo.Resource.GetString("데이터가 많아 불러올수없습니다. 검색조건을 설정한뒤에 다시 시도하시기 바랍니다.", "YOO8AV0H"), caption, acMessageBox.emMessageBoxType.CONFIRM);

                        }
                        else
                        {
                            acMessageBoxError msg = new acMessageBoxError(parent, ex);

                            msg.Text = caption;

                            msg.ShowDialog();

                            //acMessageBox.Show(bizEx.Message, "확인", emMessageBoxType.CONFIRM);


                        }

                    }
                }
                else
                {
                    acMessageBox.Show(bizEx.Message, caption, acMessageBox.emMessageBoxType.CONFIRM);
                }

            }
            else
            {
                acMessageBoxError msg = new acMessageBoxError(parent, ex);


                msg.Text = caption;

                msg.ShowDialog();
            }



        }

        /// <summary>
        /// 도움말 표시합니다. ==> 사용안함.
        /// </summary>
        /// <param name="menuCode"></param>
        /// <returns></returns>
        //public static void ShowHelp(Control parent, string menuCode)
        //{

        //    try
        //    {
        //        DataTable paramTable = new DataTable("RQSTDT");
        //        paramTable.Columns.Add("PLT_CODE", typeof(String)); //
        //        paramTable.Columns.Add("MENU_CODE", typeof(String)); //
        //        paramTable.Columns.Add("LANG", typeof(String)); //

        //        DataRow paramRow = paramTable.NewRow();
        //        paramRow["PLT_CODE"] = acInfo.PLT_CODE;
        //        paramRow["MENU_CODE"] = menuCode;
        //        paramRow["LANG"] = acInfo.Lang;
        //        paramTable.Rows.Add(paramRow);
        //        DataSet paramSet = new DataSet();
        //        paramSet.Tables.Add(paramTable);


        //        DataSet resultSet = acInfo.QBizActorRun.ExecuteService(GetClassName(), "GET_HELP_CLASS", paramSet, "RQSTDT", "RSLTDT");

        //        if (resultSet.Tables["RSLTDT"].Rows.Count > 0)
        //        {
        //            DataRow helpRow = resultSet.Tables["RSLTDT"].Rows[0];

        //            string className = helpRow["HELP_CLASS"].toStringEmpty();

        //            Assembly assemDLL = Assembly.Load(className);

        //            Type reportClassType = assemDLL.GetType("HELP" + "." + className, true, true);


        //            if (reportClassType != null)
        //            {

        //                Object[] objPrameters = new Object[1];

        //                object rptObject = System.Activator.CreateInstance(reportClassType);


        //                object result = reportClassType.InvokeMember("Save", BindingFlags.InvokeMethod, null, rptObject, new object[] { });

        //                byte[] fileData = (byte[])result;

        //                string fileName = acInfo.GetTempSystemDirectory() + "\\" + className + ".xps";


        //                FileInfo fInfo = new FileInfo(fileName);

        //                if (fInfo.Exists == false)
        //                {

        //                    FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

        //                    fs.Write(fileData, 0, fileData.Length);

        //                    fs.Close();
        //                }

        //                acMessageBoxHelp help = new acMessageBoxHelp(fileName);

        //                help.ParentControl = parent;

        //                help.StartPosition = FormStartPosition.CenterParent;

        //                help.ShowDialog();

        //                help.Dispose();

        //            }

        //        }
        //        else
        //        {
        //            throw new BizActorException(100013);

        //        }

        //    }
        //    catch (FileNotFoundException)
        //    {
        //        acMessageBox.Show(acInfo.BizError.GetDesc(100014), (parent as IBase).Caption, acMessageBox.emMessageBoxType.CONFIRM);

        //    }
        //    catch (Exception ex)
        //    {
        //        acMessageBox.Show(parent, ex);
        //    }


        //}
    }
}
