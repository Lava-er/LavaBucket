using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace LavaBucket.Items
{
    class LavaCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();


            DisplayName.SetDefault("Lava Core");
            DisplayName.AddTranslation(GameCulture.Chinese, "熔岩核心");
        }
        public override void SetDefaults()
        {
            // 物品的价格，这里用sellPrice，也就是卖出物品的价格作为基准
            item.value = Item.sellPrice(0, 0, 70, 0);
            item.width = 16;
            item.height = 16;
            // 让它变小一点
            item.scale = 1.2f;
            // 最大堆叠数量，唔，对于一般武器来说，即使你堆了99个，使用的时候还是只有一个的效果
            item.maxStack = 99;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 6);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 2);

            recipe.AddTile(TileID.MythrilAnvil);
            // 生成1个这种物品
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
