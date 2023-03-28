using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Drawing;

namespace ControlManager
{
    [Serializable]
    public class acGanttUserConfig : ISerializable
    {

        /// <summary>
        /// Stop 타임 추가 시간(분)
        /// </summary>
        private double _AddMinutesValue = 0;

        public double AddMinutesValue
        {
            get { return _AddMinutesValue; }
        }



        private int _RowHeight = 0;


        /// <summary>
        /// 간트 로우높이
        /// </summary>
        public int RowHeight
        {
            get { return _RowHeight; }
        }




        private int _GridWidth = 0;


        /// <summary>
        /// 그리드 크기
        /// </summary>
        public int GridWidth
        {
            get { return _GridWidth; }
        }


        private Dictionary<string, object> _ColumnDic = new Dictionary<string, object>();

        /// <summary>
        /// 그리드 컬럼 사전
        /// </summary>
        public Dictionary<string, object> ColumnDic
        {
            get { return _ColumnDic; }
        }


        private acGantt _UserGantt = null;


        public acGanttUserConfig(acGantt gantt)
        {
            this._UserGantt = gantt;


        }

        public acGanttUserConfig(SerializationInfo info, StreamingContext context)
        {


            try
            {
                this._AddMinutesValue = (double)info.GetValue("AddMinutesValue", typeof(double));
            }
            catch { }

            try
            {
                this._RowHeight = (int)info.GetValue("RowHeight", typeof(int));
            }
            catch { }


            try
            {
                this._GridWidth = (int)info.GetValue("GridWidth", typeof(int));
            }
            catch { }


            try
            {
                this._ColumnDic = (Dictionary<string, object>)info.GetValue("ColumnDic", typeof(Dictionary<string, object>));
            }
            catch { }


        }

        public Byte[] ToArray()
        {
            this._AddMinutesValue = this._UserGantt.AddMinutesValue;
            this._RowHeight = this._UserGantt.RowHeight;
            this._GridWidth = this._UserGantt.GridWidth;


            Dictionary<string, object> columnDic = new Dictionary<string, object>();

            //그리드 컬럼 속성 저장

            foreach (acGanntGridColumn col in this._UserGantt.Grid.Columns)
            {
                acGanntGridColumnSerializable srz = new acGanntGridColumnSerializable();

                srz.ColumnName = col.ColumnName;
                srz.UserIndex = col.Index;
                srz.Width = col.Width;

                columnDic.Add(col.ColumnName, srz);
            }

            this._ColumnDic = columnDic;


            MemoryStream configStream = new MemoryStream();

            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(configStream, this);

            byte[] result = configStream.ToArray();

            configStream.Close();

            return result;

        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AddMinutesValue", this._AddMinutesValue, typeof(double));

            info.AddValue("RowHeight", this._RowHeight, typeof(int));

            info.AddValue("GridWidth", this._GridWidth, typeof(int));

            info.AddValue("ColumnDic", this._ColumnDic, typeof(Dictionary<string, object>));
        }

        #endregion
    }
}
