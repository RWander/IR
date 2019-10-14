namespace IR.Core.Domain
{
    public sealed class CandleInterval
    {
        public static CandleInterval Minute() => new CandleInterval("1min");
        public static CandleInterval TwoMinutes() => new CandleInterval("2min");
        public static CandleInterval ThreeMinutes() => new CandleInterval("3min");
        public static CandleInterval FiveMinutes() => new CandleInterval("5min");
        public static CandleInterval TenMinutes() => new CandleInterval("10min");
        public static CandleInterval QuarterHour() => new CandleInterval("15min");
        public static CandleInterval HalfHour() => new CandleInterval("30min");
        public static CandleInterval Hour() => new CandleInterval("hour");
        public static CandleInterval TwoHours() => new CandleInterval("2hour");
        public static CandleInterval FourHours() => new CandleInterval("4hour");
        public static CandleInterval Day() => new CandleInterval("day");
        public static CandleInterval Week() => new CandleInterval("week");
        public static CandleInterval Month() => new CandleInterval("month");

        public string Value { get; }

        private CandleInterval(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}