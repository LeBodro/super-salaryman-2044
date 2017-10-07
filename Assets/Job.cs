using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Job
{
    [SerializeField] string name;
    [SerializeField] Texture2D icon;
    [SerializeField] SuperPower[] acceptedPowers;
    [SerializeField] SuperPower[] forbiddenPowers;

    public bool IsCompatibleWith(IList<SuperPower> powers)
    {
        return true;
    }
}
