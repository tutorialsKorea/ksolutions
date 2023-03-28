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
    public class acSplitContainerControlUserConfig : ISerializable
    {

        private double _SplitterRatio = 0;


        /// <summary>
        /// 분할 비율
        /// </summary>
        public double SplitterRatio
        {
            get { return _SplitterRatio; }
        }


        private acSplitContainerControl _UseControl = null;


        public acSplitContainerControlUserConfig(acSplitContainerControl control)
        {
            this._UseControl = control;

            if (this._UseControl.Horizontal == true)
            {
                //가로 분할
                this._SplitterRatio = ((double)this._UseControl.SplitterBounds.X / (double)this._UseControl.Size.Width);

            }
            else
            {
                //세로 분할
                this._SplitterRatio = ((double)this._UseControl.SplitterBounds.Y / (double)this._UseControl.Size.Height);
            }

        }

        public acSplitContainerControlUserConfig(SerializationInfo info, StreamingContext context)
        {

            try
            {

                this._SplitterRatio = (double)info.GetValue("SplitterRatio", typeof(double));
            }
            catch { }



        }

        public Byte[] ToArray()
        {
               
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

            info.AddValue("SplitterRatio", this._SplitterRatio, typeof(double));


        }

        #endregion
    }
}
