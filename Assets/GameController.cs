using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] Job[] listOfJobs;
    [SerializeField] SuperPower[] listOfPowers;

    public Job GetRandomJob()
    {
        return listOfJobs[1];
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
