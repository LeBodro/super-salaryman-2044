using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Job
{
    [SerializeField] string name;
    [SerializeField] Texture2D icon;
    [SerializeField] SuperPower[] acceptedPowers;
    [SerializeField] SuperPower[] forbiddenPowers;

    public bool IsCompatibleWith(List<SuperPower> powers)
    {
        bool isCompatible;
        foreach (var power in forbiddenPowers)
        {
            if (powers.Contains(power))
            {   
                isCompatible = false;
            }
        }
        foreach (var power in acceptedPowers)
        {
            if (powers.Contains(power))
            {
                isCompatible = true;
            }
        }
        isCompatible = false;
        return isCompatible;
    }
}
