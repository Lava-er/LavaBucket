using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LavaBucket.Buffs
{
    class BonyShield : ModBuff
    {
        public override void SetDefaults()
        {
            // 设置buff名字和描述
            DisplayName.SetDefault("骨盾");
            Description.SetDefault("防御提升，免疫摔落伤害");
            // 因为buff严格意义上不是一个TR里面自定义的数据类型，所以没有像buff.XXXX这样的设置属性方式了
            // 我们需要用另外一种方式设置属性
            // 这个属性决定buff在游戏退出再进来后会不会仍然持续，true就是不会，false就是会
            Main.buffNoSave[Type] = true;
            // 用来判定这个buff算不算一个debuff，如果设置为true会得到TR里对于debuff的限制，比如无法取消
            Main.debuff[Type] = false;
            // 当然你也可以用这个属性让这个buff即使不是debuff也不能取消，设为false就是不能取消了
            this.canBeCleared = true;
            // 决定这个buff是不是照明宠物的buff，以后讲宠物和召唤物的时候会用到的，现在先设为false
            Main.lightPet[Type] = false;
            // 决定这个buff会不会显示持续时间，false就是会显示，true就是不会显示，一般宠物buff都不会显示
            Main.buffNoTimeDisplay[Type] = false;
            // 决定这个buff在专家模式会不会持续时间加长，false是不会，true是会
            this.longerExpertDebuff = false;
            // 如果这个属性为true，pvp的时候就可以给对手加上这个debuff/buff
            Main.pvpBuff[Type] = false;
            // 决定这个buff是不是一个装饰性宠物，用来判定的，比如消除buff的时候不会消除它
            Main.vanityPet[Type] = false;
        }
        // 注意这里我们选择的是对Player生效的Update，另一个是对NPC生效的Update
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 6;
            player.noFallDmg = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense += 6;
        }
        public override bool ReApply(Player player, int time, int buffIndex)
        {
            // 这段代码的作用就是当玩家被重新添加buff的时候延长buff时间
            player.buffTime[buffIndex] += time;
            return true;
        }
    }
}
