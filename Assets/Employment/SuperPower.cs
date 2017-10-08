using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperPower
{
    string name;
    Sprite icon;

    public SuperPower(string name)
    {
        this.name = name;
    }

    public void SetIcon(Sprite sprite)
    {
        icon = sprite;
    }

    public string Power { get { return name; } }

    public Sprite Icon { get { return icon; } }
}
