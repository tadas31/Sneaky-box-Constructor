using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedSave : MonoBehaviour
{
    public static SelectedSave Instance { get; set; }

    public int selectedSave;

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
    }
}
