using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Job
{
    [SerializeField] string name;
    [SerializeField] Texture2D icon;
    [SerializeField] SuperPower[] acceptedPowers;
    [SerializeField] Fear[] forbiddenFears;

    public bool IsCompatibleWith(List<SuperPower> powers, List<Fear> fears)
    {
        foreach (var fear in forbiddenFears)
        {
            if (fears.Contains(fear))
            {   
                return false;
            }
        }
        foreach (var power in acceptedPowers)
        {
            if (powers.Contains(power))
            {
                return true;
            }
        }
        return false;
    }
}
