using System.Net;

namespace Framework
{
    public class TcpAppender
    {
        private IPEndPoint _ipEndPoint;
        public TcpAppender(IPAddress ip, int port)
        {
            _ipEndPoint = new IPEndPoint(ip, port);
            
        }
    }
}