using System.Collections.Generic;

namespace IR.Core.Domain
{
    public sealed class MagicStore
    {
        public Portfolio Portfolio { get; set; }
        public MarketInstrumentList MarketInstrumentList { get; set; }
        public Operations Operations { get; set; }
        public IList<Candle> Candles { get; set; }
    }
}
