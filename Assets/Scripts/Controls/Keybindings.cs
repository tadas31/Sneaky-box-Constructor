using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
    // Player movement.
    public KeyCode moveForward;
    public KeyCode moveBack;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode sprint;
    public KeyCode rotateCamera;

    // Object rotation.
    public KeyCode rotateObjectForward;
    public KeyCode rotateObjectBack;
    public KeyCode rotateObjectLeft;
    public KeyCode rotateObjectRight;

    // Object actions.
    public KeyCode placeObject;
    public KeyCode selectObject;
    public KeyCode deleteObject;
    public KeyCode resetObjectRotation;

    // Pause.
    public KeyCode pause;

    /// <summary>
    /// Returns key codes by name.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case "MoveForward":
                return moveForward;
            case "MoveBack":
                return moveBack;
            case "MoveLeft":
                return moveLeft;
            case "MoveRight":
                return moveRight;
            case "MoveUp":
                return moveUp;
            case "MoveDown":
                return moveDown;
            case "Sprint":
                return sprint;
            case "RotateCamera":
                return rotateCamera;
            case "RotateObjectForward":
                return rotateObjectForward;
            case "RotateObjectBack":
                return rotateObjectBack;
            case "RotateObjectLeft":
                return rotateObjectLeft;
            case "RotateObjectRight":
                return rotateObjectRight;
            case "PlaceObject":
                return placeObject;
            case "SelectObject":
                return selectObject;
            case "DeleteObject":
                return deleteObject;
            case "ResetObjectRotation":
                return resetObjectRotation;
            case "Pause":
                return pause;
            default:
                return KeyCode.None;
        }
    }

    /// <summary>
    /// Sets new key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="newKey"></param>
    public void ChangeKeybinding(string key, KeyCode newKey)
    {
        switch (key)
        {
            case "MoveForward":
                moveForward = newKey;
                break;
            case "MoveBack":
                moveBack = newKey;
                break;
            case "MoveLeft":
                moveLeft = newKey;
                break;
            case "MoveRight":
                moveRight = newKey;
                break;
            case "MoveUp":
                moveUp = newKey;
                break;
            case "MoveDown":
                moveDown = newKey;
                break;
            case "Sprint":
                sprint = newKey;
                break;
            case "RotateCamera":
                rotateCamera = newKey;
                break;
            case "RotateObjectForward":
                rotateObjectForward = newKey;
                break;
            case "RotateObjectBack":
                rotateObjectBack = newKey;
                break;
            case "RotateObjectLeft":
                rotateObjectLeft = newKey;
                break;
            case "RotateObjectRight":
                rotateObjectRight = newKey;
                break;
            case "PlaceObject":
                placeObject = newKey;
                break;
            case "SelectObject":
                selectObject = newKey;
                break;
            case "DeleteObject":
                deleteObject = newKey;
                break;
            case "ResetObjectRotation":
                resetObjectRotation = newKey;
                break;
            case "Pause":
                pause = newKey;
                break;
        }
    }
}
