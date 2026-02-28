using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InvisibleEnemiesByUnk.Content
{
    public static class EchoVision
    {
        public static bool HasSpectreGoggles(Player player)
        {
            // armor[] 里包含盔甲、饰品、社交栏等（具体槽位分布不用死记，直接全扫最稳）
            for (int i = 3; i < 9; i++)
            {
                if (player.armor[i] != null && player.armor[i].type == ItemID.SpectreGoggles)
                    return true;
            }

            // 也可以把 miscEquips 扫一遍（一般不需要）
            return false;
        }

        public static bool CanSeeEcho(Player player)
        {
            if (player == null || !player.active)
                return false;

            var cfg = ModContent.GetInstance<MyModConfig>();
            
            if (!cfg.InvisibleEnemies)
                return true;
            
            if (cfg.IgnoreSpectreGoggles)
                return false;

            // 先实现最核心的：佩戴幽灵护目镜
            if (HasSpectreGoggles(player))
                return true;

            // TODO: 若你想加入“回声室范围内可见”，可在这里追加判断
            // return IsNearEchoChamber(player);

            return false;
        }
    }
}