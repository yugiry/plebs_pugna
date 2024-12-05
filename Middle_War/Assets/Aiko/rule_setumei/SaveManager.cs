using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class SaveData
{
    public int MyInt;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData saveData1;
    private string saveFileName1 = "Data.alicia";

    void Start()
    {
        saveData1 = LoadDataFromFile(saveFileName1);
        Debug.Log("saveData1.MyInt: " + saveData1.MyInt);
    }

    public void SaveData1()
    {
       // saveData1.MyInt = csvcontroler.i;
        Debug.Log("Button clicked. Saving " + saveData1.MyInt + " to file.");
        SaveDataToFile(saveData1, saveFileName1);
    }

    public void LoadData1()
    {
        saveData1 = LoadDataFromFile(saveFileName1);
        //csvcontroler.i = saveData1.MyInt;
        Debug.Log("saveData1.MyInt: " + saveData1.MyInt);
    }

    private void SaveDataToFile(SaveData data, string fileName)
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, data);
        fileStream.Close();
        //  Debug.Log("Save data saved to " + filePath);
    }

    private SaveData LoadDataFromFile(string fileName)
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(filePath))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            SaveData data = (SaveData)bf.Deserialize(fileStream);
            fileStream.Close();
            // Debug.Log("Save data loaded from " + filePath);
            return data;
        }
        else
        {
            Debug.Log("Save file not found.");
            return new SaveData();
        }
    }
}
