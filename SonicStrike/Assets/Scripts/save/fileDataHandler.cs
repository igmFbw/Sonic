using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class fileDataHandler
{
    private string dataDirPath;
    private string dataFileName;
    public fileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public void save(gameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
        string dataToStore = JsonUtility.ToJson(data, true);
        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(dataToStore);
            }
        }
    }
    public gameData load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        gameData loadData = null;
        if (File.Exists(fullPath))
        {
            string dataToLoad = string.Empty;
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }
            loadData = JsonUtility.FromJson<gameData>(dataToLoad);
        }
        return loadData;
    }
}