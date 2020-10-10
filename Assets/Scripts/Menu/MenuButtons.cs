using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    public GameObject selectSave;
    public GameObject confirmWindow;

    public GameObject settingsWindow;

    private int? saveToDelete;

    // -------------------------------------------------------------------------
    // Main menu buttons.
    // -------------------------------------------------------------------------
    public void OnPlayClick()
    {
        selectSave.SetActive(true);
    }

    public void OnSettingsClick()
    {
        settingsWindow.SetActive(true);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }


    // -------------------------------------------------------------------------
    // Select save buttons.
    // -------------------------------------------------------------------------

    public void OnSelectSaveClick()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (button != null)
        {
            SelectedSave.Instance.selectedSave = int.Parse(button.name);
        }

        LevelLoader.Instance.LoadNexScene("Game");
    }

    public void OnDeleteSaveClick()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (button != null)
        {
            saveToDelete = int.Parse(button.name);
            confirmWindow.SetActive(true);
        }
    }

    public void OnYesClick()
    {
        if (saveToDelete != null)
        {
            string saveFile = SaveSystem.SavePath((int)saveToDelete);
            File.Delete(saveFile);
            SaveButtonsText.Instance.setSaveText();
            confirmWindow.SetActive(false);
        }
    }

    public void OnNoClick()
    {
        confirmWindow.SetActive(false);
    }
}
