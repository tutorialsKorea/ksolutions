using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using DevExpress.Utils;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors.Repository;


namespace ControlManager
{


    [Serializable]
    public class acTreeListUserConfig : ISerializable
    {


        private acTreeList _List = null;
        private acTreeList _OriginList = null;

        public acTreeListUserConfig(acTreeList list)
        {
            _List = list;

        }

        public acTreeListUserConfig(SerializationInfo info, StreamingContext context)
        {


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



        public void Save(out byte[] layoutOutput, out byte[] configOutput)
        {
            try
            {
                MemoryStream layoutStream = new MemoryStream();
                MemoryStream configStream = new MemoryStream();

                _List.SaveLayoutToStream(layoutStream, OptionsLayoutBase.FullLayout);

                this._ResourceDic.Clear();
                this._UseResourceDic.Clear();
                this._IsRequiredDic.Clear();

                this._MaskDic.Clear();
                this._EditorDataDic.Clear();
                this._EditorTypeDic.Clear();

                foreach (acTreeListColumn col in _List.Columns)
                {
                    this._ResourceDic.Add(col.FieldName, col.ResourceID);

                    this._UseResourceDic.Add(col.FieldName, col.UseResourceID);

                    this._IsRequiredDic.Add(col.FieldName, col.IsRequired);


                    acTreeListMask mask = new acTreeListMask(col.ColumnEdit);

                    this._MaskDic.Add(col.FieldName, mask);

                    /*
                    if (col.EditorType == acGridView.emEditorType.LOOKUP || col.EditorType == acGridView.emEditorType.LOOKUP_CODE)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Restore(object configName, object configMaker, byte[] layoutData, byte[] configData)
        {
            try
            {

                MemoryStream loadLayoutSt = new MemoryStream(layoutData, 0, layoutData.Length);

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                _List.RestoreLayoutFromStream(loadLayoutSt, OptionsLayoutTreeList.FullLayout);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Load(object configName, object configMaker, byte[] layoutData, byte[] configData)
        {
            try
            {

                bool isSystemLayoutChanged = false;

                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Binder = new acTreeListUserConfigSerializationBinder();

                //시스템 기본 레이아웃을 알아옵니다.
                Form panel = new Form();

                acTreeList systemTreeList = new acTreeList();
                systemTreeList.ParentControl = panel;

                panel.Controls.Add(systemTreeList);

                systemTreeList.Name = "tempTreeList";
                systemTreeList.Parent = panel;
                systemTreeList.Location = new Point(0, 0);
                systemTreeList.Size = new Size(0, 0);
                systemTreeList.Visible = false;

                //현재 트리 컨트롤의 시스템 레이아웃
                MemoryStream sysConfigStrm = new MemoryStream(_List._SystemConfig, 0, _List._SystemConfig.Length);

                MemoryStream sysLayoutStrm = new MemoryStream(_List._SystemLayout, 0, _List._SystemLayout.Length);

                //시스템 그리드 설정 정보로 restore
                systemTreeList.RestoreLayoutFromStream(sysLayoutStrm, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                acTreeListUserConfig sysConfig = (acTreeListUserConfig)bformatter.Deserialize(sysConfigStrm);


                if (this.ConvertView(systemTreeList, sysConfig) == false)
                {
                    isSystemLayoutChanged = true;
                }

                MemoryStream loadLayoutSt = new MemoryStream(layoutData, 0, layoutData.Length);

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);

                #region 레이아웃 변경시 기존 컬럼을 불러오기위한 뷰

                _OriginList = new acTreeList();

                //sysGridControl.ViewCollection.Add(_OriginView);
                //try
                //{
                //    _OriginView.Assign(_View, true);
                //}
                //catch { }


                #endregion
                acTreeListUserConfig config = (acTreeListUserConfig)bformatter.Deserialize(loadConfigSt);

                _List.RestoreLayoutFromStream(loadLayoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                _List._Config.AlwaysBestFit = config.AlwaysBestFit;
                //_List._Config.EditCellStyle = config.EditCellStyle;
                //_List._Config.ModifiedRowStyle = config.ModifiedRowStyle;

                _List._Config.ConfigName = config.ConfigName;
                _List._Config.ConfigMaKer = config.ConfigMaKer;
                _List._Config.MaskDic = config.MaskDic;
                _List._Config.ResourceDic = config.ResourceDic;
                _List._Config.ConfigName = (string)configName;
                _List._Config.ConfigMaKer = (string)configMaker;

                if (this.ConvertView(_List, config) == false)
                {
                    isSystemLayoutChanged = true;
                }

                //************************
                //시스템 UI와  다른구조가 있는지 확인한다.

                //추가될 컬럼명
                List<string> addColumns = new List<string>();


                //삭제될 컬럼명
                List<string> removeColumns = new List<string>();



                //삭제될 컬럼 선정
                foreach (acTreeListColumn viewCol in _List.Columns)
                {

                    acTreeListColumn tempColumn = (acTreeListColumn)systemTreeList.Columns[viewCol.FieldName];
                    acTreeListColumn viewColumn = (acTreeListColumn)_List.Columns[viewCol.FieldName];

                    if (viewCol.EditorType == acTreeList.emEditorType.LOOKUP)
                    {

                        //RepositoryItemLookUpEdit edit = viewCol.ColumnEdit as RepositoryItemLookUpEdit;

                        //Dictionary<string, object> editData = viewCol.EditorData as Dictionary<string, object>;


                        //if (editData == null)
                        //{
                        //    removeColumns.Add(viewCol.FieldName);
                        //}
                        //else
                        //{
                        //    if (editData.ContainsKey("CURRENT_SHOW_COLUMN_NAME"))
                        //    {
                        //        edit.DisplayMember = editData["CURRENT_SHOW_COLUMN_NAME"].ToString();
                        //    }
                        //}

                    }


                    //시스템 그리드에 존재하지않은 컬럼
                    if (!systemTreeList.Columns.Contains(systemTreeList.Columns[viewCol.FieldName]))
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
                        //if (tempColumn.ResourceID != viewColumn.ResourceID)
                        //{
                        //    if (!removeColumns.Contains(viewCol.FieldName))
                        //    {
                        //        removeColumns.Add(viewCol.FieldName);
                        //    }
                        //}

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


                foreach (acTreeListColumn tempCol in systemTreeList.Columns)
                {
                    if (!_List.Columns.Contains(_List.Columns[tempCol.FieldName]))
                    {
                        removeColumns.Add(tempCol.FieldName);
                    }
                }


                foreach (string removeCol in removeColumns)
                {
                    _List.RemoveColumn(removeCol);
                }

                if (removeColumns.Count > 0)
                {
                    isSystemLayoutChanged = true;
                }

                //시스템 컬럼이 추가되면 기본에 추가

                foreach (acTreeListColumn tempCol in systemTreeList.Columns)
                {

                    if (!_List.Columns.Contains(_List.Columns[tempCol.FieldName]))
                    {
                        switch (tempCol.EditorType)
                        {

                            case acTreeList.emEditorType.CHECK:

                                _List.AddCheckEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, (acTreeList.emCheckEditDataType)tempCol.EditorData);

                                break;

                            case acTreeList.emEditorType.TEXT:

                                _List.AddTextEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, (acTreeList.emTextEditMask)tempCol.EditorData);

                                break;

                            case acTreeList.emEditorType.DATE:


                                _List.AddDateEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible, (acTreeList.emDateMask)tempCol.EditorData);



                                break;


                            case acTreeList.emEditorType.LOOKUP:


                                Dictionary<string, object> lookUpeditorData = (Dictionary<string, object>)tempCol.EditorData;


                                _List.AddLookUpEdit(tempCol.FieldName, tempCol.Caption, tempCol.ResourceID, tempCol.UseResourceID, tempCol.AppearanceCell.TextOptions.HAlignment, tempCol.OptionsColumn.AllowEdit, tempCol.Visible,
                                    lookUpeditorData["DATASOURCE"] as DataTable,
                                    (string)lookUpeditorData["DISPLAY_COLUMN_NAME"],
                                    (string)lookUpeditorData["VALUE_COLUMN_NAME"],
                                    false
                                    );


                                break;

                        }

                        isSystemLayoutChanged = true;

                    }


                }
                //************************

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

        private bool ConvertView(acTreeList tl, acTreeListUserConfig config)
        {
            try
            {
                foreach (acTreeListColumn col in tl.Columns)
                {

                    col.ResourceID = config.ResourceDic[col.FieldName];

                    col.UseResourceID = config.UseResourceDic[col.FieldName];

                    col.IsRequired = config.IsRequiredDic[col.FieldName];

                    if (col.UseResourceID)
                        col.Caption = acInfo.Resource.GetString(col.Caption, col.ResourceID);

                    col.EditorData = config.EditorDataDic[col.FieldName];

                    col.EditorType = (acTreeList.emEditorType)config.EditorTypeDic[col.FieldName];

                    acTreeListMask mask = (acTreeListMask)config.MaskDic[col.FieldName];


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


        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            //info.AddValue("EditCellStyle", this._EditCellStyle, typeof(acGridViewApperance));

            //info.AddValue("ModifiedRowStyle", this._ModifiedRowStyle, typeof(acGridViewApperance));

            info.AddValue("AlwaysBestFit", this._AlwaysBestFit, typeof(bool));

            info.AddValue("ResourceDic", this._ResourceDic, typeof(Dictionary<string, string>));

            info.AddValue("UseResourceDic", this._UseResourceDic, typeof(Dictionary<string, bool>));

            info.AddValue("IsRequiredDic", this._IsRequiredDic, typeof(Dictionary<string, bool>));

            info.AddValue("MaskDic", this._MaskDic, typeof(Dictionary<string, acTreeListMask>));

            info.AddValue("EditorTypeDic", this._EditorTypeDic, typeof(Dictionary<string, object>));

            info.AddValue("EditorDataDic", this._EditorDataDic, typeof(Dictionary<string, object>));



        }

        #endregion

    }
}
