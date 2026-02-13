using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InvisibleEnemiesByUnk.Content
{
    public class EchoedGlobalProjectile : GlobalProjectile
    {
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.active && projectile.hostile && !projectile.friendly)
            {
                var viewer = Main.LocalPlayer;
                if (!EchoVision.CanSeeEcho(viewer))
                {
                    return false;
                }
            }
            return true;
        }
    }
}