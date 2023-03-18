using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using DevExpress.XtraEditors.Drawing;
using System.Drawing.Design;
using System.Reflection;
using DevExpress.Utils;

namespace ControlManager
{
    [UserRepositoryItem("Register")]
    public class acRepositoryItemRadioGroup : RepositoryItemRadioGroup
    {

        public acRepositoryItemRadioGroup() : base() { }

        static acRepositoryItemRadioGroup() { Register(); }

        public const string CustomEditName = "acRadioGroup";

        public override string EditorTypeName { get { return CustomEditName; } }

        //Register the editor
        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(acRadioGroup), typeof(acRepositoryItemRadioGroup),
              typeof(RadioGroupViewInfo), new RadioGroupPainter(), true, (Image)null));
        }


        protected override RadioGroupItemCollection CreateItemCollection()
        {
            return new acRadioGroupItemCollection();
        }

        [Category("Data"), Localizable(true), Editor("System.Windows.Forms.Design.CollectionEditor, System.Design", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new acRadioGroupItemCollection Items
        {
            get
            {
                return (acRadioGroupItemCollection)base.Items;
            }
        }

    }

    public class acRadioGroupItemCollection : RadioGroupItemCollection
    {
        public acRadioGroupItemCollection() : base() { }

        public new acRadioGroupItem this[int index]
        {
            get
            {
                return (base.List[index] as acRadioGroupItem);
            }
            set
            {
                base.List[index] = value;
            }
        }
    }

    public class acRadioGroup : RadioGroup, IBaseEditControl
    {

        static acRadioGroup() { acRepositoryItemRadioGroup.Register(); }

        public acRadioGroup()
        {

        }

        public override string EditorTypeName { get { return acRepositoryItemRadioGroup.CustomEditName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new acRepositoryItemRadioGroup Properties
        {
            get { return base.Properties as acRepositoryItemRadioGroup; }
        }


        public void AddRadioItem(string name, bool useResourceID, string resourceID, bool useToolTipID, string toolTipID, object value)
        {
            acRadioGroupItem item = new acRadioGroupItem(value, name, useResourceID, resourceID, useToolTipID, toolTipID);

            if (item.UseResourceID == true)
            {
                item.Description = acInfo.Resource.GetString(name, resourceID);

            }

            this.Properties.Items.Add(item);

        }

        public acRadioGroupItem GetRadioGroupItem(object value)
        {
            foreach (acRadioGroupItem item in this.Properties.Items)
            {
                if (item.Value.Equals(value))
                {
                    return item;
                }


            }

            return null;
        }

        public bool ContainsRadioGroupItem(object value)
        {
            foreach (acRadioGroupItem item in this.Properties.Items)
            {
                if (item.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;

        }


        #region IBaseControl 멤버

        public BaseEdit Editor
        {
            get
            {
                return this;
            }

        }




        private bool _isRequired = false;

        /// <summary>
        /// 필수입력 여부
        /// </summary>
        public bool isRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                _isRequired = value;

            }
        }


        private bool _isReadyOnly = false;

        /// <summary>
        /// 읽기전용 여부
        /// </summary>
        public bool isReadyOnly
        {
            get
            {
                return _isReadyOnly;
            }
            set
            {
                _isReadyOnly = value;

                if (_isReadyOnly == true)
                {
                    this.Properties.ReadOnly = true;
                }
                else
                {
                    this.Properties.ReadOnly = false;

                }

            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Value
        {
            get
            {
                return this.EditValue;
            }
            set
            {
                if (this.Enabled == false)
                    return;

                this.EditValue = value;
            }
        }


        private string _ColumnName = null;

        /// <summary>
        /// 컬럼명
        /// </summary>
        public string ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                _ColumnName = value;
            }
        }

        public void Clear()
        {
            this.EditValue = null;
        }


        public void FocusEdit()
        {
            this.Focus();
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



        private bool _isChanged = false;


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool isChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }


        #endregion
    }

    [TypeConverter(typeof(acRadioGroupItemTypeConverter))]
    public class acRadioGroupItem : RadioGroupItem, IBaseViewControl
    {

        public enum emGroupItemType { STANDARD, CODE };

        private emGroupItemType _GroupItemType = emGroupItemType.STANDARD;

        public emGroupItemType GroupItemType
        {
            get { return _GroupItemType; }
        }


        public acRadioGroupItem() : base() { }

        public acRadioGroupItem(
    object value,
    string description,
    string comment
    )
            : base(value, description)
        {
            this.Comment = comment;
            this._GroupItemType = emGroupItemType.CODE;
        }
        
        public acRadioGroupItem(
            object value,
            string description,
            bool useResourceID,
            string resourceID,
            bool useToolTip,
            string toolTipID
            )
            : base(value, description)
        {
            this.UseResourceID = useResourceID;
            this.ResourceID = resourceID;

            this.UseToolTipID = useToolTip;
            this.ToolTipID = toolTipID;

            this._GroupItemType = emGroupItemType.STANDARD;
        }

        public override object Clone()
        {
            return new acRadioGroupItem(this.Value, this.Description, this.UseResourceID, this.ResourceID, this.UseToolTipID, this.ToolTipID);
        }


        private string _Comment = null;

        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value;
            }
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
    }

    public class acRadioGroupItemTypeConverter : DevExpress.XtraEditors.Design.RadioGroupItemTypeConverter
    {
        public acRadioGroupItemTypeConverter() : base() { }

        protected override InstanceDescriptor GetInstanceDescriptor(object value)
        {
            acRadioGroupItem item = (acRadioGroupItem)value;
            ConstructorInfo ctor = null;
            object[] parameters = null;


            ctor = typeof(acRadioGroupItem).GetConstructor(new Type[] { typeof(object), typeof(string), typeof(bool), typeof(string), typeof(bool), typeof(string) });

            parameters = new object[] { item.Value, item.Description, item.UseResourceID, item.ResourceID, item.UseToolTipID, item.ToolTipID };



            return new InstanceDescriptor(ctor, parameters);
        }
    }





}
