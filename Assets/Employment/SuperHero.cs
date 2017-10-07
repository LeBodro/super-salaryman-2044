using UnityEngine;
using System.Collections.Generic;
using System;

public class SuperHero
{
    [SerializeField] List<SuperPower> powers;
    [SerializeField] List<Fear> fears;
    //[SerializeField] string Name;

    public SuperHero()
    {
        powers = new List<SuperPower>();
        fears = new List<Fear>();
    }

    public void AddPower(SuperPower power) {
        powers.Add(power);
    }

    public void AddFear(Fear fear) {
        fears.Add(fear);
    }

    public List<SuperPower> GetPowers()
    {
        return powers;
    }

    public List<Fear> GetFears()
    {
        return fears;
    }
}
