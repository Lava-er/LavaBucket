using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

// 确保这个文件一定要放在Items/Armors/文件夹里，与命名空间匹配
// 这个套装的贴图来自ExampleMOD
namespace LavaBucket.Items.Armors {
    // 注意这里，这是C#里面的一个神奇的语法
    // 作用是给一个类附加一个属性
    // 比如这里就是给这个类附加一个装备样式为头盔的属性，这样TML就会把它识别成头盔
    [AutoloadEquip(EquipType.Head)]
    public class LavaHelmet : ModItem {
        // 设置物品描述的地方 
        public override void SetStaticDefaults() {
            DisplayName.AddTranslation(GameCulture.Chinese, "狱岩头盔的升级版");
            Tooltip.AddTranslation(GameCulture.Chinese, "+5生命上限" +"\n增加3%近战伤害");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;

            // 防御+12
            item.defense = 12;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.03f;
            player.statLifeMax2 += 5;

        }
        // 重点来了，IsArmorSet这个重写函数用来判断身上的物品能不能组成一件完整套装
        // 比如这里我需要让头盔，胸甲，护腿全部都是模板装备的才能算是套装
        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType("LavaBreastplate") && legs.type == mod.ItemType("LavaLeggings");
        }

        // 如果在上面的函数中玩家被判定穿上了模板套装，那么就会在这里执行其效果
        public override void UpdateArmorSet(Player player) {
            // 套装描述，就是鼠标移上去最底下现实的套装效果
            player.setBonus = "进一步增加回血速度，吸取红心范围增大" +
                "\n增加10%伤害减免和12%近战伤害";
            player.meleeDamage += 0.12f;
            player.endurance += 0.5f;
            player.lifeRegen += 2;
            player.lifeMagnet = true;
            // 加点特技
            player.armorEffectDrawShadow = true;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenHelmet, 1);
            recipe.AddIngredient(ModContent.ItemType<LavaCore>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
