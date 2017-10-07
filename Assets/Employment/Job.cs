using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Job
{
    [SerializeField] string name;
    [SerializeField] Texture2D icon;
    [SerializeField] SuperPower[] acceptedPowers;
    [SerializeField] Fear[] forbiddenFears;

    public bool IsCompatibleWith(SuperHero hero)
    {
        foreach (var fear in forbiddenFears)
        {
            if (hero.GetFears().Contains(fear))
            {   
                return false;
            }
        }
        foreach (var power in acceptedPowers)
        {
            if (hero.GetPowers().Contains(power))
            {
                return true;
            }
        }
        return false;
    }
}
