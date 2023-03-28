using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Drawing;

namespace ControlManager
{
    [Serializable]
    public class acUserPopupContainerEditUserConfig : ISerializable
    {


        private Size _PopupControlSize = Size.Empty;

        public Size PopupControlSize
        {
            get { return _PopupControlSize; }
        }


        private acUserPopupContainerEdit _UserControl = null;


        public acUserPopupContainerEditUserConfig(acUserPopupContainerEdit ctrl)
        {
            this._UserControl = ctrl;

        }

        public acUserPopupContainerEditUserConfig(SerializationInfo info, StreamingContext context)
        {

            try
            {
                this._PopupControlSize = (Size)info.GetValue("PopupControlSize", typeof(Size));
            }
            catch { }

        }

        public Byte[] ToArray()
        {
            this._PopupControlSize = this._UserControl.Properties.PopupControl.Size;


            MemoryStream configStream = new MemoryStream();

            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(configStream, this);

            byte[] result = configStream.ToArray();

            configStream.Close();

            return result;

        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("PopupControlSize", this._PopupControlSize, typeof(Size));


        }

        #endregion
    }
}
