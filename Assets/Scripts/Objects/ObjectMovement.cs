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

    // Speed at with object is rotated.
    private float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 20f;

        // Gets game objects.
        spawnPosition = GameObject.Find("Main Camera/SpawnPosition").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlaced)
        {
            // Moves object.
            transform.position = spawnPosition.position;

            // Rotate object.
            if (InputManager.Instance.GetKey("RotateObjectForward"))
            {
                transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
            }

            if (InputManager.Instance.GetKey("RotateObjectBack"))
            {
                transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
            }

            if (InputManager.Instance.GetKey("RotateObjectRight"))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
            }

            if (InputManager.Instance.GetKey("RotateObjectLeft"))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            }

            // Reset rotation.
            if (InputManager.Instance.KeyDown("ResetObjectRotation"))
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }

        }
    }

    /// <summary>
    /// Checks if object is touching other objects.
    /// Stops object movement when selected button is pressed.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (InputManager.Instance.KeyUp("PlaceObject") && !_isPlaced)
        {
            _isPlaced = true;
            ColorPicker.Done();
            CreateObjects.Instance.EnableButtons();
            GameManager.Instance.isObjectSelected = false;
            gameObject.tag = "Save";
        }
    }
}
