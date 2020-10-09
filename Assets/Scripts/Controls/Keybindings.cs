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
}
