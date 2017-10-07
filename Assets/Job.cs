using UnityEngine;

[System.Serializable]
public class Job : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Texture2D icon;
    [SerializeField] SuperPower[] acceptedPowers;
    [SerializeField] SuperPower[] forbiddenPowers;
}
