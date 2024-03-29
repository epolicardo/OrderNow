﻿namespace OrderNow.Common.Data.Entities
{
    public class Ingredient : EntityBase
    {
        public Product itemIngredient { get; set; }
        public float Quantity { get; set; }
    }

    public class Product : EntityBase
    {
        public string? Brand { get; set; }
        public Business? Business { get; set; }
        public Category? Category { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? EAN { get; set; }
        public bool HasRecipe { get; set; }
        public bool IsSelleable { get; set; }
        public bool IsSuggested { get; set; }

        [MaxLength(40)]
        public string? LegalName { get; set; }

        public string? Name { get; set; }
        public IList<ProductOptions>? OptionsList { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;

        public UInt64 Qualifications { get; set; }

        [ForeignKey("RecipeId")]
        public Recipes? Recipe { get; set; }

        public float Score { get; set; }
        public bool Status { get; set; }
        public float Stock { get; set; }
        public string? URLIcon { get; set; }
        public string? URLImage { get; set; }
    }

    public class Recipes : EntityBase
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
    }
}