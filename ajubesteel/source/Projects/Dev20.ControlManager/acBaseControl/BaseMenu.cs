using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using DevExpress.XtraEditors.Controls;
using ControlManager;
using System.Diagnostics;
using System.Threading;
using BizManager;
using DevExpress.XtraSpreadsheet.Model.History;
using DevExpress.XtraBars;

namespace ControlManager
{
    public partial class BaseMenu : DevExpress.XtraEditors.XtraUserControl, IBaseMenu, IBase
    {

        public string GetMenuConfig(string confName)
        {
            return acInfo.MenuConfig.GetMenuConfigByMemory(this.MenuCode, confName);

        }

        public DataTable GetMenuConfigRowTableByServer(object menuCode)
        {
            return acInfo.MenuConfig.GetMenuConfigRowTableByServer(this.MenuCode);
        }

        private class InputKey
        {
            public string deviceName;

            public ushort key;
        }

        private List<InputKey> _InputKeys = new List<InputKey>();


        private acKey.InputDevice _InputDevice = null;


        public virtual void ReceiveWindowMessage(string msg)
        {

        }


        public void ShowHelp()
        {
            acMessageBoxHelp frm = new acMessageBoxHelp(this.Name);

            frm.ParentControl = this;

            frm.Show();
        }



        void InputDevice_KeyPressed(object sender, acKey.InputDevice.KeyControlEventArgs e)
        {

            try
            {
                
                
                if (acInfo.IsRunTime == false)
                {
                    return;
                }

                //if (!acInfo.IsSystemFocused())
                //{
                //    return;
                //}

                //Ű�Է� ����
                if (e.Keyboard != null)
                {
                    this._InputKeys.Add(new InputKey() { deviceName = e.Keyboard.deviceName, key = e.Keyboard.key });


                    List<string> barcodeScannerIDs = new List<string>(acInfo.SysConfig.GetSysConfigByMemory("BARCODE_SCANNER_HARDWARE_ID").Split(','));

                    foreach (string barcodeScannerID in barcodeScannerIDs)
                    {
                        if (e.Keyboard.deviceName.IndexOf(barcodeScannerID, 0) > -1)
                        {
                            ////BARCODE ��ĵ
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            

            this._InputDevice = new acKey.InputDevice(Handle);
            this._InputDevice.EnumerateDevices();
            this._InputDevice.KeyPressed += new acKey.InputDevice.DeviceEventHandler(InputDevice_KeyPressed);

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

            //MessageBox.Show("a");
        }
        
        public void ReLoadInputDevice()
        {
            this._InputDevice = new acKey.InputDevice(Handle);
            this._InputDevice.EnumerateDevices();
            this._InputDevice.KeyPressed += new acKey.InputDevice.DeviceEventHandler(InputDevice_KeyPressed);
        }

        protected override void WndProc(ref Message m)
        {

            if (this._InputDevice != null)
            {
                this._InputDevice.ProcessMessage(m);

            }


            base.WndProc(ref m);
        }



        private Dictionary<object, BaseMenuDialog> _ChildForms = new Dictionary<object, BaseMenuDialog>();

        public Form GetChildForm(object key)
        {
            if (ChildFormContains(key))
            {
                return this._ChildForms[key];
            }
            else
            {
                return null;
            }
        }

        public bool ChildFormContains(object key)
        {
            return this._ChildForms.ContainsKey(key);

        }

        public void ChildFormFocus(object key)
        {
            this._ChildForms[key].Focus();
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

        void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BaseMenuDialog frm = sender as BaseMenuDialog;

            this._ChildForms.Remove(frm.FormKey);


        }

        public Dictionary<object, BaseMenuDialog> GetChildForms()
        {
            return this._ChildForms;
        }


        public IBaseMenu Menu
        {
            get
            {
                return (IBaseMenu)this;
            }
        }

        public IMainControl Main
        {
            get
            {
                return (IMainControl)this.Menu.MainControl;
            }

        }

        private static void _GetTopParentControl(Control ctrl, ref Control findControl)
        {
            if (ctrl.Parent != null)
            {
                findControl = ctrl.Parent;

                _GetTopParentControl(ctrl.Parent, ref findControl);

            }


        }

        private static void _GetBaseChildControls(Control ctrl, ref Control findControl)
        {


            foreach (Control c in ctrl.Controls)
            {
                if (c is IBase)
                {
                    findControl = c;

                    break;
                }


            }

        }

        private static void _GetBaseControl(Control ctrl, ref Control findControl)
        {
            if (ctrl.Parent != null)
            {
                if (ctrl.Parent is IBase)
                {
                    findControl = ctrl.Parent;
                }
                else
                {
                    _GetBaseControl(ctrl.Parent, ref findControl);
                }
            }
        }


        /// <summary>
        /// �θ���Ʈ�ѿ��� �ֻ��� ��Ʈ���� ��ȯ�Ѵ�.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static Control GetTopParentControl(Control ctrl)
        {
            Control findControl = null;

            _GetTopParentControl(ctrl, ref findControl);

            return findControl;
        }


        /// <summary>
        /// �θ���Ʈ�ѿ��� ���̽� ��Ʈ���� ��ȯ�Ѵ�.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static IBase GetBase(Control ctrl)
        {
            Control findControl = null;

            if (ctrl is IBase)
            {
                findControl = ctrl;
            }
            else
            {

                _GetBaseControl(ctrl, ref findControl);
            }

            return findControl as IBase;
        }

        /// <summary>
        /// �θ���Ʈ�ѿ��� ���̽� ��Ʈ���� ��ȯ�Ѵ�.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static Control GetBaseControl(Control ctrl)
        {
            Control findControl = null;

            if (ctrl is IBase)
            {
                findControl = ctrl;
            }
            else
            {

                _GetBaseControl(ctrl, ref findControl);
            }

            return findControl;
        }



        /// <summary>
        /// �ڽ���Ʈ�ѿ��� ���̽� ��Ʈ���� ��ȯ�Ѵ�.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static Control GetBaseChildControls(Control ctrl)
        {
            Control findControl = null;

            _GetBaseChildControls(ctrl, ref findControl);


            return findControl;
        }


        private Dictionary<object, object> _Data = new Dictionary<object, object>();


        public void SetData(object name, object data)
        {
            if (this._Data.ContainsKey(name))
            {
                this._Data[name] = data;
            }
            else
            {
                this._Data.Add(name, data);
            }
        }

        public object GetData(object name)
        {
            if (this._Data.ContainsKey(name))
            {
                return this._Data[name];
            }
            else
            {
                return null;
            }
        }


        public bool IsData(object name)
        {
            if (this._Data.ContainsKey(name))
            {
                return true;
            }


            return false;

        }

        private string _InstantLog = null;


        /// <summary>
        /// �α�
        /// </summary>
        public virtual string InstantLog
        {
            set { _InstantLog = value; }
        }



        public virtual acBarManager BarManager
        {
            get { return null; }
        }



        private bool _isMenuInit = false;


        /// <summary>
        /// �޴� �ʱ�ȭ ���� ����
        /// </summary>
        public bool IsMenuInit
        {
            get { return _isMenuInit; }
            set { _isMenuInit = value; }
        }

        private bool _MenuDestroy = false;

        public bool IsMenuDestroy
        {
            get { return _MenuDestroy; }
            set { _MenuDestroy = value; }
        }

        public void SetLog(QBiz.emExecuteType excuteType, int cnt, TimeSpan executeTime)
        {


            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " +
                string.Format(acInfo.Resource.GetString("{0}���� ��", "A92L4ILN"), cnt) +
                " | " +
                executeTime.TotalSeconds.ToString() + acInfo.Resource.GetString("(��)", "RZ05IZP8");

        }

        public void SetLog(QBiz.emExecuteType excuteType, int cnt)
        {


            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " +
                string.Format(acInfo.Resource.GetString("{0}���� ��", "A92L4ILN"), cnt);
                
        }

        public void SetLog(QBiz.emExecuteType excuteType, TimeSpan executeTime)
        {

            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " + executeTime.TotalSeconds.ToString() + acInfo.Resource.GetString("(��)", "RZ05IZP8");

        }


        public void SetLog(QThread.emExecuteType excuteType, TimeSpan executeTime)
        {

            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QThread.GetExecuteTypeString(excuteType))
                + " | " + executeTime.TotalSeconds.ToString() + acInfo.Resource.GetString("(��)", "RZ05IZP8");

        }

        public void SetLog(QBiz.emExecuteType excuteType)
        {

            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType));

        }

        public void SetLog(QBiz.emExecuteType excuteType, string message)
        {


            this.InstantLog = string.Format("{0} | {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), QBiz.GetExecuteTypeString(excuteType))
                + " | " + message;

        }

        /// <summary>
        /// �޴� �ʱ�ȭ
        /// </summary>
        public virtual void MenuInit()
        {


            _isMenuInit = true;
        }



        /// <summary>
        /// �޴� ��ũ�̵��� �ʱ� ����
        /// </summary>
        public virtual void MenuLink(object data)
        {

        }
        /// <summary>
        /// �޴� �˸��̵� �ʱ� ����
        /// </summary>
        public virtual void MenuNotify(object data)
        {

        }

        /// <summary>
        /// ������ ����
        /// </summary>
        public virtual void DataRefresh(object data)
        {

        }


        public delegate void MenuLoadManagerEventHandler(object sender);

        public event MenuLoadManagerEventHandler OnMenuLoadManager;

        /// <summary>
        /// �޴� Manager �ҷ���
        /// </summary>
        public void MenuLoadManager()
        {
            if (this.OnMenuLoadManager != null)
            {
                this.OnMenuLoadManager(this);
            }

        }


        public delegate void MenuLoadBarManagerEventHandler(object sender);

        public event MenuLoadBarManagerEventHandler OnMenuLoadBarManager;

        /// <summary>
        /// �޴� BarManager �ҷ���
        /// </summary>
        public void MenuLoadBarManager()
        {
            if (this.OnMenuLoadBarManager != null)
            {
                this.OnMenuLoadBarManager(this);
            }

        }


        public delegate void MenuLoadDockManagerEventHandler(object sender);

        public event MenuLoadDockManagerEventHandler OnMenuLoadDockManager;

        /// <summary>
        /// �޴� DockManager �ҷ���
        /// </summary>
        public void MenuLoadDockManager()
        {
            if (this.OnMenuLoadDockManager != null)
            {
                this.OnMenuLoadDockManager(this);
            }

        }





        /// <summary>
        /// �޴� �ʱ�ȭ �Ϸ�
        /// </summary>
        public virtual void MenuInitComplete()
        {
            
        }

        void BarManagerChildButtonIconChange(Color iconColor)
        {
            if (BarManager == null)
                return;
		    foreach(BarItem item in BarManager.Items)
            {
                if(item.Glyph != null)
                {
                    item.Glyph = ChangeIconColor(item.Glyph, iconColor);
                }
			}
        }

        void ControlIconColorChange(ControlCollection parentCtrls, Color iconColor)
        {
            foreach(Control ctrl in parentCtrls)
            {
                if(ctrl.GetType() == typeof(acSimpleButton))
                {
                    acSimpleButton btn = ctrl as acSimpleButton;
                    if (btn.Image != null)
                    {
                        btn.Image = ChangeIconColor(btn.Image, iconColor);
                    }
                }
                else if(ctrl is acUserPopupContainerEdit)
                {
                    acUserPopupContainerEdit codeHelperBtn = ctrl as acUserPopupContainerEdit;

                    foreach(EditorButton eb in codeHelperBtn.Properties.Buttons)
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

            //�� �����ŭ �ݺ��� �ϸ鼭 �ϳ��ϳ��� �ȼ��� �����Ѵ�.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    
                    //if (p.R == 0 && p.G == 0 && p.B == 0)
                        bmp.SetPixel(x, y, Color.FromArgb(a,iconColor));
                }
            }
            return bmp;
        }
        public delegate void MenuDestoryEventHandler(object sender);

        public event MenuDestoryEventHandler OnMenuDestory;


        /// <summary>
        /// �޴� �Ҹ� (��ȯ�� true-�Ҹ� , false - ���)  
        /// </summary>
        public virtual bool MenuDestory(object sender)
        {

            //ó������ �۾��� �մ��� Ȯ���Ѵ�.

            if (this._IsProcessing == true)
            {
                return false;
            }


            foreach (object key in this._ChildForms.Keys)
            {
                this._ChildForms[key].Dispose();
            }

            this._ChildForms.Clear();

            if (this.OnMenuDestory != null)
            {
                this.OnMenuDestory(this);
            }

            return true;
        }



        /// <summary>
        /// �޴� ��Ŀ���� �������
        /// </summary>
        public virtual void MenuGotFocus()
        {

            foreach (object key in this._ChildForms.Keys)
            {
                this._ChildForms[key].Show();
            }

        }

        /// <summary>
        /// �޴� ��Ŀ���� �Ҿ�����
        /// </summary>
        public virtual void MenuLostFocus()
        {
            foreach (object key in this._ChildForms.Keys)
            {

                if (this._ChildForms[key].IsFixedWindow == false)
                {
                    this._ChildForms[key].Hide();
                }

            }
        }






        public enum emMenuStatus
        {
            /// <summary>
            /// ����
            /// </summary>
            NONE,

            /// <summary>
            /// �����ϰų� �۾����� �׸��� ����
            /// </summary>
            WORK,

        }


        private emMenuStatus _MenuStatus = emMenuStatus.NONE;


        /// <summary>
        /// �޴� ����
        /// </summary>
        public virtual emMenuStatus MenuStatus
        {
            get { return _MenuStatus; }
            set { _MenuStatus = value; }
        }


        //private DevExpress.XtraBars.BarManager _DefaultBarManager = null;


        public BaseMenu()
        {

            InitializeComponent();

            //if (acInfo.IsRunTime == true)
            //{

            //    this._DefaultBarManager = new DevExpress.XtraBars.BarManager();

            //    this._DefaultBarManager.AllowCustomization = false;
            //    this._DefaultBarManager.AllowQuickCustomization = false;
            //    this._DefaultBarManager.AllowShowToolbarsPopup = false;
            //    this._DefaultBarManager.CloseButtonAffectAllTabs = false;
            //    this._DefaultBarManager.ShowFullMenusAfterDelay = false;
            //    this._DefaultBarManager.ShowFullMenus = true;



            //    this._DefaultBarManager.Form = this;
            //}

        }


        #region IBaseMenu ���


        Control IBaseMenu.MenuControl
        {
            get
            {
                return this;
            }

        }


        private Control _MainControl = null;

        Control IBaseMenu.MainControl
        {
            get
            {
                return _MainControl;
            }
            set
            {
                _MainControl = value;
            }
        }


        #endregion



        #region IBase ���

        public virtual void ChildContainerInit(Control sender)
        {

        }



        /// <summary>
        /// ���ڵ� ��ĵ �Է�
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

        /// <summary>
        /// ����Ʈ�� �޴���
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get { return this.Parent.Text; }
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

        private string _MenuCode = null;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MenuCode
        {
            get
            {
                return _MenuCode;
            }
            set
            {
                _MenuCode = value;
            }
        }

        private string _MenuName = null;

        public string MenuName
        {
            get
            {
                return _MenuName;
            }
            set
            {
                _MenuName = value;
            }
        }


        private string _ClassName = null;

        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
            }
        }


        private bool _readOnly = false;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
            }
        }


        #endregion

        private void BaseMenu_Load(object sender, EventArgs e)
        {

        }


        


    }


}
