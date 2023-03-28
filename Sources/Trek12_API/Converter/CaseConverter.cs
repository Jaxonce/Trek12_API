using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model;
using System.Runtime.CompilerServices;
using Trek12_API.DTO;

namespace Trek12_API.Converter
{
    public static class CaseConverter
    {
        public static CaseDTO toDTO(this Case caseToConvert)
        {
            CaseDTO dto = new CaseDTO();
            dto.Id = caseToConvert.Id;
            dto.Value = caseToConvert.Valeur;
            return dto;
        }

        public static List<CaseDTO> toDTOs(this List<Case> listParam)
        {
            List<CaseDTO> list = new List<CaseDTO>();
            foreach(var caseToConvert in listParam)
            {
                list.Add(caseToConvert.toDTO());
            }

            return list;
        }

        public static List<Case> toModels(this List<CaseDTO> listParam)
        {
            List<Case> list = new List<Case>();
            foreach (var caseToConvert in listParam)
            {
                list.Add(caseToConvert.toModel());
            }

            return list;
        }

        public static Case toModel(this CaseDTO caseToConvert)
        {
            Case model = new Case();
            model.Id = caseToConvert.Id;
            model.Valeur = caseToConvert.Value;
            return model;
        }
    }
}
