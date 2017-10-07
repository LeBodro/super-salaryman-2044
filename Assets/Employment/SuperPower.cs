using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower
{
    string name;
    Texture2D icon;

    public SuperPower(string name)
    {
        this.name = name;
    }

    public string Power { get { return name; } }

    public Texture2D Icon { get { return icon; } }
}
