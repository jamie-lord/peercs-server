using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace peercs_server
{
    public class Program
    {
        private static WebSocketServer _wss;

        public static void Main(string[] args)
        {
            InitializeWSS(null);
            Console.ReadLine();
            if (_wss != null)
            {
                _wss.Stop();
            }
        }

        public class PeerCSWebSocketBehavior : WebSocketBehavior
        {
            protected override void OnOpen()
            {
                var query = Context.RequestUri;
                var id = ID;
            }

            protected override void OnError(ErrorEventArgs e)
            {
                base.OnError(e);
            }
        }

        private static void InitializeWSS(object server)
        {
            _wss = new WebSocketServer("ws://localhost:12345");
            _wss.AddWebSocketService<PeerCSWebSocketBehavior>("/peerjs");
            _wss.Start();
            Console.WriteLine(_wss.Address);
            Console.WriteLine(_wss.Port);
        }

        private void ConfigureWS(object socket, object key, object id, object token)
        {

        }

        private void CheckAllowsDiscovery(object key, object cb)
        {

        }

        private void CheckKey(object key, object ip, object cb)
        {

        }

        private void InitializeHTTP()
        {

        }

        private void StartStreaming(object res, object key, object id, object token, object open)
        {

        }

        private void PruneOutstanding()
        {

        }

        private void SetCleanupIntervals()
        {

        }

        private void ProcessOutstanding()
        {

        }

        private void RemovePeer(object key, object id)
        {

        }

        private void HandleTransmission(object key, object message)
        {

        }

        private void GenerateClientId(object key)
        {

        }

        private void Log()
        {

        }
    }
}
