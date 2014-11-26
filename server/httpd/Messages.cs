using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib_HTTPd
{
    public static class Messages
    {
        public static void log(String msg)
        {
            NXTRemoteSC.Manager.Log(msg);
        }

        public static void con(String msg)
        {
            NXTRemoteSC.Manager.Log(msg);
        }
    }
}
