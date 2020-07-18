using LavaBucket.Buffs;
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
    class BoneShieldPotion : ModItem
    {
        public override void SetStaticDefaults()
        {

            // 这个是物品名字，也就是忽略游戏语言的情况下显示的文字
            DisplayName.SetDefault("Bone Shield Potion");
            DisplayName.AddTranslation(GameCulture.Chinese, "骨盾药水");

            // 物品的描述，加入换行符 '\n' 可以多行显示哦
            Tooltip.SetDefault("It's bitter and astringent, but it works" + "\nIncreased defense, immune to fall damage");
            Tooltip.AddTranslation(GameCulture.Chinese, "又苦又涩，但很有效" + "\n防御提升，免疫摔落伤害");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 32;

            item.useAnimation = 17;
            item.useTime = 17;

            item.maxStack = 30;

            item.rare = 5;
            item.value = Item.sellPrice(0, 0, 50, 0);
            // 物品的使用方式，还记得2是什么吗
            item.useStyle = 2;
            // 喝药的声音
            item.UseSound = SoundID.Item3;
            // 决定这个物品使用以后会不会减少，true就是使用后物品会少一个，默认为false
            item.consumable = true;
            // 决定使用动画出现后，玩家转身会不会影响动画的方向，true就是会，默认为false
            item.useTurn = true;
            // 告诉T
            // 加buff的方法1：设置物品的buffType为buff的ID
            // 这里我设置了中毒debuff（2333
            //item.buffType = BuffID.Poisoned;
            item.buffTime = 36000;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<BonyShield>(), 36000);
            return false;
        }
        // 物品合成表的设置部分
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // 合成材料，需要10个泥土块
            recipe.AddIngredient(ItemID.IronskinPotion, 1);
            recipe.AddIngredient(ItemID.Bone, 6);
            // 以及在工作台旁边
            recipe.AddTile(TileID.Bottles);
            // 生成1个这种物品
            recipe.SetResult(this);
            // 把这个合成表装进tr的系统里
            recipe.AddRecipe();
        }
    }
}
