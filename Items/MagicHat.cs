
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace LavaBucket.Items
{
    class MagicHat : ModItem
    {
        // 设置物品名字，描述的地方
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            
            DisplayName.SetDefault("Unimate Magic Hat");
            DisplayName.AddTranslation(GameCulture.Chinese, "最终魔法帽");

            Tooltip.SetDefault("It's The End, isn't it?" + "\nshoot any barrage randomly (including those of other MODs)");
            Tooltip.AddTranslation(GameCulture.Chinese, "到终点了，不是吗？"+"\n随机射出任何弹幕（包括其他Mod的弹幕）");
        }

        // 最最最重要的物品基本属性部分
        public override void SetDefaults()
        {

            item.damage = 1;
            item.knockBack = 0f;
            item.crit = -4;
            item.rare = 13;
            // 攻击速度和攻击动画持续时间！
            // 这个数值越低越快，因为TR游戏速度每秒是60帧，这里的10就是
            // 10.0 / 60.0 = 0.1666... 秒使用1次！也就是一秒6次
            // 一般来说我们要把这两个值设成一样，但也有例外的时候，我们以后会讲
            item.useTime = 5;
            item.useAnimation = 5;

            // 使用方式，这个值决定了武器使用时到底是按什么样的动画播放
            // 1 代表挥动，也就是剑类武器！
            // 2 代表像药水一样喝下去，emmmm这个放在剑上会不会很奇怪（吞
            // 3 代表像同志短剑一样刺x 出去
            // 4 唔，这个一般不是用在武器上的，想象一下生命水晶使用的时候的动作
            // 5 手持，枪、弓、法杖类武器的动作，用途最广，这里就用它
            item.useStyle = 5;

            // 决定了这个武器鼠标按住不放能不能一直攻击， true代表可以
            // （我就是要按废你的鼠标！
            item.autoReuse = true;

            // 决定了这个武器的伤害属性，
            // melee 代表近战
            // ranged 代表远程
            // magic 代表膜法，不，魔法
            // summon 代表召唤
            // thrown 代表

            // 物品的价格，这里用sellPrice，也就是卖出物品的价格作为基准
            item.value = Item.sellPrice(1, 30, 0, 0);

            // 设置这个物品使用时发出的声音，以后会讲到怎么调出其他声音
            // 在这里我用的是开枪的声音
            item.UseSound = SoundID.Item36;

            // 物品的碰撞体积大小，可以与贴图无关，但是建议设为跟贴图一样的大小
            // 不然鬼知道会不会发生奇怪的事情（无所谓的）
            item.width = 30;
            item.height = 30;

            // 让它变小一点
            item.scale = 1.5f;

            // 最大堆叠数量，唔，对于一般武器来说，即使你堆了99个，使用的时候还是只有一个的效果
            item.maxStack = 1;

            //-------------------------------------------------------------------------
            // 接下来就是枪械武器独特的属性

            // noMelee代表这个武器使用的时候贴图会不会造成伤害
            // 如果你希望开枪的时候你的手枪还能敲在敌人头上就把它设为false
            // 反正我不希望：（，就当枪本身没有伤害吧
            item.noMelee = false;

            // 决定枪射出点什么和射出的速度的量
            // 这里我让枪射出子弹，并且以 （7像素 / 帧） 的速度射出去
            item.shoot = ProjectileID.SilkRopeCoil;
            item.shootSpeed = 5f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = Main.rand.Next(Main.projectileTexture.Length);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PortalGun, 1);
            recipe.AddIngredient(ItemID.GravityGlobe, 1);
            recipe.AddIngredient(ItemID.LunarBar, 20);

            recipe.AddTile(TileID.Anvils);
            // 生成1个这种物品
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
