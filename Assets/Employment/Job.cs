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
        acceptedPowers = new List<SuperPower>();
        forbiddenFears = new List<Fear>();
    }

    public void AddPower(SuperPower power)
    {
        acceptedPowers.Add(power);
    }

    public void AddFear(Fear fear)
    {
        forbiddenFears.Add(fear);
    }

    public string GetName()
    {
        return name;
    }

    public List<SuperPower> GetPowers()
    {
        return acceptedPowers;
    }

    public List<Fear> GetFears()
    {
        return forbiddenFears;
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
