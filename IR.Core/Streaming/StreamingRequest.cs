using IR.Core.Domain;

namespace IR.Core.Streaming
{
    /// <summary>
    /// Copied (and modified) from https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk/blob/master/src/Tinkoff.Trading.OpenApi/Models/StreamingRequest.cs
    /// </summary>
    public abstract class StreamingRequest
    {
        public string Event { get; }

        protected StreamingRequest(bool subscribe, string payloadName)
        {
            Event = $"{payloadName}:{(subscribe ? "subscribe" : "unsubscribe")}";
        }

        public static CandleRequest SubscribeCandle(string figi, CandleInterval interval)
            => CandleRequest.Subscribe(figi, interval);
        public static CandleRequest UnsubscribeCandle(string figi, CandleInterval interval)
            => CandleRequest.Unsubscribe(figi, interval);

        //public static OrderbookSubscribeRequest SubscribeOrderbook(string figi, int depth)
        //{
        //    return new OrderbookSubscribeRequest(figi, depth);
        //}

        //public static OrderbookUnsubscribeRequest UnsubscribeOrderbook(string figi, int depth)
        //{
        //    return new OrderbookUnsubscribeRequest(figi, depth);
        //}

        //public static InstrumentInfoSubscribeRequest SubscribeInstrumentInfo(string figi)
        //{
        //    return new InstrumentInfoSubscribeRequest(figi);
        //}

        //public static InstrumentInfoUnsubscribeRequest UnsubscribeInstrumentInfo(string figi)
        //{
        //    return new InstrumentInfoUnsubscribeRequest(figi);
        //}

        public class CandleRequest : StreamingRequest
        {
            public string Figi { get; }

            public CandleInterval Interval { get; }

            private CandleRequest(bool subscribe, string figi, CandleInterval interval)
                : base(subscribe, "candle")
            {
                Figi = figi;
                Interval = interval;
            }

            internal static CandleRequest Subscribe(string figi, CandleInterval interval)
            {
                return new CandleRequest(true, figi, interval);
            }

            internal static CandleRequest Unsubscribe(string figi, CandleInterval interval)
            {
                return new CandleRequest(false, figi, interval);
            }
        }

        //public class OrderbookSubscribeRequest : StreamingRequest
        //{
        //    public override string Event => "orderbook:subscribe";

        //    [JsonProperty(PropertyName = "figi")] public string Figi { get; }

        //    [JsonProperty(PropertyName = "depth")] public int Depth { get; }

        //    public OrderbookSubscribeRequest(string figi, int depth)
        //    {
        //        Figi = figi;
        //        Depth = depth;
        //    }
        //}

        //public class OrderbookUnsubscribeRequest : StreamingRequest
        //{
        //    public override string Event => "orderbook:unsubscribe";

        //    [JsonProperty(PropertyName = "figi")] public string Figi { get; }

        //    [JsonProperty(PropertyName = "depth")] public int Depth { get; }

        //    public OrderbookUnsubscribeRequest(string figi, int depth)
        //    {
        //        Figi = figi;
        //        Depth = depth;
        //    }
        //}

        //public class InstrumentInfoSubscribeRequest : StreamingRequest
        //{
        //    public override string Event => "instrument_info:subscribe";

        //    [JsonProperty(PropertyName = "figi")] public string Figi { get; }

        //    public InstrumentInfoSubscribeRequest(string figi)
        //    {
        //        Figi = figi;
        //    }
        //}

        //public class InstrumentInfoUnsubscribeRequest : StreamingRequest
        //{
        //    public override string Event => "instrument_info:unsubscribe";

        //    [JsonProperty(PropertyName = "figi")] public string Figi { get; }

        //    public InstrumentInfoUnsubscribeRequest(string figi)
        //    {
        //        Figi = figi;
        //    }
        //}
    }
}
