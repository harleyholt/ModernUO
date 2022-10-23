namespace Server.Mobiles;

public abstract class MonsterAbilityResistanceDebuff : MonsterAbilitySingleTargetDoT
{
    public virtual string ModName => $"{GetHashCode()}:ResistanceMod";

    protected override void OnTarget(MonsterAbilityTrigger trigger, BaseCreature source, Mobile defender)
    {
        base.OnTarget(trigger, source, defender);

        defender.AddResistanceMod(GetResistanceMod(source, defender));
    }

    protected override void OnTick(BaseCreature source, Mobile defender)
    {
        defender.RemoveResistanceMod(ModName);
    }

    protected abstract ResistanceMod GetResistanceMod(BaseCreature source, Mobile defender);
}
