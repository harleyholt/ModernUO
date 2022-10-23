﻿namespace Server.Mobiles;

public class RuneCorruption : MonsterAbilitySingleTargetDoT
{
    public override MonsterAbilityType AbilityType => MonsterAbilityType.RuneCorruption;
    public override MonsterAbilityTrigger AbilityTrigger => MonsterAbilityTrigger.GiveMeleeDamage;
    public override double ChanceToTrigger => 0.05;

    private const string Name = "RuneCorruption";

    protected override void OnEffectRemoved(Mobile defender)
    {
        defender.RemoveResistanceMod(Name);
    }

    protected override void OnTick(BaseCreature source, Mobile defender)
    {
        RemoveEffect(defender);
        defender.SendLocalizedMessage(1071967); // The corruption of your armor has worn off
    }

    protected override void OnEffectAdded(BaseCreature source, Mobile defender)
    {
        if (RemoveEffect(defender))
        {
            defender.SendLocalizedMessage(1070845); // The creature continues to corrupt your armor!
        }
        else
        {
            defender.SendLocalizedMessage(1070846); // The creature magically corrupts your armor!
        }

        /**
         * Rune Corruption
         * Start cliloc: 1070846 "The creature magically corrupts your armor!"
         * Effect: All resistances -70 (lowest 0) for 5 seconds
         * End ASCII: "The corruption of your armor has worn off"
         */

        if (Core.ML)
        {
            if (defender.PhysicalResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Physical,
                        Name,
                        -(defender.PhysicalResistance / 2)
                    )
                );
            }

            if (defender.FireResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Fire,
                        Name,
                        -(defender.FireResistance / 2)
                    )
                );
            }

            if (defender.ColdResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Cold,
                        Name,
                        -(defender.ColdResistance / 2)
                    )
                );
            }

            if (defender.PoisonResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Poison,
                        Name,
                        -(defender.PoisonResistance / 2)
                    )
                );
            }

            if (defender.EnergyResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Energy,
                        Name,
                        -(defender.EnergyResistance / 2)
                    )
                );
            }
        }
        else
        {
            if (defender.PhysicalResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Physical,
                        Name,
                        defender.PhysicalResistance > 70 ? -70 : -defender.PhysicalResistance
                    )
                );
            }

            if (defender.FireResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Fire,
                        Name,
                        defender.FireResistance > 70 ? -70 : -defender.FireResistance
                    )
                );
            }

            if (defender.ColdResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Cold,
                        Name,
                        defender.ColdResistance > 70 ? -70 : -defender.ColdResistance
                    )
                );
            }

            if (defender.PoisonResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Poison,
                        Name,
                        defender.PoisonResistance > 70 ? -70 : -defender.PoisonResistance
                    )
                );
            }

            if (defender.EnergyResistance > 0)
            {
                defender.AddResistanceMod(
                    new ResistanceMod(
                        ResistanceType.Energy,
                        Name,
                        defender.EnergyResistance > 70 ? -70 : -defender.EnergyResistance
                    )
                );
            }
        }

        defender.FixedEffect(0x37B9, 10, 5);
    }
}
