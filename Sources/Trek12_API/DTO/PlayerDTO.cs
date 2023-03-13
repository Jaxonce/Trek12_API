namespace Trek12_API.DTO
{
    public class PlayerDTO
    {
        public string Pseudo { get; set; }
        public StatsDTO Stats { get; set; } = new StatsDTO();

    }
}
