using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;

namespace Server.Database.Server;

[PrimaryKey(nameof(UnitOwningUserId))]
public class UnitOwning
{
    public int UnitOwningUserId { get; set; }

    public int UserId { get; set; }
    public int UnitId { get; set; }
    public int Exp { get; set; }
    public int NextExp { get; set; }
    public int Level { get; set; }
    public int MaxLevel { get; set; }
    public int LevelLimitId { get; set; }
    public UnitRank Rank { get; set; }
    public UnitRank MaxRank { get; set; }
    public int Love { get; set; }
    public int MaxLove { get; set; }
    public int UnitSkillExp { get; set; }
    public int UnitSkillLevel { get; set; }
    public int MaxUnitSkillLevel { get; set; }
    public int MaxHp { get; set; }
    public int UnitRemovableSkillCapacity { get; set; }
    public int MaxUnitRemovableSkillCapacity { get; set; }
    public int FavoriteFlag { get; set; }
    public UnitRank DisplayRank { get; set; }
    public bool IsSigned { get; set; }

    public int Attribute { get; set; }
    public int StatSmile { get; set; }
    public int StatPure { get; set; }
    public int StatCool { get; set; }

    public DateTime InsertDate { get; set; }

    public virtual User User { get; set; }
}