namespace SupportClasses
{
    public class Item : BaseItem
    {
        public bool Attunement { get; set; }
        public string Rarity { get; set; }
        public string Subcategory2 { get; set; }
        public string Subcategory { get; set; }

        public Item(string category, string subcategory, string subcategory2, string rarity, string attunement, string name, string costGP)
        {
            Category = category;
            Subcategory = subcategory;
            Subcategory2 = subcategory2;
            Rarity = rarity;
            Attunement = attunement == "Required";
            if (name == "Amulet of the Devout")
            {
                switch (Rarity)
                {
                    case "Uncommon":
                        name += ", +1";
                        break;
                    case "Rare":
                        name += ", +2";
                        break;
                    case "Very Rare":
                        name += ", +3";
                        break;
                }
            }
            Name = name;
            CostGP = SetCostGP(costGP);
        }

        public override string Stringify()
        {
            return $"{Name}: {GetCostGP(out var coin)} {coin}\n\tAttunement: {(Attunement ? "Yes" : "No")}{(Rarity == "" ? "" : $", Rarity: {Rarity}")}\n\tCategory: {Category} {(Subcategory==""?"":$"({Subcategory}{(Subcategory2==""?"":$" ({Subcategory2})")})")}";
        }
    }
}