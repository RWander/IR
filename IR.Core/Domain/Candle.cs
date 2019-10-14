using System;

using IR.Core.Common;

namespace IR.Core.Domain
{

    /// <summary>
    /// Copied (and modified) from https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk/blob/master/src/Tinkoff.Trading.OpenApi/Models/CandlePayload.cs
    /// </summary>
    public class Candle: Payload
    {
        public decimal Open { get; }
        public decimal Close { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Volume { get; }
        public DateTime Time { get; }
        public CandleInterval Interval { get; } // TODO use enum instead of static class CandleInterval
        public string Figi { get; }

        //[JsonConstructor]
        //public CandlePayload(
        //    [JsonProperty("o")] decimal open,
        //    [JsonProperty("c")] decimal close,
        //    [JsonProperty("h")] decimal high,
        //    [JsonProperty("l")] decimal low,
        //    [JsonProperty("v")] decimal volume,
        //    DateTime time,
        //    CandleInterval interval,
        //    string figi)
        //{
        //    Open = open;
        //    Close = close;
        //    High = high;
        //    Low = low;
        //    Volume = volume;
        //    Time = time;
        //    Interval = interval;
        //    Figi = figi;
        //}
    }
}