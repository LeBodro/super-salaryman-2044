using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkDay
{
    [SerializeField] int minimumPowerCount;
    [SerializeField] int maximumPowerCount;
    [SerializeField] Job[] todayJobs;
    //[SerializeField] bool addsJob;
    [SerializeField] static int numJobs;

    [SerializeField] static Hashtable jobToKey;

    [SerializeField] static string[] keyTabs = { "z", "q", "s", "d" };

    //public bool AddsJob { get { return addsJob; } }
    // this is used to know whether this work day adds a new job to the pool or not.

    public static void AddAJob() { numJobs++; }

    public void SelectJobs()
    {
        // init size tab
        todayJobs = new Job[numJobs];
        // reset the hashtab of the jobToKey
        jobToKey = new Hashtable();

        for(int i=0; i<numJobs; i++)
        {
            //get a job and associate it with a key
            todayJobs[i] = (GameController.GetRandomJob());
            // link a job to a key
            jobToKey.Add(keyTabs[i], todayJobs[i]);
        }
    }

    public SuperHero CreateEncounter()
    {
        // TODO: Generate a random hero from this workday's min and max power count.
        return new GameObject().AddComponent<SuperHero>();
    }
}
