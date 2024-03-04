using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealTipCalculator.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public decimal? MealCost { get; set; }

        public decimal? Tip15 { get; set; }
        public decimal? Tip20 { get; set; }
        public decimal? Tip25 { get; set; }

        public bool IsValid { get; set; } = true;
        public required string ValidationErrorMessage { get; set; }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                IsValid = false;
                ValidationErrorMessage = "Invalid meal cost. Please enter a valid number greater than 0.";
                return;
            }

            if (MealCost <= 0)
            {
                IsValid = false;
                ValidationErrorMessage = "The cost of the meal must be greater than 0.";
                return;
            }

            IsValid = true;
            ValidationErrorMessage = "";

            Tip15 = MealCost * 0.15m;
            Tip20 = MealCost * 0.20m;
            Tip25 = MealCost * 0.25m;
        }
    }
}
