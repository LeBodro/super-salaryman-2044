﻿using UnityEngine;
using System.Collections.Generic;

public class Levels : MonoBehaviour
{
    [SerializeField] WorkDay[] days;
    [SerializeField] int maxJobCount;
    [SerializeField] GameObject nextLevelInstruction;

    IList<Job> jobs = new List<Job>();
    public static SuperHero currentHero;

    int currentLevel = 0;
    bool waitForNextLevelInput;

    int jobCount { get { return jobs.Count; } }

    public bool Ended { get { return currentLevel == days.Length; } }

    event System.Action _onEnd = delegate {};

    public event System.Action OnEnd
    {
        add { _onEnd += value; }
        remove { _onEnd -= value; }
    }

    public void StartNext()
    {
        if (days[currentLevel].AddsJob)
        {      
            Job newJob = GameController.PickJob();

            if (jobCount == maxJobCount)
            {
                int replacedJob = Random.Range(0, jobCount);
                jobs[replacedJob] = newJob;
            }
            else
            {
                jobs.Add(newJob);
            }
            
            LogJob(newJob);        
        }

        // create the first encouter
        NextEncounter();
    }

    // get the next oppennant, or if the maximum opennent was done then go to the next day
    public void NextEncounter()
    {
        Debug.Log(days[currentLevel].HeroCount);

        if (days[currentLevel].HeroCount == 0)
        {
            // we change towartd the new level
            EndCurrent();
        }
        else
        {
            currentHero = days[currentLevel].CreateEncounter();
        }
    }

    public void EndCurrent()
    {
        //ends current level
        currentLevel++;

        // start the next level
        if (currentLevel < days.Length)
        {   
            waitForNextLevelInput = true;
            if (nextLevelInstruction != null)
                nextLevelInstruction.SetActive(true);
        }
        else
        {
            _onEnd();
        }
    }

    void Update()
    {
        if (waitForNextLevelInput && Input.GetKeyDown(KeyCode.Space))
        {
            waitForNextLevelInput = false;
            StartNext();
            if (nextLevelInstruction != null)
                nextLevelInstruction.SetActive(false);
        }
    }

    public int GetCurrentJobCount()
    {
        return jobCount;
    }

    public WorkDay GetCurrentDay()
    {
        return days[currentLevel];
    }

    public SuperHero GetSuperHero()
    {
        return currentHero;
    }

    public Job KeyToJob(int index)
    {
        return jobs[index];
    }

    public void LogJob(Job job)
    {
        string powersString = "";
        foreach (var p in job.GetPowers())
        {
            powersString += " " + p.Power;
        }

        string fearsString = "";
        foreach (var fear in job.GetFears())
        {
            fearsString += " " + fear.FearName;
        }
        Debug.Log("job choisi : " + job.GetName() + " / " + powersString + " / " + fearsString);
    }
}
