﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear : MonoBehaviour {

    [SerializeField] string fearName;
    [SerializeField] Texture2D icon;

    public string FearName { get { return fearName; } }

    public Texture2D Icon { get { return icon; } }

    void Start()
    {
        Debug.LogError("Fears should stay prefabs and never be instantiated.");
    }
}