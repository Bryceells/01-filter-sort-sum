using System;
using System.ComponentModel.DataAnnotations;
namespace IndyBooks.ViewModels
{
    public class SearchVM
    {
        [Display(Name = "Title to Find: ")]
        public String Title { get; set; } = "";

        [Display(Name = "Half-Price Sale: ")]
        public Boolean HalfPriceSale { get; set; }
        //TODO: Add properties with Display annotation needed for searching
        

    }
}
