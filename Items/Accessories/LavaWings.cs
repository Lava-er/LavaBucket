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
    [AutoloadEquip(EquipType.Wings)]
    public class LavaWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Wings");
            DisplayName.AddTranslation(GameCulture.Chinese, "岩浆之翼");

            Tooltip.SetDefault("Put it back，please.");
            Tooltip.AddTranslation(GameCulture.Chinese, " 背后一热");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.accessory = true;
            item.defense = 6;
            item.rare = 8;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.expert = false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // 翅膀的最长持续时间
            player.wingTimeMax = 100;
        }
        // 控制翅膀垂直飞行的参数
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            // 代码写在这
        }
        // 控制翅膀水平飞行的参数
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 1.5f;
            acceleration = 1.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.HellstoneBar,6);
            recipe.AddIngredient(ItemID.SoulofFlight,20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}