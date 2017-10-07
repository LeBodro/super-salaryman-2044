using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Job
{
    [SerializeField] string name;
    [SerializeField] Texture2D icon;
    [SerializeField] List<SuperPower> acceptedPowers;
    [SerializeField] List<Fear> forbiddenFears;

    public Job(string JobName)
    {
        name = JobName;
    }

    public void AddPower(SuperPower power)
    {
        acceptedPowers.Add(power);
    }

    public void Add(Fear fear)
    {
        forbiddenFears.Add(fear);
    }

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
