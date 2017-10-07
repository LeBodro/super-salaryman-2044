using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkDay
{
    [SerializeField] int minimumPowerCount;
    [SerializeField] int maximumPowerCount;
    [SerializeField] int minimumFearCount;
    [SerializeField] int maximumFearCount;

    [SerializeField] Job[] todayJobs;
    //[SerializeField] bool addsJob;
    [SerializeField] int numJobs = 1;

    public int GetNumJobs()
    {
        return numJobs;
    }

    //public bool AddsJob { get { return addsJob; } }
    // this is used to know whether this work day adds a new job to the pool or not.

    public Job KeyToJob(int index)
    {
        return todayJobs[index];
    }

    public void AddAJob() { numJobs++; }

    // TODO : CHECK TO NOT HAVE THE SAME JOB MULTIPLE TIMES
    public void SelectJobs()
    {
        // init size tab
        todayJobs = new Job[numJobs];

        for(int i=0; i<numJobs; i++)
        {
            //get a job and associate it with a key
            todayJobs[i] = (GameController.GetRandomJob());
            Debug.Log("job choisi : " + todayJobs[i].GetName() + " / " + todayJobs[i].GetPowers() + " / " + todayJobs[i].GetFears());
        }
    }

    public SuperHero CreateEncounter()
    {
        // TODO : CHECK TO NOT HAVE THE SAME FEAR/POWER MULTIPLE TIMES
        SuperHero currentHero = new SuperHero();
        int numPower = (int)Random.Range(minimumPowerCount, maximumPowerCount + 1);
        for (int i=0; i<numPower; i++)
        {
            currentHero.AddPower(GameController.GetRandomPower());
        }

        int numFear = (int)Random.Range(minimumFearCount, maximumFearCount + 1);
        for (int i = 0; i < numFear; i++)
        {
            currentHero.AddFear(GameController.GetRandomFear());
        }


        Debug.Log("Un nouveau héros se présente à vous " + currentHero.name + ", ses pouvoirs sont : " + currentHero.GetPowers() + ", ses peurs : " + currentHero.GetFears());

        return currentHero;
    }
}
