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
    public class acFormUserConfig : ISerializable
    {


        private Size _FormSize = new Size(0, 0);

        public Size FormSize
        {
            get { return _FormSize; }
        }

        private Point _FormLocation = new Point(0, 0);


        public Point FormLocation
        {
            get { return _FormLocation; }
        }




        public acFormUserConfig(acForm frm)
        {

            this._FormSize = frm.Size;
            this._FormLocation = frm.Location;
        }

        public acFormUserConfig(SerializationInfo info, StreamingContext context)
        {

            try
            {
                this._FormSize = (Size)info.GetValue("FormSize", typeof(Size));
            }
            catch { }

            try
            {
                this._FormLocation = (Point)info.GetValue("FormLocation", typeof(Point));
            }
            catch { }

        }

        public Byte[] ToArray()
        {

            MemoryStream configStream = new MemoryStream();

            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Binder = new acFormUserConfigSerializationBinder();


            bformatter.Serialize(configStream,this);


            byte[] result = configStream.ToArray();

            configStream.Close();

            return result;

        }



        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("FormSize", this._FormSize, typeof(Size));
            info.AddValue("FormLocation", this._FormLocation, typeof(Point));

        }

        #endregion
    }
}
