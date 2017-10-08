using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear
{
    string key;
    string fearName;
    Sprite icon;

    public Fear(string key, string name)
    {
        this.key = key;
        fearName = name;
        icon = Resources.Load<Sprite>(key);
    }

    public void SetIcon(Sprite sprite)
    {
        icon = sprite;
    }

    public string FearName { get { return fearName; } }

    public Sprite Icon { get { return icon; } }

    void Start()
    {
        Debug.LogError("Fears should stay prefabs and never be instantiated.");
    }

    public string GetKey() { return key;  }
}
