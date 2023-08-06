﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ToastyQoL.Content.Projectiles;

namespace ToastyQoL.Content.Buffs
{
    public class ToasterBuff : ModBuff
    {

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
            // DisplayName.SetDefault("Toaster");
            // Description.SetDefault("He tries, but often burns it");
        }

        public override void Update(Player player, ref int buffIndex)
        { // This method gets called every frame your buff is active on your player.
            player.buffTime[buffIndex] = 18000;

            int projType = ModContent.ProjectileType<ToasterProj>();

            // If the player is local, and there hasn't been a pet projectile spawned yet - spawn it.
            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
            {
                var entitySource = player.GetSource_Buff(buffIndex);

                Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
            }
        }
    }
}
