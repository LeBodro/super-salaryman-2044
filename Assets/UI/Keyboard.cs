using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard
{
    [SerializeField] Text up;
    [SerializeField] Text right;
    [SerializeField] Text down;
    [SerializeField] Text left;

    public void SetFrenchUI()
    {
        up.text = "Z";
        right.text = "D";
        down.text = "S";
        left.text = "Q";
    }

    public void SetCanadianUI()
    {
        up.text = "W";
        right.text = "D";
        down.text = "S";
        left.text = "A";
    }

    /*
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    */
}
