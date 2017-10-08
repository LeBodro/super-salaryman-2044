using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    /* Cette classe a pour destin d'être sur un prefab.
     * Ce prefab agira comme une config manuelle de niveaux pour faciliter le level design.
     * On pourra faire différentes configs si on veut (mettons une par difficulté) et ultimement glisser cette config dans le gamecontroller
     * pour qu'il s'en serve.
     * */
    [SerializeField] Job[] jobs;
    [SerializeField] WorkDay[] days;
    [SerializeField] int maxJobCount;

    public static SuperHero currentHero;

    int currentLevel = 0;
    int jobCount = 0;

    public void StartNext()
    {
        //starts next level
        if (days[currentLevel].AddsJob)
        {
            // add a job to pool            
            Job job = GameController.PickJob();

            // replace a job if we are at the max
            if (jobCount == maxJobCount)
            {
                // we just replace one of the job
                int rand = Random.Range(0, maxJobCount + 1);

                jobs[rand] = job;
            } else
            {
                // we just add the job
                jobs[jobCount] = job;
                jobCount++;
            }
            
            LogJob(job);        
        }

        // create the first encouter
        this.NextEncounter();
    }

    // get the next oppennant, or if the maximum opennent was done then go to the next day
    public void NextEncounter()
    {
        Debug.Log(days[currentLevel].GetHeroCount());

        if (days[currentLevel].GetHeroCount() == 0)
        {
            // we change towartd the new level
            this.EndCurrent();
        } else
        {
            currentHero = days[currentLevel].CreateEncounter();
        }
    }

    public void EndCurrent()
    {
        //ends current level
        currentLevel++;

        // start the next level
        this.StartNext();
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
