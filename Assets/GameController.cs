using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Levels levelsConfig;
    [SerializeField] static Job[] listOfJobs;
    [SerializeField] static SuperPower[] listOfPowers;
    int playerScore;

    public static Job GetRandomJob()
    {
        return listOfJobs[1];
    }

    // Use this for initialization
    void Start () {
        //initialisation logic
    }

    // Update is called once per frame
    void Update () {
		
	}

}
