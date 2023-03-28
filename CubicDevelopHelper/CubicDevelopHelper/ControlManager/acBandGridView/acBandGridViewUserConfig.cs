using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using DevExpress.Utils;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace ControlManager
{



    [Serializable]
    public class acBandGridViewConfig : ISerializable
    {

        /// <summary>
        /// 적용된 그리드UI 이름
        /// </summary>
        private string _ConfigName = null;

        public string ConfigName
        {
            get { return _ConfigName; }
            set { _ConfigName = value; }
        }


        /// <summary>
        /// 적용된 그리드UI 작성자
        /// </summary>
        private string _ConfigMaKer = null;

        public string ConfigMaKer
        {
            get { return _ConfigMaKer; }
            set { _ConfigMaKer = value; }
        }


        private acBandGridViewApperance _EditCellStyle = new acBandGridViewApperance();

        /// <summary>
        /// 수정가능한 Cell 스타일
        /// </summary>
        public acBandGridViewApperance EditCellStyle
        {
            get { return _EditCellStyle; }
            set { _EditCellStyle = value; }
        }


        private acBandGridViewApperance _ModifiedRowStyle = new acBandGridViewApperance();

        /// <summary>
        /// 변경된 행 스타일
        /// </summary>
        public acBandGridViewApperance ModifiedRowStyle
        {
            get { return _ModifiedRowStyle; }
            set { _ModifiedRowStyle = value; }
        }


        private bool _AlwaysBestFit = false;

        /// <summary>
        /// 조회후 항상 컬럼최적화(전체)
        /// </summary>
        public bool AlwaysBestFit
        {
            get { return _AlwaysBestFit; }
            set { _AlwaysBestFit = value; }
        }

        private Dictionary<string, string> _ResourceDic = new Dictionary<string, string>();

        /// <summary>
        /// 리소스 사전
        /// </summary>
        public Dictionary<string, string> ResourceDic
        {
            get { return _ResourceDic; }
            set { _ResourceDic = value; }
        }



        private Dictionary<string, bool> _UseResourceDic = new Dictionary<string, bool>();

        public Dictionary<string, bool> UseResourceDic
        {
            get { return _UseResourceDic; }
            set { _UseResourceDic = value; }
        }

        private Dictionary<string, bool> _IsRequiredDic = new Dictionary<string, bool>();

        public Dictionary<string, bool> IsRequiredDic
        {
            get { return _IsRequiredDic; }
            set { _IsRequiredDic = value; }
        }



        private Dictionary<string, object> _MaskDic = new Dictionary<string, object>();

        /// <summary>
        /// 마스크 사전
        /// </summary>
        public Dictionary<string, object> MaskDic
        {
            get { return _MaskDic; }
            set { _MaskDic = value; }
        }


        /// <summary>
        /// 에디터 형태 사전
        /// </summary>
        private Dictionary<string, object> _EditorTypeDic = new Dictionary<string, object>();

        public Dictionary<string, object> EditorTypeDic
        {
            get { return _EditorTypeDic; }
            set { _EditorTypeDic = value; }
        }


        /// <summary>
        /// 에디터 데이터 사전
        /// </summary>
        private Dictionary<string, object> _EditorDataDic = new Dictionary<string, object>();

        public Dictionary<string, object> EditorDataDic
        {
            get { return _EditorDataDic; }
            set { _EditorDataDic = value; }
        }







        private acBandGridView _View = null;



        public acBandGridViewConfig(acBandGridView view)
        {
            _View = view;


        }

        public void Save(out byte[] layoutOutput, out byte[] configOutput)
        {
            MemoryStream layoutStream = new MemoryStream();
            MemoryStream configStream = new MemoryStream();


            _View.SaveLayoutToStream(layoutStream, OptionsLayoutBase.FullLayout);



            this._ResourceDic.Clear();
            this._UseResourceDic.Clear();
            this._IsRequiredDic.Clear();

            this._MaskDic.Clear();
            this._EditorDataDic.Clear();
            this._EditorTypeDic.Clear();


            foreach (acBandedGridColumn col in _View.Columns)
            {
                this._ResourceDic.Add(col.FieldName, col.ResourceID);

                this._UseResourceDic.Add(col.FieldName, col.UseResourceID);

                this._IsRequiredDic.Add(col.FieldName, col.IsRequired);


                acBandGridViewMask mask = new acBandGridViewMask(col.ColumnEdit);

                this._MaskDic.Add(col.FieldName, mask);

                /*
                if (col.EditorType == acBandGridView.emEditorType.LOOKUP || col.EditorType == acBandGridView.emEditorType.LOOKUP_CODE)
                {
                    if (col.EditorData == null)
                    {
                        Dictionary<string, object> data = new Dictionary<string, object>();

                        RepositoryItemLookUpEdit edit = col.ColumnEdit as RepositoryItemLookUpEdit;

                        data.Add("DISPLAY_COLUMN_NAME", edit.DisplayMember);

                        data.Add("VALUE_COLUMN_NAME", edit.ValueMember);

                        col.EditorData = data;
                    }

                }
                 * */

                this._EditorDataDic.Add(col.FieldName, col.EditorData);

                this._EditorTypeDic.Add(col.FieldName, col.EditorType);

            }


            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(configStream, this);

            layoutOutput = layoutStream.ToArray();

            configOutput = configStream.ToArray();

            layoutStream.Close();
            configStream.Close();
        }

        public void Reset()
        {
            _View._Config.ConfigName = null;
            _View._Config.ConfigMaKer = null;

        }

        public void Load(object configName, object configMaker, byte[] layoutData, byte[] configData)
        {
            try
            {

                bool isSystemLayoutChanged = false;


                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Binder = new acBandGridViewUserConfigSerializationBinder();


                //시스템 기본 레이아웃을 알아옵니다.

                Form panel = new Form();

                acBandGridControl systemGridControl = new acBandGridControl();

                acBandGridView systemGridView = new acBandGridView(systemGridControl);

                systemGridView.ParentControl = panel;

                panel.Controls.Add(systemGridControl);

                systemGridControl.Name = "tempGridControl";

                systemGridControl.Parent = panel;
                systemGridControl.Location = new Point(0, 0);
                systemGridControl.Size = new Size(0, 0);
                systemGridControl.Visible = false;

                systemGridControl.MainView = systemGridView;

                systemGridControl.ViewCollection.Add(systemGridView);

                acBandGridControl sysGridControl = (acBandGridControl)_View.GridControl;


                MemoryStream sysConfigStrm = new MemoryStream(sysGridControl._SystemConfig, 0, sysGridControl._SystemConfig.Length);

                MemoryStream sysLayoutStrm = new MemoryStream(sysGridControl._SystemLayout, 0, sysGridControl._SystemLayout.Length);


                systemGridView.RestoreLayoutFromStream(sysLayoutStrm, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                acBandGridViewConfig sysConfig = (acBandGridViewConfig)bformatter.Deserialize(sysConfigStrm);

                if (this.ConvertView(systemGridView, sysConfig) == false)
                {
                    isSystemLayoutChanged = true;
                }



                MemoryStream loadLayoutSt = new MemoryStream(layoutData, 0, layoutData.Length);

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);


                acBandGridViewConfig config = (acBandGridViewConfig)bformatter.Deserialize(loadConfigSt);

                _View.RestoreLayoutFromStream(loadLayoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                _View._Config.AlwaysBestFit = config.AlwaysBestFit;
                _View._Config.EditCellStyle = config.EditCellStyle;
                _View._Config.ModifiedRowStyle = config.ModifiedRowStyle;

                _View._Config.ConfigName = config.ConfigName;
                _View._Config.ConfigMaKer = config.ConfigMaKer;
                _View._Config.MaskDic = config.MaskDic;
                _View._Config.ResourceDic = config.ResourceDic;
                _View._Config.UseResourceDic = config.UseResourceDic;

                _View._Config.ConfigName = (string)configName;
                _View._Config.ConfigMaKer = (string)configMaker;

                if (this.ConvertView(_View, config) == false)
                {
                    isSystemLayoutChanged = true;
                }




                //시스템 UI와  다른구조가 있는지 확인한다.

                //추가될 컬럼명
                List<string> addColumns = new List<string>();


                //삭제될 컬럼명
                List<string> removeColumns = new List<string>();



                //삭제될 컬럼 선정
                foreach (acBandedGridColumn viewCol in _View.Columns)
                {

                    acBandedGridColumn tempColumn = (acBandedGridColumn)systemGridView.Columns[viewCol.FieldName];
                    acBandedGridColumn viewColumn = (acBandedGridColumn)_View.Columns[viewCol.FieldName];



                    if (viewCol.EditorType == acBandGridView.emEditorType.LOOKUP ||
                        viewCol.EditorType == acBandGridView.emEditorType.LOOKUP_CODE)
                    {

                        RepositoryItemLookUpEdit edit = viewCol.ColumnEdit as RepositoryItemLookUpEdit;

                        Dictionary<string, object> editData = viewCol.EditorData as Dictionary<string, object>;


                        if (editData == null)
                        {
                            removeColumns.Add(viewCol.FieldName);
                        }
                        else
                        {
                            if (editData.ContainsKey("CURRENT_SHOW_COLUMN_NAME"))
                            {
                                edit.DisplayMember = editData["CURRENT_SHOW_COLUMN_NAME"].ToString();
                            }
                        }

                    }


                    //시스템 그리드에 존재하지않은 컬럼
                    if (!systemGridView.Columns.Contains(systemGridView.Columns[viewCol.FieldName]))
                    {
                        if (!removeColumns.Contains(viewCol.FieldName))
                        {
                            removeColumns.Add(viewCol.FieldName);
                        }

                    }





                    if (acChecker.isNull(tempColumn, viewColumn) == false)
                    {
                        //필수여부가 변경된 컬럼도 삭제한다.
                        if (tempColumn.IsRequired != viewColumn.IsRequired)
                        {
                            if (!removeColumns.Contains(viewCol.FieldName))
                            {
                                removeColumns.Add(viewCol.FieldName);
                            }
                        }

                        //리소스 ID가 변경된 컬럼도 삭제한다.
                        if (tempColumn.ResourceID != viewColumn.ResourceID)
                        {
                            if (!removeColumns.Contains(viewCol.FieldName))
                            {
                                removeColumns.Add(viewCol.FieldName);
                            }
                        }

                    }

                    //컬럼데이터가 맞지않음
                    if (viewCol.Check() == false)
                    {
                        if (!removeColumns.Contains(viewCol.FieldName))
                        {
                            removeColumns.Add(viewCol.FieldName);
                        }
                    }


                }


                foreach (acBandedGridColumn tempCol in systemGridView.Columns)
                {
                    if (!_View.Columns.Contains(_View.Columns[tempCol.FieldName]))
                    {
                        removeColumns.Add(tempCol.FieldName);
                    }

                }


                foreach (string removeCol in removeColumns)
                {
                    _View.RemoveColumn(removeCol);


                }

                if (removeColumns.Count > 0)
                {
                    isSystemLayoutChanged = true;
                }





                //시스템 컬럼이 추가되면 기본에 추가

                foreach (acBandedGridColumn tempCol in systemGridView.Columns)
                {
                    if (!_View.Columns.Contains(_View.Columns[tempCol.FieldName]))
                    {
                        switch (tempCol.EditorType)
                        {

                            case acBandGridView.emEditorType.CHECK:

                                _View.AddCheckEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, (acBandGridView.emCheckEditDataType)tempCol.EditorData);

                                break;

                            case acBandGridView.emEditorType.TEXT:

                                _View.AddTextEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, tempCol.IsRequired, (acBandGridView.emTextEditMask)tempCol.EditorData);

                                break;

                            case acBandGridView.emEditorType.DATE:


                                _View.AddDateEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, tempCol.IsRequired, (acBandGridView.emDateMask)tempCol.EditorData);


                                break;

                            case acBandGridView.emEditorType.LOOKUP_CODE:


                                Dictionary<string, object> lookUpCodeEditorData = (Dictionary<string, object>)tempCol.EditorData;


                                _View.AddLookUpEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, tempCol.IsRequired,
                                    (string)lookUpCodeEditorData["CAT_CODE"]);



                                break;

                            case acBandGridView.emEditorType.LOOKUP:


                                Dictionary<string, object> lookUpeditorData = (Dictionary<string, object>)tempCol.EditorData;


                                _View.AddLookUpEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, tempCol.IsRequired,
                                    (string)lookUpeditorData["DISPLAY_COLUMN_NAME"],
                                    (string)lookUpeditorData["VALUE_COLUMN_NAME"],
                                    lookUpeditorData["DATASOURCE"]);



                                break;


                        }

                        isSystemLayoutChanged = true;

                    }


                }

                try
                {
                    foreach (acBandedGridColumn viewCol in _View.Columns)
                    {
                        if (viewCol.OwnerBand.Caption == viewCol.Caption)
                        {
                            if (_View.GridControl.DataSource == null) _View.GridControl.DataSource = _View.DefaultTable;
                            acBandPaintHelper helper = new acBandPaintHelper(_View, new GridBand[] { viewCol.OwnerBand });
                        }
                    }
                }catch
                {

                }

                if (isSystemLayoutChanged == true)
                {

                    throw new DefaultSystemLayoutChangedException();

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }


        private bool ConvertView(acBandGridView view, acBandGridViewConfig config)
        {
            try
            {
                foreach (acBandedGridColumn col in view.Columns)
                {

                    col.ResourceID = config.ResourceDic[col.FieldName];

                    col.UseResourceID = config.UseResourceDic[col.FieldName];

                    col.IsRequired = config.IsRequiredDic[col.FieldName];

                    if (col.UseResourceID)
                        col.Caption = acInfo.Resource.GetString(col.Caption, col.ResourceID);

                    col.EditorData = config.EditorDataDic[col.FieldName];

                    col.EditorType = (acBandGridView.emEditorType)config.EditorTypeDic[col.FieldName];

                    acBandGridViewMask mask = (acBandGridViewMask)config.MaskDic[col.FieldName];


                    if (col.ColumnEdit is RepositoryItemTextEdit)
                    {
                        RepositoryItemTextEdit item = (RepositoryItemTextEdit)col.ColumnEdit;

                        item.Mask.MaskType = mask.MaskType;
                        item.Mask.EditMask = mask.EditMask;

                    }
                    else if (col.ColumnEdit is RepositoryItemTimeEdit)
                    {
                        RepositoryItemTimeEdit item = (RepositoryItemTimeEdit)col.ColumnEdit;

                        item.Mask.MaskType = mask.MaskType;
                        item.Mask.EditMask = mask.EditMask;
                    }
                    else if (col.ColumnEdit is RepositoryItemDateEdit)
                    {
                        RepositoryItemDateEdit item = (RepositoryItemDateEdit)col.ColumnEdit;

                        item.Mask.MaskType = mask.MaskType;
                        item.Mask.EditMask = mask.EditMask;
                    }
                    else if (col.ColumnEdit is RepositoryItemMemoEdit)
                    {
                        RepositoryItemMemoEdit item = (RepositoryItemMemoEdit)col.ColumnEdit;

                        item.Mask.MaskType = mask.MaskType;
                        item.Mask.EditMask = mask.EditMask;
                    }
                    else if (col.ColumnEdit is RepositoryItemMemoExEdit)
                    {
                        RepositoryItemMemoExEdit item = (RepositoryItemMemoExEdit)col.ColumnEdit;

                        item.Mask.MaskType = mask.MaskType;
                        item.Mask.EditMask = mask.EditMask;
                    }
                }

                return true;

            }
            catch
            {
                return false;
            }

        }




        public acBandGridViewConfig(SerializationInfo info, StreamingContext context)
        {
            try
            {
                this._EditCellStyle = (acBandGridViewApperance)info.GetValue("EditCellStyle", typeof(acBandGridViewApperance));
            }
            catch { }

            try
            {
                this._ModifiedRowStyle = (acBandGridViewApperance)info.GetValue("ModifiedRowStyle", typeof(acBandGridViewApperance));
            }
            catch { }



            try
            {
                this._AlwaysBestFit = (bool)info.GetValue("AlwaysBestFit", typeof(bool));
            }
            catch { }

            try
            {
                this._ResourceDic = (Dictionary<string, string>)info.GetValue("ResourceDic", typeof(Dictionary<string, string>));
            }
            catch { }


            try
            {
                this._UseResourceDic = (Dictionary<string, bool>)info.GetValue("UseResourceDic", typeof(Dictionary<string, bool>));
            }
            catch { }



            try
            {
                this._IsRequiredDic = (Dictionary<string, bool>)info.GetValue("IsRequiredDic", typeof(Dictionary<string, bool>));
            }
            catch { }


            try
            {
                _MaskDic = (Dictionary<string, object>)info.GetValue("MaskDic", typeof(Dictionary<string, object>));
            }

            catch { }


            try
            {
                _EditorTypeDic = (Dictionary<string, object>)info.GetValue("EditorTypeDic", typeof(Dictionary<string, object>));
            }
            catch { }

            try
            {
                _EditorDataDic = (Dictionary<string, object>)info.GetValue("EditorDataDic", typeof(Dictionary<string, object>));

            }
            catch { }
        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("EditCellStyle", this._EditCellStyle, typeof(acBandGridViewApperance));

            info.AddValue("ModifiedRowStyle", this._ModifiedRowStyle, typeof(acBandGridViewApperance));

            info.AddValue("AlwaysBestFit", this._AlwaysBestFit, typeof(bool));

            info.AddValue("ResourceDic", this._ResourceDic, typeof(Dictionary<string, string>));

            info.AddValue("UseResourceDic", this._UseResourceDic, typeof(Dictionary<string, bool>));

            info.AddValue("IsRequiredDic", this._IsRequiredDic, typeof(Dictionary<string, bool>));

            info.AddValue("MaskDic", this._MaskDic, typeof(Dictionary<string, acBandGridViewMask>));

            info.AddValue("EditorTypeDic", this._EditorTypeDic, typeof(Dictionary<string, object>));

            info.AddValue("EditorDataDic", this._EditorDataDic, typeof(Dictionary<string, object>));



        }

        #endregion



    }
}
