using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Drawing;

namespace ControlManager
{
    public class acTrackBarControl : DevExpress.XtraEditors.TrackBarControl , IBaseEditControl
    {
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
        //        return cp;
        //    }
        //}

        //protected override void OnPaintBackground(PaintEventArgs pevent)
        //{
        //}

        //protected override void OnResize(EventArgs eventargs)
        //{
        //    if (Parent == null)
        //        return;

        //    Rectangle rc = new Rectangle(this.Location, this.Size);
        //    Parent.Invalidate(rc, true);
        //}


        #region IBaseEditControl 멤버


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
        public bool isRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                _isRequired = value;
            }
        }

        private bool _isReadyOnly = false;


        /// <summary>
        /// 읽기전용 여부
        /// </summary>
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

            }
        }

        /// <summary>
        /// 값
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new object Value
        {
            get
            {
                return this.EditValue;
            }
            set
            {
                this.EditValue = value;

            }
        }

        private string _ColumnName = null;

        /// <summary>
        /// 컬럼명
        /// </summary>
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
            this.EditValue = 0;
        }


        public void FocusEdit()
        {
            this.Focus();

        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }


        private bool _isChanged = false;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
