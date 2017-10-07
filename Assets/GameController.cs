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
    IDictionary<string, int> inputMapping = new Dictionary<string, int>();
    IDictionary<string, int> frenchInputs = new Dictionary<string, int>{ { "z",0 }, { "q", 1 }, { "s", 2 }, { "d", 3 } };
    IDictionary<string, int> canadianInputs = new Dictionary<string, int>{ { "w",0 }, { "a", 1 }, { "s", 2 }, { "d", 3 } };

    // GETTERS
    public static int GetJobCount()
    {
        return listOfJobs.Length;
    }

    public static int GetPowerCount()
    {
        return listOfPowers.Length;
    }

    public static int GetFearCount()
    {
        return listOfFears.Length;
    }

    public static Job GetJobByIndex(int i)
    {
        return listOfJobs[i];
    }

    public static SuperPower GetPowerByIndex(int i)
    {
        return listOfPowers[i];
    }

    public static Fear GetFearByIndex(int i)
    {
        return listOfFears[i];
    }


    // METHODS

    void InitLists()
    {
        listOfPowers = new SuperPower[5];
        listOfFears = new Fear[5];
        listOfJobs = new Job[2];

        listOfPowers[0] = new SuperPower("Télépathie");
        listOfPowers[1] = new SuperPower("Invisibilité");
        listOfPowers[2] = new SuperPower("Vole");
        listOfPowers[3] = new SuperPower("Gèle");
        listOfPowers[4] = new SuperPower("Embrasement");

        listOfFears[0] = new Fear("Achluophobie");
        listOfFears[1] = new Fear("Agoraphobie");
        listOfFears[2] = new Fear("Apéirophobie");
        listOfFears[3] = new Fear("Arithmophobie");
        listOfFears[4] = new Fear("Athazagoraphobie");

        Job job1 = new Job("A");
        job1.AddPower(listOfPowers[2]);
        job1.AddFear(listOfFears[3]);
        listOfJobs[0] = job1;

        Job job2 = new Job("B");
        job2.AddPower(listOfPowers[0]);
        job2.AddFear(listOfFears[2]);
        listOfJobs[1] = job2;
    }

    // Use this for initialization
    void Start()
    {
        // create jobs, fears, powers
        InitLists();

        //initialisation logic
        inputMapping = frenchInputs;
        dayTest = new WorkDay();
        dayTest.SelectJobs();
        currentHero = dayTest.CreateEncounter();
    }

    bool hasInput = false;
    bool isCompatible = false;
    // Update is called once per frame
    void Update()
    {

        // depending on the touch pressed by the player the superhero is sent to a different job
        foreach (var input in inputMapping)
        {
            ProcessKeyInput(input.Key, input.Value);
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
            hasInput = false;
        }
    }

    void ProcessKeyInput(string key, int jobId)
    {
        if (Input.GetKeyDown(key) && dayTest.GetJobCount() > jobId)
        {
            hasInput = true;
            Job job = dayTest.KeyToJob(jobId);
            isCompatible = job.IsCompatibleWith(currentHero);
        }
    }
}
