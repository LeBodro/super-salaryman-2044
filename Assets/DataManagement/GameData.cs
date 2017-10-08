using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData
{
    string powersFile = "powers.json";
    string fearsFile = "fears.json";
    string jobsFile = "jobs.json";

    public List<PowerData> powers = new List<PowerData>();



    public List<PowerData> LoadGameData(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            string[] allJsonObjects = dataAsJson.Split('/');

            foreach (string json in allJsonObjects)
            {
                powers.Add(JsonUtility.FromJson<PowerData>(json));
            }
        }
        else
        {
            Debug.LogError("Cannot load game data!");
            throw new System.ArgumentException(string.Format("File {0} does not exist.", fileName));
        }

        return powers;
    }
}
