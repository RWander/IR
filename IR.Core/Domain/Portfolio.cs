using System.Collections.Generic;

namespace IR.Core.Domain
{
    public sealed class Portfolio
    {
        public IList<PortfolioPosition> Positions;

        public Portfolio()
        {
            Positions = new List<PortfolioPosition>();
        }
    }

    // TODO: incomplete
    public sealed class PortfolioPosition
    {
        public string Figi { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string InstrumentType { get; set; } // TODO: enum
        public double Balance { get; set; }
        public double Blocked { get; set; }
    }
}