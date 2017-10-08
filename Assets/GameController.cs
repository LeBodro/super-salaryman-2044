using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] Timer dayTimer;
    [SerializeField] Effect wrong;
    [SerializeField] Effect right;

    static SuperPower[] listOfPowers;
    static Fear[] listOfFears;
    int playerScore;
    static Hat<Job> jobs;

    IDictionary<string, int> inputMapping = new Dictionary<string, int>();
    IDictionary<string, int> frenchInputs = new Dictionary<string, int>{ { "z",0 }, { "q", 1 }, { "s", 2 }, { "d", 3 } };
    IDictionary<string, int> canadianInputs = new Dictionary<string, int>{ { "w",0 }, { "a", 1 }, { "s", 2 }, { "d", 3 } };

    // Use this for initialization
    void Start()
    {
        dayTimer.Begin();
        // create jobs, fears, powers
        InitLists();

        //initialisation logic
        inputMapping = frenchInputs;

        // start the first level
        levelsConfig.StartNext();

        //dayTest = new WorkDay();
        //dayTest.SelectJobs();
        //currentHero = dayTest.CreateEncounter();
    }

    // METHODS
    void InitLists()
    {
        listOfPowers = new SuperPower[5];
        listOfFears = new Fear[5];
        jobs = new Hat<Job>();

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
        jobs.Put(job1);

        Job job2 = new Job("B");
        job2.AddPower(listOfPowers[0]);
        job2.AddFear(listOfFears[2]);
        jobs.Put(job2);

        Job job3 = new Job("C");
        job2.AddPower(listOfPowers[1]);
        job2.AddFear(listOfFears[0]);
        jobs.Put(job3);

        Job job4 = new Job("D");
        job2.AddPower(listOfPowers[1]);
        job2.AddFear(listOfFears[0]);
        jobs.Put(job3);
    }

    bool aHeroWasChosen = false;
    bool isCompatible = false;
    // Update is called once per frame
    void Update()
    {

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
            }
            else
            {
                wrong.Play();
            }
            print("Next Encounter");
            levelsConfig.NextEncounter();

            aHeroWasChosen = false;
        }
    }

    void ProcessKeyInput(string key, int jobId)
    {
        if (Input.GetKeyDown(key) && levelsConfig.GetCurrentJobCount() > jobId)
        {
            aHeroWasChosen = true;

            Job job = levelsConfig.KeyToJob(jobId);
            isCompatible = job.IsCompatibleWith(levelsConfig.GetSuperHero());
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
