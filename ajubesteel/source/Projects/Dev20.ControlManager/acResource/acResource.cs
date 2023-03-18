using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BizManager;

namespace ControlManager
{
    public class acResource
    {

        private Dictionary<string, string> _ResourceDic = new Dictionary<string, string>();

        public acResource(DataTable dt)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                this._ResourceDic.Add(dt.Rows[i]["RES_ID"].ToString(), dt.Rows[i]["RES_CONTENTS"].ToString());

            }


        }

        public void Update(string resourceID, string value)
        {
            this._ResourceDic[resourceID] = value;
        }

        public void Update()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("RES_LANG", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();

            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["RES_LANG"] = acInfo.Lang;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_RESOURCE_ALL", paramSet, "RQSTDT", "RSLTDT");

            //DataSet resultSet = BizManager.acControls.GET_RESOURCE_ALL(paramSet);

            this._ResourceDic.Clear();

            foreach (DataRow row in resultSet.Tables["RSLTDT"].Rows)
            {

                this._ResourceDic.Add(row["RES_ID"].ToString(), row["RES_CONTENTS"].ToString());

            }

        }

        public String GetString(string original, string resourceID)
        {
            if (!string.IsNullOrEmpty(resourceID))
            {

                if (_ResourceDic.ContainsKey(resourceID))
                {

                    return _ResourceDic[resourceID];

                }
                else
                {
                    return original + " [" + resourceID + "]";
                }



            }
            else
            {
                if (!string.IsNullOrEmpty(original))
                {
                    return original;
                    //return original + "[NOT RESOURCE ID]";
                }

                else
                {
                    return original;
                }

            }
        }

    }
}
