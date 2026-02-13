using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace InvisibleEnemiesByUnk.Content
{
    public class EchoedGlobalTile : GlobalTile
    {
        private static readonly HashSet<int> TrapTiles = new()
        {
            TileID.Traps,//陷阱
            TileID.Spikes,//尖刺
            TileID.WoodenSpikes,//木刺
            TileID.Meteorite,//陨石
            TileID.Hellstone,//狱石
            TileID.WaterCandle,//水蜡烛
            TileID.Cobweb,//蜘蛛网
            TileID.GeyserTrap,//喷泉
            TileID.LandMine,//地雷
            TileID.Boulder,//巨石
            TileID.PressurePlates,//压力板
            TileID.Detonator,//引爆器
            TileID.Explosives,//炸药
            TileID.BreakableIce,//薄冰
            TileID.TNTBarrel,//TNT
            TileID.LifeCrystalBoulder,//生命水晶巨石
            TileID.BeeHive,//蜂巢
            TileID.AntlionLarva,//蚁狮卵
            TileID.Larva,//蜂王卵
            TileID.PlanteraBulb,//世纪之花灯泡
            TileID.RollingCactus,//仙人掌球
            TileID.LifeFruit,//生命果
            TileID.Heart,//生命水晶
        };

        public override bool PreDraw(int i, int j, int type, SpriteBatch spriteBatch)
        {
            if (TrapTiles.Contains(type))
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
