using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace Framework
{
    public abstract class AbstractTcpSocket
    {
        protected Socket socket;
        public abstract void Send(string msg);

        /// <summary>
        ///     断开连接
        /// </summary>
        public abstract void Disconnect();
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static Byte[] GetBytes(string msg)
        {
            return Encoding.UTF8.GetBytes(msg);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static string GetString(Byte[] bytes,int index,int count)
        {
            return Encoding.UTF8.GetString(bytes, index, count);
        }
    }
}