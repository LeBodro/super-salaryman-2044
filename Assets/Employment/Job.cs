using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Job
{
    string key;
    string name;
    Sprite icon;
    List<SuperPower> acceptedPowers;
    List<Fear> forbiddenFears;

    public Job(string key, string JobName, string icon)
    {
        this.key = key;
        name = JobName;

        //TODO : icon gestion same as the other
        acceptedPowers = new List<SuperPower>();
        forbiddenFears = new List<Fear>();
    }

    public string GetKey() { return key; }

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
