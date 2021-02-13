using MagicShield.Dusts;
using MagicShield.Tile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicShield.Items
{
	public class Guardian : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Guardian"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Looks hot!");
		}

		public override void SetDefaults() 
		{
			item.damage = 220;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 20;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GuardianProj");
		}
      
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FieryGreatsword, 1);
			recipe.AddIngredient(mod.ItemType("RectaBar"), 10);
			recipe.AddIngredient(ItemID.LavaBucket, 3);
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 5 * 60);
        }
		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
			}
		}
	}
}