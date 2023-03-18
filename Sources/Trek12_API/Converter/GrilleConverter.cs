using Model;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class GrilleConverter
    {
        public static GrilleDTO toDTO(this Grille grille)
        {
            return new GrilleDTO()
            {
                Id = grille.Id,
                NbChaines = grille.NbChaine,
                NbZones = grille.NbZone,
                MaxChaines = grille.MaxChaine,
                MaxZones = grille.MaxZone
            };
        }
    }
}
