using Newtonsoft.Json;

namespace BeerUIApp.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        [JsonProperty("first_brewed")]
        public string FirstBrewed { get; set; }
        public string Description { get; set; }
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
        [JsonProperty("abv")]
        public string ABV { get; set; }
        [JsonProperty("ibu")]
        public string IBU { get; set; }
        [JsonProperty("target_fg")]
        public string TargetFG { get; set; }
        [JsonProperty("target_og")]
        public string targetOG { get; set; }
        [JsonProperty("ebc")]
        public string EBC { get; set; }
        [JsonProperty("srm")]
        public string SRM { get; set; }
        [JsonProperty("ph")]
        public string PH { get; set; }
        [JsonProperty("attenuation_level")]
        public string AttenuationLevel { get; set; }
        public Volume Volume { get; set; }
        [JsonProperty("boil_volume")]
        public BoilVolume BoilVolume { get; set; }
        public Method Method { get; set; }
        public Ingredients Ingredients { get; set; }
        [JsonProperty("food_pairing")]
        public List<string> FoodPairing { get; set; }
        [JsonProperty("brewers_tips")]
        public string BrewersTips { get; set; }
        [JsonProperty("contributed_by")]
        public string ContributedBy { get; set; }
        public int PageNumer = 1;
    }
}
