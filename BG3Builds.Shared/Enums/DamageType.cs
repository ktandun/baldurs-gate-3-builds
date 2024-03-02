namespace BG3Builds.Shared.Enums;

public enum DamageType
{
    Bludgeoning = 1,
    Piercing = 2,
    Slashing = 3,
    Cold = 4,
    Fire = 5,
    Lightning = 6,
    Thunder = 7,
    Acid = 8,
    Poison = 9,
    Radiant = 10,
    Necrotic = 11,
    Force = 12,
    Psychic = 13,
    None = 14,
}

public static class DamageTypeExtensions
{
    public static DamageType ToDamageType(this string damageType)
    {
        return damageType switch
        {
            "Bludgeoning" => DamageType.Bludgeoning,
            "Piercing" => DamageType.Piercing,
            "Slashing" => DamageType.Slashing,
            "Cold" => DamageType.Cold,
            "Fire" => DamageType.Fire,
            "Lightning" => DamageType.Lightning,
            "Thunder" => DamageType.Thunder,
            "Acid" => DamageType.Acid,
            "Poison" => DamageType.Poison,
            "Radiant" => DamageType.Radiant,
            "Necrotic" => DamageType.Necrotic,
            "Force" => DamageType.Force,
            "Psychic" => DamageType.Psychic,
            _ => DamageType.None,
        };
    }
}