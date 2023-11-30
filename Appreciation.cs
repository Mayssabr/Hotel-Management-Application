
using System.ComponentModel.DataAnnotations;

namespace Hotellerie_Mayssa.Models.HotellerieModel
{
    public class Appreciation
    {
        public int Id { get; set; }
        [Required,Display(Name ="Nom Personne")]
        public string NomPres { get; set; }= null!;
        [Required,DataType(DataType.MultilineText)]
        public string Commentaire { get; set; } = null!;
        public int HotelId { get; set; }
        [Required(ErrorMessage ="ce champ est obligatoire"),Range(1,5)]
        public int Note  { get; set; }
        public virtual Hotel ? Hotel { get; set; }
    }
}
