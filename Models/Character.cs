namespace ad_dotnet_core_7_2023.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public string? Description { get; set; }
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}