using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;

namespace ReportManager
{
    public sealed partial class ImagePage : acReport
    {

        public ImagePage()
        {
            InitializeComponent();
        }

        public override object DataSourceProcess(object datasource)
        {

            byte[] img = (byte[])datasource;

            ImagePage_DS newDatasource = new ImagePage_DS();
            
            ImagePage_DS.DRow newRow = newDatasource.D.NewDRow();

            newRow.Image = img;

            newDatasource.D.AddDRow(newRow);

            return newDatasource;

        }


    }
}
