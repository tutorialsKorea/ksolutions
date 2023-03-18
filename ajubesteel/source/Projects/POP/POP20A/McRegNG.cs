using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using BizManager;
using CodeHelperManager;

namespace POP
{
    public partial class McRegNg : BaseMenuDialog
    {
        private DataRow _row = null;
        private DateTime _actStartTime = DateTime.Now;
        private DateTime _actEndTime = DateTime.Now;
        private string _strNGID = "";
     
   
        private string _strMcCode = "";
        public McRegNg(DataRow row, string emp_code, string mc_code)
        {
            InitializeComponent();

            _row = row;
            _strMcCode = mc_code;
            #region 컨트롤 설정

            Control[] con = POP04A_M0A.formcount(this);
            foreach (Control down in con) // 컨트롤 전체 조회
            {
                if (down.Name.StartsWith("btn"))
                {
                    Control[] ctrls = this.Controls.Find(down.Name, true);

                    ((ControlManager.acSimpleButton)ctrls[0]).Font = new Font(acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT"), acInfo.SysConfig.GetSysConfigByMemory("DEFAULT_FONT_SIZE").toInt() + 3,
                    FontStyle.Regular, GraphicsUnit.Point);
                }
            }

            #endregion

            acLayoutControl4.DataBind(row, false);




            acLayoutControl4.GetEditor("EMP_CODE").Value = emp_code;

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("SR_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["SR_CODE"] = "NG";

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

          //  DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "CTRL", "GET_SERIALNO", paramSet, "RQSTDT", "RSLTDT");

          //  _strNGID = resultSet.Tables["RSLTDT"].Rows[0]["SERIAL_NO"].ToString();
       
            acLayoutControl4.OnValueChanged += acLayoutControl4_OnValueChanged;


            #region 이벤트 설정



            #endregion

        }


        public override void DialogInit()
        {
            (acLayoutControl4.GetEditor("NG_CLASS") as acLookupEdit).SetCode("Q005");
           // acLayoutControl4.GetEditor("NG_CLASS").Value = _strNgClass;
            (acLayoutControl4.GetEditor("MASTER_CAUSE") as acLookupEdit).SetCode("C400");
            //(acLayoutControl4.GetEditor("DETAIL_CAUSE") as acLookupEdit).SetCode("C401");

            acLayoutControl4.GetEditor("NG_DATE").Value = acDateEdit.GetNowDateFromServer();
            acLayoutControl4.GetEditor("QUANTITY").Value = 1;
        }
        void acLayoutControl4_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {
            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            switch (info.ColumnName)
            {
                case "MASTER_CAUSE":

                    (acLayoutControl4.GetEditor("DETAIL_CAUSE") as acLookupEdit).SetCode("C401", newValue);

                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //저장

            if (acLayoutControl4.ValidCheck() == false)
            {
                return;
            }

            DataRow layoutRow = acLayoutControl4.CreateParameterRow();

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String));
            paramTable.Columns.Add("NG_ID", typeof(String));
            paramTable.Columns.Add("NG_STATE", typeof(String));
            paramTable.Columns.Add("LINK_KEY", typeof(String));
            paramTable.Columns.Add("NG_CLASS", typeof(String));
            paramTable.Columns.Add("NG_DATE", typeof(String));
            paramTable.Columns.Add("MASTER_CAUSE", typeof(String));
            paramTable.Columns.Add("DETAIL_CAUSE", typeof(String));
            paramTable.Columns.Add("QUANTITY", typeof(int));
            //paramTable.Columns.Add("NG_PART_CODE", typeof(String));
            paramTable.Columns.Add("NG_CONTENTS", typeof(String));
            paramTable.Columns.Add("EMP_CODE", typeof(String));
            paramTable.Columns.Add("NG_IMG1", typeof(Byte[]));
            paramTable.Columns.Add("NG_IMG2", typeof(Byte[]));
            paramTable.Columns.Add("NG_IMG3", typeof(Byte[]));
            paramTable.Columns.Add("NG_IMG4", typeof(Byte[]));
            paramTable.Columns.Add("ACT_TYPE", typeof(String));
            paramTable.Columns.Add("PLANTS", typeof(String));
            paramTable.Columns.Add("MC_CODE", typeof(String));

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["NG_ID"] = _strNGID;
            paramRow["NG_STATE"] = "W";
            paramRow["LINK_KEY"] = _row["WO_NO"]; // 작업지시번호
            paramRow["NG_CLASS"] = layoutRow["NG_CLASS"];
            paramRow["NG_DATE"] = layoutRow["NG_DATE"];
            paramRow["MASTER_CAUSE"] = layoutRow["MASTER_CAUSE"];
            paramRow["DETAIL_CAUSE"] = layoutRow["DETAIL_CAUSE"];
            paramRow["QUANTITY"] = layoutRow["QUANTITY"];
            //paramRow["NG_PART_CODE"] = layoutRow["NG_PART_CODE"];
            paramRow["NG_CONTENTS"] = layoutRow["NG_CONTENTS"];
            paramRow["EMP_CODE"] = layoutRow["EMP_CODE"];
            paramRow["NG_IMG1"] = layoutRow["NG_IMG1"];
            paramRow["NG_IMG2"] = layoutRow["NG_IMG2"];
            paramRow["NG_IMG3"] = layoutRow["NG_IMG3"];
            paramRow["NG_IMG4"] = layoutRow["NG_IMG4"];
            paramRow["ACT_TYPE"] = "W";
            paramRow["PLANTS"] = "3605";
            paramRow["MC_CODE"] = _strMcCode;

            paramTable.Rows.Add(paramRow);

            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            BizRun.QBizRun.ExecuteService(this, QBiz.emExecuteType.SAVE, "POP30A_INS3", paramSet, "RQSTDT", "RSLTDT",
           QuickNG,
           QuickException);
        }

        void QuickNG(object sender, QBiz QBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

        void QuickException(object sender, QBiz qBiz, BizException ex)
        {
            acMessageBox.Show(this, ex);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //취소
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

