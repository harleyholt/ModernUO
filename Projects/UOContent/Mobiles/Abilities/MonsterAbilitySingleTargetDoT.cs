﻿using System;
using System.Collections.Generic;

namespace Server.Mobiles;

public abstract class MonsterAbilitySingleTargetDoT : MonsterAbilitySingleTarget
{
    private Dictionary<Mobile, ExpireTimer> _table;

    public virtual TimeSpan MinDelay => TimeSpan.FromSeconds(10.0);
    public virtual TimeSpan MaxDelay => TimeSpan.FromSeconds(10.0);

    protected override void OnTarget(MonsterAbilityTrigger trigger, BaseCreature source, Mobile defender)
    {
        // defender.AddResistanceMod(GetResistanceMod(source, defender));
        _table ??= new Dictionary<Mobile, ExpireTimer>();
        _table.Remove(defender);

        var duration = Utility.RandomMinMax(MinDelay, MaxDelay);
        var timer = _table[defender] = new ExpireTimer(this, source, defender, duration);
        timer.Start();
    }

    protected abstract void OnTick(BaseCreature source, Mobile defender);

    public void RemoveEffect(Mobile defender)
    {
        if (_table.Remove(defender, out var timer))
        {
            timer.Stop();
        }
    }

    private class ExpireTimer : Timer
    {
        private BaseCreature _source;
        private Mobile _defender;
        private MonsterAbilitySingleTargetDoT _ability;

        public ExpireTimer(
            MonsterAbilitySingleTargetDoT ability,
            BaseCreature source,
            Mobile defender,
            TimeSpan delay
        ) : base(delay)
        {
            _ability = ability;
            _source = source;
            _defender = defender;
        }

        protected void OnTick() => _ability.OnTick(_source, _defender);
    }
}
