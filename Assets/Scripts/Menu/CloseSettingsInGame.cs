using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseSettingsInGame : MonoBehaviour, IPointerClickHandler
{
    public GameObject settingsWindow;

    public GameObject selectKey;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!selectKey.activeSelf)
        {
            settingsWindow.SetActive(false);
        }
    }
}
