using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkDay
{
    [SerializeField] int minimumPowerCount;
    [SerializeField] int maximumPowerCount;
    [SerializeField] bool addsJob;

    public bool AddsJob { get { return addsJob; } }
    // this is used to know wether this work day adds a new job to the pool or not.

    public SuperHero CreateEncounter()
    {
        // TODO: Generate a random hero from this workday's min and max power count.
        return new GameObject().AddComponent<SuperHero>();
    }
}
