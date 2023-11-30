using System.ComponentModel.DataAnnotations;

namespace Hotellerie_Mayssa.Models.HotellerieModel
{
   
    public class Hotel
    {
        public int Id { get; set; }

        public string Tel { get; set; } = null!;
        [Required(ErrorMessage = "Ce champs est obligatoire")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Longueur comprise entre 3 et 20")]
        public string Nom { get; set; } = null!;
        // les anotation de validation de données sont avant les crochés 
        // et avant l'attribut spécifié
        //null! : accepte null lors de l'initialisaton 
        // string? accepte les valeurs null


        [Range(1,5,ErrorMessage ="valeur comprise entre 1 et 5")]
        public int Etoiles { get; set; }

        [Required(ErrorMessage ="champ obligatoire")]
        public string Ville { get; set; } = null!;
        //combiner toutes les annotations 
        //Display pour l'affichage
        [Required,Url(ErrorMessage ="Url non valide"),Display(Name ="Site Web")]
        public string SiteWeb { get; set; } = null!;
        // ? : car elle peut etre nullable
        public virtual ICollection<Appreciation> ? Appreciations { get; set;}
    }
}
