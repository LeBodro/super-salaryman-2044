using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperPower
{
    string key;
    string name;
    Sprite icon;

    public SuperPower(string key, string name)
    {
        this.key = key;
        this.name = name;
        icon = Resources.Load<Sprite>(key);
    }

    public void SetIcon(Sprite sprite)
    {
        icon = sprite;
    }

    public string Power { get { return name; } }

    public Sprite Icon { get { return icon; } }

    public string GetKey() { return key; }

}
