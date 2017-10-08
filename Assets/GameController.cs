using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] Timer dayTimer;
    [SerializeField] Effect wrong;
    [SerializeField] Effect right;

    [SerializeField] Keyboard keyboard;

    static SuperPower[] listOfPowers;
    static Fear[] listOfFears;
    int playerScore;
    static Hat<Job> jobs;

    IDictionary<string, int> inputMapping = new Dictionary<string, int>();
    IDictionary<string, int> frenchInputs = new Dictionary<string, int>{ { "z", 0 }, { "q", 1 }, { "s", 2 }, { "d", 3 } };
    IDictionary<string, int> canadianInputs = new Dictionary<string, int>{ { "w", 0 }, { "a", 1 }, { "s", 2 }, { "d", 3 } };

    void Start()
    {
        inputMapping = frenchInputs;
        keyboard.SetFrenchUI();

        // create jobs, fears, powers
        InitLists();

        // start the first level
        dayTimer.Begin();
        levelsConfig.StartNext();
        levelsConfig.OnEnd += EndGame; // TODO: Pass endgame method as parameter instead of lambda debug
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
            listOfPowers[i] = new SuperPower(powerData.key, powerData.name, powerData.icon);
            keyToIndexOfPower.Add(powerData.key, i);
            i++;
        }

        i = 0;
        foreach (var fearData in listOfFearsData)
        {
            listOfFears[i] = new Fear(fearData.key, fearData.name, fearData.icon);
            keyToIndexOfFear.Add(fearData.key, i);
            i++;
        }

        foreach (var jobData in listOfJobsData)
        {
            Job job = new Job(jobData.key, jobData.name, jobData.icon);
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
