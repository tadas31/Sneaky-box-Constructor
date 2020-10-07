using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    // Position of object.
    private Transform spawnPosition;

    // False when object is being moved.
    public bool isPlaced
    {
        get { return _isPlaced; }
        set { _isPlaced = value; }
    }
    private bool _isPlaced;


    // Start is called before the first frame update
    void Start()
    {
        _isPlaced = false;

        // Gets game objects.
        spawnPosition = GameObject.Find("Main Camera/SpawnPosition").GetComponent<Transform>();
        CreateObjects.Instance.DisableButtons();
        GetComponent<ObjectColor>().ChoseColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlaced)
        {
            // Moves object.
            transform.position = spawnPosition.position;

            // Stops object movement.
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _isPlaced = true;
                ColorPicker.Done();
                CreateObjects.Instance.EnableButtons();
                GameManager.Instance.isObjectSelected = false;
            }
        }
    }
}
