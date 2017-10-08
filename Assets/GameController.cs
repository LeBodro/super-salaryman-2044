using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] Timer dayTimer;

    static SuperPower[] listOfPowers;
    static Fear[] listOfFears;
    int playerScore;
    static Hat<Job> jobs;

    WorkDay dayTest;
    SuperHero currentHero;
    IDictionary<string, int> inputMapping = new Dictionary<string, int>();
    IDictionary<string, int> frenchInputs = new Dictionary<string, int>{ { "z",0 }, { "q", 1 }, { "s", 2 }, { "d", 3 } };
    IDictionary<string, int> canadianInputs = new Dictionary<string, int>{ { "w",0 }, { "a", 1 }, { "s", 2 }, { "d", 3 } };

    // for flashing red when you're wrong
    bool isWrong = false;
    public Image wrongImage;
    public float flashSpeed = 20f;
    public Color wrongColour = new Color(1f, 0f, 0f, 0.1f);
    //public Color rightColour = new Color(0f, 0f, 1f, 0.1f);

    // audio
    AudioSource gameAudio;
    public AudioClip rightClip;
    public AudioClip wrongClip;

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
    }

    // Use this for initialization
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();

        // create jobs, fears, powers
        InitLists();

        //initialisation logic
        inputMapping = frenchInputs;
        dayTest = new WorkDay();
        dayTest.SelectJobs();
        currentHero = dayTest.CreateEncounter();
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
                gameAudio.clip = rightClip;
                gameAudio.Play();
            }
            else
            {
                gameAudio.clip = wrongClip;
                gameAudio.Play();
                isWrong = true;
            }
            print("Next Encounter");
            currentHero = dayTest.CreateEncounter();
            aHeroWasChosen = false;
        }

        // for red flash
        if (isWrong)
        {
            wrongImage.color = wrongColour;
            isWrong = false;
        }
        else
        {
            wrongImage.color = Color.Lerp(wrongImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
    }

    void ProcessKeyInput(string key, int jobId)
    {
        if (Input.GetKeyDown(key) && dayTest.GetJobCount() > jobId)
        {
            aHeroWasChosen = true;
            Job job = dayTest.KeyToJob(jobId);
            isCompatible = job.IsCompatibleWith(currentHero);
        }
    }
}
