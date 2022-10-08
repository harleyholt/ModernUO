using System;

namespace Server.Mobiles;

public class FanningFire : MonsterAbility
{
    public override MonsterAbilityTrigger AbilityTrigger => MonsterAbilityTrigger.GiveMeleeDamage;

    public override MonsterAbilityType AbilityType => MonsterAbilityType.FanningFire;

    public override double ChanceToTrigger => 0.10;

    public override TimeSpan MaxTriggerCooldown => TimeSpan.FromSeconds(10);
    public override TimeSpan MinTriggerCooldown => TimeSpan.FromSeconds(10);
}
