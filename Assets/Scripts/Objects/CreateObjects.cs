using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateObjects : MonoBehaviour
{
    public static CreateObjects Instance { get; set; }

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

    /// <summary>
    /// Gets name of pressed button and creates object according to that name.
    /// </summary>
    public void OnPrimitiveTypeClick()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        CreatePrimitiveObject(button.name, "InHand", false, true);
    }

    /// <summary>
    /// Creates new primitive object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="tag"></param>
    /// <param name="isSelected"></param>
    /// <returns></returns>
    public GameObject CreatePrimitiveObject(string type, string tag, bool isPlaced, bool isSelected)
    {
        GameObject newPrimitiveObject = null;

        // Creates new object.
        switch (type)
        {
            case "Cube":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newPrimitiveObject.GetComponent<BoxCollider>().isTrigger = true;
                break;
            case "Sphere":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                newPrimitiveObject.GetComponent<SphereCollider>().isTrigger = true;
                break;
            case "Capsule":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                newPrimitiveObject.GetComponent<CapsuleCollider>().isTrigger = true;
                break;
            case "Cylinder":
                newPrimitiveObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                newPrimitiveObject.GetComponent<CapsuleCollider>().isTrigger = true;
                break;
        }

        // Adds components to new object and marks that object is selected.
        if (newPrimitiveObject != null)
        {
            newPrimitiveObject.AddComponent<ObjectMovement>().isPlaced = isPlaced;
            newPrimitiveObject.AddComponent<ObjectColor>();
            newPrimitiveObject.AddComponent<DestroyObject>();

            // Add rigidbody and set its values.
            Rigidbody rigidbody = newPrimitiveObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;


            newPrimitiveObject.tag = tag;

            GameManager.Instance.isObjectSelected = isSelected;

            if (!isPlaced)
            {
                DisableButtons();
                newPrimitiveObject.GetComponent<ObjectColor>().ChoseColor();
            }
        }

        return newPrimitiveObject;
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
