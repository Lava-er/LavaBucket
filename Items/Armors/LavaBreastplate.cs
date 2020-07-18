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
    [AutoloadEquip(EquipType.Body)]
    public class LavaBreastplate : ModItem {
        // 设置物品描述的地方
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            // SetDefaults也可以不写
            DisplayName.AddTranslation(GameCulture.Chinese, "岩浆胸甲");
            Tooltip.AddTranslation(GameCulture.Chinese, "狱岩胸甲的升级版"
                + "\n免疫灼烧debuff和岩浆"
                + "\n+15生命上限"
                + "\n少量增加回血能力");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;
            // 装备的防御值
            item.defense = 25;
        }

        public override void UpdateEquip(Player player) {
            // 免疫灼伤debuff
            player.buffImmune[BuffID.OnFire] = true;
            player.lavaImmune = true;
            // 增加生命上限50
            player.statLifeMax2 += 15;

            // 增加2点生命恢复，虽然看起来不多，其实在游戏里还挺可观的
            player.lifeRegen += 1;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenBreastplate, 1);
            recipe.AddIngredient(ModContent.ItemType<LavaCore>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
