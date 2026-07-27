using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Core.Simulation;

/// <summary>
/// Hệ thống mô phỏng NPC tự động làm việc. Đây là trái tim của điểm khác biệt
/// với Minecraft: càng nhiều NPC được giao vai trò và càng nhiều công trình quản lý
/// được xây, AutomationLevel của vương quốc càng tăng, giảm dần yêu cầu thao tác
/// thủ công của người chơi.
/// </summary>
public class AutomationSystem
{
    public void Tick(KingdomState kingdom)
    {
        foreach (var npc in kingdom.Npcs)
        {
            switch (npc.Role)
            {
                case NpcRole.Farmer:
                    kingdom.Resources.Add("food", npc.SkillLevel);
                    break;
                case NpcRole.Lumberjack:
                    kingdom.Resources.Add("wood", npc.SkillLevel);
                    break;
                case NpcRole.Miner:
                    kingdom.Resources.Add("stone", npc.SkillLevel);
                    break;
                case NpcRole.Merchant:
                    kingdom.Resources.Add("gold", npc.SkillLevel);
                    break;
            }
        }

        RecalculateAutomationLevel(kingdom);
    }

    private void RecalculateAutomationLevel(KingdomState kingdom)
    {
        var activeNpcCount = kingdom.Npcs.Count(n => n.Role != NpcRole.Idle);
        var stewardCount = kingdom.Npcs.Count(n => n.Role == NpcRole.Steward);

        // Công thức tạm thời — sẽ tinh chỉnh khi có tài liệu thiết kế Kingdom Simulation.
        var level = Math.Min(100, activeNpcCount * 5 + stewardCount * 10);
        kingdom.AutomationLevel = level;
    }
}
