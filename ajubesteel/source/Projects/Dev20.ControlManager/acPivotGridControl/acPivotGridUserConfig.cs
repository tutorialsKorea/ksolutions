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
using DevExpress.XtraPivotGrid;

namespace ControlManager
{


    [Serializable]
    public class acPivotGridConfig : ISerializable
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



        private Dictionary<string, object> _MaskDic = new Dictionary<string, object>();

        /// <summary>
        /// 마스크 사전
        /// </summary>
        public Dictionary<string, object> MaskDic
        {
            get { return _MaskDic; }
            set { _MaskDic = value; }
        }


        private Dictionary<string, string> _CodeDic = new Dictionary<string, string>();

        /// <summary>
        /// 코드사전
        /// </summary>
        public Dictionary<string, string> CodeDic
        {
            get { return _CodeDic; }
            set { _CodeDic = value; }
        }



        private Dictionary<string, object> _FieldTypeDic = new Dictionary<string, object>();

        /// <summary>
        /// 필드 형태 사전
        /// </summary>
        public Dictionary<string, object> FieldTypeDic
        {
            get { return _FieldTypeDic; }
            set { _FieldTypeDic = value; }
        }


        private acPivotGridControl _View = null;



        public acPivotGridConfig(acPivotGridControl view)
        {
            _View = view;


        }

        public void Clear()
        {
            this._ConfigMaKer = null;
            this._ConfigName = null;

        }

        public void Save(out byte[] layoutOutput, out byte[] configOutput)
        {
            MemoryStream layoutStream = new MemoryStream();
            MemoryStream configStream = new MemoryStream();


            _View.SaveLayoutToStream(layoutStream, OptionsLayoutBase.FullLayout);

            this._ResourceDic.Clear();
            this._UseResourceDic.Clear();
            this._MaskDic.Clear();
            this._CodeDic.Clear();
            this._FieldTypeDic.Clear();


            foreach (acPivotGridField col in _View.Fields)
            {

                this._ResourceDic.Add(col.FieldName, col.ResourceID);

                this._UseResourceDic.Add(col.FieldName, col.UseResourceID);

                this._MaskDic.Add(col.FieldName, col.Mask);

                this._CodeDic.Add(col.FieldName, col.Code);

                this._FieldTypeDic.Add(col.FieldName, col.FieldType);

            }




            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(configStream, this);

            layoutOutput = layoutStream.ToArray();

            configOutput = configStream.ToArray();

            layoutStream.Close();
            configStream.Close();
        }

        public void Load(object configName, object configMaker, byte[] layoutData, byte[] configData)
        {
            try
            {
                bool isSystemLayoutChanged = false;

                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Binder = new acPivotGridUserConfigSerializationBinder();


                //시스템 사용자 UI 불러오기

                Form panel = new Form();


                acPivotGridControl tempPivotGrid = new acPivotGridControl();

                tempPivotGrid.ParentControl = panel;

                panel.Controls.Add(tempPivotGrid);

                tempPivotGrid.Name = "tempPivotGrid";

                tempPivotGrid.Parent = panel;
                tempPivotGrid.Location = new Point(0, 0);
                tempPivotGrid.Size = new Size(0, 0);
                tempPivotGrid.Visible = false;

                MemoryStream sysConfigStrm = new MemoryStream(_View._SystemConfig, 0, _View._SystemConfig.Length);

                MemoryStream sysLayoutStrm = new MemoryStream(_View._SystemLayout, 0, _View._SystemLayout.Length);


                tempPivotGrid.RestoreLayoutFromStream(sysLayoutStrm, DevExpress.Utils.OptionsLayoutBase.FullLayout);



                acPivotGridConfig sysConfig = (acPivotGridConfig)bformatter.Deserialize(sysConfigStrm);

                if (this.ConvertView(tempPivotGrid, sysConfig) == false)
                {
                    isSystemLayoutChanged = true;
                }


                MemoryStream loadLayoutSt = new MemoryStream(layoutData, 0, layoutData.Length);

                MemoryStream loadConfigSt = new MemoryStream(configData, 0, configData.Length);


                acPivotGridConfig config = (acPivotGridConfig)bformatter.Deserialize(loadConfigSt);

                _View.RestoreLayoutFromStream(loadLayoutSt, DevExpress.Utils.OptionsLayoutBase.FullLayout);

                _View._Config.AlwaysBestFit = config.AlwaysBestFit;
                _View._Config.ConfigName = config.ConfigName;
                _View._Config.ConfigMaKer = config.ConfigMaKer;
                _View._Config.MaskDic = config.MaskDic;
                _View._Config.ResourceDic = config.ResourceDic;
                _View._Config._CodeDic = config.CodeDic;



                _View._Config.ConfigName = (string)configName;
                _View._Config.ConfigMaKer = (string)configMaker;

                if (this.ConvertView(_View, config) == false)
                {
                    isSystemLayoutChanged = true;
                }


                //시스템 UI와 다른구조가 있는지 확인한다.



                List<string> removeColumns = new List<string>();

                foreach (acPivotGridField field in _View.Fields)
                {
                    acPivotGridField tempField = (acPivotGridField)tempPivotGrid.Fields[field.FieldName];
                    acPivotGridField viewField = (acPivotGridField)_View.Fields[field.FieldName];

                    if (!tempPivotGrid.Fields.Contains(tempPivotGrid.Fields[field.FieldName]))
                    {
                        removeColumns.Add(field.FieldName);


                    }
                    else
                    {

                        //임시 필드가 아니면 컬럼삭제목록에 추가

                        if (viewField.FieldType != acPivotGridControl.emFieldType.TEMP)
                        {
                            if (acChecker.isNull(tempField, viewField) == false)
                            {
                                //리소스 ID가 변경된 컬럼도 삭제한다.

                                if (tempField.ResourceID != viewField.ResourceID)
                                {
                                    removeColumns.Add(field.FieldName);
                                }

                            }
                        }

                    }

                }


                foreach (acPivotGridField field in tempPivotGrid.Fields)
                {
                    //임시 필드가 아니면 컬럼삭제목록에 추가

                    if (field.FieldType != acPivotGridControl.emFieldType.TEMP)
                    {
                        if (!_View.Fields.Contains(_View.Fields[field.FieldName]))
                        {
                            //시스템 필드에서 포함되지않는 현재 뷰 필드를 삭제한다.

                            removeColumns.Add(field.FieldName);
                        }
                    }


                }


                foreach (string removeCol in removeColumns)
                {
                    _View.Fields.Remove(_View.Fields.GetFieldByName("PN_" + removeCol));


                }

                if (removeColumns.Count > 0)
                {
                    isSystemLayoutChanged = true;

                }


                //시스템 사용자 UI에 추가된 컬럼 설정한다.

                foreach (acPivotGridField field in tempPivotGrid.Fields)
                {
                    if (!_View.Fields.Contains(_View.Fields[field.FieldName]))
                    {
                        switch (field.FieldType)
                        {

                            case acPivotGridControl.emFieldType.TEXT:

                                _View.AddField(field.FieldName, field.Caption, field.ResourceID, field.UseResourceID, field.Area, field.Appearance.Value.TextOptions.HAlignment, field.Mask);

                                break;

                            case acPivotGridControl.emFieldType.CODE:

                                _View.AddCodeField(field.FieldName, field.Caption, field.ResourceID, field.UseResourceID, field.Area, field.Appearance.Value.TextOptions.HAlignment, field.Code);

                                break;


                        }

                        isSystemLayoutChanged = true;

                    }


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


        private bool ConvertView(acPivotGridControl view, acPivotGridConfig config)
        {
            try
            {
                foreach (acPivotGridField col in view.Fields)
                {
                    if (col.FieldType != acPivotGridControl.emFieldType.TEMP)
                    {


                        if (config.ResourceDic.ContainsKey(col.FieldName))
                        {
                            col.ResourceID = config.ResourceDic[col.FieldName];
                        }
                        else
                        {

                        }
                        
                        if (col.UseResourceID)
                            col.Caption = acInfo.Resource.GetString(col.Caption, col.ResourceID);

                        //col.UseResourceID = config.UseResourceDic[col.FieldName];

                        //col.Caption = acInfo.Resource.GetString(col.Caption, col.ResourceID);


                        col.Mask = (acPivotGridControl.emPivotMask)config.MaskDic[col.FieldName];


                        col.Code = config.CodeDic[col.FieldName];


                        col.FieldType = (acPivotGridControl.emFieldType)config.FieldTypeDic[col.FieldName];


                    }
                }

                return true;

            }
            catch
            {
                return false;
            }
        }






        public acPivotGridConfig(SerializationInfo info, StreamingContext context)
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
                this._MaskDic = (Dictionary<string, object>)info.GetValue("MaskDic", typeof(Dictionary<string, object>));
            }
            catch { }

            try
            {
                this._CodeDic = (Dictionary<string, string>)info.GetValue("CodeDic", typeof(Dictionary<string, string>));
            }
            catch { }

            try
            {
                this._FieldTypeDic = (Dictionary<string, object>)info.GetValue("FieldTypeDic", typeof(Dictionary<string, object>));
            }
            catch { }

        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("AlwaysBestFit", this._AlwaysBestFit, typeof(bool));

            info.AddValue("ResourceDic", this._ResourceDic, typeof(Dictionary<string, string>));

            info.AddValue("UseResourceDic", this._UseResourceDic, typeof(Dictionary<string, bool>));

            info.AddValue("MaskDic", this._MaskDic, typeof(Dictionary<string, object>));

            info.AddValue("CodeDic", this._CodeDic, typeof(Dictionary<string, string>));

            info.AddValue("FieldTypeDic", this._FieldTypeDic, typeof(Dictionary<string, object>));
        }

        #endregion



    }
}
