using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InvisibleEnemiesByUnk.Content.Enemy
{
    public class BloodySlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6; // 6帧动画
        }

        public override void SetDefaults()
        {
            NPC.width = 87;
            NPC.height = 60;
            NPC.scale = 0.5f;

            NPC.damage = 22;
            NPC.defense = 6;
            NPC.lifeMax = 120;

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = 60f;
            NPC.knockBackResist = 0.8f;

            NPC.aiStyle = NPCAIStyleID.Slime; // 史莱姆AI
            AIType = NPCID.BlueSlime; // 直接继承蓝史莱姆逻辑
            AnimationType = -1; // 我们自己控制动画

            NPC.noGravity = false;
            NPC.noTileCollide = false;
        }

        public override void FindFrame(int frameHeight)
        {
            if (NPC.velocity.Y == 0)
            {
                // 在地面，播放待机两帧
                NPC.frameCounter++;
                if (NPC.frameCounter >= 20)
                {
                    NPC.frame.Y += frameHeight;
                    NPC.frameCounter = 0;
                }

                if (NPC.frame.Y >= frameHeight * 2)
                    NPC.frame.Y = 0;
            }
            else
            {
                // 空中阶段
                if (NPC.velocity.Y < 0)
                {
                    NPC.frame.Y = frameHeight * 2; // 起跳
                }
                else if (NPC.velocity.Y < 6f)
                {
                    NPC.frame.Y = frameHeight * 3; // 空中
                }
                else if (NPC.velocity.Y >= 6f)
                {
                    NPC.frame.Y = frameHeight * 4; // 下落
                }
            }
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];

            if (!target.active || target.dead)
            {
                NPC.TargetClosest();
                target = Main.player[NPC.target];
            }

            float distance = Vector2.Distance(NPC.Center, target.Center);

            if (distance < 400f)
            {
                NPC.localAI[0]++;

                if (NPC.localAI[0] >= 120)
                {
                    NPC.localAI[0] = 0;

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 direction = target.Center - NPC.Center;
                        direction.Normalize();
                        direction *= 6f;

                        Projectile.NewProjectile(
                            NPC.GetSource_FromAI(),
                            NPC.Center,
                            direction,
                            ProjectileID.BloodShot,
                            15,
                            1f,
                            Main.myPlayer
                        );
                    }
                }
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D spikes = ModContent.Request<Texture2D>(
                "InvisibleEnemiesByUnk/Content/Enemy/BloodySlime_Spikes"
            ).Value;

            Vector2 drawPos = NPC.Center - screenPos;
            // 尖刺绘制位置往上方偏移一点点
            drawPos.Y -= NPC.height * NPC.scale;

            spriteBatch.Draw(
                spikes,
                drawPos,
                null,
                drawColor,
                0f,
                spikes.Size() / 2f,
                NPC.scale,
                NPC.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
            );
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneCrimson && spawnInfo.SpawnTileY < Main.worldSurface)
            {
                return 0.3f;
            }
            return 0f;
        }
    }
}