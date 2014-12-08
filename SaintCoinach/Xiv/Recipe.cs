using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintCoinach.Xiv {
    public class Recipe : XivRow {
        #region Fields
        private RecipeLevel _RecipeLevel = null;
        private RecipeIngredient[] _Ingredients = null;
        #endregion

        #region Properties
        public CraftType CraftType { get { return As<CraftType>(); } }
        public ClassJob ClassJob { get { return CraftType.ClassJob; } }
        public RecipeElement RecipeElement { get { return As<RecipeElement>(); } }
        public RecipeLevel RecipeLevel { get { return _RecipeLevel ?? (_RecipeLevel = new RecipeLevel(this)); } }

        public Item ResultItem { get { return As<Item>("Item{Result}"); } }
        public int ResultCount { get { return AsInt32("Amount{Result}"); } }

        public IEnumerable<RecipeIngredient> Ingredients { get { return _Ingredients ?? (_Ingredients = BuildIngredients()); } }

        public bool IsSecondary { get { return AsBoolean("IsSecondary"); } }
        public bool CanQuickSynth { get { return AsBoolean("CanQuickSynth"); } }
        public bool CanHq { get { return AsBoolean("CanHq"); } }

        public int RequiredCraftsmanship { get { return AsInt32("RequiredCraftsmanship"); } }
        public int RequiredControl { get { return AsInt32("RequiredControl"); } }
        public Status RequiredStatus { get { return As<Status>("Status{Required}"); } }
        public Item RequiredItem { get { return As<Item>("Item{Required}"); } }

        public RecipeLevelTable RecipeLevelTable { get { return As<RecipeLevelTable>(); } }
        public int DifficultyFactor { get { return AsInt32("DifficultyFactor"); } }
        public int QualityFactor { get { return AsInt32("QualityFactor"); } }
        public int DurabilityFactor { get { return AsInt32("DurabilityFactor"); } }
        #endregion

        #region Constructor
        public Recipe(IXivSheet sheet, Ex.Relational.IRelationalRow sourceRow) : base(sheet, sourceRow) { }
        #endregion

        #region Build
        private RecipeIngredient[] BuildIngredients() {
            const int MaterialCount = 8;
            const int CrystalCount = 2;

            var ingredients = new List<RecipeIngredient>();

            for (var i = 0; i < MaterialCount; ++i) {
                var item = As<Item>("Item{Ingredient}", i);
                if (item.Key == 0)
                    continue;

                var count = AsInt32("Amount{Ingredient}", i);
                if (count == 0)
                    continue;

                ingredients.Add(new RecipeIngredient(RecipeIngredientType.Material, item, count));
            }
            for (var i = 0; i < CrystalCount; ++i) {
                var craftCrystal = As<CraftCrystalType>("CraftCrystalType", i);
                if (craftCrystal == null)
                    continue;

                var count = AsInt32("Amount{Crystal}", i);
                if (count == 0)
                    continue;

                ingredients.Add(new RecipeIngredient(RecipeIngredientType.Material, craftCrystal.Item, count));
            }

            return ingredients.ToArray();
        }
        #endregion
    }
}