using System;

namespace A2_final.Models
{
    public class FoodDetailedData
    {
        public string food_name { get; set; }
        public string brand_name { get; set; }
        public double serving_qty { get; set; }
        public string serving_unit { get; set; }
        public double? serving_weight_grams { get; set; }
        public double? nf_calories { get; set; }
        public double? nf_total_fat { get; set; }
        public double? nf_saturated_fat { get; set; }
        public double? nf_cholesterol { get; set; }
        public double? nf_sodium { get; set; }
        public double? nf_total_carbohydrate { get; set; }
        public double? nf_dietary_fiber { get; set; }
        public double? nf_sugars { get; set; }
        public double? nf_protein { get; set; }
        public FoodImage photo { get; set; }
    }
}
