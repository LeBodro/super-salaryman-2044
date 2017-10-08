using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData
{
    string powersFile = "powers.json";
    string fearsFile = "fears.json";
    string jobsFile = "jobs.json";

    public string[] LoadFile(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            string[] allJsonObjects = dataAsJson.Split('/');
            return allJsonObjects;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
            throw new System.ArgumentException(string.Format("File {0} does not exist.", fileName));
        }
    }

    public List<PowerData> LoadPowersData()
    {
        List<PowerData> powers = new List<PowerData>();

        string[] allJsonObjects = LoadFile(powersFile);

        foreach (string json in allJsonObjects)
        {
            powers.Add(JsonUtility.FromJson<PowerData>(json));
        }

        return powers;
    }

    public List<FearData> LoadFearsData()
    {
        List<FearData> fears = new List<FearData>();

        string[] allJsonObjects = LoadFile(fearsFile);

        foreach (string json in allJsonObjects)
        {
            fears.Add(JsonUtility.FromJson<FearData>(json));
        }

        return fears;
    }

    public List<JobData> LoadJobData()
    {
        List<JobData> jobs = new List<JobData>();

        string[] allJsonObjects = LoadFile(jobsFile);

        foreach (string json in allJsonObjects)
        {
            jobs.Add(JsonUtility.FromJson<JobData>(json));
        }

        return jobs;
    }

}
