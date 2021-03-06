﻿using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] Effect wrong;
    [SerializeField] Effect right;

    [SerializeField] Keyboard keyboard;

    static SuperPower[] listOfPowers;
    static Fear[] listOfFears;
    int playerScore;
    static Hat<Job> jobs;

    IDictionary<string, int> inputMapping = new Dictionary<string, int>();
    IDictionary<string, int> frenchInputs = new Dictionary<string, int>{ { "z", 0 }, { "q", 1 }, { "s", 2 }, { "d", 3 }, { "x", 0 } };
    IDictionary<string, int> canadianInputs = new Dictionary<string, int>{ { "w", 0 }, { "a", 1 }, { "s", 2 }, { "d", 3 }, { "x", 0 } };

    void Start()
    {
        inputMapping = frenchInputs;
        keyboard.SetFrenchUI();

        // create jobs, fears, powers
        InitLists();

        // start the first level
        levelsConfig.StartNext();
        levelsConfig.OnEnd += EndGame; // TODO: Pass endgame method as parameter instead of lambda debug
        StartCoroutine(DelayedPlayMusic());
    }

    IEnumerator DelayedPlayMusic()
    {
        yield return null;
        yield return null;
        CrackleAudio.SoundController.PlayMusic("main");
    }

    void EndGame()
    {
        Debug.Log("END GAME");
    }

    void InitLists()
    {
        // Get the data from the JSON File
        var json = new GameData();
        List<PowerData> listofPowersData = json.LoadPowersData();        
        List<FearData> listOfFearsData = json.LoadFearsData();        
        List<JobData> listOfJobsData = json.LoadJobData();

        // to key the position of each powers in the tab, using the key
        Dictionary<string, int> keyToIndexOfPower = new Dictionary<string, int>();
        Dictionary<string, int> keyToIndexOfFear = new Dictionary<string, int>();

        // Create all the lists
        listOfPowers = new SuperPower[listofPowersData.Count];
        listOfFears = new Fear[listOfFearsData.Count];
        jobs = new Hat<Job>();

        // Fill the list with the data
        int i = 0;
        foreach (var powerData in listofPowersData)
        { 
            listOfPowers[i] = new SuperPower(powerData.key, powerData.name);
            keyToIndexOfPower.Add(powerData.key, i);
            i++;
        }

        i = 0;
        foreach (var fearData in listOfFearsData)
        {
            listOfFears[i] = new Fear(fearData.key, fearData.name);
            keyToIndexOfFear.Add(fearData.key, i);
            i++;
        }

        foreach (var jobData in listOfJobsData)
        {
            Job job = new Job(jobData.key, jobData.name);
            foreach (var powerKey in jobData.acceptedPowers)
            {
                job.AddPower(listOfPowers[keyToIndexOfPower[powerKey]]);
            }

            foreach (var fearKey in jobData.forbiddenFears)
            {
                job.AddFear(listOfFears[keyToIndexOfFear[fearKey]]);
            }

            jobs.Put(job);
        }
    }

    bool aHeroWasChosen = false;
    bool isCompatible = false;
    // Update is called once per frame
    void Update()
    {
        // TODO: Input processing should be in its own class. Game controller may have a reference to pass along information.
        // HACK: kind of hack to stop receiving inputs once game ended.
        if (levelsConfig.Ended || !levelsConfig.IsPlaying)
            return;
        
        // depending on the touch pressed by the player the superhero is sent to a different job
        foreach (var input in inputMapping)
        {
            ProcessKeyInput(input.Key, input.Value);
        }

        if (aHeroWasChosen)
        {
            if (isCompatible)
            {
                CrackleAudio.SoundController.PlaySound("right");
                levelsConfig.scoreManager.ScoreRightAnswer();
            }
            else
            {
                wrong.Play();
                levelsConfig.scoreManager.ScoreWrongAnswer();
            }
            print("Next Encounter");
            levelsConfig.NextEncounter();

            aHeroWasChosen = false;
        }
    }

    void ProcessKeyInput(string key, int jobId)
    {
        if (Input.GetKeyDown(key))
        {
            aHeroWasChosen = true;

            // if we press the delete button
            if (key.Equals("x"))
            {                
                // then we try for all the job
                // by default we say, it's ok for the trash
                isCompatible = true;

                foreach (var input in inputMapping)
                {
                    Job job = levelsConfig.KeyToJob(jobId);
                    // if there is a job compatible, then the trash is not ok -> iCompatible = False
                    if (job.IsCompatibleWith(levelsConfig.GetSuperHero()))
                    {
                        isCompatible = false;
                        break;
                    }
                }          

            }
            else if (levelsConfig.GetCurrentJobCount() > jobId)
            {
                // if it's a normal key
                Job job = levelsConfig.KeyToJob(jobId);
                isCompatible = job.IsCompatibleWith(levelsConfig.GetSuperHero());
            }         
        }
    }

    // GETTERS
    public static int GetJobCount()
    {
        return jobs.Count;
    }

    public static int GetPowerCount()
    {
        return listOfPowers.Length;
    }

    public static int GetFearCount()
    {
        return listOfFears.Length;
    }

    public static Job PickJob()
    {
        return jobs.Pick();
    }

    public static SuperPower GetPowerByIndex(int i)
    {
        return listOfPowers[i];
    }

    public static Fear GetFearByIndex(int i)
    {
        return listOfFears[i];
    }
}
