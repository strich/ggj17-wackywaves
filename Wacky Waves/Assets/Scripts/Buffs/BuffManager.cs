using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public const string KEY_LOCAL_SPEED = "KEY_LOCAL_SPEED";
    public const string KEY_GLOBAL_SPEED = "KEY_GLOBAL_SPEED";

    public Dictionary<string, List<Buff>> _Buffs = new Dictionary<string, List<Buff>>();

    public void AddBuff(string key, Buff buff)
    {
        if (!_Buffs.ContainsKey(key))
        {
            _Buffs.Add(key, new List<Buff>());
        }

        _Buffs[key].Add(buff);
    }

    public void RemoveBuff(string key, Buff buff)
    {
        if (!_Buffs.ContainsKey(key))
        {
            Debug.LogErrorFormat("No buff with key {0}", key);
        }
        else
        {
            _Buffs[key].Remove(buff);
        }
    }

    public float Modify(string key, float value)
    {
        if (!_Buffs.ContainsKey(key))
        {
            Debug.LogFormat("No buff with key {0}", key);
            _Buffs.Add(key, new List<Buff>());
        }

        return Modify(_Buffs[key], value);
    }

    public void Wipe(string key)
    {
        if (!_Buffs.ContainsKey(key))
        {
            Debug.LogFormat("No buff with key {0}", key);
        }
        else
        {
            _Buffs[key].Clear();
        }
    }

    float Modify(List<Buff> buffs, float value)
    {
        for (int i = 0; i < buffs.Count; ++i)
        {
            value = buffs[i].Modify(value);
        }
        return value;
    }
}
