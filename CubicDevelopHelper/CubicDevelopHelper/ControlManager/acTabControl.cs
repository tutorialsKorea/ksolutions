using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTab;
using DevExpress.Utils;
using System.Windows.Forms;

namespace ControlManager
{
    public class acTabControl : DevExpress.XtraTab.XtraTabControl
    {
        public acTabControl()
            : base()
        {

        }

        protected override DevExpress.XtraTab.XtraTabPageCollection CreateTabCollection()
        {

            return new acTabPageCollection(this);
        }

        protected override void OnCreateControl()
        {


            base.OnCreateControl();


            foreach (acTabPage tp in this.TabPages)
            {
                if (acInfo.IsRunTime == true)
                {
                    if (tp.UseResourceID == true)
                    {
                        tp.Text = acInfo.Resource.GetString(tp.Text, tp.ResourceID);
                    }



                    if (tp.UseToolTipID == true)
                    {
                        if (!string.IsNullOrEmpty(tp.ToolTipID))
                        {
                            if (acInfo.ToolTip.IsToolTip(tp.ToolTipID))
                            {
                                SuperToolTip stt = acInfo.ToolTip.GetToolTip(tp.ToolTipID);

                                foreach (BaseToolTipItem tt in stt.Items)
                                {
                                    if (tt is ToolTipItem)
                                    {

                                        tp.Tooltip = (tt as ToolTipItem).Text;

                                        tp.Image = Resource.sign_question_x16;

                                        break;
                                    }

                                }


                            }
                        }


                    }


                }
            }



        }




        /// <summary>
        /// 선택된 컨테이너 이름을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public string GetSelectedContainerName()
        {
            acTabPage page = this.SelectedTabPage as acTabPage;

            if (page != null)
            {
                return page.ContainerName;
            }
            else
            {
                return null;
            }

        }

        public XtraTabPage GetContainerName(string contailnerName)
        {

            foreach (XtraTabPage p in this.TabPages)
            {
                acTabPage page = p as acTabPage;

                if (page.ContainerName == contailnerName)
                {
                    return page as XtraTabPage;
                }

            }

            return null;

        }

        public void SetSelectedContainerName(string contailnerName)
        {

            foreach (XtraTabPage p in this.TabPages)
            {
                acTabPage page = p as acTabPage;

                if (page.ContainerName == contailnerName)
                {
                    this.SelectedTabPage = page as XtraTabPage;

                    return;
                }

            }

        }
        /// <summary>
        /// 선택 탭페이지 변경이벤트를 발생시킨다.
        /// </summary>
        public void RaiseSelectedPageChangedEvent()
        {
            base.OnSelectedPageChanged(this, new DevExpress.XtraTab.ViewInfo.ViewInfoTabPageChangedEventArgs(null, this.SelectedTabPage));
        }

        /// <summary>
        /// 선택 탭페이지 변경이벤트를 발생시킨다.
        /// </summary>
        public void RaiseSelectedPageChangingEvent()
        {

            base.OnSelectedPageChanging(this, new DevExpress.XtraTab.ViewInfo.ViewInfoTabPageChangingEventArgs(null, this.SelectedTabPage));
        }

    }


    public class acTabPageCollection : DevExpress.XtraTab.XtraTabPageCollection
    {

        public acTabPageCollection(acTabControl tabControl)
            : base(tabControl)
        {

        }

        protected override DevExpress.XtraTab.XtraTabPage CreatePage()
        {
            return new acTabPage();
        }




    }

    public class acTabPage : DevExpress.XtraTab.XtraTabPage, IBaseViewControl, IBaseContainer
    {
        public acTabPage()
            : base()
        {

        }


        public BaseMenu GetBaseMenu()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is BaseMenu)
                {
                    BaseMenu menu = ctrl as BaseMenu;

                    return menu;

                }

            }

            return null;
        }

        #region IBaseViewControl 멤버

        private string _ResourceID = null;

        public string ResourceID
        {
            get
            {
                return _ResourceID;
            }
            set
            {
                _ResourceID = value;
            }
        }

        private bool _UseResourceID = false;

        public bool UseResourceID
        {
            get
            {
                return _UseResourceID;
            }
            set
            {
                _UseResourceID = value;
            }
        }

        private string _ToolTipID = null;

        public string ToolTipID
        {
            get
            {
                return _ToolTipID;
            }
            set
            {
                _ToolTipID = value;
            }
        }

        private bool _UseToolTipID = false;

        public bool UseToolTipID
        {
            get
            {
                return _UseToolTipID;
            }
            set
            {
                _UseToolTipID = value;
            }
        }


        #endregion



        #region IBaseContainer 멤버

        private string _ContainerName = null;

        public string ContainerName
        {
            get
            {
                return _ContainerName;
            }
            set
            {
                _ContainerName = value;
            }
        }

        #endregion


    }

}
