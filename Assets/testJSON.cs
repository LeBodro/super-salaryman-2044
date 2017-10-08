using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class testJSON {
    // https://unity3d.com/fr/learn/tutorials/topics/scripting/loading-game-data-json

    private string powersFile = "powers.json";
    private string fearsFile = "fears.json";
    private string jobsFile = "jobs.json";


    // Take filename in argument
    private void LoadGameData(string file)
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, file);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it

            //original line :
            //GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            //new line :
            List<string> loadedData = JsonUtility.FromJson<List<string>>(dataAsJson);

            // Retrieve the allRoundData property of loadedData
            //allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
