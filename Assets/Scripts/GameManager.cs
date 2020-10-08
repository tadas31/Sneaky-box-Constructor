using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    // True if objects is selected to move.
    public bool isObjectSelected
    {
        get { return _isObjectSelected; }
        set { _isObjectSelected = value; }
    }
    private bool _isObjectSelected;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        _isObjectSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            Save();

        if (Input.GetKeyDown(KeyCode.O))
            Load();
    }

    /// <summary>
    /// Saves game.
    /// </summary>
    private void Save()
    {
        List<GameObject> objectsToSave = GameObject.FindGameObjectsWithTag("Save").ToList();
        List<SavableObject> savableObjects = new List<SavableObject>();

        foreach (GameObject objectToSave in objectsToSave)
        {
            Color color = objectToSave.GetComponent<Renderer>().sharedMaterial.color;

            savableObjects.Add(
                new SavableObject(
                    objectToSave.name,
                    objectToSave.transform.position,
                    objectToSave.transform.rotation,
                    "#" + ColorUtility.ToHtmlStringRGB(color)
                )
            );
        }

        SaveSystem.SaveScene(savableObjects);
    }

    /// <summary>
    /// Loads saved game.
    /// </summary>
    private void Load()
    {
        List<SavableObject> savableObjects = SaveSystem.LoadScene();

        foreach (SavableObject savableObject in savableObjects)
        {
            GameObject newPrimitiveObject = CreateObjects.Instance.CreatePrimitiveObject(savableObject.objectType, "Save", true, false);
            newPrimitiveObject.transform.position = new Vector3(savableObject.positionX, savableObject.positionY, savableObject.positionZ);
            newPrimitiveObject.transform.rotation = new Quaternion(savableObject.rotationX, savableObject.rotationY, savableObject.rotationZ, savableObject.rotationW);


            ObjectColor color = newPrimitiveObject.GetComponent<ObjectColor>();

            Color savedColor;
            if (ColorUtility.TryParseHtmlString(savableObject.color, out savedColor))
            {
                color.SetColor(savedColor);
                color.ChoseColor();
                ColorPicker.Done();
            }
        }
    }
}
