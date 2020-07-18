
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace LavaBucket.Items
{
    class SilkFlintlock : ModItem
    {
        // 设置物品名字，描述的地方
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            
            DisplayName.SetDefault("Silk Flintlock Pistol");
            DisplayName.AddTranslation(GameCulture.Chinese, "丝绸燧发枪");

            Tooltip.SetDefault("Shoot the Silk Rope Coil"+ "\n To help you climb");
            Tooltip.AddTranslation(GameCulture.Chinese, "射出丝绸绳卷"+"\n来帮助你攀爬");
        }

        // 最最最重要的物品基本属性部分
        public override void SetDefaults()
        {

            item.damage = 20;
            item.knockBack = 5f;
            item.crit = 10;
            item.rare = 2;
            // 攻击速度和攻击动画持续时间！
            // 这个数值越低越快，因为TR游戏速度每秒是60帧，这里的10就是
            // 10.0 / 60.0 = 0.1666... 秒使用1次！也就是一秒6次
            // 一般来说我们要把这两个值设成一样，但也有例外的时候，我们以后会讲
            item.useTime = 30;
            item.useAnimation = 30;

            // 使用方式，这个值决定了武器使用时到底是按什么样的动画播放
            // 1 代表挥动，也就是剑类武器！
            // 2 代表像药水一样喝下去，emmmm这个放在剑上会不会很奇怪（吞
            // 3 代表像同志短剑一样刺x 出去
            // 4 唔，这个一般不是用在武器上的，想象一下生命水晶使用的时候的动作
            // 5 手持，枪、弓、法杖类武器的动作，用途最广，这里就用它
            item.useStyle = 5;

            // 决定了这个武器鼠标按住不放能不能一直攻击， true代表可以
            // （我就是要按废你的鼠标！
            item.autoReuse = false;

            // 决定了这个武器的伤害属性，
            // melee 代表近战
            // ranged 代表远程
            // magic 代表膜法，不，魔法
            // summon 代表召唤
            // thrown 代表投掷
            item.ranged = true;

            // 物品的价格，这里用sellPrice，也就是卖出物品的价格作为基准
            item.value = Item.sellPrice(0, 1, 0, 0);

            // 设置这个物品使用时发出的声音，以后会讲到怎么调出其他声音
            // 在这里我用的是开枪的声音
            item.UseSound = SoundID.Item36;

            // 物品的碰撞体积大小，可以与贴图无关，但是建议设为跟贴图一样的大小
            // 不然鬼知道会不会发生奇怪的事情（无所谓的）
            item.width = 40;
            item.height = 40;

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
            item.shootSpeed = 15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlintlockPistol, 1);
            recipe.AddIngredient(ItemID.SilkRopeCoil, 10);

            recipe.AddTile(TileID.Anvils);
            // 生成1个这种物品
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
