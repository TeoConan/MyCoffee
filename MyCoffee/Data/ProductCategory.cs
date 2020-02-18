using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoffee.Data
{
    public enum ProductCategory
    {
        //Naming convention ok

        [Display(Name = "Boisson chaude")]
        HotDrink,
        [Display(Name = "Viennoiserie")]
        Viennoiserie,
        [Display(Name = "Sandwich")]
        Sandwich,
        [Display(Name = "Salade")]
        Salad,
        [Display(Name = "Boisson")]
        Drink,
        [Display(Name = "Snack")]
        Snack,
        [Display(Name = "Boîte repas")]
        BoxLunch
    }
}
