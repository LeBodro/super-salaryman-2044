using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPower : MonoBehaviour
{
    [SerializeField] string power;
    [SerializeField] Texture2D icon;

    public string Power { get { return power; } }

    public Texture2D Icon { get { return icon; } }

    void Start()
    {
        Debug.LogError("SuperPowers should stay prefabs and never be instantiated.");
    }
}
