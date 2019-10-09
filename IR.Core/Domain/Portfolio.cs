using IR.Core.Common;

namespace IR.Core.Domain
{
    public sealed class Portfolio: Payload
    {
        public PortfolioPosition[] Positions { get; set; }
    }

    public sealed class PortfolioPosition: Payload
    {
        public string Figi { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string InstrumentType { get; set; } // TODO: enum
        public double Balance { get; set; }
        public double Blocked { get; set; }
        public ExpectedYield ExpectedYield { get; set; }
        public uint Lots { get; set; }
    }

    public sealed class ExpectedYield : Payload
    {
    }
}