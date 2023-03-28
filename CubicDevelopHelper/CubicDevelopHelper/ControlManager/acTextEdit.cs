using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace ControlManager
{
    public class acTextEdit : DevExpress.XtraEditors.TextEdit, IBaseEditControl
    {
        private object _SaveValue = null;

        public acTextEdit()
            : base()
        {


            this.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(acTextEdit_InvalidValue);

            this.GotFocus += new EventHandler(acTextEdit_GotFocus);

            this.LostFocus += new EventHandler(acTextEdit_LostFocus);

            this.EnabledChanged += AcTextEdit_EnabledChanged;
            this.EditValueChanged += AcTextEdit_EditValueChanged;
        }

        private void AcTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //if (this.Enabled == true && this.EditValue.isNullOrEmpty() == false)
           if (this.Enabled == true || (this.Enabled == false && this.EditValue.isNullOrEmpty() == false))
            {
                this._SaveValue = this.EditValue;
            }
        }

        private void AcTextEdit_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true&& this._SaveValue.isNullOrEmpty() == false)
                this.EditValue = this._SaveValue;
        }

        void acTextEdit_LostFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig != null)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
                {
                    this.SetColor();

                }
            }
        }

        void acTextEdit_GotFocus(object sender, EventArgs e)
        {
            if (acInfo.SysConfig != null)
            {
                if (acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_ENABLED").toBoolean())
                {
                    this.Properties.Appearance.BackColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_BACKCOLOR").toColor();

                    this.Properties.Appearance.ForeColor = acInfo.SysConfig.GetSysConfigByMemory("FOCUS_EDIT_FORECOLOR").toColor();

                    this.Properties.Appearance.Options.UseBackColor = true;

                }

                if (this.Properties.Mask.MaskType != DevExpress.XtraEditors.Mask.MaskType.None)
                {

                    this.Refresh();
                }

            }


            if (this.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
            {
                this.SelectAll();
            }

        }




        protected override bool ProcessKeyPreview(ref Message m)
        {

            IBase b = BaseMenu.GetBase(this);

            if (b != null)
            {
                if (b.IsBarCodeScaning == true)
                {
                    return true;

                }
            }


            return base.ProcessKeyPreview(ref m);
        }

        protected override void OnEditorKeyDownProcessNullInputKeys(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == false && e.KeyCode == System.Windows.Forms.Keys.Tab)
            {
                SendKeys.SendWait("{TAB}");


                return;


            }

            base.OnEditorKeyDownProcessNullInputKeys(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                
                
                if (this._MaskType == emMaskType.QTY ||
                this._MaskType == emMaskType.QTY_OVER)
                //this._MaskType == emMaskType.MONEY)
                {
                    char ch = e.KeyChar;


                    if (e.KeyChar == (char)('-'))
                    {
                        e.Handled = true;

                        return;
                    }
                }

                

                base.OnKeyPress(e);
            }
            catch { }
        }


        
        protected override void OnEditorKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SendKeys.SendWait("+{TAB}");
            }
            base.OnEditorKeyDown(e);
        }
        protected override void OnPropertiesChanged()
        {
            if (this.MaskType == emMaskType.USER_CODE)
            {
                if (this.Properties.ReadOnly == true)
                {
                    //읽기전용일경우 마스크를 주지않는다. 기존에 CODE 타입에 맞지않게 입력했을경우가 있음

                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                }
            }
        }


        protected override void OnEnabledChanged(EventArgs e)
        {

            this.SetColor();


            base.OnEnabledChanged(e);

        }

        private string _DefaultInvalidValueText = string.Empty;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DefaultInvalidValueText
        {
            get { return _DefaultInvalidValueText; }
            set { _DefaultInvalidValueText = value; }
        }



        void acTextEdit_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {

            if (acInfo.Resource != null)
            {
                e.ErrorText = acInfo.Resource.GetString("입력 형식이 잘못되었습니다.", "MVQ27WXK");
            }
            else
            {
                e.ErrorText = this._DefaultInvalidValueText;
            }
        }



        public enum emMaskType
        {

            /// <summary>
            /// 없음
            /// </summary>
            NONE,


            /// <summary>
            /// 숫자
            /// </summary>
            NUMBER,

            /// <summary>
            /// 1 이상의 수량
            /// </summary>
            QTY_OVER,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT,

            /// <summary>
            /// 소수점 첫째자리
            /// </summary>
            F1,

            /// <summary>
            /// 소수점 첫째자리(소수점 이하 숫자 없으면 표시 안함)
            /// </summary>
            F1_DOT_ZERO,
            /// <summary>
            /// 소수점 둘째자리
            /// </summary>
            F2,

            /// <summary>
            /// 소수점 둘째자리
            /// </summary>
            F3,

            /// <summary>
            /// 소수점 네째자리
            /// </summary>
            F4,

            /// <summary>
            /// 소수점 여섯째자리
            /// </summary>
            F6,

            /// <summary>
            /// 퍼센트 최대 100% 소수점자리없음
            /// </summary>
            PER100,

            /// <summary>
            /// 돈
            /// </summary>
            MONEY,


            //수량
            QTY,

            /// <summary>
            /// IP 주소
            /// </summary>
            IP,

            /// <summary>
            /// 전화번호
            /// </summary>
            TEL,

            /// <summary>
            /// 우편번호
            /// </summary>
            ZIP,

            /// <summary>
            /// 사업자등록번호
            /// </summary>
            CORP,

            /// <summary>
            /// 법인번호
            /// </summary>
            LAW,


            PLT_CODE,
            
            /// <summary>
            /// 분류 코드
            /// </summary>
            CAT_CODE,

            /// <summary>
            /// 기준정보 코드
            /// </summary>
            STD_CODE,

            /// <summary>
            /// 기준정보 명칭
            /// </summary>
            STD_NAME,

            /// <summary>
            /// 사용자 정보 코드
            /// </summary>
            USER_CODE,

            /// <summary>
            /// 사용자 정보 명칭
            /// </summary>
            USER_NAME,

            /// <summary>
            /// 기준정보 코드(VARCHAR(10))
            /// </summary>
            CODE,

            /// <summary>
            /// 비고(NVARCHAR100))
            /// </summary>
            SHORT_COMMENT,

            /// <summary>
            /// 작업번호
            /// </summary>
            ORD_NO,

            /// <summary>
            /// BOM 반제품 코드
            /// </summary>
            BAN_PART,

            /// <summary>
            /// n4 1,234.0000
            /// </summary>
            n4,

            /// <summary>
            /// n2 1,234.00
            /// </summary>
            n2,

            n1,
            /// <summary>
            /// NUM_4_0 0001~9999
            /// </summary>
            NUM_4_0,

            /// <summary>
            /// HH:mm
            /// </summary>
            HHmm,

            /// <summary>
            /// 주민번호
            /// </summary>
            REG_NUMBER,

            /// <summary>
            /// E-MAIL 
            /// </summary>
            E_MAIL

        }


        private emMaskType _MaskType = emMaskType.NONE;

        public emMaskType MaskType
        {
            get { return _MaskType; }

            set
            {
                _MaskType = value;


                this.SetMask();


            }

        }

        private void SetMask()
        {

            if (acInfo.IsRunTime == true)
            {
                switch (_MaskType)
                {
                    case emMaskType.NONE:


                        break;

                    case emMaskType.NUMBER:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "d";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        this.Properties.EditFormat.FormatString = "d";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0;
                        }

                        break;


                    case emMaskType.PER100:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = @"(\d{1,2}|\d{1,2}\.\d{1,2}|100)";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0;
                        }

                        break;

                    case emMaskType.QTY_OVER:



                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "N0";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        this.Properties.EditFormat.FormatString = "N0";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0;
                        }


                        break;

                    case emMaskType.F3:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "F3";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;


                        this.Properties.EditFormat.FormatString = "F3";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;



                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;

                    case emMaskType.F2:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "F2";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;


                        this.Properties.EditFormat.FormatString = "F2";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        

                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;

                    case emMaskType.F1:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "F1";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;


                        this.Properties.EditFormat.FormatString = "F1";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        

                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;

                    case emMaskType.F4:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "F4";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;


                        this.Properties.EditFormat.FormatString = "F4";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        

                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;
                    case emMaskType.F1_DOT_ZERO:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "##0.#";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;


                        this.Properties.EditFormat.FormatString = "##0.#";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        //this.ImeMode = System.Windows.Forms.ImeMode.Disable;

                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;
                    case emMaskType.F6:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "F6";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;


                        this.Properties.EditFormat.FormatString = "F6";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;



                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;

                    case emMaskType.WEIGHT:


                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "F2";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        


                        this.Properties.EditFormat.FormatString = "F2";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (this.EditValue == null)
                        {
                            this.EditValue = (double)0;
                        }

                        break;


                    case emMaskType.MONEY:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;



                        this.Properties.EditFormat.FormatString = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        

                        if (this.EditValue == null)
                        {
                            this.EditValue = (decimal)0;
                        }

                        break;

                    case emMaskType.QTY:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "N0";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        

                        this.Properties.EditFormat.FormatString = "N0";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0;
                        }

                        break;

                    case emMaskType.IP:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.TEL:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_TEL_TYPE");

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.ZIP:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_ZIP_TYPE");

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.CORP:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_CORP_TYPE");

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.LAW:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_LAW_TYPE");

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;


                    case emMaskType.PLT_CODE:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = "[a-zA-Z0-9]+";

                        this.Properties.MaxLength = 3;

                        break;

                    case emMaskType.CAT_CODE:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_STD_CODE_TYPE");

                        this.Properties.MaxLength = 4;

                        

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.STD_CODE:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_STD_CODE_TYPE");

                        this.Properties.MaxLength = 30;

                        
                        
                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.STD_NAME:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                        this.Properties.MaxLength = 150;

                        break;

                    case emMaskType.USER_CODE:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                        this.Properties.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_USER_CODE_TYPE");

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.USER_NAME:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                        this.Properties.MaxLength = 50;

                        break;

                    case emMaskType.CODE:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                        this.Properties.MaxLength = 10;

                        break;

                    case emMaskType.SHORT_COMMENT:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

                        this.Properties.MaxLength = 100;

                        break;

                    case emMaskType.ORD_NO:

                        //this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;

                        //this.Properties.Mask.EditMask = @"d{4}\-\d{4}"; // @"[A-Z.~/\-0-9]{0,10}" ; 
                        //\d{ 4}-\d{ 4}
                        this.Properties.MaskSettings.MaskExpression = @"\d{4}-\d{4}";
                        this.Properties.MaxLength = 9;

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;
                        this.Properties.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.BAN_PART:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;

                        this.Properties.Mask.EditMask = @"BAN\-\d{4}\-\d{6}"; // @"[A-Z.~/\-0-9]{0,10}" ; 

                        this.Properties.MaxLength = 14;

                        
                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        break;

                    case emMaskType.n4:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "n4";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;



                        this.Properties.EditFormat.FormatString = "n4";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0.0000;
                        }

                        break;
                    case emMaskType.n2:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "n2";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        this.Properties.EditFormat.FormatString = "n2";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0.00;
                        }

                        break;

                    case emMaskType.n1:

                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

                        this.Properties.Mask.EditMask = "N1";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;

                        this.Properties.EditFormat.FormatString = "N1";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                        if (this.EditValue == null)
                        {
                            this.EditValue = 0.0;
                        }

                        break;

                    case emMaskType.NUM_4_0:
                        //this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        //this.Properties.Mask.EditMask = "0000";
                        //this.Properties.MaxLength = 4;
                        //this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //this.Properties.DisplayFormat.FormatString = "K{0:d4}";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;
                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.Properties.Mask.EditMask = "K0000";
                        break;

                    case emMaskType.HHmm:
                        //this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        //this.Properties.Mask.EditMask = "0000";
                        //this.Properties.MaxLength = 4;
                        //this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        //this.Properties.DisplayFormat.FormatString = "K{0:d4}";

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;
                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        this.Properties.Mask.EditMask = @"(0?\d|1\d|2[0-3])\:[0-5]\d";


                        this.Properties.EditFormat.FormatString = @"(0?\d|1\d|2[0-3])\:[0-5]\d";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        break;

                    case emMaskType.REG_NUMBER:

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;
                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        this.Properties.Mask.EditMask = @"[0-9][0-9][01][0-9][0123][0-9]-[12345678][0-9]{6}";


                        this.Properties.EditFormat.FormatString = @"[0-9][0-9][01][0-9][0123][0-9]-[12345678][0-9]{6}";
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        break;

                    case emMaskType.E_MAIL:

                        this.Properties.Mask.UseMaskAsDisplayFormat = true;
                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        this.Properties.Mask.EditMask = @"\w+([-+.']\w+)*@\w+([-.]\w+)*.\w+([-.]\w+)*";
                        
                        this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        break;

                }

                //마스크 타입이 숫자이고 기본정렬 일때 오른쪽 정렬을 기본으로 사용
                if (this.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric
                && this.Properties.Appearance.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Default)
                {
                    this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
            }
        }

        protected override void OnEditValueChanging(DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            switch (_MaskType)
            {
                case emMaskType.QTY_OVER:

                    if (e.NewValue.toDecimal() < 0)
                    {
                        e.NewValue = 1;

                        e.Cancel = true;

                        this.UpdateDisplayText();

                    }

                    break;
                
            }


            base.OnEditValueChanging(e);

        }


        protected override void OnEditValueChanged()
        {

            //EditValue 가 null아 아니면 빈 스페이스인지 판단하여, null 처리]

            if (this.EditValue != null)
            {


                if (this.EditValue is string)
                {
                    string value = (string)this.EditValue;

                    value = value.Trim();

                    if (value.Equals(string.Empty))
                    {
                        this.EditValue = null;
                    }



                }


            }
            else
            {

                //EditValue 가 null이면 마스크타입에 따라 기본값 설정

                switch (_MaskType)
                {
                    case emMaskType.NUMBER:

                        this.EditValue = 0;

                        break;

                    case emMaskType.PER100:


                        this.EditValue = 0;

                        break;

                    case emMaskType.QTY_OVER:

                        this.EditValue = 1;

                        break;

                    case emMaskType.MONEY:

                        this.EditValue = 0;

                        break;


                    case emMaskType.QTY:

                        this.EditValue = 0;

                        break;

                    case emMaskType.WEIGHT:

                        this.EditValue = 0;

                        break;

                }

            }


            base.OnEditValueChanged();


        }





        private void SetSuperTip()
        {
            if (acInfo.IsRunTime == true)
            {
                if (_UseToolTipID == true)
                {
                    if (!string.IsNullOrEmpty(_ToolTipID))
                    {
                        this.SuperTip = acInfo.ToolTip.GetToolTip(_ToolTipID);


                    }
                }
            }
        }

        /// <summary>
        /// 속성에 따른 배경색 결정
        /// </summary>
        private void SetColor()
        {

            //필수 +  읽기전용

            if (this.Enabled == true)
            {

                if (_isRequired == true && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;

                }
                //필수 
                else if (_isRequired == true && _isReadyOnly == false)
                {
                    this.Properties.Appearance.BackColor = acInfo.RequiredBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.RequiredForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;
                }

                //읽기전용
                else if (_isRequired == false && _isReadyOnly == true)
                {
                    this.Properties.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

                    this.Properties.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

                    this.Properties.AppearanceReadOnly.Options.UseBackColor = true;
                }
                else
                {

                    this.Properties.Appearance.BackColor = acInfo.StandardBackColor;

                    this.Properties.Appearance.ForeColor = acInfo.StandardForeColor;

                    this.Properties.Appearance.Options.UseBackColor = true;
                    
                    
                }
            }
            else
            {
                //this.Properties.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                //this.Properties.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

                //this.Properties.Appearance.Options.UseBackColor = true;
            }

            //this.Refresh();


        }




        protected override void OnCreateControl()
        {
            this.SetMask();

            this.SetColor();

            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            base.OnCreateControl();
        }

        #region IBaseControl 멤버


        public BaseEdit Editor
        {
            get
            {
                return this;
            }

        }




        private bool _isRequired = false;

        /// <summary>
        /// 필수입력 여부
        /// </summary>
        [DefaultValue(false)]
        public bool isRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                _isRequired = value;

                this.SetColor();
            }
        }


        private bool _isReadyOnly = false;

        /// <summary>
        /// 읽기전용 여부
        /// </summary>
        [DefaultValue(false)]
        public bool isReadyOnly
        {
            get
            {
                return _isReadyOnly;
            }
            set
            {
                _isReadyOnly = value;

                if (_isReadyOnly == true)
                {
                    this.Properties.ReadOnly = true;
                }
                else
                {
                    this.Properties.ReadOnly = false;

                }

                this.SetColor();
            }
        }

        //private bool _isSetup = false;

        ///// <summary>
        ///// 읽기전용 여부
        ///// </summary>
        //[DefaultValue(false)]
        //public bool isSetup
        //{
        //    get
        //    {
        //        return _isSetup;
        //    }
        //    set
        //    {
        //        _isSetup = value;

        //        if (_isSetup == true)
        //        {
        //            this.Properties.ReadOnly = true;
        //        }
        //        else
        //        {
        //            this.Properties.ReadOnly = false;

        //        }

        //        this.SetColor();
        //    }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get
            {
                return this.EditValue;
            }
            set
            {
                _SaveValue = value;

                if (this.Enabled == false)
                {
                    this.EditValue = null;
                    return;
                }
                //else
                //{
                //_SaveValue = value;    
                //}

                this.EditValue = value;


            }
        }
       
        private string _ColumnName = null;

        /// <summary>
        /// 컬럼명
        /// </summary>
        [DefaultValue(null)]
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }

        public void Clear()
        {
            switch (this.MaskType)
            {
                case emMaskType.QTY_OVER:

                    this.EditValue = 1;

                    break;

                default:

                    this.EditValue = null;

                    break;

            }

        }


        public void FocusEdit()
        {
            this.Focus();
        }

        private string _ToolTipID = null;

        [DefaultValue(null)]
        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {


                _ToolTipID = value;

                this.SetSuperTip();

            }
        }

        private bool _UseToolTipID = false;

        [DefaultValue(false)]
        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;

                this.SetSuperTip();
            }
        }

        private bool _isChanged = false;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        public bool isChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }


        #endregion
    }
}
