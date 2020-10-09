using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Normal speed of camera movement.
    public float movementSpeed = 10f;

    // Speed of camera movement when shift is held down.
    public float fastMovementSpeed = 100f;

    // Sensitivity for free look.
    public float freeLookSensitivity = 3f;

    // Set to true when free looking (on right mouse button).
    private bool looking = false;

    // Update is called once per frame
    void Update()
    {
        var fastMode = InputManager.Instance.GetKey("Sprint");
        var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

        if (InputManager.Instance.GetKey("MoveLeft"))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }

        if (InputManager.Instance.GetKey("MoveRight"))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }

        if (InputManager.Instance.GetKey("MoveForward"))
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }

        if (InputManager.Instance.GetKey("MoveBack"))
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        if (InputManager.Instance.GetKey("MoveUp"))
        {
            transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (InputManager.Instance.GetKey("MoveDown"))
        {
            transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }

        if (InputManager.Instance.KeyDown("RotateCamera"))
        {
            StartLooking();
        }
        else if (InputManager.Instance.KeyUp("RotateCamera"))
        {
            StopLooking();
        }
    }

    /// <summary>
    /// Enable free looking.
    /// </summary>
    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Disable free looking.
    /// </summary>
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
