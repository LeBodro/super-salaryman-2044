using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public string Power { get { return name; } }

    public Sprite Icon { get { return icon; } }

    public string GetKey() { return key; }
}
