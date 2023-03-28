using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using System.Threading;
using BizManager;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;

namespace ControlManager
{
    public partial class BaseMenuDialog : acForm, IBase
    {

        public string GetMenuConfig(string confName)
        {
            return acInfo.MenuConfig.GetMenuConfigByMemory(this.MenuCode, confName);

        }

        public DataTable GetMenuConfigRowTableByServer()
        {
            return acInfo.MenuConfig.GetMenuConfigRowTableByServer(this.MenuCode);
        }

        public virtual acBarManager BarManager
        {
            get { return null; }
        }

        private Dictionary<object, BaseMenuDialog> _ChildForms = new Dictionary<object, BaseMenuDialog>();

        public bool ChildFormContains(object key)
        {
            return this._ChildForms.ContainsKey(key);

        }

        public void ChildFormFocus(object key)
        {
            this._ChildForms[key].Focus();
        }


        private acKey.InputDevice _InputDevice = null;

        private class InputKey
        {
            public string deviceName;

            public ushort key;
        }

        private List<InputKey> _InputKeys = new List<InputKey>();

        void InputDevice_KeyPressed(object sender, acKey.InputDevice.KeyControlEventArgs e)
        {
            try
            {

                if (acInfo.IsRunTime == false)
                {
                    return;
                }

                if ((int)this.Handle != WIN32API.GetForegroundWindow())
                {
                    return;
                }


                //키입력 저장
                if (e.Keyboard != null)
                {
                    this._InputKeys.Add(new InputKey() { deviceName = e.Keyboard.deviceName, key = e.Keyboard.key });

                    if (acInfo.SysConfig.isNullOrEmpty())
                        return;
                    if (acInfo.SysConfig.GetSysConfigByMemory("BARCODE_SCANNER_HARDWARE_ID").isNullOrEmpty())
                        return;
                    List<string> barcodeScannerIDs = new List<string>(acInfo.SysConfig.GetSysConfigByMemory("BARCODE_SCANNER_HARDWARE_ID").Split(','));

                    foreach (string barcodeScannerID in barcodeScannerIDs)
                    {
                        if (e.Keyboard.deviceName.IndexOf(barcodeScannerID, 0) > -1)
                        {
                            ////BARCODE 스캔
                            this._IsBarCodeScaning = true;

                            if ((int)e.Keyboard.key == WIN32API.VK_RETURN)
                            {


                                Thread showBarCodeThread = new Thread(new ParameterizedThreadStart(ShowBarCodeThreadStarter));

                                List<InputKey> parameter = new List<InputKey>();

                                parameter.AddRange(this._InputKeys);

                                this._InputKeys.Clear();

                                showBarCodeThread.Start(parameter);


                                return;

                            }

                            break;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void ShowBarCodeThreadStarter(object args)
        {
            string barCode = string.Empty;

            List<InputKey> keyList = args as List<InputKey>;

            foreach (InputKey key in keyList)
            {

                List<string> barcodeScannerIDs = new List<string>(acInfo.SysConfig.GetSysConfigByMemory("BARCODE_SCANNER_HARDWARE_ID").Split(','));

                foreach (string barcodeScannerID in barcodeScannerIDs)
                {
                    if (key.deviceName.IndexOf(barcodeScannerID, 0) > -1)
                    {

                        int nonVirtualKey = WIN32API.MapVirtualKeyEx(key.key, 2, WIN32API.GetKeyboardLayout(0));

                        char mappedChar = Convert.ToChar(nonVirtualKey);


                        if (mappedChar != '\0' && mappedChar != '\r')
                        {
                            barCode += mappedChar.ToString();
                        }

                    }

                }

            }


            this.BeginInvoke((MethodInvoker)delegate
            {

                acMessageBox.ShowBarCode(this, barCode);

                this._IsBarCodeScaning = false;
            });


        }

        private Dictionary<string, DataSet> _TempReadSet = new Dictionary<string, DataSet>();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, DataSet> TempReadSet
        {
            get { return _TempReadSet; }
            set { _TempReadSet = value; }
        }


        protected override void OnLoad(EventArgs e)
        {

            this._InputDevice = new acKey.InputDevice(Handle);
            this._InputDevice.EnumerateDevices();
            this._InputDevice.KeyPressed += new acKey.InputDevice.DeviceEventHandler(InputDevice_KeyPressed);


            base.OnLoad(e);

            try
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("IS_FORM_ICON_COLOR_USE").toStringEmpty().Equals("1"))
                {
                    ControlIconColorChange(this.Controls, acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor());
                    BarManagerChildButtonIconChange(acInfo.SysConfig.GetSysConfigByMemory("ICON_COLOR").toColor());
                }
            }
            catch
            {

            }
        }



        protected override void WndProc(ref Message m)
        {

            if (this._InputDevice != null)
            {
                this._InputDevice.ProcessMessage(m);
            }

            base.WndProc(ref m);
        }



        public void ChildFormAdd(object key, BaseMenuDialog form)
        {
            form.FormKey = key;

            form.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);

            this._ChildForms.Add(key, form);
        }


        public void ChildFormRemove(object key)
        {
            if (this._ChildForms.ContainsKey(key))
            {
                this._ChildForms[key].Dispose();

                this._ChildForms.Remove(key);
            }
        }


        protected override void OnHandleDestroyed(EventArgs e)
        {

            foreach (object key in this._ChildForms.Keys)
            {
                this._ChildForms[key].Dispose();
            }

            this._ChildForms.Clear();


            base.OnHandleDestroyed(e);
        }

        void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BaseMenuDialog frm = sender as BaseMenuDialog;

            this._ChildForms.Remove(frm.FormKey);


        }



        public enum emDialogMode
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,

            /// <summary>
            /// 새로만들기
            /// </summary>
            NEW,

            /// <summary>
            /// 열기
            /// </summary>
            OPEN,


            /// <summary>
            /// 사용자정의
            /// </summary>
            USER
        }




        private emDialogMode _DialogMode = emDialogMode.NONE;

        /// <summary>
        /// 다이얼로그 모드
        /// </summary>
        public emDialogMode DialogMode
        {
            get { return _DialogMode; }
            set { _DialogMode = value; }
        }


        private bool _IsFixedWindow = false;

        /// <summary>
        /// 창고정 여부
        /// </summary>
        public bool IsFixedWindow
        {
            get { return _IsFixedWindow; }
            set { _IsFixedWindow = value; }
        }




        public override string InstantLog
        {
            set
            {
                base.InstantLog = value;
            }
        }


        public BaseMenuDialog()
        {


            InitializeComponent();
            
        }



        public bool IsDialogInit = false;

        /// <summary>
        /// 초기화
        /// </summary>
        public virtual void DialogInit()
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.IsDialogInit = true;
        }


        /// <summary>
        /// 새로운 다이얼로그를 열때
        /// </summary>
        public virtual void DialogNew()
        {

        }



        /// <summary>
        /// 사용자정의 다이얼로그를 열때
        /// </summary>
        public virtual void DialogUser()
        {


        }


        /// <summary>
        /// 지정된 다이얼로그를 열때
        /// </summary>
        public virtual void DialogOpen()
        {


        }


        /// <summary>
        /// 다이얼로그 초기화 완료
        /// </summary>
        public virtual void DialogInitComplete()
        {



        }

        void BarManagerChildButtonIconChange(Color iconColor)
        {
            if (BarManager == null)
                return;
            foreach (BarItem item in BarManager.Items)
            {
                if (item.Glyph != null)
                {
                    item.Glyph = ChangeIconColor(item.Glyph, iconColor);
                }
            }
        }

        void ControlIconColorChange(Control.ControlCollection parentCtrls, Color iconColor)
        {
            foreach (Control ctrl in parentCtrls)
            {
                if (ctrl.GetType() == typeof(acSimpleButton))
                {
                    acSimpleButton btn = ctrl as acSimpleButton;
                    if (btn.Image != null)
                    {
                        btn.Image = ChangeIconColor(btn.Image, iconColor);
                    }
                }
                else if (ctrl is acUserPopupContainerEdit)
                {
                    acUserPopupContainerEdit codeHelperBtn = ctrl as acUserPopupContainerEdit;

                    foreach (EditorButton eb in codeHelperBtn.Properties.Buttons)
                    {
                        if (eb.Image != null)
                        {
                            eb.Image = ChangeIconColor(eb.Image, iconColor);
                        }
                    }
                }
                ControlIconColorChange(ctrl.Controls, iconColor);
            }
        }

        Bitmap ChangeIconColor(Image img, Color iconColor)
        {

            Bitmap bmp = new Bitmap(img);

            int width = bmp.Width;
            int height = bmp.Height;

            //총 사이즈만큼 반복을 하면서 하나하나의 픽셀을 변경한다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;

                    //if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a, iconColor));
                }
            }
            return bmp;
        }
        public delegate void DialogDestoryEventHandler(object sender);

        public event DialogDestoryEventHandler OnDialogDestory;


        /// <summary>
        /// 다이얼로그 닫기
        /// </summary>
        public virtual bool DialogClosing()
        {
            if (this._IsProcessing == true)
            {
                return false;
            }

            return true;
        }

        public void SetLog(QBiz.emExecuteType excuteType, int cnt, TimeSpan executeTime)
        {


            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " +
                string.Format(acInfo.Resource.GetString("{0}개의 행", "A92L4ILN"), cnt) +
                " | " +
                executeTime.TotalSeconds.ToString() + acInfo.Resource.GetString("(초)", "RZ05IZP8");

        }

        public void SetLog(QBiz.emExecuteType excuteType, TimeSpan executeTime)
        {

            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " + executeTime.TotalSeconds.ToString() + acInfo.Resource.GetString("(초)", "RZ05IZP8");

        }

        public void SetLog(QBiz.emExecuteType excuteType)
        {

            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType));
        }

        public void SetLog(QBiz.emExecuteType excuteType, int cnt)
        {

            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " +
                string.Format(acInfo.Resource.GetString("{0}개의 행", "A92L4ILN"), cnt);
        }


        protected override void OnShown(EventArgs e)
        {
            this.Activate();

            base.OnShown(e);

        }


        protected override void OnClosing(CancelEventArgs e)
        {

            e.Cancel = !this.DialogClosing();

            if (e.Cancel == false)
            {
                if (this.OnDialogDestory != null)
                {
                    this.OnDialogDestory(this);
                }
            }

            base.OnClosing(e);
        }

        public delegate void DialogLoadManagerEventHandler(object sender);

        public event DialogLoadManagerEventHandler OnDialogLoadManager;

        /// <summary>
        /// 메뉴 Manager 불러옴
        /// </summary>
        public void DialogLoadManager()
        {
            if (this.OnDialogLoadManager != null)
            {
                this.OnDialogLoadManager(this);
            }

        }


        public delegate void DialogLoadBarManagerEventHandler(object sender);

        public event DialogLoadBarManagerEventHandler OnDialogLoadBarManager;

        /// <summary>
        /// 메뉴 BarManager 불러옴
        /// </summary>
        public void DialogLoadBarManager()
        {
            if (this.OnDialogLoadBarManager != null)
            {
                this.OnDialogLoadBarManager(this);
            }

        }


        public delegate void DialogLoadDockManagerEventHandler(object sender);

        public event DialogLoadDockManagerEventHandler OnDialogLoadDockManager;

        /// <summary>
        /// 메뉴 DockManager 불러옴
        /// </summary>
        public void DialogLoadDockManager()
        {
            if (this.OnDialogLoadDockManager != null)
            {
                this.OnDialogLoadDockManager(this);
            }

        }


        protected override void OnVisibleChanged(EventArgs e)
        {

            try
            {

                base.OnVisibleChanged(e);


                if (this.Visible == true)
                {

                    if (this._IsInit == false)
                    {

                        this.DialogInit();


                        switch (_DialogMode)
                        {
                            case emDialogMode.NEW:

                                this.DialogNew();

                                break;

                            case emDialogMode.USER:

                                this.DialogUser();

                                break;

                            case emDialogMode.OPEN:

                                this.DialogOpen();

                                break;


                        }


                        this.DialogLoadManager();

                        this.DialogLoadBarManager();

                        this.DialogLoadDockManager();

                        this.DialogInitComplete();

                        this._IsInit = true;

                    }


                    foreach (object key in this._ChildForms.Keys)
                    {
                        this._ChildForms[key].Show();
                    }

                }
                else
                {
                    foreach (object key in this._ChildForms.Keys)
                    {
                        this._ChildForms[key].Hide();
                    }

                }


            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }



        }

        bool _IsInit = false;



        #region IBase 멤버

        public virtual void ChildContainerInit(Control sender)
        {

        }


        /// <summary>
        /// 바코드 스캔 입력
        /// </summary>
        public virtual void BarCodeScanInput(string barcode)
        {

        }
        private bool _IsBarCodeScaning = false;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBarCodeScaning
        {
            get
            {
                return _IsBarCodeScaning;
            }
            set
            {
                this._IsBarCodeScaning = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get { return this.Text; }
        }

        private bool _IsProcessing = false;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsProcessing
        {
            get
            {
                return _IsProcessing;
            }
            set
            {
                _IsProcessing = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MenuCode
        {
            get
            {
                return (BaseMenu.GetBaseControl(this.ParentControl) as IBase).MenuCode;
            }
        }



        #endregion


    }
}