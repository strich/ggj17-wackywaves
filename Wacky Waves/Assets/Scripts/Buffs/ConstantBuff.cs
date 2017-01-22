using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantBuff : Buff
{
	public ConstantBuff(float modifier) : base (modifier) { }

	public override float Modify(float value)
	{
		return value + _Modifier;
	}
}
