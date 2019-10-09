using IR.Core.Common;

namespace IR.Core.Domain
{
    public sealed class MarketInstrumentList: Payload
    {
        public ushort Total { get; set; }
        public MarketInstrument[] Instruments { get; set; }
    }

    public sealed class MarketInstrument: Payload
    {
        public string Figi { get; set; }

        public string Ticker { get; set; }

        public string Isin { get; set; }

        public double MinPriceIncrement { get; set; }

        public uint Lot { get; set; }

        public /*ECurrency*/ string Currency { get; set; } // TODO: enum
    }
}