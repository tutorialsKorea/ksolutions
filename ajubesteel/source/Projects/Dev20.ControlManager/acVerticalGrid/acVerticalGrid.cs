using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Data;
using DevExpress.XtraEditors;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid;
using BizManager;


namespace ControlManager
{




    public class acVerticalGrid : DevExpress.XtraVerticalGrid.VGridControl
    {
        private ImageList imageList1 = new ImageList();

        public acVerticalGrid()
        {
            this.imageList1.ImageSize = new Size(16, 16);

            this.imageList1.ColorDepth = ColorDepth.Depth32Bit;

            this.imageList1.Images.Add(ControlManager.Resource.sign_question_x16);

            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;


            this.ImageList = this.imageList1;

            this.LayoutStyle = LayoutViewStyle.BandsView;

            this.ToolTipController = new ToolTipController();

            this.InvalidValueException += new InvalidValueExceptionEventHandler(acVerticalGrid_InvalidValueException);


            this.RowHeaderWidthChanged += new EventHandler(acVerticalGrid_RowHeaderWidthChanged);


            System.Windows.Forms.Timer hoverTimeItemTimer = new System.Windows.Forms.Timer();

            hoverTimeItemTimer.Interval = 300;

            hoverTimeItemTimer.Tick += new EventHandler(hoverTimeItemTimer_Tick);

            if (acInfo.IsRunTime == true)
            {
                hoverTimeItemTimer.Start();
            }


        }




        private int _StopHitCnt = 0;

        private Point _HitPoint = Point.Empty;

        void hoverTimeItemTimer_Tick(object sender, EventArgs e)
        {

            if (this.IsHandleCreated == false)
            {

                return;
            }

            if (WIN32API.WindowFromPoint(Control.MousePosition.X, Control.MousePosition.Y) != (IntPtr)this.Handle)
            {
                this.ToolTipController.HideHint();

                this._StopHitCnt = 0;

                return;
            }


            if (this.Enabled == false)
            {
                this.ToolTipController.HideHint();


                this._StopHitCnt = 0;

                return;

            }

            Point pt = this.PointToClient(Control.MousePosition);


            if (this._HitPoint.X != pt.X || this._HitPoint.Y != pt.Y)
            {
                this.ToolTipController.HideHint();

                this._HitPoint = pt;

                this._StopHitCnt = 0;

                return;
            }



            if (this._StopHitCnt == 4)
            {

                VGridHitInfo hi = this.CalcHitInfo(pt);

                if (hi != null)
                {
                    acEditorRow row = hi.Row as acEditorRow;

                    if (row != null)
                    {
                        if (!string.IsNullOrEmpty(row.Description))
                        {
                            SuperToolTip superTT = new SuperToolTip();

                            ToolTipTitleItem titleTT = new ToolTipTitleItem();

                            ToolTipItem contentTT = new ToolTipItem();

                            titleTT.Text = hi.Row.Properties.Caption;
                            superTT.Items.Add(titleTT);

                            contentTT.Text = row.Description;
                            superTT.Items.Add(contentTT);

                            DevExpress.Utils.ToolTipControllerShowEventArgs args = new DevExpress.Utils.ToolTipControllerShowEventArgs();

                            args.SuperTip = superTT;

                            args.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;

                            this.ToolTipController.ShowHint(args, Control.MousePosition);


                            this._StopHitCnt = 0;
                        }
                    }

                }

            }



            ++this._StopHitCnt;

        }




        void acVerticalGrid_RowHeaderWidthChanged(object sender, EventArgs e)
        {
            this.OnResize(null);
        }


        protected override void OnResize(EventArgs e)
        {
            this.RecordWidth = this.Width - this.RowHeaderWidth;

            base.OnResize(e);
        }


        void acVerticalGrid_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }


        public delegate void ValueChangedEventHandler(object sender, string columnName, object newValue);

        public event ValueChangedEventHandler OnValueChanged;

        public enum emEditorType
        {
            NONE,

            CUSTOM,

            TEXT,

            HIDDEN,

            CHECK,

            DATE,

            TIME,

            LOOKUP,

            BUTTON,

            COLOR,

            COMBOBOX

        }


        public object GetCellValue(string fieldName)
        {
            return this.GetCellValue(this.Rows[fieldName], 0);
        }

        public void SetCellValue(string fieldName, object value)
        {
            this.SetCellValue(this.Rows[fieldName], 0, value);
        }


        public void AddCategoryRow(string caption, string resourceID, bool useResourceID, string[] childColumns)
        {
            CategoryRow row = new CategoryRow();

            row.Height = 30;
            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }



            //this.Rows.Add(row);

            foreach (string column in childColumns)
            {

                acEditorRow bRow = (acEditorRow)this.GetRowByFieldName(column);
                row.Height = 40;
                if (bRow != null)
                {
                    row.ChildRows.Add(this.Rows[column]);

                    this.Rows.Remove(this.Rows[column]);
                }

            }

            this.Rows.Add(row);


        }

        private bool IsRowByFieldName(string fieldName)
        {
            try
            {
                BaseRow row = this.Rows[fieldName];

                if (row != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }


        public void AddCategoryRow(string categoryName, string caption, string resourceID, bool useResourceID, string parentCategoryName, string[] childColumns)
        {
            CategoryRow row = new CategoryRow();

            row.Name = categoryName;
            row.Properties.FieldName = categoryName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }


            foreach (string column in childColumns)
            {

                if (this.IsRowByFieldName(column) == true)
                {
                    row.ChildRows.Add(this.Rows[column]);

                    this.Rows.Remove(this.Rows[column]);
                }

            }

            if (this.IsRowByFieldName(parentCategoryName) == true)
            {

                this.Rows[parentCategoryName].ChildRows.Add(row);

            }
            else
            {
                this.Rows.Add(row);
            }



        }

        public enum emTextEditMask
        {
            /// <summary>
            /// 없음
            /// </summary>
            NONE,


            /// <summary>
            /// 대문자 영문
            /// </summary>
            UPPERCASE,

            /// <summary>
            /// 숫자
            /// </summary>
            NUMERIC,

            /// <summary>
            /// 수량
            /// </summary>
            QTY,

            /// <summary>
            /// 돈
            /// </summary>
            MONEY,

            /// <summary>
            /// 무게
            /// </summary>
            WEIGHT,


            /// <summary>
            /// 공수(시간)
            /// </summary>
            TIME,

            /// <summary>
            /// PASSWORD
            /// </summary>
            PW

        };


        public void AddCustomEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, RepositoryItem editor)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.CUSTOM;

            row.Name = columnName;


            row.Visible = visible;


            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }


            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;


            row.ResourceID = resourceID;

            row.useResourceID = useResourceID;


            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            row.Properties.RowEdit = editor;

            editor.Tag = row;

            editor.ReadOnly = !allowEdit;

            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);

            this.Rows.Add(row);

        }

        public void AddHidden(string columnName)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.HIDDEN;

            row.Name = columnName;

            row.Properties.FieldName = columnName;

            row.Visible = false;

            this.Rows.Add(row);
        }

        public void AddTextEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, emTextEditMask mask)
        {
            acEditorRow row = new acEditorRow();


            row.EditorType = emEditorType.TEXT;

            row.Name = columnName;

            row.Properties.FieldName = columnName;

            row.Visible = visible;

            row.Height = 27;
            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }


            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }


            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;

            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;



            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemTextEdit editor = new RepositoryItemTextEdit();

            editor.Tag = row;

            switch (mask)
            {
                case emTextEditMask.NONE:

                    break;

                case emTextEditMask.NUMERIC:



                    editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    editor.Mask.EditMask = "d";


                    break;

                case emTextEditMask.QTY:


                    editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    editor.Mask.EditMask = "N0";

                    break;

                case emTextEditMask.MONEY:

                    editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    editor.Mask.EditMask = acInfo.SysConfig.GetSysConfigByMemory("MASK_MONEY_TYPE");

                    break;

                case emTextEditMask.TIME:



                    editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    editor.Mask.EditMask = "F0";

                    break;

                case emTextEditMask.WEIGHT:

                    editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    editor.Mask.EditMask = "F2";

                    break;

                case emTextEditMask.UPPERCASE:


                    editor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

                    editor.Mask.EditMask = @"\p{Lu}+";

                    break;

                case emTextEditMask.PW:

                    editor.PasswordChar = '●';

                    break;


            }

            editor.Mask.UseMaskAsDisplayFormat = true;


            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;


            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;


            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);

            //editor.PropertiesChanged += new EventHandler(editor_PropertiesChanged);

            this.Rows.Add(row);




        }



        private Dictionary<string, List<string>> _GroupDic = new Dictionary<string, List<string>>();


        /// <summary>
        /// 에디터를 종료한다.
        /// </summary>
        public void EndEditor()
        {
            this.CloseEditor();

        }


        /// <summary>
        /// 특정그룹에 읽기전용을 설정한다.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="readOnly"></param>
        public void SetReadOnlyGroup(string group, bool readOnly)
        {
            foreach (string key in _GroupDic[group])
            {
                acEditorRow bRow = (acEditorRow)this.GetRowByFieldName(key);

                if (bRow != null)
                {
                    this.Rows[key].Properties.RowEdit.ReadOnly = readOnly;
                }
            }
        }


        /// <summary>
        /// 특정그룹에 표시여부를 설정한다.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="readOnly"></param>
        public void SetVisibleGroup(string group, bool visible)
        {
            foreach (string key in _GroupDic[group])
            {
                acEditorRow bRow = (acEditorRow)this.GetRowByFieldName(key);

                if (bRow != null)
                {
                    this.Rows[key].Properties.Row.Visible = visible;
                }
            }
        }


        /// <summary>
        /// 그룹을 생성한다.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="columns"></param>
        public void CreateGroup(string group, string[] columns)
        {
            List<string> colList = new List<string>();

            foreach (string col in columns)
            {
                colList.Add(col);
            }

            _GroupDic.Add(group, colList);

        }



        public void ClearRows()
        {
            this.Rows.Clear();

        }


        public void Clear()
        {
            for (int i = 0; i < this.Rows.Count; i++)
            {
                this.Rows[i].Properties.Value = null;
            }

        }


        public void SetReadOnly(string[] columns, bool readOnly)
        {
            foreach (string col in columns)
            {
                acEditorRow bRow = (acEditorRow)this.GetRowByFieldName(col);

                if (bRow != null)
                {
                    this.Rows[col].Properties.RowEdit.ReadOnly = readOnly;
                }

            }
        }

        /*
        void editor_PropertiesChanged(object sender, EventArgs e)
        {

            RepositoryItem editor = sender as RepositoryItem;

            acEditorRow row = (acEditorRow)editor.Tag;

            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;


        }
        */


        private List<string> _EditValueChangedRows = new List<string>();


        void editor_EditValueChanged(object sender, EventArgs e)
        {

            BaseEdit baseEditor = sender as BaseEdit;

            RepositoryItem editor = (RepositoryItem)baseEditor.Tag;

            acEditorRow row = (acEditorRow)editor.Tag;


            this._EditValueChangedRows.Add(row.Name);


            if (this.OnValueChanged != null)
            {
                this.OnValueChanged(sender, row.Name, baseEditor.EditValue);

            }

        }



        public enum emDateMask
        {
            /// <summary>
            /// 년월일
            /// </summary>
            SHORT_DATE,

            /// <summary>
            /// 년월일시분
            /// </summary>
            MEDIUM_DATE,

            /// <summary>
            /// 년월일시분초
            /// </summary>
            LONG_DATE

        };

        public enum emCheckEditDataType { _BOOL, _STRING, _INT, _BYTE, _YN };

        public void AddCheckEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, emCheckEditDataType chekEditDataType)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.COLOR;

            row.Name = columnName;

            row.Visible = visible;

            row.Properties.FieldName = columnName;

            row.Height = 40;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }

            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {

                row.Description = description;
            }


            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }


            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;

            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;





            RepositoryItemCheckEdit editor = new RepositoryItemCheckEdit();

            editor.GlyphAlignment = align;

            editor.Caption = string.Empty;

            editor.NullStyle = StyleIndeterminate.Unchecked;


            switch (chekEditDataType)
            {
                case emCheckEditDataType._BOOL:

                    editor.ValueChecked = true;
                    editor.ValueUnchecked = false;


                    break;

                case emCheckEditDataType._INT:

                    editor.ValueChecked = 1;
                    editor.ValueUnchecked = 0;



                    break;

                case emCheckEditDataType._BYTE:

                    editor.ValueChecked = (byte)1;
                    editor.ValueUnchecked = (byte)0;




                    break;

                case emCheckEditDataType._STRING:

                    editor.ValueChecked = "1";
                    editor.ValueUnchecked = "0";

                    break;
                case emCheckEditDataType._YN:

                    editor.ValueChecked = "Y";
                    editor.ValueUnchecked = "N";

                    break;

            }

            editor.Tag = row;


            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;

            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;


            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);

            // editor.PropertiesChanged += new EventHandler(editor_PropertiesChanged);

            this.Rows.Add(row);
        }

        public void AddColorEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible)
        {

            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.COLOR;

            row.Name = columnName;

            row.Visible = visible;

            row.Properties.FieldName = columnName;


            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }

            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;

            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;


            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemColorEdit editor = new RepositoryItemColorEdit();

            editor.Tag = row;


            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;

            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;


            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);

            editor.KeyDown += new KeyEventHandler(editor_KeyDown);

            //editor.PropertiesChanged += new EventHandler(editor_PropertiesChanged);

            this.Rows.Add(row);

        }

        void editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ColorEdit)
            {
                ColorEdit edit = sender as ColorEdit;

                edit.EditValue = DBNull.Value;
            }
        }

        public void AddMemoEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment hAlign, VertAlignment vAlign, bool allowEdit, bool visible)
        {
            acEditorRow row = new acEditorRow();


            row.EditorType = emEditorType.TEXT;

            row.Name = columnName;

            row.Properties.FieldName = columnName;

            row.Visible = visible;


            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }


            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;

            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;



            row.Appearance.TextOptions.VAlignment = vAlign;


            row.Appearance.TextOptions.HAlignment = hAlign;


            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemMemoEdit editor = new RepositoryItemMemoEdit();

            editor.Appearance.TextOptions.VAlignment = vAlign;

            editor.Appearance.TextOptions.HAlignment = hAlign;

            editor.Appearance.Options.UseTextOptions = true;

            editor.Tag = row;




            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;


            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;


            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);


            this.Rows.Add(row);


        }

        public void AddComboBoxEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, List<object> list)
        {
            acEditorRow row = new acEditorRow();
            row.EditorType = emEditorType.COMBOBOX;
            row.Name = columnName;
            row.Visible = visible;
            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }

            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;
            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;
            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;
            row.Appearance.TextOptions.HAlignment = align;
            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemComboBox editor = new RepositoryItemComboBox();
            editor.BorderStyle = BorderStyles.NoBorder;
            editor.TextEditStyle = TextEditStyles.DisableTextEditor;

            foreach (object t in list)
            {
                editor.Items.Add(t);
            }

            editor.Tag = row;
            row.Properties.RowEdit = editor;
            editor.ReadOnly = !allowEdit;
            editor.Appearance.BackColor = acInfo.StandardBackColor;
            editor.Appearance.ForeColor = acInfo.StandardForeColor;
            editor.Appearance.Options.UseBackColor = true;
            editor.Appearance.Options.UseForeColor = true;
            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;
            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;
            editor.AppearanceReadOnly.Options.UseBackColor = true;
            editor.AppearanceReadOnly.Options.UseForeColor = true;

            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;
                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;
                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;
            }

            row.Appearance.Options.UseBackColor = true;
            row.Appearance.Options.UseForeColor = true;

            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);

            this.Rows.Add(row);
        }

        public void AddDateEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, emDateMask mask)
        {
            acEditorRow row = new acEditorRow();
            row.EditorType = emEditorType.DATE;
            row.Name = columnName;
            row.Visible = visible;
            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }

            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;
            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;
            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;
            row.Appearance.TextOptions.HAlignment = align;
            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemDateEdit editor = new RepositoryItemDateEdit();
            editor.Tag = row;
            switch (mask)
            {
                case emDateMask.SHORT_DATE:
                    editor.Mask.EditMask = "d";
                    break;
                case emDateMask.MEDIUM_DATE:
                    editor.Mask.EditMask = "yyyy-MM-dd HH:mm";
                    break;
                case emDateMask.LONG_DATE:
                    editor.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
                    break;
            }

            editor.Mask.UseMaskAsDisplayFormat = true;
            row.Properties.RowEdit = editor;
            editor.ReadOnly = !allowEdit;
            editor.Appearance.BackColor = acInfo.StandardBackColor;
            editor.Appearance.ForeColor = acInfo.StandardForeColor;
            editor.Appearance.Options.UseBackColor = true;
            editor.Appearance.Options.UseForeColor = true;
            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;
            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;
            editor.AppearanceReadOnly.Options.UseBackColor = true;
            editor.AppearanceReadOnly.Options.UseForeColor = true;

            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;
                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;
                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;
            }

            row.Appearance.Options.UseBackColor = true;
            row.Appearance.Options.UseForeColor = true;

            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);

            this.Rows.Add(row);

        }


        public void AddDateEdit(string columnName, string caption, string resourceID, bool useReSourceID, HorzAlignment align, bool allowEdit, bool visible, bool isRequired, string mask, string ctr)
        {
            acGridColumn col = new acGridColumn();
            col.FieldName = columnName;
            if (useReSourceID == true)
            {
                col.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                col.Caption = caption;
            }

            col.ResourceID = resourceID;
            col.UseResourceID = useReSourceID;
            col.OptionsColumn.AllowEdit = allowEdit;
            col.Visible = visible;

            if (col.Visible == true)
            {
                //col.VisibleIndex = this.VisibleColumns.Count + 1;
            }
            col.IsRequired = isRequired;
            col.OptionsColumn.AllowMerge = DefaultBoolean.False;
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            col.AppearanceHeader.Options.UseTextOptions = true;
            col.AppearanceCell.TextOptions.HAlignment = align;
            col.AppearanceCell.Options.UseTextOptions = true;
            //col.EditorType = emEditorType.DATE;

            if (!mask.isNullOrEmpty())
            {
                col.EditorData = mask;
            }

            RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit();
            dateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;

            if (!mask.isNullOrEmpty())
            {
                dateEdit.Mask.EditMask = mask;
            }
            if (!ctr.isNullOrEmpty())
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(ctr);
                dateEdit.Mask.Culture = culture;
            }

            dateEdit.Mask.UseMaskAsDisplayFormat = true;
            dateEdit.Appearance.TextOptions.HAlignment = align;
            dateEdit.Appearance.Options.UseTextOptions = true;
            col.ColumnEdit = dateEdit;

            //this.Columns.Add(col);
        }

        private Control _ParentControl = null;

        /// <summary>
        /// 부모컨트롤
        /// </summary>
        public Control ParentControl
        {
            get { return _ParentControl; }
            set
            {
                _ParentControl = value;

            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.ParentControl == null)
            {
                this.ParentControl = this.GetContainerControl() as Control;
            }

        }

        /// <summary>
        /// 기본레이아웃을 저장한다.
        /// </summary>
        void SaveDefaultLayout()
        {



            MemoryStream layoutSt = new MemoryStream();


            this.SaveLayoutToStream(layoutSt);



            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //
            paramTable.Columns.Add("CONFIG_NAME", typeof(String)); //
            paramTable.Columns.Add("DEFAULT_USE", typeof(String)); //기본UI로 설정
            paramTable.Columns.Add("LAYOUT", typeof(Byte[])); //
            paramTable.Columns.Add("OBJECT", typeof(Byte[])); //
            paramTable.Columns.Add("OVERWRITE", typeof(String)); //덮어쓰기 여부

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;

            paramRow["CLASS_NAME"] = this._ParentControl;

            paramRow["CONTROL_NAME"] = this.Name;
            paramRow["CONFIG_NAME"] = acInfo.DefaultConfigName;
            paramRow["DEFAULT_USE"] = "1";
            paramRow["LAYOUT"] = layoutSt.ToArray();
            paramRow["OBJECT"] = null;
            paramRow["OVERWRITE"] = "1";
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "SET_USERCONFIG_SAVE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.SET_USERCONFIG_SAVE(paramSet);

            layoutSt.Close();

        }

        /// <summary>
        /// 기본레이아웃을 불러온다.
        /// </summary>
        public void LoadDefaultLayout()
        {


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("EMP_CODE", typeof(String)); //
            paramTable.Columns.Add("CLASS_NAME", typeof(String)); //
            paramTable.Columns.Add("CONTROL_NAME", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["EMP_CODE"] = acInfo.UserID;
            paramRow["CLASS_NAME"] = this._ParentControl;
            paramRow["CONTROL_NAME"] = this.Name;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_USERCONFIG_DEFAULT_USE", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_USERCONFIG_DEFAULT_USE(paramSet);

            if (resultSet.Tables["RSLTDT"].Rows.Count != 0)
            {

                byte[] layout = (byte[])resultSet.Tables["RSLTDT"].Rows[0]["LAYOUT"];

                MemoryStream layoutSt = new MemoryStream(layout, 0, layout.Length);

                this.RestoreLayoutFromStream(layoutSt);

                layoutSt.Close();

            }


        }


        public void AddTimeEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, string mask)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.TIME;

            row.Name = columnName;

            row.Visible = visible;

            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }


            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }


            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;

            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;


            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemTimeEdit editor = new RepositoryItemTimeEdit();

            editor.Tag = row;

            editor.Mask.EditMask = mask;

            editor.Mask.UseMaskAsDisplayFormat = true;

            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;




            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;



            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);



            this.Rows.Add(row);

        }

        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, string catCode)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.LOOKUP;

            row.Name = columnName;

            row.Visible = visible;

            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }

            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;


            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;

            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemLookUpEdit editor = new RepositoryItemLookUpEdit();

            editor.Tag = row;

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();

            editor.Mask.UseMaskAsDisplayFormat = true;


            displayColumnInfo.FieldName = "CD_NAME";
            displayColumnInfo.Caption = "CD_NAME";

            valueColumnInfo.FieldName = "CD_CODE";
            valueColumnInfo.Caption = "CD_CODE";

            valueColumnInfo.Visible = false;

            editor.NullText = string.Empty;
            editor.ShowHeader = false;
            editor.ShowFooter = true;

            editor.Columns.Add(displayColumnInfo);
            editor.Columns.Add(valueColumnInfo);



            editor.DataSource = acInfo.StdCodes.GetCatTable(catCode);

            editor.DisplayMember = "CD_NAME";

            editor.ValueMember = "CD_CODE";

            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;



            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;



            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);



            this.Rows.Add(row);

        }


        public void AddLookUpEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible, string displayColumnName, string valueColumnName, object dataSource)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.LOOKUP;

            row.Name = columnName;

            row.Visible = visible;

            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }

            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }

            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;


            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;

            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemLookUpEdit editor = new RepositoryItemLookUpEdit();

            editor.Tag = row;

            LookUpColumnInfo displayColumnInfo = new LookUpColumnInfo();
            LookUpColumnInfo valueColumnInfo = new LookUpColumnInfo();

            editor.Mask.UseMaskAsDisplayFormat = true;


            displayColumnInfo.FieldName = displayColumnName;
            displayColumnInfo.Caption = valueColumnName;

            valueColumnInfo.FieldName = valueColumnName;
            valueColumnInfo.Caption = valueColumnName;

            valueColumnInfo.Visible = false;

            editor.NullText = string.Empty;
            editor.ShowHeader = false;
            editor.ShowFooter = true;

            editor.Columns.Add(displayColumnInfo);
            editor.Columns.Add(valueColumnInfo);



            editor.DataSource = dataSource;

            editor.DisplayMember = displayColumnName;

            editor.ValueMember = valueColumnName;

            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;



            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;



            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);



            this.Rows.Add(row);

        }

        public void AddButtonEdit(string columnName, string caption, string resourceID, bool useResourceID, string description, string descriptionID, bool useDescriptionID, HorzAlignment align, bool allowEdit, bool visible)
        {
            acEditorRow row = new acEditorRow();

            row.EditorType = emEditorType.BUTTON;

            row.Name = columnName;



            row.Visible = visible;

            row.Properties.FieldName = columnName;

            if (useResourceID == true)
            {
                row.Properties.Caption = acInfo.Resource.GetString(caption, resourceID);
            }
            else
            {
                row.Properties.Caption = caption;
            }



            if (useDescriptionID == true)
            {
                row.Description = acInfo.Resource.GetString(description, descriptionID);
            }
            else
            {
                row.Description = description;
            }


            if (!string.IsNullOrEmpty(row.Description))
            {
                row.Properties.ImageIndex = 0;

            }

            row.DescriptionID = descriptionID;
            row.UseDescriptionID = useDescriptionID;


            row.ResourceID = resourceID;
            row.useResourceID = useResourceID;


            row.Appearance.TextOptions.HAlignment = align;

            row.Appearance.Options.UseTextOptions = true;

            RepositoryItemButtonEdit editor = new RepositoryItemButtonEdit();

            editor.TextEditStyle = TextEditStyles.DisableTextEditor;

            editor.Tag = row;

            row.Properties.RowEdit = editor;

            editor.ReadOnly = !allowEdit;



            editor.Appearance.BackColor = acInfo.StandardBackColor;

            editor.Appearance.ForeColor = acInfo.StandardForeColor;

            editor.Appearance.Options.UseBackColor = true;

            editor.Appearance.Options.UseForeColor = true;


            editor.AppearanceReadOnly.BackColor = acInfo.ReadOnlyBackColor;

            editor.AppearanceReadOnly.ForeColor = acInfo.ReadOnlyForeColor;

            editor.AppearanceReadOnly.Options.UseBackColor = true;

            editor.AppearanceReadOnly.Options.UseForeColor = true;


            if (editor.ReadOnly == false)
            {
                row.Appearance.BackColor = acInfo.StandardBackColor;

                row.Appearance.ForeColor = acInfo.StandardForeColor;
            }
            else
            {
                row.Appearance.BackColor = acInfo.ReadOnlyBackColor;

                row.Appearance.ForeColor = acInfo.ReadOnlyForeColor;

            }

            row.Appearance.Options.UseBackColor = true;

            row.Appearance.Options.UseForeColor = true;



            editor.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;


            editor.EditValueChanged += new EventHandler(editor_EditValueChanged);



            this.Rows.Add(row);

        }



        private int _CarretPosition = 0;


        public void SaveActiveEditorCaretPosition()
        {

            if (this.ActiveEditor is TextEdit)
            {

                _CarretPosition = (this.ActiveEditor as TextEdit).SelectionStart;
            }

        }

        public void SetActiveEditorCaretPosition()
        {
            this.ShowEditor();

            if (this.ActiveEditor is TextEdit)
            {
                DevExpress.XtraEditors.TextEdit editor = this.ActiveEditor as TextEdit;

                editor.SelectionStart = _CarretPosition;

                editor.SelectionLength = 0;

            }

        }


        private void _CreateEditColumn(VGridRows vRows, ref DataTable dt, bool isValueChanged)
        {

            foreach (BaseRow row in vRows)
            {
                if (row.ChildRows.Count > 0)
                {
                    _CreateEditColumn(row.ChildRows, ref dt, isValueChanged);
                }
                else
                {

                    if (isValueChanged == true)
                    {
                        if (this._EditValueChangedRows.Contains(row.Properties.FieldName))
                        {

                            dt.Columns.Add(row.Properties.FieldName);
                        }

                    }

                }
            }
        }

        public DataTable CreateParameterTable(bool isValueChanged)
        {

            DataTable temp = new DataTable();

            this._CreateEditColumn(this.Rows, ref temp, isValueChanged);


            DataRow tempRow = temp.NewRow();

            foreach (DataColumn col in temp.Columns)
            {
                RepositoryItem item = this.Rows[col.ColumnName].Properties.RowEdit;

                if (item is RepositoryItemColorEdit)
                {
                    tempRow[col.ColumnName] = this.Rows[col.ColumnName].Properties.Value.toColor().ToArgb();
                }
                else if (item is RepositoryItemTimeEdit)
                {
                    RepositoryItemTimeEdit timeEdit = item as RepositoryItemTimeEdit;

                    tempRow[col.ColumnName] = this.Rows[col.ColumnName].Properties.Value.toDateTime().ToString(timeEdit.Mask.EditMask);
                }
                else
                {
                    tempRow[col.ColumnName] = this.Rows[col.ColumnName].Properties.Value;
                }
            }

            temp.Rows.Add(tempRow);


            return temp;

        }

        public void ClearValueChanged()
        {
            this._EditValueChangedRows.Clear();
        }

        private DataRow _DataBindRow = null;

        public DataRow DataBindRow
        {
            get { return _DataBindRow; }
            set { _DataBindRow = value; }
        }


        /// <summary>
        /// 바인딩된 데이터를 갱신한다.
        /// </summary>
        public void RefreshData()
        {
            this.DataBind(_DataBindRow);
        }

        public void DataBind(DataRow row)
        {

            foreach (DataColumn col in row.Table.Columns)
            {
                acEditorRow bRow = (acEditorRow)this.GetRowByFieldName(col.ColumnName);

                if (bRow != null)
                {
                    switch (bRow.EditorType)
                    {
                        case emEditorType.DATE:

                            this.Rows[col.ColumnName].Properties.Value = row[col.ColumnName].isNull() ? (object)DBNull.Value : (object)row[col.ColumnName].toDateTime();

                            break;

                        case emEditorType.TIME:

                            this.Rows[col.ColumnName].Properties.Value = row[col.ColumnName].isNull() ? (object)DBNull.Value : (object)row[col.ColumnName].toTimeSpan();

                            break;

                        case emEditorType.LOOKUP:

                            RepositoryItemLookUpEdit editor = (RepositoryItemLookUpEdit)this.Rows[col.ColumnName].Properties.RowEdit;

                            this.Rows[col.ColumnName].Properties.Value = Convert.ChangeType(row[col.ColumnName], ((DataTable)editor.DataSource).Columns[editor.ValueMember].DataType);

                            break;


                        default:

                            this.Rows[col.ColumnName].Properties.Value = row[col.ColumnName];


                            break;
                    }

                }
            }

            _DataBindRow = row;


        }

    }

    public class acEditorRow : EditorRow
    {
        private ControlManager.acVerticalGrid.emEditorType _EditorType = acVerticalGrid.emEditorType.NONE;

        public ControlManager.acVerticalGrid.emEditorType EditorType
        {
            get { return _EditorType; }
            set { _EditorType = value; }
        }


        public string _ResourceID = null;

        public string ResourceID
        {
            get { return _ResourceID; }
            set { _ResourceID = value; }
        }

        private bool _useResourceID = false;

        public bool useResourceID
        {
            get { return _useResourceID; }
            set { _useResourceID = value; }
        }


        public string _Description = null;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string _DescriptionID = null;

        public string DescriptionID
        {
            get { return _DescriptionID; }
            set { _DescriptionID = value; }
        }

        public bool _UseDescriptionID = false;

        public bool UseDescriptionID
        {
            get { return _UseDescriptionID; }
            set { _UseDescriptionID = value; }
        }


    }
}
