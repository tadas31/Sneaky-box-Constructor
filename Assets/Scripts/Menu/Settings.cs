using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class Settings : MonoBehaviour
{
    private const string RESOLUTION_KEY = "resolution";
    private const string WINDOW_MODE_KEY = "windowed";

    // Objects for video settings
    public TMP_Dropdown resolutionsDorpdown;
    public Toggle windowModeToggle;
    private List<Resolution> resolutions;

    // Objects for controls settings.
    public GameObject selectKey;
    public GameObject controlls;
    private Button keyToChange;


    // Start is called before the first frame update
    void Start()
    {
        // Gets supported resolutions.
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToList();
        foreach (Resolution r in resolutions)
        {
            resolutionsDorpdown.options.Add(new TMP_Dropdown.OptionData() { text = r.width + "x" + r.height });
        }

        // Gets saved values.
        int togleValue = PlayerPrefs.GetInt(WINDOW_MODE_KEY, 0);
        resolutionsDorpdown.value = PlayerPrefs.GetInt(RESOLUTION_KEY, resolutions.Count);

        Resolution selecteResolution = resolutions[resolutionsDorpdown.value];

        // Sets resolution
        if (togleValue == 0)
        {
            Screen.SetResolution(selecteResolution.width, selecteResolution.height, true);
            windowModeToggle.isOn = false;
        }

        else
        {
            Screen.SetResolution(selecteResolution.width, selecteResolution.height, false);
            windowModeToggle.isOn = true;
        }

        // Gets saved keybindings.
        keyToChange = null;
        foreach (Transform controll in controlls.GetComponentInChildren<Transform>())
        {
            SetKeyText(controll.GetComponentInChildren<Button>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyToChange != null && Input.anyKeyDown)
        {
            foreach (KeyCode c in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(c))
                {
                    InputManager.Instance.keybindings.ChangeKeybinding(keyToChange.name, c);
                    keyToChange.GetComponentInChildren<TextMeshProUGUI>().text = c.ToString();
                    keyToChange = null;
                    selectKey.SetActive(false);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Initializes change of keybinding.
    /// </summary>
    public void OnChnageKeybindingClick()
    {
        selectKey.SetActive(true);
        GameObject button = EventSystem.current.currentSelectedGameObject;
        keyToChange = button.GetComponent<Button>();
    }

    /// <summary>
    /// Saves settings.
    /// </summary>
    public void OnSaveChangesClick()
    {
        SaveSystem.SaveKeybindings(InputManager.Instance.keybindings);

        PlayerPrefs.SetInt(RESOLUTION_KEY, resolutionsDorpdown.value);
        if (windowModeToggle.isOn)
            PlayerPrefs.SetInt(WINDOW_MODE_KEY, 1);
        else if (!windowModeToggle.isOn)
            PlayerPrefs.SetInt(WINDOW_MODE_KEY, 0);

        Resolution selecteResolution = resolutions[resolutionsDorpdown.value];

        Screen.SetResolution(selecteResolution.width, selecteResolution.height, !windowModeToggle.isOn);
    }

    /// <summary>
    /// Sets text for buttons to change keybindings.
    /// </summary>
    /// <param name="key"></param>
    private void SetKeyText(Button key)
    {
        KeyCode keyCode = InputManager.Instance.keybindings.CheckKey(key.name);
        if (keyCode != KeyCode.None)
        {
            key.GetComponentInChildren<TextMeshProUGUI>().text = keyCode.ToString();
        }
    }

}
