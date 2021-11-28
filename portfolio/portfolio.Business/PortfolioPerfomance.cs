namespace portfolio.Business
{
    public class PortfolioIndicator
    {
        public PortfolioIndicator()
        {
            IndicatorName = "Indicator default name";
            Value = 0;
        }

        public  string IndicatorName { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"Name {this.IndicatorName} value {this.Value}";
        }
    }
}