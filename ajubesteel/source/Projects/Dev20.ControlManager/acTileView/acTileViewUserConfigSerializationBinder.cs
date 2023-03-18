using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.Windows.Forms;

namespace ControlManager
{
    sealed class acTileViewUserConfigSerializationBinder : SerializationBinder
    {

        public override Type BindToType(string assemblyName, string typeName)
        {
            
            Type returntype = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;

            returntype =
                Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));

            
            return returntype;

        }
    }
}
