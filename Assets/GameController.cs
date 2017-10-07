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

    // randomly choose a superpower within the listOfPowers
    public static Fear GetRandomFear()
    {
        return listOfFears[(int)Random.Range(0.0f, listOfFears.Length)];
    }

    // Use this for initialization
    void Start () {
        //initialisation logic
    }

    // Update is called once per frame
    void Update () {
		
	}

}
