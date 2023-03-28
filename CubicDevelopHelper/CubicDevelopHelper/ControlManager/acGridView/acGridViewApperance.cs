using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using DevExpress.XtraGrid;

namespace ControlManager
{
    [Serializable]
    public class acGridViewApperance : ISerializable
    {

        public Color BackColor = Color.Empty;

        public Color BackColor2 = Color.Empty;

        public Color ForeColor = Color.Empty;

        public Font Font = DevExpress.Utils.AppearanceObject.DefaultFont;

        public System.Drawing.Drawing2D.LinearGradientMode GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;

        public acGridViewApperance()
        {
            
        }

        public void Reset()
        {
            BackColor = Color.Empty;
            BackColor2 = Color.Empty;
            ForeColor = Color.Empty;
            Font = new Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);


            GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        }

        public acGridViewApperance(SerializationInfo info, StreamingContext context)
        {
            try
            {
                BackColor = (Color)info.GetValue("BackColor", typeof(Color));
            }
            catch { }

            try
            {

                BackColor2 = (Color)info.GetValue("BackColor2", typeof(Color));
            }
            catch { }

            try
            {
                ForeColor = (Color)info.GetValue("ForeColor", typeof(Color));
            }
            catch { }

            try
            {
                Font = (Font)info.GetValue("Font", typeof(Font));
            }
            catch { }

            try
            {
                GradientMode = (System.Drawing.Drawing2D.LinearGradientMode)info.GetValue("GradientMode", typeof(System.Drawing.Drawing2D.LinearGradientMode));
            }
            catch { }
        }


        #region ISerializable 멤버

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BackColor", BackColor , typeof(Color));
            info.AddValue("BackColor2", BackColor2, typeof(Color));
            info.AddValue("ForeColor", ForeColor, typeof(Color));
            info.AddValue("Font", Font, typeof(Font));
            info.AddValue("GradientMode", GradientMode, typeof(System.Drawing.Drawing2D.LinearGradientMode));
        }

        #endregion


    }
}
