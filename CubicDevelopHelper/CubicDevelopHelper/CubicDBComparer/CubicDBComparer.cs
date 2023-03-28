using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubicDBComparer.Properties;
using System.Data.OleDb;
using System.Data.Odbc;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;

namespace CubicDBComparer
{
    public partial class CubicDBComparer : Form
    {
        public CubicDBComparer()
        {
            InitializeComponent();

            txtIP.Text = Settings.Default["DB_IP"].ToString();
            txtID.Text = Settings.Default["DB_ID"].ToString();
            txtPW.Text = Settings.Default["DB_PW"].ToString();

            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = false;

        }

        DB_Manage db_mng;
        DataTable dt_Column;


        void Conn_DB(string txtIP, string txtDB, string txtID, string txtPW, ComboBox cboBox, DevExpress.XtraEditors.TextEdit txtBox)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //DB접속
                db_mng = new DB_Manage(txtIP, txtDB, txtID, txtPW);

                string strQuery = "select NAME from sys.sysdatabases order by name asc";

                cboBox.DataSource = db_mng.GetQueryToDataTable(strQuery);

                cboBox.DisplayMember = "NAME";

                cboBox.ValueMember = "NAME";

                txtBox.Text = "CONNECTED";
                txtBox.ForeColor = System.Drawing.Color.White;
                txtBox.BackColor = System.Drawing.Color.LimeGreen;

                Cursor.Current = Cursors.Default;


            }
            catch
            {
                txtBox.Text = "FAIL";
                txtBox.ForeColor = System.Drawing.Color.White;
                txtBox.BackColor = System.Drawing.Color.Crimson;

                Cursor.Current = Cursors.Default;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // DB접속 (BASE DB)

            Conn_DB(txtIP.Text, "master", txtID.Text, txtPW.Text, cboDB, txtSTAT);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // DB접속 (Target DB)
            
            Conn_DB(txtIP_TG.Text, "master", txtID_TG.Text, txtPW_TG.Text, cboDB_TG, txtSTAT_TG);
        }

        private void txtSTAT_EditValueChanged(object sender, EventArgs e)
        {
            if(txtSTAT.Text == "CONNECTED" && txtSTAT_TG.Text == "CONNECTED")
            {
                button1.Enabled = true;
            }
        }

        private void txtSTAT_TG_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSTAT.Text == "CONNECTED" && txtSTAT_TG.Text == "CONNECTED")
            {
                button1.Enabled = true;
            }
        }



        // 비교
        private void button1_Click(object sender, EventArgs e)
        {
          
            //Compare 

            DB_Manage bsDB = new DB_Manage(txtIP.Text, cboDB.Text, txtID.Text, txtPW.Text);

            DB_Manage tgDB = new DB_Manage(txtIP_TG.Text, cboDB_TG.Text, txtID_TG.Text, txtPW_TG.Text);

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(" SELECT");
            sbQuery.Append(" A.TABLE_NAME");
            sbQuery.Append(" ,A.COLUMN_NAME");
            sbQuery.Append(" ,A.ORDINAL_POSITION");
            sbQuery.Append(" ,A.IS_NULLABLE");
            sbQuery.Append(" ,A.DATA_TYPE");
            sbQuery.Append(" ,A.CHARACTER_MAXIMUM_LENGTH AS LENGTH");
            sbQuery.Append(" ,A.NUMERIC_PRECISION");
            sbQuery.Append(" ,A.NUMERIC_SCALE");
            sbQuery.Append(" ,CASE WHEN B.COLUMN_NAME IS NOT NULL THEN 'PK' ELSE NULL END AS PK");
            sbQuery.Append(" FROM INFORMATION_SCHEMA.COLUMNS  A");
            sbQuery.Append(" LEFT JOIN");
            sbQuery.Append(" (");
            sbQuery.Append(" SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE");
            sbQuery.Append(" WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_NAME), 'ISPRIMARYKEY') = 1");
            sbQuery.Append(" ) B");
            sbQuery.Append(" ON A.TABLE_NAME = B.TABLE_NAME");
            sbQuery.Append(" AND A.COLUMN_NAME = B.COLUMN_NAME");
            sbQuery.Append(" ORDER BY A.TABLE_NAME, A.ORDINAL_POSITION");

            DataTable bsTable = bsDB.GetQueryToDataTable(sbQuery.ToString());

            DataTable tgTable = tgDB.GetQueryToDataTable(sbQuery.ToString());

            DataTable tempTable = bsTable.Clone();

            tempTable.Columns.Add("FLAG", typeof(string));

            foreach (DataRow bsRow in bsTable.Rows)
            {
                bool isAdd = true;
                DataRow removeRow = null;
                foreach (DataRow tgRow in tgTable.Rows)
                {
                    // 테이블명, 컬럼명도 똑같으나 
                    if (bsRow["TABLE_NAME"].Equals(tgRow["TABLE_NAME"])
                        && bsRow["COLUMN_NAME"].Equals(tgRow["COLUMN_NAME"]))
                    {
                       

                        //타입비교해서 다르면
                        if (!bsRow["IS_NULLABLE"].Equals(tgRow["IS_NULLABLE"])
                            || !bsRow["DATA_TYPE"].Equals(tgRow["DATA_TYPE"])
                            || !bsRow["LENGTH"].Equals(tgRow["LENGTH"])
                            || !bsRow["NUMERIC_PRECISION"].Equals(tgRow["NUMERIC_PRECISION"])
                            || !bsRow["NUMERIC_SCALE"].Equals(tgRow["NUMERIC_SCALE"])
                            || !bsRow["PK"].Equals(tgRow["PK"]))
                        {
                            DataRow newRow = tempTable.NewRow();
                            newRow.ItemArray = bsRow.ItemArray;

                            newRow["FLAG"] = "ALTER";

                            tempTable.Rows.Add(newRow);
                        }

                        isAdd = false;
                        removeRow = tgRow;
                        tgTable.Rows.Remove(tgRow);

                        break;
                    }
                }

                if (isAdd)
                {
                    DataRow newRow = tempTable.NewRow();
                    newRow.ItemArray = bsRow.ItemArray;

                    newRow["FLAG"] = "ADD";
                    tempTable.Rows.Add(newRow);
                }
            }

            foreach (DataRow dropRow in tgTable.Rows)
            {
                DataRow newRow = tempTable.NewRow();
                newRow.ItemArray = dropRow.ItemArray;

                newRow["FLAG"] = "DROP";
                tempTable.Rows.Add(newRow);
            }

            //dataGridView1.DataSource = tempTable;
            //dataGridView1.AutoResizeColumns();

            gridControl1.DataSource = tempTable;

            gridView1.BestFitColumns();
          
            button1.Text = " COMPARE COMPLETED ";
            button1.ForeColor = System.Drawing.Color.White;
            button1.BackColor = System.Drawing.Color.LimeGreen;

        }

        private void cboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Text = " COMPARE ";
            button1.ForeColor = System.Drawing.Color.Black;
            button1.BackColor = System.Drawing.Color.Transparent;
        }

        private void cboDB_TG_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Text = " COMPARE ";
            button1.ForeColor = System.Drawing.Color.Black;
            button1.BackColor = System.Drawing.Color.Transparent;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //CREATE TABLE 

            DataRow focused = gridView1.GetFocusedDataRow();

            if (focused == null || focused.ToString() == "") return;

            string tbName = focused["TABLE_NAME"].ToString();
     
            DataTable source = gridControl1.DataSource as DataTable;

            DataTable filteredDt = source.AsEnumerable().Where(Row => Row.Field<string>("TABLE_NAME") == tbName).CopyToDataTable();


            string header = "USE [" + cboDB_TG.Text + "]\r\r"; 
            string Script = header + "CREATE TABLE " + tbName + "(" + "\r";
            string body = string.Empty;
            string key = string.Empty;

            foreach(DataRow dr in filteredDt.Rows)
            {
                string temp = string.Empty;

                temp = "\t" + dr["COLUMN_NAME"].ToString();

                if(dr["PK"].ToString() == "PK")
                {
                    key += dr["COLUMN_NAME"].ToString() + ", ";
                }


                if (dr["DATA_TYPE"].ToString() == "tinyint" || dr["DATA_TYPE"].ToString() == "int" || dr["DATA_TYPE"].ToString() == "bigint" || dr["DATA_TYPE"].ToString() == "datetime" || dr["DATA_TYPE"].ToString() == "image" || dr["DATA_TYPE"].ToString() == "real" || dr["DATA_TYPE"].ToString() == "float" || dr["DATA_TYPE"].ToString() == "date")
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "";
                }
                else if(dr["DATA_TYPE"].ToString() == "numeric" || dr["DATA_TYPE"].ToString() == "decimal")
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "(" + dr["NUMERIC_PRECISION"].ToString() + "," + dr["NUMERIC_SCALE"].ToString() + ")";
                }
                else if(dr["DATA_TYPE"].ToString() == "varbinary" || (dr["DATA_TYPE"].ToString() == "nvarchar" && dr["LENGTH"].ToString() == "-1") || (dr["DATA_TYPE"].ToString() == "varchar" && dr["LENGTH"].ToString() == "-1"))
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "(MAX)";
                }
                else
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "(" + dr["LENGTH"].ToString() + ")";
                }


                if(dr["IS_NULLABLE"].ToString() == "NO")
                {
                    temp += " NOT NULL, \r";
                }
                else
                {
                    temp += ", \r";
                }
              

                body += temp;
            }

            Script += body;

            if (key.Length > 0)
            {
                key = key.Remove(key.Length - 2, 1);
                Script += "\t" + "PRIMARY KEY(" + key + "))\r";
            }

            Script = Script.Remove(Script.Length - 3, 1);  // 마지막 ,문자 제거

            Script += ");";

            richTextBox1.Text = Script;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DROP TABLE 

            DataRow focused = gridView1.GetFocusedDataRow();
            if (focused == null || focused.ToString() == "") return;

            string tbName = focused["TABLE_NAME"].ToString();

            string header = "USE [" + cboDB.Text + "]\r\r";
            string Script = header + "DROP TABLE " + tbName + ";";

            richTextBox1.Text = Script;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ADD COLUMNS

            richTextBox1.Text = "";

            DataRow focused = gridView1.GetFocusedDataRow();
         
            string tbName = focused["TABLE_NAME"].ToString();

            int[] handles = gridView1.GetSelectedRows();

            if (handles.Length == 0) return;

            DataTable dtSource = gridControl1.DataSource as DataTable;

            DataTable dtSelected = dtSource.Clone();

            foreach(int i in handles)
            {
                DataRow rw = gridView1.GetDataRow(i);
                dtSelected.ImportRow(rw);
            }


            string header = "USE [" + cboDB_TG.Text + "]\r\r";
            string Script = header + "ALTER TABLE " + tbName + "\rADD\r";
            string body = string.Empty;
        
            foreach(DataRow dr in dtSelected.Rows)
            {
                string temp = string.Empty;

                temp = dr["COLUMN_NAME"].ToString();


                if (dr["DATA_TYPE"].ToString() == "tinyint" || dr["DATA_TYPE"].ToString() == "int" || dr["DATA_TYPE"].ToString() == "bigint" || dr["DATA_TYPE"].ToString() == "datetime" || dr["DATA_TYPE"].ToString() == "image" || dr["DATA_TYPE"].ToString() == "real" || dr["DATA_TYPE"].ToString() == "float" || dr["DATA_TYPE"].ToString() == "date")
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "";
                }
                else if (dr["DATA_TYPE"].ToString() == "numeric" || dr["DATA_TYPE"].ToString() == "decimal")
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "(" + dr["NUMERIC_PRECISION"].ToString() + "," + dr["NUMERIC_SCALE"].ToString() + ")";
                }
                else if (dr["DATA_TYPE"].ToString() == "varbinary" || (dr["DATA_TYPE"].ToString() == "nvarchar" && dr["LENGTH"].ToString() == "-1") || (dr["DATA_TYPE"].ToString() == "varchar" && dr["LENGTH"].ToString() == "-1"))
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "(MAX)";
                }
                else
                {
                    temp += " " + dr["DATA_TYPE"].ToString() + "(" + dr["LENGTH"].ToString() + ")";
                }


                if (dr["IS_NULLABLE"].ToString() == "NO")
                {
                    temp += " NOT NULL,\r";
                }
                else
                {
                    temp += ",\r";
                }

                body += temp;
            }

            Script += body;

            Script = Script.Remove(Script.Length - 2, 2);  

            Script += ";";

            richTextBox1.Text = Script;

         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // DROP COLUMNS

            richTextBox1.Text = "";

            DataRow focused = gridView1.GetFocusedDataRow();
            string tbName = focused["TABLE_NAME"].ToString();

            int[] handles = gridView1.GetSelectedRows();

            if (handles.Length == 0) return;

            DataTable dtSource = gridControl1.DataSource as DataTable;

            DataTable dtSelected = dtSource.Clone();

            foreach (int i in handles)
            {
                DataRow rw = gridView1.GetDataRow(i);
                dtSelected.ImportRow(rw);
            }


            string header = "USE [" + cboDB_TG.Text + "]\r\r";
            string Script = header + "ALTER TABLE " + tbName + "\rDROP COLUMN\r";
            string body = string.Empty;

            foreach (DataRow dr in dtSelected.Rows)
            {
                string temp = string.Empty;

                temp = dr["COLUMN_NAME"].ToString() + ", \r";

                body += temp;
            }

            Script += body;

            Script = Script.Remove(Script.Length - 3, 3);  

            Script += ";";

            richTextBox1.Text = Script;

        }
    }

}
