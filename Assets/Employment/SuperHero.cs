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

    void Start()
    {
		
    }
}
