using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear
{
    [SerializeField] string fearName;
    [SerializeField] Sprite icon;

    public Fear(string name)
    {
        fearName = name;
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
}
