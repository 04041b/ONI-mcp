using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace MCPServerMod
{
    public static class HttpServer
    {
        private static HttpListener listener;
        private static Thread listenerThread;
        private static bool isRunning = false;

        public static void StartServer()
        {
            if (isRunning) return;

            try
            {
                listener = new HttpListener();
                // Listen on localhost port 8080
                listener.Prefixes.Add("http://127.0.0.1:8080/");
                listener.Start();
                isRunning = true;

                listenerThread = new Thread(ListenLoop);
                listenerThread.Start();
                Console.WriteLine("MCPServerMod: HTTP Server started on http://127.0.0.1:8080/");
            }
            catch (Exception ex)
            {
                Console.WriteLine("MCPServerMod: Failed to start HTTP Server - " + ex.Message);
            }
        }

        public static void StopServer()
        {
            if (!isRunning) return;
            isRunning = false;

            if (listener != null)
            {
                listener.Stop();
                listener.Close();
                listener = null;
            }

            if (listenerThread != null)
            {
                listenerThread.Abort();
                listenerThread = null;
            }
            Console.WriteLine("MCPServerMod: HTTP Server stopped.");
        }

        private static void ListenLoop()
        {
            while (isRunning && listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    ProcessRequest(context);
                }
                catch (HttpListenerException)
                {
                    // This happens when the listener is stopped while waiting for a context.
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("MCPServerMod: Error processing request - " + ex.Message);
                }
            }
        }

        private static void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string responseString = "{\"status\": \"error\", \"message\": \"Unknown request\"}";
            int statusCode = 400;

            if (request.HttpMethod == "POST")
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string body = reader.ReadToEnd();
                    Console.WriteLine($"MCPServerMod: Received Request {request.Url.AbsolutePath}: {body}");

                    try
                    {
                        string result = ActionHandlers.HandleAction(request.Url.AbsolutePath, body);
                        responseString = result;
                        statusCode = 200;
                    }
                    catch (Exception ex)
                    {
                        responseString = $"{{\"status\": \"error\", \"message\": \"{ex.Message}\"}}";
                        statusCode = 500;
                    }
                }
            }
            else
            {
                responseString = "{\"status\": \"error\", \"message\": \"Only POST requests are supported\"}";
            }

            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            response.StatusCode = statusCode;
            response.ContentType = "application/json";

            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
