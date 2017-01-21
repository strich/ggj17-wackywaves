using System;
using UnityEngine;

public class Buff
{
    protected float _Modifier;

    public Buff(float modifier)
    {
        _Modifier = modifier;
    }

    public virtual float Modify(float value)
    {
        return value * _Modifier;
    }
}
