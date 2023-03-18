using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using System.Data;

namespace ControlManager
{
    public class acToolTip
    {
        private Dictionary<string, SuperToolTip> _ToolTipDic = new Dictionary<string, SuperToolTip>();
        

        public acToolTip(DataTable tooltipDt)
        {

            foreach (DataRow dr in tooltipDt.Rows)
            {
                SuperToolTip superTT = new SuperToolTip();

                ToolTipTitleItem titleTT = new ToolTipTitleItem();

                ToolTipItem contentTT = new ToolTipItem();

                contentTT.LeftIndent = 3;

                ToolTipTitleItem footerTT = new ToolTipTitleItem();

                titleTT.Text = dr["TITLE"].toStringNull();

                contentTT.Text = dr["CONTENTS"].toStringNull();

                if (!string.IsNullOrEmpty(titleTT.Text))
                {
                    superTT.Items.Add(titleTT);
                }
                //superTT.Items.Add()

                if (!string.IsNullOrEmpty(contentTT.Text))
                {
                    superTT.Items.Add(contentTT);
                }



                this._ToolTipDic.Add(dr["TT_GUID"].ToString(), superTT);
                
            }

        }

        public bool IsToolTip(string tooltipID)
        {
            return this._ToolTipDic.ContainsKey(tooltipID);
        }

      

        public SuperToolTip GetToolTip(string tooltipID)
        {
            if (this._ToolTipDic.ContainsKey(tooltipID))
            {
                return this._ToolTipDic[tooltipID];
            }
            else
            {
                SuperToolTip superTT = new SuperToolTip();

                ToolTipTitleItem titleTT = new ToolTipTitleItem();

                ToolTipItem contentTT = new ToolTipItem();

                contentTT.LeftIndent = 3;

                ToolTipTitleItem footerTT = new ToolTipTitleItem();

                titleTT.Text = tooltipID;

                contentTT.Text = null;

                if (!string.IsNullOrEmpty(titleTT.Text))
                {
                    superTT.Items.Add(titleTT);
                }


                if (!string.IsNullOrEmpty(contentTT.Text))
                {
                    superTT.Items.Add(contentTT);
                }

                

                return superTT;
            }

        }
        public void Update(string tooltipID, string title, string content)
        {
            if (this._ToolTipDic.ContainsKey(tooltipID))
            {

          
                foreach (BaseToolTipItem tt in this._ToolTipDic[tooltipID].Items)
                {
                    if (tt is ToolTipTitleItem)
                    {
                        
                        (tt as ToolTipTitleItem).Text = title;

                    }
                    else if (tt is ToolTipItem)
                    {
                        (tt as ToolTipItem).Text = content;
                    }

                }

              
            }

        }

    }
}
