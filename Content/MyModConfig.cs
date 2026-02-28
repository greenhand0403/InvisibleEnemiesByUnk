using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace InvisibleEnemiesByUnk.Content
{
    public class MyModConfig : ModConfig
    {
        // 这会影响弹幕行为（联机需要统一），建议 ServerSide
        public override ConfigScope Mode => ConfigScope.ServerSide;

        // [Label("敌怪和陷阱隐身")]
        [DefaultValue(true)]
        public bool InvisibleEnemies;

        [DefaultValue(false)]
        // [Label("忽略幽灵护目镜")]
        public bool IgnoreSpectreGoggles;
    }
}