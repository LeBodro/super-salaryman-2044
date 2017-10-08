using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkDay
{
    [SerializeField] int minimumPowerCount;
    [SerializeField] int maximumPowerCount;
    [SerializeField] int minimumFearCount;
    [SerializeField] int maximumFearCount;

    [SerializeField] bool addsJob;

    [SerializeField] int heroCount;

    public int HeroCount { get { return heroCount; } }

    public bool AddsJob { get { return addsJob; } }
    // this is used to know whether this work day adds a new job to the pool or not.


    public SuperHero CreateEncounter()
    {
        // TODO : CHECK TO NOT HAVE THE SAME FEAR/POWER MULTIPLE TIMES
        heroCount--;

        SuperHero currentHero = new SuperHero();
        List<int> randomPick = new List<int>();
        int rand;

        int numPower = Random.Range(minimumPowerCount, maximumPowerCount + 1);
        for (int i = 0; i < numPower; i++)
        {
            // get a random index
            do
            {
                rand = Random.Range(0, GameController.GetPowerCount());
            }
            while (randomPick.Contains(rand));
            randomPick.Add(rand);

            currentHero.AddPower(GameController.GetPowerByIndex(rand));
        }

        randomPick.Clear();

        int numFear = Random.Range(minimumFearCount, maximumFearCount + 1);
        for (int i = 0; i < numFear; i++)
        {
            // get a random index
            do
            {
                rand = Random.Range(0, GameController.GetFearCount());
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
