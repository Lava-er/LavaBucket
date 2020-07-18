using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace LavaBucket.Items
{
	public class LavaSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lava Sword");
			DisplayName.AddTranslation(GameCulture.Chinese, "岩浆利剑");

			Tooltip.SetDefault("It isn't too hot");
			Tooltip.AddTranslation(GameCulture.Chinese, "没那么烫手");
		}

		public override void SetDefaults() 
		{
			item.damage = 25;//伤害
			item.melee = true;//近战

			//碰撞体积，最好设置成图片大小
			item.width = 40;
			item.height = 40;

			//使用速度
			item.useTime = 30;
			item.useAnimation = 30;

			item.useStyle = 1;//使用方式
			item.knockBack =9.5f;//击退

			item.value = Item.sellPrice(0, 0, 40, 60);//价格
			item.rare = 13;//稀有度（这把剑有纪念意义2333）

			item.UseSound = SoundID.Item1;//声音
			item.autoReuse = true;//自动挥舞

			//射弹
			item.shoot = ProjectileID.EnchantedBeam;
			item.shootSpeed = 10f;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height, Utils.MyDustId.Fire, 0, 0, 100, Color.White, 2f);
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(24, 200);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.Torch, 99);
			recipe.AddIngredient(ItemID.EnchantedSword, 1);

			recipe.AddTile(TileID.Anvils);
			recipe.AddTile(TileID.Furnaces);
			recipe.AddTile(TileID.Torches);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}