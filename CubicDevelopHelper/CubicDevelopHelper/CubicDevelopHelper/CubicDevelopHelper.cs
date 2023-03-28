using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Cubic_Query_Builder
{
    public partial class CubicDevelopHelper : Form
    {
        public CubicDevelopHelper()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //테이블 조회
            Search_Table();
        }

        DB_Manage db_mng;
        DataTable dt_Column;
        string MDB_File_Path = "";
        void Search_Table()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //테이블 조회
                db_mng = new DB_Manage(txtIP.Text, cboDB.Text, txtID.Text, txtPW.Text);

                string strQuery = "select * from information_schema.tables order by table_name";

                cboTable.DataSource = db_mng.GetQueryToDataTable(strQuery);

                cboTable.DisplayMember = "TABLE_NAME";

                cboTable.ValueMember = "TABLE_NAME";

                lbStatus.Text = "▶ Table Refresh OK.";

                Cursor.Current = Cursors.Default;
            }
            catch
            {
                lbStatus.Text = "▶ Error.";
                Cursor.Current = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //쿼리 빌더 실행
                if (tabControl1.SelectedIndex == 0)
                {
                    Excute_BR();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    Excute_PT();
                }

                Cursor.Current = Cursors.Default;
            }
            catch
            {
                lbStatus.Text = "▶ Error.";
                Cursor.Current = Cursors.Default;
            }
        }

        void Excute_BR()
        {
            string sSel = string.Empty;

            //쿼리 빌더 실행
            if (radioButton1.Checked)//select
            {
                rTb_BR.Text = GetSelectQuery(cboTable.Text);
                sSel = "Select";
            }
            else if (radioButton2.Checked)//insert
            {
                rTb_BR.Text = GetInsertQuery(cboTable.Text);
                sSel = "Insert";
            }
            else if (radioButton3.Checked)//update
            {
                rTb_BR.Text = GetUpdateQuery(cboTable.Text);
                sSel = "Update";
            }
            //else if (radioButton4.Checked)//delete
            //    richTextBox1.Text = GetUpdateQuery(cboTable.Text);

            string sClip = string.Empty;
            if (cbClip.Checked)
            {
                //클릭보드 복사
                Clipboard.SetText(rTb_BR.Text);
                sClip = "and Clipboard Copy";
            }

            lbStatus.Text = "▶ [ " + sSel + " ] Made Query " + sClip + " OK.";
        }

        //Param Table
        void Excute_PT()
        {
            rTb_PT.Text = GetParamTable(cboTable.Text);

            string sClip = string.Empty;
            if (cbClip.Checked)
            {
                //클릭보드 복사
                Clipboard.SetText(rTb_PT.Text);
                sClip = "and Clipboard Copy";
            }

            lbStatus.Text = "▶ Made Param Table " + sClip + " OK.";

        }

        private DataTable GetTableColumnInfo(DB_Manage db_mng, string table_name)
        {
            try
            {
                string query = "select a.column_name, a.data_type, a.character_maximum_length, a.column_default , case when b.COLUMN_NAME is null then 0 else 1 end as pk "
                                + " from information_schema.columns a "
                                + " left join INFORMATION_SCHEMA.KEY_COLUMN_USAGE b "
                                + " on a.TABLE_NAME = b.TABLE_NAME "
                                + " and a.COLUMN_NAME = b.COLUMN_NAME "
                                + string.Format(" where a.table_name = '{0}'", table_name);

                return db_mng.GetQueryToDataTable(query); ;
            }
            catch
            {
                MessageBox.Show("테이블 정보를 찾을 수가 없습니다.");
                return null;
            }
        }

        //Select
        private string GetSelectQuery(string table_name)
        {
            DataTable dtColumn = dt_Listview();

            if (dtColumn == null)
                return "";


            string templet = string.Format("        public static DataTable {0}_SER(DataTable dtParam, BizExecute.BizExecute bizExecute) ", table_name) + "\r"
                                        + "        {" + "\r"
                                        + "            try" + "\r"
                                        + "            {" + "\r"
                                        + "                DataSet dsResult = new DataSet();" + "\r\r"
                                        + "                if (dtParam.Rows.Count > 0)" + "\r"
                                        + "                {" + "\r"
                                        + "                    StringBuilder sbQuery = new StringBuilder();" + "\r\r"
                                        + "                    @strValue" + "\r"
                                        + "                    foreach (DataRow row in dtParam.Rows)" + "\r"
                                        + "                    {" + "\r"
                                        + "                        bool isHasColumn = true;" + "\r\r"
                                        + "                        @strValid" + "\r"
                                        + "                        if (isHasColumn == true)" + "\r"
                                        + "                        {" + "\r"
                                        + "                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();" + "\r\r"
                                        + "                            sourceTable.TableName = \"RSLTDT\";" + "\r"
                                        + "                            dsResult.Merge(sourceTable);" + "\r"
                                        + "                        }" + "\r"
                                        + "                    }" + "\r"
                                        + "                }" + "\r"
                                        + "                return UTIL.GetDsToDt(dsResult);" + "\r"
                                        + "            }" + "\r"
                                        + "            catch (Exception ex)" + "\r"
                                        + "            {" + "\r"
                                        + "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r"
                                        + "            }" + "\r"
                                        + "        }" + "\r";



            string result = " SELECT \r {0} FROM {1} \r WHERE {2}";

            string column = string.Empty;
            string where = string.Empty;
            string valid = string.Empty;
            foreach (DataRow row in dtColumn.Rows)
            {
                column += (column == "" ? "" : ",") + (row["column_name"].ToString() + "\r");
                if (row["PK"].ToString() == "1")
                {
                    where += (where == "" ? "" : " AND ") + (row["column_name"].ToString() + " = @" + row["column_name"].ToString() + " \r");
                    valid += (valid == "" ? "" : "                        ") + string.Format("if (!UTIL.ValidColumn(row, \"{0}\")) isHasColumn = false;" + "\r", row["column_name"].ToString());
                }
            }

            result = string.Format(result, column, table_name, where);
            string temp = string.Empty;
            foreach (string line in result.Split('\r'))
            {
                if (line.ToString() != "")
                {
                    temp += (temp == "" ? "" : "                    ") + "sbQuery.Append(\" " + line.Replace("\r", "") + " \");\r";
                }
            }

            templet = templet.Replace("@strValue", temp).Replace("@strValid", valid);

            return templet;
        }

        //Insert
        private string GetInsertQuery(string table_name)
        {
            DataTable dtColumn = dt_Listview();

            string[] InsertCheckColumn = { "MDFY_EMP", "MDFY_DATE", "DEL_EMP", "DEL_DATE" };
            string[] ReplaceCheckColumn = { "REG_EMP", "REG_DATE" };

            if (dtColumn == null)
                return "";


            string templet = string.Format("        public static void {0}_INS(DataTable dtParam, BizExecute.BizExecute bizExecute) ", table_name) + "\r"
                                        + "        {" + "\r"
                                        + "            try" + "\r"
                                        + "            {" + "\r"
                                        + "                DataSet dsResult = new DataSet();" + "\r\r"
                                        + "                if (dtParam.Rows.Count > 0)" + "\r"
                                        + "                {" + "\r"
                                        + "                    StringBuilder sbQuery = new StringBuilder();" + "\r\r"
                                        + "                    @strValue" + "\r"
                                        + "                    foreach (DataRow row in dtParam.Rows)" + "\r"
                                        + "                    {" + "\r"
                                        + "                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);" + "\r"
                                        + "                    }" + "\r"
                                        + "                }" + "\r"
                                        + "            }" + "\r"
                                        + "            catch (Exception ex)" + "\r"
                                        + "            {" + "\r"
                                        + "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r"
                                        + "            }" + "\r"
                                        + "        }" + "\r";



            string result = "INSERT INTO {0} ( \r {1} ) VALUES ( \r @{2} )";

            string column = string.Empty;
            string value = string.Empty;

            foreach (DataRow row in dtColumn.Rows)
            {

                if (InsertCheckColumn.Contains(row["column_name"].ToString())) continue;
                column += (column == "" ? "" : ",") + (row["column_name"].ToString() + "\r");

                if(ReplaceCheckColumn.Contains(row["column_name"].ToString()))
                {
                    if(row["column_name"].ToString().Contains("_DATE"))
                    {
                        value += (value == "" ? "" : ",GETDATE()\r");
                    }
                    else
                    {
                        value += (value == "" ? "" : ",'") + "\" + ConnInfo.UserID + \"" + "'\r";
                    }
                }
                else
                    value += (value == "" ? "" : ",@") + (row["column_name"].ToString() + "\r");
            }

            result = string.Format(result, table_name, column, value);
            string temp = string.Empty;
            foreach (string line in result.Split('\r'))
            {
                if (line.ToString() != "")
                {
                    temp += (temp == "" ? "" : "                    ") + "sbQuery.Append(\" " + line.Replace("\r", "") + " \");\r";
                }
            }

            templet = templet.Replace("@strValue", temp);

            return templet;
        }

        //Update
        private string GetUpdateQuery(string table_name)
        {
            DataTable dtColumn = dt_Listview();

            string[] UpdateCheckColumn = { "REG_EMP", "REG_DATE", "DEL_EMP", "DEL_DATE" };
            string[] ReplaceCheckColumn = { "MDFY_EMP", "MDFY_DATE" };
            if (dtColumn == null)
                return "";


            string templet = string.Format("        public static void {0}_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute) ", table_name) + "\r"
                        + "        {" + "\r"
                        + "            try" + "\r"
                        + "            {" + "\r"
                        + "                DataSet dsResult = new DataSet();" + "\r\r"
                        + "                if (dtParam.Rows.Count > 0)" + "\r"
                        + "                {" + "\r"
                        + "                    StringBuilder sbQuery = new StringBuilder();" + "\r\r"
                        + "                    @strValue"
                        + "                    foreach (DataRow row in dtParam.Rows)" + "\r"
                        + "                    {" + "\r"
                        + "                        bool isHasColumn = true;" + "\r\r"
                        + "                        @strValid" + "\r"
                        + "                        if (isHasColumn == true)" + "\r"
                        + "                        {" + "\r"
                        + "                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);" + "\r"
                        + "                        }" + "\r"
                        + "                    }" + "\r"
                        + "                }" + "\r"
                        + "            }" + "\r"
                        + "            catch (Exception ex)" + "\r"
                        + "            {" + "\r"
                        + "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r"
                        + "            }" + "\r"
                        + "        }" + "\r";



            string result = "UPDATE {0} SET \r {1} WHERE {2}";

            string value = string.Empty;
            string where = string.Empty;
            string valid = string.Empty;
            foreach (DataRow row in dtColumn.Rows)
            {
                if (row["PK"].ToString() == "1")
                {
                    where += (where == "" ? "" : " AND ") + (row["column_name"].ToString() + " = @" + row["column_name"].ToString() + "\r");
                    valid += (valid == "" ? "" : "                        ") + string.Format("if (!UTIL.ValidColumn(row, \"{0}\")) isHasColumn = false;" + "\r", row["column_name"].ToString());
                }
                else
                {
                    if (UpdateCheckColumn.Contains(row["column_name"].ToString())) continue;
                    if (ReplaceCheckColumn.Contains(row["column_name"].ToString()))
                    {
                        if (row["column_name"].ToString().Contains("_DATE"))
                        {
                            value += (value == "" ? "" : ",") + (row["column_name"].ToString() + " = GETDATE()\r");
                        }
                        else
                        {
                            value += (value == "" ? "" : ",") + (row["column_name"].ToString() + " = '" + "\" + ConnInfo.UserID + \"" + "'\r");
                        }
                    }
                    else
                        value += (value == "" ? "" : ",") + (row["column_name"].ToString() + " = @" + row["column_name"].ToString() + "\r");
                }
            }

            result = string.Format(result, table_name, value, where);
            string temp = string.Empty;
            foreach (string line in result.Split('\r'))
            {
                if (line.ToString() != "")
                {
                    temp += (temp == "" ? "" : "                    ") + "sbQuery.Append(\" " + line.Replace("\r", "") + " \");\r";
                }
            }

            templet = templet.Replace("@strValue", temp).Replace("@strValid", valid);

            return templet;
        }

        //Param Table
        private string GetParamTable(string table_name)
        {
            DataTable dtColumn = dt_Listview();

            if (dtColumn == null)
                return "";


            string templet = "        DataTable Save(DataRow dr)" + "\r"
                                        + "        {" + "\r"
                                        + "             DataTable paramTable = new DataTable(\"RQSTDT\");" + "\r"
                                        + "@strTable" + "\r"
                                        + "             DataRow paramRow = paramTable.NewRow();" + "\r"
                                        + "@strRow" + "\r"
                                        + "             paramTable.Rows.Add(paramRow);" + "\r"
                                        + "             return paramTable;" + "\r"
                                        + "        }" + "\r";


            //string result = "  {0} ";

            //string column = string.Empty;
            string strTable = string.Empty;
            string strRow = string.Empty;
            foreach (DataRow row in dtColumn.Rows)
            {
                strTable += "             paramTable.Columns.Add(\"" + (row["column_name"].ToString() + "\", typeof(" + GetColumnType(row["data_type"].ToString()) + "));\r");
                strRow += "             paramRow[\"" + (row["column_name"].ToString() + "\"] = dr[\"" + row["column_name"].ToString() + "\"];\r");
            }

            templet = templet.Replace("@strTable", strTable).Replace("@strRow", strRow);

            return templet;
        }

        //컬럼 타입 변환
        string GetColumnType(string ColType)
        {
            string sReturn = string.Empty;

            switch (ColType.ToLower())
            {
                case "numeric":
                    sReturn = "Decimal";
                    break;
                case "int":
                    sReturn = "Int32";
                    break;
                case "tinyint":
                    sReturn = "Byte";
                    break;
                case "datetime":
                    sReturn = "DateTime";
                    break;
                default:
                    sReturn = "String";
                    break;

            }
            return sReturn;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DB 접속
            Conn_DB();
        }

        void Conn_DB()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //DB 접속
                db_mng = new DB_Manage(txtIP.Text, txtDB.Text, txtID.Text, txtPW.Text);

                string strQuery = "select NAME from sys.sysdatabases order by name asc";

                cboDB.DataSource = db_mng.GetQueryToDataTable(strQuery);
                cboDB.DisplayMember = "NAME";
                cboDB.ValueMember = "NAME";

                lbStatus.Text = "▶ DataBase Connection OK.";

                Cursor.Current = Cursors.Default;
            }
            catch
            {
                lbStatus.Text = "▶ Error.";
                Cursor.Current = Cursors.Default;
            }
        }

        private void cboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //테이블 목록 조회
            if (cboDB.Text != "System.Data.DataRowView")
            {
                Search_Table();
            }
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //컬럼 검색
            Search_Column();
        }

        void Search_Column()
        {
            if (cboTable.Text.Length > 0)
            {
                rTb_BR.Text = string.Empty;
                dt_Column = GetTableColumnInfo(db_mng, cboTable.Text);
                lvCol.Items.Clear();

                int i = 0;
                foreach (DataRow dr in dt_Column.Rows)
                {
                    i++;

                    ListViewItem lvt = new ListViewItem();
                    lvt.Checked = true;
                    lvt.SubItems.Add(dr["column_name"].ToString());
                    lvt.SubItems.Add(dr["data_type"].ToString());
                    lvt.SubItems.Add(dr["character_maximum_length"].ToString());
                    lvt.SubItems.Add(dr["pk"].ToString());
                    lvt.SubItems.Add(dr["column_default"].ToString());
                    lvCol.Items.Add(lvt);
                }

                for (int j = 0; j < lvCol.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        lvCol.Columns[j].TextAlign = HorizontalAlignment.Center;
                    }
                    lvCol.Columns[j].Width = -2;
                }

                this.Refresh();
            }
        }

        DataTable dt_Listview()
        {
            string column_name = string.Empty;
            foreach (ListViewItem list in lvCol.Items)
            {
                if (!list.Checked)
                {
                    column_name += " '" + list.SubItems[1].Text + "',";
                }
            }

            if (column_name.Length > 0)
            {
                column_name = column_name.Substring(0, column_name.Length - 1);
                column_name = "column_name not in (" + column_name + ")";
            }

            return dt_Column.Select(column_name).CopyToDataTable();

        }

        private void lvCol_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {

        }

        // 컬럼헤더에 있는 체크박스 클릭시 나머지 체크박스들도 자동 체크되도록 하는 로직
        private void Bink(object sender, System.EventArgs e)
        {
            CheckBox cck = sender as CheckBox;
            for (int i = 0; i < lvCol.Items.Count; i++)
            {
                lvCol.Items[i].Checked = cck.Checked;
            }
        }

        private void lvCol_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvCol_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //add StringBuilder
            StringBuilderAdd();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //remove StringBuilder
            StringBuilderRemove();
        }

        void StringBuilderAdd()
        {
            string strRslt = "StringBuilder sbQuery = new StringBuilder();\r\r";

            foreach (string strLine in rTb_Util.Lines)
            {
                if (strLine.Trim() != "")
                {
                    if (strLine.IndexOf("sbQuery") == -1)
                    {
                        strRslt += "sbQuery.Append(\" " + strLine.Trim().ToUpper() + "\");\r";
                    }
                    else
                    {
                        if (strLine.IndexOf("StringBuilder") == -1)
                        {
                            strRslt += strLine.Trim() + "\r";
                        }
                    }
                }
            }

            rTb_Util.Text = strRslt;

            lbStatus.Text = "▶ Add StringBuilder OK.";

        }

        void StringBuilderRemove()
        {
            string strRslt = "";

            foreach (string strLine in rTb_Util.Lines)
            {
                string[] strs = strLine.Split('\"');

                if (strs.Length > 1)
                {
                    if (strs[1].Trim() != "")
                    {
                        strRslt += strs[1].Trim().ToUpper() + "\r";
                    }
                }
                else
                {
                    if (strLine.IndexOf("StringBuilder") == -1)
                    {
                        strRslt += strLine.Trim() + "\r";
                    }
                }
            }

            rTb_Util.Text = strRslt;

            lbStatus.Text = "▶ Remove StringBuilder OK.";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Compare
            DB_Manage oriDB = new DB_Manage(txtIP.Text, cboDB.Text, txtID.Text, txtPW.Text);

            DB_Manage cpDB = new DB_Manage(txtCpIP.Text, txtCpDB.Text, txtCpID.Text, txtCpPW.Text);

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

            DataTable oriTable = oriDB.GetQueryToDataTable(sbQuery.ToString());

            DataTable cpTable = cpDB.GetQueryToDataTable(sbQuery.ToString());

            DataTable tempTable = oriTable.Clone();
            tempTable.Columns.Add("FLAG", typeof(string));

            foreach (DataRow oriRow in oriTable.Rows)
            {
                bool isAdd = true;
                DataRow removeRow = null;
                foreach (DataRow cpRow in cpTable.Rows)
                {
                    if (oriRow["TABLE_NAME"].Equals(cpRow["TABLE_NAME"])
                        && oriRow["COLUMN_NAME"].Equals(cpRow["COLUMN_NAME"]))
                    {
                        if (oriRow["TABLE_NAME"].ToString() == "LSE_SIMULATION" && oriRow["COLUMN_NAME"].ToString() == "PLT_CODE")
                        {
                        }

                        //타입비교해서 다르면
                        if (!oriRow["IS_NULLABLE"].Equals(cpRow["IS_NULLABLE"])
                            || !oriRow["DATA_TYPE"].Equals(cpRow["DATA_TYPE"])
                            || !oriRow["LENGTH"].Equals(cpRow["LENGTH"])
                            || !oriRow["NUMERIC_PRECISION"].Equals(cpRow["NUMERIC_PRECISION"])
                            || !oriRow["NUMERIC_SCALE"].Equals(cpRow["NUMERIC_SCALE"])
                            || !oriRow["PK"].Equals(cpRow["PK"]))
                        {
                            DataRow newRow = tempTable.NewRow();
                            newRow.ItemArray = oriRow.ItemArray;

                            newRow["FLAG"] = "ALTER";

                            tempTable.Rows.Add(newRow);
                        }

                        isAdd = false;
                        removeRow = cpRow;
                        cpTable.Rows.Remove(cpRow);

                        break;
                    }
                }

                if (isAdd)
                {
                    DataRow newRow = tempTable.NewRow();
                    newRow.ItemArray = oriRow.ItemArray;

                    newRow["FLAG"] = "ADD";
                    tempTable.Rows.Add(newRow);
                }
            }

            foreach (DataRow dropRow in cpTable.Rows)
            {
                DataRow newRow = tempTable.NewRow();
                newRow.ItemArray = dropRow.ItemArray;

                newRow["FLAG"] = "DROP";
                tempTable.Rows.Add(newRow);
            }

            dataGridView1.DataSource = tempTable;

            dataGridView1.AutoResizeColumns();

            lbStatus.Text = "▶ Compare OK.";
        }

        DataConn conn1 = new DataConn();

        private void button7_Click(object sender, EventArgs e)
        {

            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "파일 열기";
            //ofd.FileName = "test";
            ofd.Filter = "MDF Files (*.mdb) | *.mdb";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = ofd.FileName;

                //MessageBox.Show(fileFullName);
                label11.Text = "File Path : " + fileFullName;

                MDB_File_Path = fileFullName;

                DataSet ds, ds2, ds3;
                string DB_path = MDB_File_Path;


                string sql = @"SELECT SBG_NAME from SYS_BM_GRP ORDER BY SBG_NAME ";

                ds = conn1.GetDataset(sql, DB_path);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            TreeNode node1 = new TreeNode(dr1["SBG_NAME"].ToString());

                            sql = @"SELECT SBO_ID, SBO_NAME, SBO_DESC, SBG_NAME from SYS_BM_OBJ " 
                                + string.Format(" WHERE SBG_NAME = '{0}'", dr1["SBG_NAME"].ToString())
                                + " ORDER BY SBO_ID ";
                            ds2 = conn1.GetDataset(sql, DB_path);
                            if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                                {
                                    TreeNode node2 = new TreeNode(dr2["SBO_ID"].ToString());

                                    sql = @"SELECT SBA_ID, SBA_NAME, SBA_DESC, SBO_ID from SYS_BM_ACT "
                                        + string.Format(" WHERE SBO_ID = '{0}'", dr2["SBO_ID"].ToString())
                                        + " ORDER BY SBA_ID ";
                                    ds3 = conn1.GetDataset(sql, DB_path);
                                    if (ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
                                    {
                                        foreach(DataRow dr3 in ds3.Tables[0].Rows)
                                        {
                                            TreeNode node3 = new TreeNode(dr3["SBA_ID"].ToString());
                                            node2.Nodes.Add(node3);
                                        }
                                    }
                                    node1.Nodes.Add(node2);
                                }
                            }

                            treeView1.Nodes.Add(node1);
                        }
                    }

                }
                tabControl2.SelectedTab = tabPage6;
            }
        }
        class DataConn
        {
            public DataSet GetDataset(string sql, string DB_path)
            {

                string connStr = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + DB_path + "; Jet OLEDB:Database Password = ";

                OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connStr);
                DataSet ds = new DataSet();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                adp.Fill(ds);
                return ds;

            }


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeKey = e.Node.Text;
            richTextBox1.Text = "";
            if (!string.IsNullOrEmpty(nodeKey))
            {
                //string sql = @"SELECT SBA_ID, SBC_NUM, SBC_MTHD, SBC_TYPE, SBC_CMNT from SYS_BM_CMD "
                //    + string.Format(" WHERE SBA_ID = '{0}' AND SBC_TYPE = 'DATA' ", nodeKey)
                //    + " ORDER BY SBC_NUM ";
                string sql = @"SELECT SBC_MTHD, SBC_NUM from SYS_BM_CMD "
                    + string.Format(" WHERE SBA_ID = '{0}' AND SBC_TYPE = 'DATA' ", nodeKey)
                    + " ORDER BY SBC_NUM ";
                DataSet ds;

                ds = conn1.GetDataset(sql, MDB_File_Path);

                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;

                if (ds.Tables.Count > 0)
                {
                    dataGridView2.DataSource = ds.Tables[0];

                    dataGridView2.AutoResizeColumns();

                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        dataGridView2.Columns[i].ReadOnly = true;
                    }
                    
                }
                //MessageBox.Show("선택된 노드 키 : " + nodeKey);

                sql = @"SELECT SBA_ID, SBC_NUM, SBCD_TYPE, SBCD_NAME, SBCD_CELL from SYS_BM_CMD_DISP "
                        + string.Format(" WHERE SBA_ID = '{0}' ", nodeKey)
                        + " ORDER BY SBC_NUM ";

                ds = conn1.GetDataset(sql, MDB_File_Path);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable countTable = new DataTable();
                    countTable.Columns.Add("X", typeof(int));
                    countTable.Columns.Add("Y", typeof(int));

                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        DataRow newRow = countTable.NewRow();
                        newRow["X"] = dr["SBCD_CELL"].ToString().Split(',')[0];
                        newRow["Y"] = dr["SBCD_CELL"].ToString().Split(',')[1];
                        countTable.Rows.Add(newRow);
                    }

                    DataRow[] resultRow = countTable.Select();

                    int maxX = resultRow.Max(r => (int)r["X"]);
                    int maxY = resultRow.Max(r => (int)r["Y"]);
                    //MessageBox.Show(maxX.ToString() + "," + maxY.ToString());

                    DataTable newTable = new DataTable();
                    for (int i = 0; i <= maxX; i++)
                    {
                        newTable.Columns.Add("X" + i.ToString(), typeof(string));
                    }
                    for (int j = 0; j <= maxY; j++)
                    {
                        DataRow newRow = newTable.NewRow();
                        newTable.Rows.Add(newRow);
                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int x = int.Parse(dr["SBCD_CELL"].ToString().Split(',')[0]);
                        int y = int.Parse(dr["SBCD_CELL"].ToString().Split(',')[1]);

                        newTable.Rows[y][x] = dr["SBCD_TYPE"].ToString() + "\nTest";

                    }

                    dataGridView3.RowHeadersVisible = false;
                    dataGridView3.DataSource = newTable;
                    dataGridView3.RowTemplate.Height = 50;
                    
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dataGridView3.AutoResizeColumns();
                    for (int i = 0; i < dataGridView3.Columns.Count; i++)
                    {
                        dataGridView3.Columns[i].ReadOnly = true;
                        dataGridView3.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dataGridView3.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }


                }



            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string searchText = textBox1.Text;
            
            //if (string.IsNullOrEmpty(searchText))
            //    return;
            
            //foreach (TreeNode node in treeView1.Nodes)
            //{
            //    if(node.Text == searchText)
            //    {
            //        treeView1.SelectedNode = node;
            //        treeView1.Select();
            //        return;
            //    }
                
            //}
        }
        private TreeNode SearchNode(string SearchText, TreeNode StartNode)
        {
            TreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.Text.ToLower().Contains(SearchText.ToLower()))
                {
                    node = StartNode;
                    break;
                };
                if (StartNode.Nodes.Count != 0)
                {
                    node = SearchNode(SearchText, StartNode.Nodes[0]);  //Recursive Search
                    if (node != null)
                    {
                        break;
                    };
                };
                StartNode = StartNode.NextNode;
            };
            return node;
        }


        private string GetQuery(DataTable dt)
        {
            string resultQuery = "";

            resultQuery += string.Format("        public static DataTable {0}_BM(DataTable dtParam, BizExecute.BizExecute bizExecute) ", dt.Rows[0]["SDA_ID"].ToString()) + "\r";
            resultQuery += "        {" + "\r";
            resultQuery += "            try" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                DataSet dsResult = new DataSet();" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                if (dtParam.Rows.Count > 0)" + "\r";
            resultQuery += "                {" + "\r";
            resultQuery += "                    StringBuilder sbQuery = new StringBuilder();" + "\r";
            //resultQuery += "" + "\r";
            foreach (DataRow dr in dt.Rows)
            {
                if(dr["SDC_SEQ"].ToString() == "1")
                {
                    string[] str = dr["SDC_RAW"].ToString().Split('\r');
                    for (int i = 0; i < str.Length; i++)
                    {
                        string remark = "";
                        if (str[i].Contains("--"))
                            remark = "//";
                        resultQuery += string.Format(remark + "                    sbQuery.Append(\"{0} \"); ", str[i].Replace('\n',' ').Replace('\r',' ')) + "\r";
                    }

                }
            }
            if (dt.Rows.Count > 1)
            {
                resultQuery += "" + "\r";
                resultQuery += "                    foreach (DataRow row in dtParam.Rows)" + "\r";
                resultQuery += "                    {" + "\r";
                resultQuery += "                        StringBuilder sbWhere = new StringBuilder();" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "                        sbWhere.Append(\" WHERE 1 = 1 \");" + "\r";

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["SDC_SEQ"].ToString() != "1")
                    {
                        if (!string.IsNullOrEmpty(dr["SDC_PARA"].ToString()))
                        {
                            string remark = "";
                            //if (dr["SDC_RAW"].ToString().Contains("--"))
                            //    remark = "//";
                            resultQuery += string.Format(remark + "                        sbWhere.Append(UTIL.GetWhere(row, \"@{0}\", \" {1} \"));", dr["SDC_PARA"].ToString().Replace(",", ",@"), dr["SDC_RAW"].ToString().Replace('\r', ' ').Replace('\n', ' ')) + "\r";
                        }
                    }
                }

                resultQuery += "" + "\r";

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["SDC_SEQ"].ToString() != "1")
                    {
                        if (string.IsNullOrEmpty(dr["SDC_PARA"].ToString()))
                        {
                            string remark = "";
                            if (dr["SDC_RAW"].ToString().Contains("--"))
                                remark = "//";
                            if (dr["SDC_RAW"].ToString().Trim().StartsWith("ORDER BY") || dr["SDC_RAW"].ToString().Trim().StartsWith("GROUP BY"))
                            {
                                resultQuery += string.Format(remark + "                        sbWhere.Append(\" {0} \");", dr["SDC_RAW"].ToString().Replace('\n', ' ').Replace('\r', ' ')) + "\r";
                            }
                            else
                            {
                                resultQuery += string.Format(remark + "                        sbWhere.Append(\" AND {0} \");", dr["SDC_RAW"].ToString().Replace('\n', ' ').Replace('\r', ' ')) + "\r";
                            }
                        }
                    }
                }
                resultQuery += "" + "\r";
                resultQuery += "                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "                        sourceTable.TableName = \"RSLTDT\";" + "\r";
                resultQuery += "                        dsResult.Merge(sourceTable);" + "\r";
                resultQuery += "                    }" + "\r";
                resultQuery += "                }" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "                return UTIL.GetDsToDt(dsResult);" + "\r";
                resultQuery += "            }" + "\r";
                resultQuery += "            catch (Exception ex)" + "\r";
                resultQuery += "            {" + "\r";
                resultQuery += "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r";
                resultQuery += "            }" + "\r";
                resultQuery += "        }" + "\r";
            }
            else
            {
                resultQuery += "" + "\r";
                resultQuery += "                    foreach (DataRow row in dtParam.Rows)" + "\r";
                resultQuery += "                    {" + "\r";

                resultQuery += "" + "\r";
                resultQuery += "                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "                        sourceTable.TableName = \"RSLTDT\";" + "\r";
                resultQuery += "                        dsResult.Merge(sourceTable);" + "\r";
                resultQuery += "                    }" + "\r";
                resultQuery += "                }" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "" + "\r";
                resultQuery += "                return UTIL.GetDsToDt(dsResult);" + "\r";
                resultQuery += "            }" + "\r";
                resultQuery += "            catch (Exception ex)" + "\r";
                resultQuery += "            {" + "\r";
                resultQuery += "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r";
                resultQuery += "            }" + "\r";
                resultQuery += "        }" + "\r";

            }
            return resultQuery;
        }




        private string GetSelectQuery(DataTable dt)
        {
            string resultQuery = "";

            resultQuery += string.Format("        public static DataTable {0}_BM(DataTable dtParam, BizExecute.BizExecute bizExecute)", dt.Rows[0]["SDA_ID"].ToString()) + "\r";
            resultQuery += "        {" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "            try" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                DataSet dsResult = new DataSet();" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                if (dtParam.Rows.Count > 0)" + "\r";
            resultQuery += "                {" + "\r";
            resultQuery += "                    StringBuilder sbQuery = new StringBuilder();" + "\r";

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["SDC_SEQ"].ToString() == "1")
                {
                    string[] str = dr["SDC_RAW"].ToString().Split('\r');
                    for (int i = 0; i < str.Length; i++)
                    {
                        string remark = "";
                        if (str[i].Contains("--"))
                            remark = "//";
                        resultQuery += string.Format(remark + "                    sbQuery.Append(\"{0} \");", str[i].Replace('\n', ' ')) + "\r";
                    }

                }
            }


            resultQuery += "" + "\r";
            resultQuery += "                    foreach (DataRow row in dtParam.Rows)" + "\r";
            resultQuery += "                    {" + "\r";
            resultQuery += "                        bool isHasColumn = true;" + "\r";
            resultQuery += "" + "\r";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["SDC_SEQ"].ToString() == "1")
                {
                    string[] str = dr["SDC_PARA"].ToString().Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        resultQuery += string.Format("                        if (!UTIL.ValidColumn(row, \"{0}\")) isHasColumn = false;", str[i]) + "\r";
                    }

                }
            }
            resultQuery += "" + "\r";
            resultQuery += "                        if (isHasColumn == true)" + "\r";
            resultQuery += "                        {" + "\r";
            resultQuery += "                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                            sourceTable.TableName = \"RSLTDT\";" + "\r";
            resultQuery += "                            dsResult.Merge(sourceTable);" + "\r";
            resultQuery += "                        }" + "\r";
            resultQuery += "                    }" + "\r";
            resultQuery += "                }" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                return UTIL.GetDsToDt(dsResult);" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "            }" + "\r";
            resultQuery += "            catch (Exception ex)" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r";
            resultQuery += "            }" + "\r";
            resultQuery += "        }" + "\r";

            return resultQuery;
        }

        private string GetInsertQuery(DataTable dt)
        {
            string resultQuery = "";

            resultQuery += string.Format("        public static void {0}_BM(DataTable dtParam, BizExecute.BizExecute bizExecute)", dt.Rows[0]["SDA_ID"].ToString()) + "\r";
            resultQuery += "        {" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "            try" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                DataSet dsResult = new DataSet();" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                if (dtParam.Rows.Count > 0)" + "\r";
            resultQuery += "                {" + "\r";
            resultQuery += "                    StringBuilder sbQuery = new StringBuilder();" + "\r";

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["SDC_SEQ"].ToString() == "1")
                {
                    string[] str = dr["SDC_RAW"].ToString().Split('\r');
                    for (int i = 0; i < str.Length; i++)
                    {
                        string remark = "";
                        if (str[i].Contains("--"))
                            remark = "//";
                        resultQuery += string.Format(remark + "                    sbQuery.Append(\"{0} \");", str[i].Replace('\n', ' ')) + "\r";
                    }

                }
            }


            resultQuery += "" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                    foreach (DataRow row in dtParam.Rows)" + "\r";
            resultQuery += "                    {" + "\r";
            resultQuery += "                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);" + "\r";
            resultQuery += "                    }" + "\r";
            resultQuery += "                }" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "            }" + "\r";
            resultQuery += "            catch (Exception ex)" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r";
            resultQuery += "            }" + "\r";
            resultQuery += "        }" + "\r";

            return resultQuery;
        }

        private string GetUpdateQuery(DataTable dt)
        {
            bool isWhere = false;
            string whereString = "";
            string resultQuery = "";

            resultQuery += string.Format("        public static void {0}_BM(DataTable dtParam, BizExecute.BizExecute bizExecute)", dt.Rows[0]["SDA_ID"].ToString()) + "\r";
            resultQuery += "        {" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "            try" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                DataSet dsResult = new DataSet();" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                if (dtParam.Rows.Count > 0)" + "\r";
            resultQuery += "                {" + "\r";
            resultQuery += "                    StringBuilder sbQuery = new StringBuilder();" + "\r";

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["SDC_SEQ"].ToString() == "1")
                {
                    string[] str = dr["SDC_RAW"].ToString().Split('\r');
                    for (int i = 0; i < str.Length; i++)
                    {
                        string remark = "";
                        if (str[i].Contains("--"))
                            remark = "//";
                        resultQuery += string.Format(remark + "                    sbQuery.Append(\"{0} \");", str[i].Replace('\n', ' ')) + "\r";
                        if(str[i].Contains("WHERE") || isWhere)
                        {
                            isWhere = true;
                            if (str[i].Contains("@"))
                            {
                                string[] str2 = str[i].Split('@');
                                string str3 = str2[1].Trim();
                                whereString += str3 + ",";

                            }
                        }
                    }

                }
            }

            resultQuery += "" + "\r";
            resultQuery += "                    foreach (DataRow row in dtParam.Rows)" + "\r";
            resultQuery += "                    {" + "\r";
            resultQuery += "                        bool isHasColumn = true;" + "\r";
            resultQuery += "" + "\r";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["SDC_SEQ"].ToString() == "1")
                {
                    string[] str = dr["SDC_PARA"].ToString().Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (whereString.Contains(str[i]))
                        {
                            resultQuery += string.Format("                        if (!UTIL.ValidColumn(row, \"{0}\")) isHasColumn = false;", str[i]) + "\r";
                        }
                    }

                }
            }
            resultQuery += "" + "\r";
            resultQuery += "                        if (isHasColumn == true)" + "\r";
            resultQuery += "                        {" + "\r";
            resultQuery += "                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);" + "\r";
            resultQuery += "" + "\r";
            resultQuery += "                        }" + "\r";
            resultQuery += "                    }" + "\r";
            resultQuery += "                }" + "\r";
            resultQuery += "            }" + "\r";
            resultQuery += "            catch (Exception ex)" + "\r";
            resultQuery += "            {" + "\r";
            resultQuery += "                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);" + "\r";
            resultQuery += "            }" + "\r";
            resultQuery += "        }" + "\r";

            return resultQuery;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectMtd = dataGridView2.Rows[e.RowIndex].Cells["SBC_MTHD"].Value.ToString();

            if (!string.IsNullOrEmpty(selectMtd))
            {
                //string sql = @"SELECT SBA_ID, SBC_NUM, SBC_MTHD, SBC_TYPE, SBC_CMNT from SYS_BM_CMD "
                //    + string.Format(" WHERE SBA_ID = '{0}' AND SBC_TYPE = 'DATA' ", nodeKey)
                //    + " ORDER BY SBC_NUM ";
                string sql = @"SELECT SDA_ID,SDC_STEP, SDC_SEQ, SDC_RAW, SDC_PARA, SDC_TYPE from SYS_DM_CMD "
                    + string.Format(" WHERE SDA_ID = '{0}' ", selectMtd)
                    + " ORDER BY SDC_SEQ ";
                DataSet ds;

                ds = conn1.GetDataset(sql, MDB_File_Path);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string _Type = ds.Tables[0].Rows[0]["SDC_TYPE"].ToString();
                    switch (_Type)
                    {
                        case "I":
                            richTextBox1.Text = GetInsertQuery(ds.Tables[0]);
                            break;
                        case "U":
                            richTextBox1.Text = GetUpdateQuery(ds.Tables[0]);
                            break;
                        case "S":
                            richTextBox1.Text = GetSelectQuery(ds.Tables[0]);
                            break;
                        case "H":
                            //MessageBox.Show(ds.Tables[0].Rows[0]["SDC_RAW"].ToString());
                            richTextBox1.Text = GetQuery(ds.Tables[0]);
                            break;
                        case "D":
                            //MessageBox.Show(ds.Tables[0].Rows[0]["SDC_RAW"].ToString());
                            richTextBox1.Text = GetUpdateQuery(ds.Tables[0]);
                            break;
                    }
                }
                else
                {
                    richTextBox1.Text = "";
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                string searchText = textBox1.Text;

                if (string.IsNullOrEmpty(searchText))
                    return;
                TreeNode resultNode = searchNode(treeView1.Nodes, searchText);
            }
        }

        private TreeNode searchNode(TreeNodeCollection nodes, string searchText)
        {

            foreach (TreeNode node in nodes)
            {

                if (node.Text.ToUpper().Contains(searchText.ToUpper()))
                {
                    treeView1.SelectedNode = node;
                    treeView1.Select();
                    return node;
                }
                if(node.Nodes.Count > 0)
                {
                    TreeNode resultNode = searchNode(node.Nodes, searchText);
                    if (resultNode != null)
                        return resultNode;
                }
            }
            return null;
        }
    }
}
