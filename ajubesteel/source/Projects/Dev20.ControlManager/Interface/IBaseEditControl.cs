using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ControlManager
{
    public interface IBaseEditControl
    {

        DevExpress.XtraEditors.BaseEdit Editor { get;}


        bool isChanged { set; get; }

         
        /// <summary>
        /// 필수여부
        /// </summary>
        bool isRequired { set;get;}

        /// <summary>
        /// 값
        /// </summary>
        
        object Value { set;get;}


        /// <summary>
        /// 읽기전용여부
        /// </summary>
        bool isReadyOnly { set;get;}


        /// <summary>
        /// 컬럼이름
        /// </summary>
        string ColumnName { set;get;}


        /// <summary>
        /// 툴팁 ID
        /// </summary>
        string ToolTipID { get;set;}


        /// <summary>
        /// 툴팁 ID 사용여부
        /// </summary>
        bool UseToolTipID { get;set;}


        void FocusEdit();

        void Clear();



    }
}
