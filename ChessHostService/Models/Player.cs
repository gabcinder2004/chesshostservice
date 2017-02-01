using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ChessHostService.Models
{
    public class Player
    {
        public string Name { get; set; }

        public string ServiceUrl { get; set; }

        public ChessMove NextMove(ChessBoard board, Color turn)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(ServiceUrl) };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var payload = new Payload() { Board = board, Turn = turn };
            var serializedBoard = JsonConvert.SerializeObject(payload);
            var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(serializedBoard));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var stopwatch = Stopwatch.StartNew();

            HttpResponseMessage response;
            try
            {
                // List data response.
                response = client.PostAsync("/api/nextMove", byteContent).Result; // Blocking call!
            }
            catch (Exception e)
            {
                return null;
            }

            stopwatch.Stop();

            if (response.IsSuccessStatusCode)
            {
                var move = response.Content.ReadAsAsync<IEnumerable<ChessMove>>().Result.FirstOrDefault();
                if (move == null)
                {
                    return null;
                }

                move.Elapsed = stopwatch.Elapsed;
                return move;
            }

            return null;
        }
    }
}