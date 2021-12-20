using System.Collections.Generic;

namespace SupportClasses
{
    public enum DamageType
    {
        Acid,
        Cold,
        Fire,
        Force,
        Lightning,
        Necrotic,
        Poison,
        Psychic,
        Radiant,
        Thunder
    }

    public class DamageTypes
    {
        public static List<DamageType> GetDamageTypes()
        {
            return new List<DamageType> { DamageType.Acid, DamageType.Cold, DamageType.Fire, DamageType.Force, DamageType.Lightning, DamageType.Necrotic, DamageType.Poison, DamageType.Psychic, DamageType.Radiant, DamageType.Thunder };
        }
    }
}
