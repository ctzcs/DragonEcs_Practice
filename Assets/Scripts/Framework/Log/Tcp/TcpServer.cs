using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework
{
    public class TcpServer : AbstractTcpSocket
    {
        private bool _isClose;
        //服务器连接客户端的线
        private List<Socket> _clientSockets;
        private CancellationTokenSource _cts;
        public TcpServer()
        {
            _clientSockets = new();
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        }
        
        public void Listen(int port)
        {
            try
            {
                if (_cts.IsCancellationRequested)
                {
                    _cts.Dispose();
                    _cts = new CancellationTokenSource();
                }
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),port);
                socket.Bind(ipEndPoint);
                socket.Listen(1024);
                Task.Run(AcceptClientConnect,_cts.Token);
                Task.Run(ReceiveMsg,_cts.Token);
                Task.Run(HandleInput, _cts.Token);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Bind Wrong: Port is not usable! or {e.Message}");
                throw;
            }
            
        }

        public override void Send(string msg)
        {
        }

        public override void Disconnect()
        {
            for (int i = 0; i < _clientSockets.Count; i++)
            {
                _clientSockets[i].Shutdown(SocketShutdown.Both);
                _clientSockets[i].Close();
            }
            _clientSockets.Clear();
            _cts.Cancel();
        }


        void AcceptClientConnect()
        {
            while (!_cts.IsCancellationRequested)
            {
                Socket clientSocket = socket.Accept();
                _clientSockets.Add(clientSocket);
                clientSocket.Send(GetBytes("Connect Success!"));
            }
        }

        void ReceiveMsg()
        {
            Byte[] bytes = new byte[1024 * 100];
            while (!_cts.IsCancellationRequested)
            {
                for(int i = 0; i < _clientSockets.Count; i++)
                {
                    Socket clientSocket = _clientSockets[i];
                    //这一句是判断该socket是否有可接受的消息
                    if (clientSocket.Available > 0)
                    {
                        int validBytesCount = clientSocket.Receive(bytes);
                        //这时候处理消息，复杂逻辑的时候，不能即时处理其他客户端的消息
                        //丢给专门处理的线程,穿进去客户端和解析的消息（自定义二进制类）
                        Task.Run(() => 
                            HandleMsg(clientSocket, GetString(bytes, 0, validBytesCount)), _cts.Token);
                    }
                    
                }
            }
        }
        void HandleMsg(Socket clientSocket,string msg)
        {
            Console.WriteLine("收到客户端{0}发来的{1}",clientSocket.RemoteEndPoint,msg);
        }


        void HandleInput()
        {
            while (!_cts.IsCancellationRequested)
            {
                string input = Console.ReadLine();
                if (input==null)
                {
                    continue;
                }
                if (input == "quit")
                {
                    
                    break;
                }
                //给所有的客户端的广播规则
                if (input.Substring(0,2)=="s:" )
                {
                    for (int i = 0; i < _clientSockets.Count; i++)
                    {
                        _clientSockets[i].Send(Encoding.UTF8.GetBytes(input.Substring(2)));
                    }    
                }
            }
            
        }
        
    }
}