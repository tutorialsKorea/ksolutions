using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ControlManager
{

    [UserRepositoryItem("Register")]
    public class RepositoryItemPartSpecTypeEdit : RepositoryItemButtonEdit
    {


        static RepositoryItemPartSpecTypeEdit()
        {
            Register();
        }

        public RepositoryItemPartSpecTypeEdit()
        {
            base.Buttons.Clear();

            base.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton("DETAIL", DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});


        }

        internal const string EditorName = "acPartSpecTypeEdit";

        public static void Register()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(acPartSpecTypePopupEdit),
                typeof(RepositoryItemPartSpecTypeEdit), typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));

        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }



    }

    public class acPartSpecTypePopupEdit : DevExpress.XtraEditors.ButtonEdit
    {


        private object _SpecType = null;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SpecType
        {
            get { return _SpecType; }
            set { _SpecType = value; }
        }

        private acGridView _GridView = null;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public acGridView GridView
        {
            get { return _GridView; }
            set { _GridView = value; }
        }



        public acPartSpecTypePopupEdit() :
            base()
        {
            
            this.Properties.Buttons.Clear();


            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton("DETAIL", DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});



        }



        static acPartSpecTypePopupEdit()
        {
            RepositoryItemPartSpecTypeEdit.Register();
        }


        public override string EditorTypeName
        {
            get { return RepositoryItemPartSpecTypeEdit.EditorName; }
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemPartSpecTypeEdit Properties
        {
            get
            {

                return base.Properties as RepositoryItemPartSpecTypeEdit;

            }
        }





        protected override void OnCreateControl()
        {

            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

  
            base.OnCreateControl();
        }




        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {


            base.OnClickButton(buttonInfo);

            acPartSpecTypePopupForm frm = new acPartSpecTypePopupForm();


            GridViewInfo info = this._GridView.GetViewInfo() as GridViewInfo;

            //GridCellInfo cellInfo = info.GetGridCellInfo(this._GridView.FocusedRowHandle, this._GridView.FocusedColumn.VisibleIndex);

            //GridCellInfo cellInfo2 = info.GetGridCellInfo(this._GridView.FocusedRowHandle, this._GridView.FocusedColumn.VisibleIndex + 1);

            GridCellInfo cellInfo = info.GetGridCellInfo(this._GridView.FocusedRowHandle, this._GridView.FocusedColumn);

            //GridCellInfo cellInfo2 = info.GetGridCellInfo(this._GridView.FocusedRowHandle, this._GridView.GetDataRow(this._GridView.FocusedRowHandle)[this._GridView.FocusedColumn.VisibleIndex + 1]);
            int nextIndex = this._GridView.FocusedColumn.VisibleIndex +1;
            DevExpress.XtraGrid.Columns.GridColumn col = (DevExpress.XtraGrid.Columns.GridColumn)this._GridView.GetDataRow(this._GridView.FocusedRowHandle)[nextIndex];
            GridCellInfo cellInfo2 = info.GetGridCellInfo(this._GridView.FocusedRowHandle, col);

            frm.ParentControl = this;

            frm.StartPosition = FormStartPosition.Manual;

            Point pt = this._GridView.GridControl.PointToScreen(new Point(cellInfo2.CellValueRect.X, cellInfo.CellValueRect.Y));

            pt.Y  +=  cellInfo.CellValueRect.Height;

            frm.Location = pt;

            frm.Size = new Size(this._GridView.FocusedColumn.VisibleWidth, cellInfo.CellValueRect.Height);
            
            if (frm.ShowDialog() == DialogResult.OK)
            {

                this.EditValue = frm.OutputData;

            }



        }


    }
}
