using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [SerializeField] Text up;
    [SerializeField] Image upIcon;

    [SerializeField] Text right;
    [SerializeField] Image rIcon;

    [SerializeField] Text down;
    [SerializeField] Image dIcon;

    [SerializeField] Text left;
    [SerializeField] Image lIcon;

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
