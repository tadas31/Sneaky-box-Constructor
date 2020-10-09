using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool objectSelectedChanged;

    // True if saved game is loaded.
    private bool isLoaded;

    // Pause menu elements.
    public GameObject pauseMenu;
    public GameObject confirmationWindow;


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

    // Start is called before the first frame update
    void Start()
    {
        _isObjectSelected = false;
        objectSelectedChanged = false;
        isLoaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoaded)
        {
            LoadGame();
            isLoaded = true;
        }

        if (InputManager.Instance.KeyUp("Pause"))
        {
            if (!pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                CreateObjects.Instance.DisableButtons();
                Time.timeScale = 0;
                if (!_isObjectSelected)
                {
                    _isObjectSelected = true;
                    objectSelectedChanged = true;
                }
                
            }
            else
            {
                OnResumeClick();
            }
           
        }
           
    }

    /// <summary>
    /// Saves game.
    /// </summary>
    private void SaveGame()
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

        SaveSystem.SaveScene(savableObjects, SelectedSave.Instance.selectedSave);
    }

    /// <summary>
    /// Loads saved game.
    /// </summary>
    private void LoadGame()
    {
        List<SavableObject> savableObjects = SaveSystem.LoadScene(SelectedSave.Instance.selectedSave);

        if (savableObjects != null)
        {
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

    // -------------------------------------------------------------------------
    // Pause buttons.
    // -------------------------------------------------------------------------

    public void OnResumeClick()
    {
        pauseMenu.SetActive(false);
        CreateObjects.Instance.EnableButtons();
        Time.timeScale = 1;
        if (objectSelectedChanged)
        {
            _isObjectSelected = false;
            objectSelectedChanged = false;
        }
        
    }

    public void OnBackToMenuClick()
    {
        confirmationWindow.SetActive(true);
    }

    public void OnYesClick()
    {
        Time.timeScale = 1;
        SaveGame();
        SceneManager.LoadScene("Menu");
    }

    public void OnNoClick()
    {
        confirmationWindow.SetActive(false);
    }

    public void OnSettingsClick()
    {

    }

}
