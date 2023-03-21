using Model;

namespace Trek12_API.DTO
{
    public class GrilleDTO
    {
        public int Id { get; set; }
        public int NbChaines { get; set; }
        public int NbZones { get; set; }
        public int MaxChaines { get; set; }
        public int MaxZones { get; set; }
        public List<CaseDTO> Cases { get; set; }

    }
}
