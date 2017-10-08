using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperPower
{
    string powerName;
    Sprite icon;

    public SuperPower(string name)
    {
        this.powerName = name;
    }

    public void SetIcon(Sprite sprite)
    {
        icon = sprite;
    }

    public string Power { get { return powerName; } }

    public Sprite Icon { get { return icon; } }
}
