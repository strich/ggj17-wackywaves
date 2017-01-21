using System;
using UnityEngine;

public class DecreasingBuff : Buff
{
    //NOTE: This is the best name variable you'll ever see
    protected float _ModifierModifier;

    public DecreasingBuff(float modifier, float modifierModifier) : base (modifier)
    {
        _ModifierModifier = modifierModifier;
    }

    public override float Modify(float value)
    {
        value = value * _Modifier;
        _Modifier = Mathf.Max(1f, _Modifier * _ModifierModifier);
        return value;
    }
}
