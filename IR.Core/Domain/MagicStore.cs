using System.Collections.Generic;

namespace IR.Core.Domain
{
    public sealed class MagicStore
    {
        public Portfolio Portfolio { get; set; }
        public IList<Stock> Stocks { get; set; }
        public Operations Operations { get; set; }
    }
}
