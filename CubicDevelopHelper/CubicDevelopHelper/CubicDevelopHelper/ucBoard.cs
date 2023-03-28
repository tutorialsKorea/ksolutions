using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CubicDevelopHelper.Properties;

namespace Cubic_Query_Builder
{
    public partial class ucBoard : MetroFramework.Controls.MetroUserControl
    {
        private DB_Manage dm;
        public ucBoard()
        {
            InitializeComponent();
            dm = new DB_Manage("db_ip", "db_name", "db_id", "db_pw");

            // 기본타입
            cboCategory.Items.Add("Issue");
            cboCategory.Items.Add("DevControl");
            cboCategory.Items.Add("REST API");

            //metroGrid1.AutoGenerateColumns = true;
            metroDateTime1.Value = DateTime.Today.AddDays(-30);
            metroDateTime2.Value = DateTime.Today;
            txtUserID.Text = Settings.Default["UserID"].ToString();

            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
           

            search();
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;

            if(e.MenuType == GridMenuType.User)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if(e.MenuType == GridMenuType.Row)
            {
                if (e.HitInfo.RowHandle >= 0)
                {
                    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }

            if (e.HitInfo.HitTest == GridHitTest.EmptyRow || e.HitInfo.HitTest == GridHitTest.Row || e.HitInfo.HitTest == GridHitTest.RowCell)
            {

                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

                popupMenu1.ShowPopup(view.GridControl.PointToScreen(e.Point));

            }
        }




        private void search()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" select kb_id, kb_type, kb_subject, kb_contents, reg_date, reg_emp from tmnt_kb ");
                query.Append(" where CONVERT(CHAR(8), reg_date, 112) between '");
                query.Append(metroDateTime1.Value.ToString("yyyyMMdd") + "' and '");
                query.Append(metroDateTime2.Value.ToString("yyyyMMdd") + "'");
                if (metroTextBox1.Text != "")
                {
                    query.Append(" and (kb_subject like '%" + metroTextBox1.Text + "%'");
                    query.Append("     or kb_contents like '%" + metroTextBox1.Text + "%')");
                }
                query.Append(" order by kb_id desc");

                DataTable dtResult = dm.GetQueryToDataTable(query.ToString());

                
                foreach(DataRow row in dtResult.Rows)
                {
                    if(!cboCategory.Items.Contains(row["kb_type"].ToString()) && row["kb_type"].ToString() != "")
                    {
                        cboCategory.Items.Add(row["kb_type"].ToString());
                    }
     
                }

                gridControl1.DataSource = dtResult;
                gridView1.BestFitColumns();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                StringBuilder query = new StringBuilder();

                string Contents = richEditControl1.HtmlText;


                if (btnSubmit.Text == "등록")
                {
                    
                    query.Append("insert into tmnt_kb");
                    query.Append(" (kb_type, kb_subject, kb_contents, reg_date, reg_emp) ");
                    query.Append(" values ( ");
                    query.Append("'" + cboCategory.Text+ "',");
                    //query.Append("'" + cboCategory.SelectedItem + "',");
                    query.Append("'" + txtSubject.Text + "', ");
                    //query.Append("'" + richEditControl1.Text + "', ");
                    query.Append(" @Contents ");
                    query.Append(",getdate(),");
                    query.Append("'" + txtUserID.Text + "')");

                }
                else
                {
                    query.Append("update tmnt_kb ");
                    query.Append("set kb_type = '" + cboCategory.Text + "'");
                    //query.Append("set kb_type = '" + cboCategory.SelectedItem + "'");
                    query.Append(", kb_subject = '" + txtSubject.Text + "'");
                    query.Append(", kb_contents =  @Contents ");
                    //query.Append(", kb_contents = '" + richEditControl1.Text + "'");
                    query.Append(" where  ");
                    query.Append(" kb_id = " + txtID.Text);

                }

                dm.SetQueryToExecute(query.ToString(),Contents);

                txtSubject.Text = string.Empty;
                richEditControl1.Text = string.Empty;
                txtID.Text = string.Empty;
                btnSubmit.Text = "등록";
                cboCategory.Text = string.Empty;
              
                metroTabControl1.SelectedTab = metroTabPage1;
                search();

  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) search();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e) //열기
        {
            try
            {

                DataRow focusedRow = gridView1.GetFocusedDataRow();

                if (focusedRow != null)
                {
                  

                    txtSubject.Text = focusedRow["kb_subject"].ToString();
                    richEditControl1.HtmlText = focusedRow["kb_contents"].ToString();
                    //richEditControl1.Text = focusedRow["kb_contents"].ToString(); 
                    cboCategory.Text = focusedRow["kb_type"].ToString();
                    //cboCategory.SelectedText = focusedRow["kb_type"].ToString();
                    txtID.Text = focusedRow["kb_id"].ToString();
                    metroTabControl1.SelectedTab = metroTabPage2;

                    btnSubmit.Text = "수정";

                }
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSubject.Text = string.Empty;
            richEditControl1.Text = string.Empty;
            txtID.Text = string.Empty;
            btnSubmit.Text = "등록";
            cboCategory.Text = string.Empty;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Delete?", 
                "Knowledge Base", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder();

                query.Append("delete from tmnt_kb");
                query.Append(" where  kb_id = " + txtID.Text);

                dm.SetQueryToExecute(query.ToString());

                txtSubject.Text = string.Empty;
                richEditControl1.Text = string.Empty;
                txtID.Text = string.Empty;
                btnSubmit.Text = "등록";
                cboCategory.Text = string.Empty;

                metroTabControl1.SelectedTab = metroTabPage1;
                search();

            }
            
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if(txtUserID.Text.Length > 3)
            {
                return;
            }
            else
            {
                Settings.Default["UserID"] = txtUserID.Text;
                Settings.Default.Save();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 행 삭제
            DataRow row = gridView1.GetFocusedDataRow();

            string txtId = row["kb_id"].ToString();

            DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Delete?",
                "Knowledge Base", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                StringBuilder query = new StringBuilder();

                query.Append("delete from tmnt_kb");
                query.Append(" where  kb_id = " + txtId);

                dm.SetQueryToExecute(query.ToString());
             
                search();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // 등록화면 바로가기

            metroTabControl1.SelectedTab = metroTabPage2;
        }


        //콤보박스 높이 변경으로 인해 추가
        private void cboCategory_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(this.cboCategory.Items[e.Index].ToString(),
                e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
}
