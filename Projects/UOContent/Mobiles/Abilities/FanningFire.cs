namespace Server.Mobiles;

public class FanningFire : MonsterAbilitySingleTargetDoT
{
    public override MonsterAbilityType AbilityType => MonsterAbilityType.FanningFire;
    public override MonsterAbilityTrigger AbilityTrigger => MonsterAbilityTrigger.GiveMeleeDamage;
    public override double ChanceToTrigger => 0.05;

    public const string Name = "FanningFire";

    protected override void OnTick(BaseCreature source, Mobile target)
    {
        RemoveEffect(target);
        // The creature surrounds you with fire, reducing your resistance to fire attacks.
        target.SendLocalizedMessage(1070835);
    }

    protected override void OnEffectRemoved(Mobile defender)
    {
        defender.RemoveResistanceMod(Name);
    }

    protected override void OnEffectAdded(BaseCreature source, Mobile defender)
    {
        if (RemoveEffect(defender))
        {
            defender.SendLocalizedMessage(1070845); // The creature continues to corrupt your armor!
        }
        else
        {
            // The creature fans you with fire, reducing your resistance to fire attacks.
            defender.SendLocalizedMessage(1070833);
        }

        /**
         * Fanning Fire
         * Start cliloc: 1070833
         * Effect: Fire res -10% for 10 seconds. Does not stack.
         * Damage: 35-45, 100% fire
         * End cliloc: 1070834
         * Sound: 0x208
         * Graphic:
         * - Type: "3"
         * - From: "0x57D4F5B"
         * - To: "0x0"
         * - ItemId: "0x3709"
         * - ItemIdName: "fire column"
         * - FromLocation: "(994 325, 16)"
         * - ToLocation: "(994 325, 16)"
         * - Speed: "10"
         * - Duration: "30"
         * - FixedDirection: "True"
         * - Explode: "False"
         * - Hue: "0x0"
         * - RenderMode: "0x0"
         * - Effect: "0x34"
         * - ExplodeEffect: "0x1"
         * - ExplodeSound: "0x0"
         * - Layer: "5"
         * - Unknown: "0x0"
         */

        var effect = -(defender.FireResistance / 10);

        var mod = new ResistanceMod(ResistanceType.Fire, Name, effect);
        defender.AddResistanceMod(mod);

        defender.FixedParticles(0x37B9, 10, 30, 0x34, EffectLayer.RightFoot);
        defender.PlaySound(0x208);

        // TODO: Trigger replaces a normal attack.
        AOS.Damage(defender, source, Utility.RandomMinMax(35, 45), 0, 100, 0, 0, 0);
    }
}
