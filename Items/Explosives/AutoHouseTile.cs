﻿using Fargowiltas.Projectiles.Explosives;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Explosives
{
    public class AutoHouseTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
        }

        public override void PlaceInWorld(int i, int j, Item item)
        {
            Projectile.NewProjectile(Main.player[Main.myPlayer].GetProjectileSource_Item(item), i * 16 + 8, (j + 2) * 16, 0f, 0f, ModContent.ProjectileType<AutoHouseProj>(), 0, 0, Main.myPlayer);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            WorldGen.KillTile(i, j);
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            return false;
        }
    }
}