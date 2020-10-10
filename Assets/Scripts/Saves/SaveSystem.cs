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

    public static readonly string KEYBINDINGS_PATH = Application.persistentDataPath + "/keybindings.save";

    /// <summary>
    /// Saves scene to file.
    /// </summary>
    /// <param name="objects"></param>
    /// <param name="selectedSave"></param>
    public static void SaveScene(List<SavableObject> objects, int selectedSave)
    {
        string saveFile = SavePath(selectedSave);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(saveFile, FileMode.Create);

        formatter.Serialize(stream, objects);
        stream.Close();
    }

    /// <summary>
    /// Loads scene from file.
    /// </summary>
    /// <param name="selectedSave"></param>
    /// <returns></returns>
    public static List<SavableObject> LoadScene(int selectedSave)
    {
        string saveFile = SavePath(selectedSave);

        if (File.Exists(saveFile))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveFile, FileMode.Open);

            List<SavableObject> objects = (List<SavableObject>)formatter.Deserialize(stream);
            stream.Close();

            return objects;
        }
        else
        {
            Debug.Log("Save file not found in " + saveFile);
            return null;
        }
    }

    /// <summary>
    /// Determines with save file to use.
    /// </summary>
    /// <param name="selectedSave"></param>
    /// <returns></returns>
    public static string SavePath(int selectedSave)
    {
        switch (selectedSave)
        {
            case 1:
                return SAVE_ONE_PATH;
            case 2:
                return SAVE_TWO_PATH;
            case 3:
                return SAVE_THREE_PATH;
            case 4:
                return SAVE_FOUR_PATH;
            default:
                return SAVE_ONE_PATH;
        }
    }

    /// <summary>
    /// Saves keybindings to file.
    /// </summary>
    /// <param name="keybindings"></param>
    public static void SaveKeybindings(Keybindings keybindings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(KEYBINDINGS_PATH, FileMode.Create);

        string json = JsonUtility.ToJson(keybindings);
        formatter.Serialize(stream, json);
        stream.Close();
    }

    /// <summary>
    /// Loads keybindings form file.
    /// </summary>
    /// <returns></returns>
    public static void LoadKeybindings()
    {
        if (File.Exists(KEYBINDINGS_PATH))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(KEYBINDINGS_PATH, FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(stream), InputManager.Instance.keybindings);
            stream.Close();
        }
        else
        {
            Debug.Log("Save file not found in " + KEYBINDINGS_PATH);
        }
    }
}
