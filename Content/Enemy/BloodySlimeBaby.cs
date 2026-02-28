using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InvisibleEnemiesByUnk.Content.Enemy
{
    public class BloodySlimeBaby : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4; // 4帧循环
        }

        public override void SetDefaults()
        {
            NPC.width = 34;
            NPC.height = 26;

            NPC.damage = 10;
            NPC.defense = 2;
            NPC.lifeMax = 35;

            NPC.knockBackResist = 0.9f;
            NPC.value = 10f;

            NPC.aiStyle = NPCAIStyleID.Slime;              // 最简单史莱姆AI
            AIType = NPCID.BlueSlime;     // 继承蓝史莱姆行为（跳一跳接近玩家）
            AnimationType = -1;           // 我们自己写4帧循环

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void FindFrame(int frameHeight)
        {
            // 不管在地面/空中都循环播放（你要求“不断循环即可”）
            NPC.frameCounter++;
            if (NPC.frameCounter >= 6) // 数值越小动画越快
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= frameHeight * 4)
                    NPC.frame.Y = 0;
            }
        }
    }
}