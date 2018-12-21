using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
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
                Uri uri = Context.RequestUri;
                string queryString = uri.Query;
                NameValueCollection queryDictionary = HttpUtility.ParseQueryString(queryString);
                string id = queryDictionary["id"];
                string token = queryDictionary["token"];
                string key = queryDictionary["token"];
                IPAddress ip = Context.UserEndPoint.Address;

                if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(key))
                {
                    Context.WebSocket.SendAsync(JsonConvert.SerializeObject(new PeerCSResponse(PeerCSResponse.ResponseType.Error, "No id, token, or key supplied to websocket server")), (complete) =>
                    {
                        if (complete)
                        {
                            Context.WebSocket.CloseAsync();
                        }
                    });
                    return;
                }


            }

            protected override void OnError(ErrorEventArgs e)
            {
                base.OnError(e);
            }
        }

        public class Payload
        {
            [JsonProperty("msg")]
            public string Message { get; set; }
        }

        public class PeerCSResponse
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("payload")]
            public Payload Payload { get; set; }

            public PeerCSResponse(ResponseType type, string msg)
            {
                Type = ResponseTypeToString(type);
                Payload = new Payload
                {
                    Message = msg
                };
            }

            public enum ResponseType
            {
                Error,
                Open
            }

            private string ResponseTypeToString(ResponseType responseType)
            {
                switch (responseType)
                {
                    case ResponseType.Open:
                        return "OPEN";
                    case ResponseType.Error:
                    default:
                        return "ERROR";
                }
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
