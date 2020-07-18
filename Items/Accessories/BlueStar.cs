using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace LavaBucket.Items.Accessories
{
    class BlueStar : ModItem {
        // 物品名字设置
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Blue Star");
            DisplayName.AddTranslation(GameCulture.Chinese, "镶金蓝色星石");

            Tooltip.SetDefault("Increases magical abilities, but halfs defenses");
            Tooltip.AddTranslation(GameCulture.Chinese, "提升魔法能力，但会使防御减半");
        }
        // 物品基本信息设置
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            // 重点在这里，这个属性设为true才能带在身上
            item.accessory = true;
            // 物品的面板防御数值，装备了以后就会增加
            item.defense = 0;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
            // 这个属性代表这是专家模式专有物品，稀有度颜色会是彩虹的！
            item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 200;
            player.statLifeMax2 -= 20;
            player.statDefense /= 2;
            player.magicDamage += 0.2f;
            player.manaCost -= 0.15f;
            player.manaRegen += 10;
        }

        // 物品合成方式设置
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddIngredient(ItemID.GoldBar, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);

            recipe.AddRecipe();
        }

    }
}
