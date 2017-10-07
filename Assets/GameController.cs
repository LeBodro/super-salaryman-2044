using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] static Job[] listOfJobs;
    [SerializeField] static SuperPower[] listOfPowers;
    [SerializeField] static Fear[] listOfFears;
    int playerScore;

    WorkDay dayTest;
    SuperHero currentHero;

    // randomly choose a job within the listOfJobs
    public static Job GetRandomJob()
    {
        return listOfJobs[(int)Random.Range(0.0f, listOfJobs.Length)];
    }

    // randomly choose a superpower within the listOfPowers
    public static SuperPower GetRandomPower()
    {
        return listOfPowers[(int)Random.Range(0.0f, listOfPowers.Length)];
    }

    // randomly choose a fear within the listOfFears
    public static Fear GetRandomFear()
    {
        return listOfFears[(int)Random.Range(0.0f, listOfFears.Length)];
    }

    // Use this for initialization
    void Start () {
        //initialisation logic
        dayTest = new WorkDay();
        dayTest.SelectJobs();
        currentHero = dayTest.CreateEncounter();
    }

    // Update is called once per frame
    void Update () {
        bool isCompatible = false;
        bool hasInput = false;

        // depending on the touch pressed by the player the superhero is sent to a different job
        if (Input.GetKeyDown("z") && dayTest.GetNumJobs() > 0)
        {
            hasInput = true;
            Job job = dayTest.KeyToJob(0);
            isCompatible = job.IsCompatibleWith(currentHero);
        }
        if (Input.GetKeyDown("q") && dayTest.GetNumJobs() > 1)
        {
            hasInput = true;
            Job job = dayTest.KeyToJob(1);
            isCompatible = job.IsCompatibleWith(currentHero);
        }
        if (Input.GetKeyDown("s") && dayTest.GetNumJobs() > 2)
        {
            hasInput = true;
            Job job = dayTest.KeyToJob(2);
            isCompatible = job.IsCompatibleWith(currentHero);
        }
        if (Input.GetKeyDown("d") && dayTest.GetNumJobs() > 3)
        {
            hasInput = true;
            Job job = dayTest.KeyToJob(3);
            isCompatible = job.IsCompatibleWith(currentHero);
        }

        if (hasInput)
        {
            if (isCompatible)
            {
                print("SUCCESS");
            }
            else
            {
                print("WRONG JOB");
            }
            print("Next Encounter");
            currentHero = dayTest.CreateEncounter();
        }
    }

}
