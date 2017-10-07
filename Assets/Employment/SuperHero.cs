using UnityEngine;
using System.Collections.Generic;

public class SuperHero : MonoBehaviour
{
    [SerializeField] List<SuperPower> powers;
    [SerializeField] List<Fear> fears;
    //[SerializeField] string Name;

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

    void Start()
    {
		
    }
}
