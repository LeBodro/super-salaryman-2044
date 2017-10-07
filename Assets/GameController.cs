using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] static Job[] listOfJobs;
    [SerializeField] static SuperPower[] listOfPowers;
    int playerScore;

    // randomly choose a job within the listOfJobs
    public static Job GetRandomJob()
    {
        return listOfJobs[(int)Random.Range(0.0f, listOfJobs.Length)];
    }

    // Use this for initialization
    void Start () {
        //initialisation logic
    }

    // Update is called once per frame
    void Update () {
		
	}

}
