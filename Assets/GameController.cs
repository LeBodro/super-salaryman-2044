using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    // for flashing red when you're wrong
    bool isWrong = false;
    public Image wrongImage;
    public float flashSpeed = 20f;
    public Color wrongColour = new Color(1f, 0f, 0f, 0.1f);
    //public Color rightColour = new Color(0f, 0f, 1f, 0.1f);


    // GETTERS 
    public static int GetNumJobs()
    {
        return listOfJobs.Length;
    }

    public static int GetNumPowers()
    {
        return listOfPowers.Length;
    }

    public static int GetNumFears()
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
    void Start () {
        // create jobs, fears, powers
        InitLists();

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
                isWrong = true;
            }
            print("Next Encounter");
            currentHero = dayTest.CreateEncounter();
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

}
