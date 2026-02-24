using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
namespace IndyBooks.ViewModels
{
    public class SearchVM
    {
        [Display(Name = "Title to Find: ")]
        public String Title { get; set; } = "";

        [Display(Name = "Half-Price Sale: ")]
        public Boolean HalfPriceSale { get; set; }
        //TODO: Add properties with Display annotation needed for searching
        [Display(Name = "Author's Last Name: ")]
        public String AuthorsLastName { get; set; } = "";
        [Display(Name = "Minimum Price: ")]
        public Decimal? MinimumPrice { get; set; }
        [Display(Name = "Maximum Price: ")]
        public Decimal? MaximumPrice { get; set; }

    }
}
