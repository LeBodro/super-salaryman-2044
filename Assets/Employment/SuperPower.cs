using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperPower
{
    string key;
    string name;
    Sprite icon;

    public SuperPower(string key, string name, string icon)
    {
        this.key = key;
        this.name = name;

        // TODO : Create the sprite depending
        //icon = Resources.Load<Sprite>("SuperPowerIcon/" + icon);
    }

    public void SetIcon(Sprite sprite)
    {
        icon = sprite;
    }

    public string Power { get { return name; } }

    public Sprite Icon { get { return icon; } }

    public string GetKey() { return key; }

}
