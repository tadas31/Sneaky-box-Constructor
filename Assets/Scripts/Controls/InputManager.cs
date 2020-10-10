using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public Keybindings keybindings;

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
        DontDestroyOnLoad(this);

        SaveSystem.LoadKeybindings();
    }

    public bool KeyDown(string key)
    {
        if (Input.GetKeyDown(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetKey(string key)
    {
        if (Input.GetKey(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool KeyUp(string key)
    {
        if (Input.GetKeyUp(keybindings.CheckKey(key)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
