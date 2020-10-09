using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseWondows : MonoBehaviour, IPointerClickHandler
{
    public GameObject selectSave;
    public GameObject settingsWindow;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectSave.SetActive(false);
        settingsWindow.SetActive(false);
    }
}
