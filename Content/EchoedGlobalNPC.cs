using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InvisibleEnemiesByUnk.Content
{
    public class EchoedGlobalNPC : GlobalNPC
    {
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // 只影响敌怪（你也可以排除城镇NPC、雕像刷怪等）
            if (!npc.friendly && npc.active)
            {
                var viewer = Main.LocalPlayer;
                if (!EchoVision.CanSeeEcho(viewer))
                {
                    return false; // 不画 => “隐身”
                }
            }

            return true;
        }
    }
}
