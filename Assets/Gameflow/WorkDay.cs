﻿using System.Collections;
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
    [SerializeField] bool addsJob;
    [SerializeField] int numJobs = 2;

    public int GetJobCount()
    {
        return numJobs;
    }

    public bool AddsJob { get { return addsJob; } }
    // this is used to know whether this work day adds a new job to the pool or not.

    public Job KeyToJob(int index)
    {
        return todayJobs[index];
    }

    public void AddAJob()
    {
        numJobs++;
    }

    // TODO : CHECK TO NOT HAVE THE SAME JOB MULTIPLE TIMES
    public void SelectJobs()
    {
        // init size tab
        todayJobs = new Job[numJobs];

        for (int i = 0; i < numJobs; i++)
        {
            todayJobs[i] = (GameController.PickJob());

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
        List<int> randomPick = new List<int>();
        int rand;

        int numPower = (int)Random.Range(minimumPowerCount, maximumPowerCount + 1);
        for (int i = 0; i < numPower; i++)
        {
            // get a random index
            do
            {
                rand = (int)Random.Range(0.0f, GameController.GetPowerCount());
            }
            while (randomPick.Contains(rand));
            randomPick.Add(rand);

            currentHero.AddPower(GameController.GetPowerByIndex(rand));
        }

        randomPick.Clear();

        int numFear = (int)Random.Range(minimumFearCount, maximumFearCount + 1);
        for (int i = 0; i < numFear; i++)
        {
            // get a random index
            do
            {
                rand = (int)Random.Range(0.0f, GameController.GetFearCount());
            }
            while (randomPick.Contains(rand));
            randomPick.Add(rand);

            currentHero.AddFear(GameController.GetFearByIndex(rand));
        }

        Log(currentHero);

        return currentHero;
    }

    static void Log(SuperHero currentHero)
    {
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
    }


}
