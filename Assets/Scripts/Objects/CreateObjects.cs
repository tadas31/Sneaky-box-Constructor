using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateObjects : MonoBehaviour
{
    public static CreateObjects Instance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Gets name of pressed button and creates object according to that name.
    /// </summary>
    public void OnPrimitiveTypeClick()
    {
        GameObject newPrimitiveObject = null;
        GameObject button = EventSystem.current.currentSelectedGameObject;

        // Creates new object.
        switch (button.name)
        {
            case "Cube":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case "Sphere":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case "Capsule":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                break;
            case "Cylinder":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;
        }

        // Adds scripts to new object and marks that object is selected.
        if (newPrimitiveObject != null)
        {
            newPrimitiveObject.AddComponent<ObjectMovement>();
            newPrimitiveObject.AddComponent<ObjectColor>();
            newPrimitiveObject.AddComponent<DestroyObject>();
            GameManager.Instance.isObjectSelected = true;
        }
    }

    /// <summary>
    /// Disables buttons for creating new objects.
    /// </summary>
    public void DisableButtons()
    {
        foreach (Transform button in gameObject.GetComponentInChildren<Transform>())
        {
            button.GetComponent<Button>().enabled = false;
        }
    }

    /// <summary>
    /// Enables buttons for creating new objects.
    /// </summary>
    public void EnableButtons()
    {
        foreach (Transform button in gameObject.GetComponentInChildren<Transform>())
        {
            button.GetComponent<Button>().enabled = true;
        }
    }
}
