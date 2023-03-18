using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using DevExpress.XtraEditors.Repository;

namespace ControlManager
{
    [Serializable]
    public class acBandGridViewMask : ISerializable 
    {

        public DevExpress.XtraEditors.Mask.MaskType MaskType = DevExpress.XtraEditors.Mask.MaskType.None;

        public string EditMask = null;


        public acBandGridViewMask(object columnEdit)
        {

            if (columnEdit is RepositoryItemTextEdit)
            {
                RepositoryItemTextEdit item = (RepositoryItemTextEdit)columnEdit;

                MaskType = item.Mask.MaskType;

                EditMask = item.Mask.EditMask;

            }
            else if (columnEdit is RepositoryItemTimeEdit)
            {
                RepositoryItemTimeEdit item = (RepositoryItemTimeEdit)columnEdit;

                MaskType = item.Mask.MaskType;

                EditMask = item.Mask.EditMask;
            }
            else if (columnEdit is RepositoryItemDateEdit)
            {
                RepositoryItemDateEdit item = (RepositoryItemDateEdit)columnEdit;

                MaskType = item.Mask.MaskType;

                EditMask = item.Mask.EditMask;
            }
            else if (columnEdit is RepositoryItemMemoEdit)
            {
                RepositoryItemMemoEdit item = (RepositoryItemMemoEdit)columnEdit;

                MaskType = item.Mask.MaskType;

                EditMask = item.Mask.EditMask;
            }
            else if (columnEdit is RepositoryItemMemoExEdit)
            {
                RepositoryItemMemoExEdit item = (RepositoryItemMemoExEdit)columnEdit;

                MaskType = item.Mask.MaskType;

                EditMask = item.Mask.EditMask;
            }


        }

        public acBandGridViewMask(SerializationInfo info, StreamingContext context)
        {

            try
            {
                MaskType = (DevExpress.XtraEditors.Mask.MaskType)info.GetValue("MaskType", typeof(DevExpress.XtraEditors.Mask.MaskType));
            }

            catch { }

            try
            {
                EditMask = (string)info.GetValue("EditMask", typeof(string));
            }
            catch { }


        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("MaskType", MaskType, typeof(DevExpress.XtraEditors.Mask.MaskType));
            info.AddValue("EditMask", EditMask, typeof(string));
        }

        #endregion




    }
}
