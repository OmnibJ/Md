using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicShield.Items
{
	public class MysteriousVertebrae : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MysteriousVertebrae"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("123");
		}

		public override void SetDefaults() 
		{
			item.width = 26;
			item.height = 24;
			item.useTime = 30;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 10000;
			item.rare = 4;
			item.autoReuse = false;
			item.useTurn = false;
			item.maxStack = 20;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 2);
			recipe.AddIngredient(ItemID.SoulofMight, 2);
			recipe.AddIngredient(ItemID.SoulofSight, 2);
			recipe.AddIngredient(mod.ItemType("RectaBar"), 5);
			recipe.AddTile(TileID.Furnace);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool UseItem (Player player) 
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Rectavius>);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}