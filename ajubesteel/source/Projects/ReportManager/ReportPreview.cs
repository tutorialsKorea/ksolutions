using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using CodeHelperManager;

namespace ReportManager
{
    public sealed partial class ReportPreview : acForm
    {
        private acReport _Report = null;
        
        public ReportPreview(acReport rpt)
        {
            InitializeComponent();

            this._Report = rpt;
        }

        protected override void OnLoad(EventArgs e)
        {

            //리소스 수동설정
            printPreviewSubItem1.Caption = acInfo.Resource.GetString("파일", "0CMDK0UT");

            printPreviewSubItem2.Caption = acInfo.Resource.GetString("보기", "YRUN9BAT");

            printPreviewSubItem3.Caption = acInfo.Resource.GetString("배경", "MZHLUE66");


            printPreviewBarItem8.Caption = acInfo.Resource.GetString("페이지 설정", "LIDHDQ1J");

            printPreviewBarItem6.Caption = acInfo.Resource.GetString("인쇄", "4HOA9EHQ");

            printPreviewBarItem7.Caption = acInfo.Resource.GetString("빠른 인쇄", "U6B3HGH3");

            printPreviewBarItem22.Caption = acInfo.Resource.GetString("파일 내보내기", "TEMS9X9O");

            printPreviewBarItem23.Caption = acInfo.Resource.GetString("E-Mail에 첨부하기", "FUNFIXB5");


            printPreviewBarItem24.Caption = acInfo.Resource.GetString("미리보기 종료", "BALD7IWV");

            printPreviewSubItem4.Caption = acInfo.Resource.GetString("페이지 레이아웃", "SM7R1WC4");

            printPreviewBarItem20.Caption = acInfo.Resource.GetString("배경색", "KYF0TDNA");

            printPreviewBarItem21.Caption = acInfo.Resource.GetString("워터마크", "NSBHPBBM");


            printPreviewBarItem2.Caption = acInfo.Resource.GetString("찾기", "6S7R2PIT");

            printPreviewBarItem2.Hint = printPreviewBarItem2.Caption;

            printPreviewBarItem4.Caption = acInfo.Resource.GetString("파일열기", "1U95KG44");
            
            printPreviewBarItem4.Hint = printPreviewBarItem4.Caption;


            printPreviewBarItem5.Caption = acInfo.Resource.GetString("문서 저장", "8MYADIGH");

            printPreviewBarItem5.Hint = printPreviewBarItem5.Caption;


            printPreviewBarItem6.Caption = acInfo.Resource.GetString("인쇄", "4HOA9EHQ");

            printPreviewBarItem6.Hint = printPreviewBarItem6.Caption;



            printPreviewBarItem7.Caption = acInfo.Resource.GetString("빠른 인쇄", "U6B3HGH3");

            printPreviewBarItem7.Hint = printPreviewBarItem7.Caption;


            printPreviewBarItem8.Caption = acInfo.Resource.GetString("페이지 설정", "LIDHDQ1J");

            printPreviewBarItem8.Hint = printPreviewBarItem8.Caption;

            printPreviewBarItem9.Caption = acInfo.Resource.GetString("머리,바닥글 설정", "3EX3MI0F");

            printPreviewBarItem9.Hint = printPreviewBarItem9.Caption;

            printPreviewBarItem10.Caption = acInfo.Resource.GetString("크기", "JVXU2AZ8");

            printPreviewBarItem10.Hint = printPreviewBarItem10.Caption;

            printPreviewBarItem11.Caption = acInfo.Resource.GetString("이동", "4E1488QE");

            printPreviewBarItem11.Hint = printPreviewBarItem11.Caption;

            printPreviewBarItem12.Caption = acInfo.Resource.GetString("돋보기", "0ST18J0W");

            printPreviewBarItem12.Hint = printPreviewBarItem12.Caption;


            printPreviewBarItem13.Caption = acInfo.Resource.GetString("축소", "V8Z581D3");
            
            printPreviewBarItem13.Hint = printPreviewBarItem13.Caption;

            printPreviewBarItem14.Caption = acInfo.Resource.GetString("확대", "XBR8598R");

            printPreviewBarItem14.Hint = printPreviewBarItem14.Caption;


            printPreviewBarItem15.Caption = acInfo.Resource.GetString("첫번째 페이지로 이동", "4ML5KDGG");
            
            printPreviewBarItem15.Hint = printPreviewBarItem15.Caption;


            printPreviewBarItem16.Caption = acInfo.Resource.GetString("이전 페이지로 이동", "D3WW5PBS");
            printPreviewBarItem16.Hint = printPreviewBarItem16.Caption;


            printPreviewBarItem17.Caption = acInfo.Resource.GetString("다음 페이지로 이동", "DTW1CUR7"); 
            printPreviewBarItem17.Hint = printPreviewBarItem17.Caption;



            printPreviewBarItem18.Caption = acInfo.Resource.GetString("마지막 페이지로 이동", "6WV6X7DE");
            printPreviewBarItem18.Hint = printPreviewBarItem18.Caption;


            printPreviewBarItem19.Caption = acInfo.Resource.GetString("다중 페이지 보기", "BYZSXI71");
            printPreviewBarItem19.Hint = printPreviewBarItem19.Caption;


            printPreviewBarItem20.Caption = acInfo.Resource.GetString("배경색", "KYF0TDNA");
            printPreviewBarItem20.Hint = printPreviewBarItem20.Caption;

            printPreviewBarItem21.Caption = acInfo.Resource.GetString("워터마크", "NSBHPBBM");
            printPreviewBarItem21.Hint = printPreviewBarItem21.Caption;


            printPreviewBarItem22.Caption = acInfo.Resource.GetString("파일 내보내기", "TEMS9X9O");
            printPreviewBarItem22.Hint = printPreviewBarItem22.Caption;


            printPreviewBarItem23.Caption = acInfo.Resource.GetString("E-Mail에 첨부하기", "FUNFIXB5");
            printPreviewBarItem23.Hint = printPreviewBarItem23.Caption;


            printPreviewBarItem24.Caption = acInfo.Resource.GetString("미리보기 종료", "BALD7IWV");
            printPreviewBarItem24.Hint = printPreviewBarItem24.Caption;



            barButtonItem1.Caption = acInfo.Resource.GetString("E-Mail로 보내기", "1R052I1C");
            barButtonItem1.Hint = barButtonItem1.Caption;



            printControl1.PrintingSystem = this._Report.PrintingSystem;

            this._Report.CreateDocument();
                        
            base.OnLoad(e);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //메일 전송
            try
            {

                ReportMailSender frm = new ReportMailSender(this._Report);

                frm.ParentControl = this;

                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }

    }
}