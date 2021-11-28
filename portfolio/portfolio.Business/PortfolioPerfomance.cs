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

     
    }
}