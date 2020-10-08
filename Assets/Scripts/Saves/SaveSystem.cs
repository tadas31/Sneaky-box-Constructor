using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveSystem 
{
    public static readonly string SAVE_ONE_PATH = Application.persistentDataPath + "/saveOne.save";
    public static readonly string SAVE_TWO_PATH = Application.persistentDataPath + "/saveTwo.save";
    public static readonly string SAVE_THREE_PATH = Application.persistentDataPath + "/saveThree.save";
    public static readonly string SAVE_FOUR_PATH = Application.persistentDataPath + "/saveFour.save";

    /// <summary>
    /// Saves scene to file.
    /// </summary>
    /// <param name="objects"></param>
    public static void SaveScene(List<SavableObject> objects)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(SAVE_ONE_PATH, FileMode.Create);

        formatter.Serialize(stream, objects);
        stream.Close();
    }

    /// <summary>
    /// Loads scene from file.
    /// </summary>
    /// <returns></returns>
    public static List<SavableObject> LoadScene()
    {
        if (File.Exists(SAVE_ONE_PATH))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(SAVE_ONE_PATH, FileMode.Open);

            List<SavableObject> objects = (List<SavableObject>)formatter.Deserialize(stream);
            stream.Close();

            return objects;
        }
        else
        {
            Debug.Log("Save file not found in " + SAVE_ONE_PATH);
            return null;
        }
    }
}
