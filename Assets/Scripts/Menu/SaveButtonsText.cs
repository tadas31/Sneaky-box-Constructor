using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveButtonsText : MonoBehaviour
{
    public static SaveButtonsText Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setSaveText();
    }

    /// <summary>
    /// Sets text for save buttons.
    /// </summary>
    public void setSaveText()
    {
        foreach (Transform button in GetComponentInChildren<Transform>())
        {
            string saveFile = SaveSystem.SavePath(int.Parse(button.name));
            if (File.Exists(saveFile))
            {
                Transform text = button.transform.GetChild(0);
                text.GetComponent<TextMeshProUGUI>().text = "Save " + button.name;
            }
            else
            {
                Transform text = button.transform.GetChild(0);
                text.GetComponent<TextMeshProUGUI>().text = "Empty";
            }

        }
    }
}
