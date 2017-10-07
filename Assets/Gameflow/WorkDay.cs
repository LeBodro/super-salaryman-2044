using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkDay
{
    [SerializeField] int minimumPowerCount = 1;
    [SerializeField] int maximumPowerCount = 2;
    [SerializeField] int minimumFearCount = 1;
    [SerializeField] int maximumFearCount = 2;

    [SerializeField] Job[] todayJobs;
    //[SerializeField] bool addsJob;
    [SerializeField] int numJobs = 2;

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

            string powersString = "";
            foreach (var p in todayJobs[i].GetPowers())
            {
                powersString += " " + p.Power;
            }

            string fearsString = "";
            foreach (var fear in todayJobs[i].GetFears())
            {
                fearsString += " " + fear.FearName;
            }
            Debug.Log("job choisi : " + todayJobs[i].GetName() + " / " + powersString + " / " + fearsString);
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

        /// TO REMVOVE
        string powersString = "";
        foreach (var p in currentHero.GetPowers())
        {
            powersString += " " + p.Power;
        }

        string fearsString = "";
        foreach (var fear in currentHero.GetFears())
        {
            fearsString += " " + fear.FearName;
        }

        Debug.Log("Un nouveau héros se présente à vous, ses pouvoirs sont : " + powersString + ", ses peurs : " + fearsString);

        return currentHero;
    }
}
