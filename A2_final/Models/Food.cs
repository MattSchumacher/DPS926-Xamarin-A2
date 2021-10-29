using SQLite;
using SQLiteNetExtensions.Attributes;
namespace A2_final.Models
{
    public class Food
    {
        public string food_name { get; set; }
        public string serving_unit { get; set; }
        public string nix_brand_id { get; set; }
        public double serving_qty { get; set; }
        public double nf_calories { get; set; }
        [OneToOne]
        public FoodImage photo { get; set; }
        public string brand_name { get; set; }
        public int region { get; set; }
        public int brand_type { get; set; }
        [PrimaryKey]
        public string nix_item_id { get; set; }
        public string locale { get; set; }
    }
}
