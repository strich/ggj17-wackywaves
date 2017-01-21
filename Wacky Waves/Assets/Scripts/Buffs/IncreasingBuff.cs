using System;
using UnityEngine;

public class IncreasingBuff : Buff
{
    //NOTE: This is the best name variable you'll ever see
    protected float _ModifierModifier;
    protected float _Cap;

    public IncreasingBuff(float modifier, float modifierModifier, float cap) : base (modifier)
    {
        _ModifierModifier = modifierModifier;
        _Cap = cap;
    }

    public override float Modify(float value)
    {
        value = value * _Modifier;
        _Modifier = Mathf.Min(_Cap, _Modifier * _ModifierModifier);
        return value;
    }
}
