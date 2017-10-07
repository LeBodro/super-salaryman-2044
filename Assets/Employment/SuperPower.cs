using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower
{
    [SerializeField] string powerName;
    [SerializeField] Texture2D icon;

    public SuperPower(string name)
    {
        powerName = name;
    }

    public string Power { get { return powerName; } }

    public Texture2D Icon { get { return icon; } }

    void Start()
    {
        Debug.LogError("SuperPowers should stay prefabs and never be instantiated.");
    }
}
