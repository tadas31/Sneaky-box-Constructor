﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseWondows : MonoBehaviour, IPointerClickHandler
{
    public GameObject selectSave;
    public GameObject settingsWindow;

    public GameObject selectKey;
    public GameObject confirmationWindow;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!selectKey.activeSelf && !confirmationWindow.activeSelf)
        {
            selectSave.SetActive(false);
            settingsWindow.SetActive(false);
        }
    }
}
