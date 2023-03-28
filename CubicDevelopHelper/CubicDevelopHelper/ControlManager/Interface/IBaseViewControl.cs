using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ControlManager
{
    public interface IBaseViewControl
    {

        /// <summary>
        /// 리소스 ID
        /// </summary>
        string ResourceID { get;set;}


        /// <summary>
        /// 리소스 ID 사용여부
        /// </summary>
        bool UseResourceID { get;set;}


        /// <summary>
        /// 툴팁 ID
        /// </summary>
        string ToolTipID { get;set;}


        /// <summary>
        /// 툴팁 ID 사용여부
        /// </summary>
        bool UseToolTipID { get;set;}

    }
}
