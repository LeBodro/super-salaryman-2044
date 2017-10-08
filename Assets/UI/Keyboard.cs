using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
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
}
