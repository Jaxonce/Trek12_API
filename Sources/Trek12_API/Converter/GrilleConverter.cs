using Model;
using System.Runtime.CompilerServices;
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
                MaxZones = grille.MaxZone,
            };
        }

        public static Grille toModel(this GrilleDTO grilleDTO)
        {
            return new Grille(grilleDTO.Cases.toModels())
            {
                Id = grilleDTO.Id,
                NbChaine = grilleDTO.NbChaines,
                NbZone = grilleDTO.NbZones,
                MaxChaine = grilleDTO.MaxChaines,
                MaxZone = grilleDTO.MaxZones
            };
        }

        public static IEnumerable<Grille> toModels(this IEnumerable<GrilleDTO> grilles)
        {
            var grilleModels = new List<Grille>();
            foreach( var grille in grilles)
            {
                grilleModels.Add(grille.toModel());
            }

            return grilleModels;
        }
    }
}
