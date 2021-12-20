namespace SupportClasses
{
    public class BaseItem
    {
        public decimal CostGP { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public BaseItem()
        {

        }
        protected decimal SetCostGP(string costGP)
        {
            if (costGP.Contains(",")) costGP = costGP.Replace(",", "").Replace("\"", "");
            else if (costGP == "") costGP = "0";
            return decimal.Parse(costGP);
        }

        protected decimal GetCostGP(out string coin)
        {
            var cost = CostGP;
            coin = "GP";
            if (CostGP < 1.0m)
            {
                cost = CostGP * 10;
                coin = "SP";
            }

            if (cost < 1.0m)
            {
                cost *= 10;
                coin = "CP";
            }

            return cost;
        }

        public virtual string Stringify()
        {
            var cost = GetCostGP(out var coin);

            return $"{Name}: {cost} {coin}\n\t{Category}";
        }
    }
}