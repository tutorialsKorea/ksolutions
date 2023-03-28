using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizManager;

namespace ControlManager
{
    public class acBizError
    {
        private Dictionary<int, string> _BizErrorDic = new Dictionary<int, string>();

        public acBizError(DataTable dt)
        {

            foreach (DataRow bizRow in dt.Rows)
            {
                this._BizErrorDic.Add(bizRow["NUMBER"].toInt(), bizRow["DESCRIPTION"].toStringNull());

            }
        }

        public string GetDesc(int number)
        {
            if (this._BizErrorDic.ContainsKey(number))
            {
                return this._BizErrorDic[number];

            }
            else
            {
                return number.ToString();
            }
        }

        public void UpdateMemoryBizError(int number, string description)
        {
            if (this._BizErrorDic.ContainsKey(number))
            {
                this._BizErrorDic[number] = description;
            }
        }

        /// <summary>
        /// 오류정보를 메모리에 업데이트한다.
        /// </summary>
        public void UpdateMemoryBizError()
        {
            this._BizErrorDic.Clear();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("LANG", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["LANG"] = acInfo.Lang;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this,"CTRL", "GET_BIZERROR", paramSet, "RQSTDT", "RSLTDT");
            //DataSet resultSet = BizManager.acControls.GET_BIZERROR(paramSet);

            foreach (DataRow bizRow in resultSet.Tables["RSLTDT"].Rows)
            {
                this._BizErrorDic.Add(bizRow["NUMBER"].toInt(), bizRow["DESCRIPTION"].toStringNull());

            }

        }
    }
}
