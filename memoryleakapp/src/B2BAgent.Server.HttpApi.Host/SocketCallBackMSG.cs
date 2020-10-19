using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Dayu.Extend;

namespace B2BAgent.Server
{
    public static class SocketCallBackMSG
    {
        static ConcurrentDictionary<string,string> Data = new ConcurrentDictionary<string, string>();

        public static void Add(string reqId, string msg)
        {
            Data.TryAdd(reqId, msg);
        }

        public static string GetMsg(string reqId)
        {
            Data.TryRemove(reqId,out string x);
            return x;
        }

    }
}
