using UnityEngine;

[System.Serializable]
public class SavableObject
{
    // Objects type.
    public string objectType;

    // Objects position.
    public float positionX;
    public float positionY;
    public float positionZ;

    // Objects rotation.
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float rotationW;

    // Objects color.
    public string color;

    public SavableObject(string objectType, Vector3 position, Quaternion rotation, string color)
    {
        this.objectType = objectType;

        positionX = position.x;
        positionY = position.y;
        positionZ = position.z;

        rotationX = rotation.x;
        rotationY = rotation.y;
        rotationZ = rotation.z;
        rotationW = rotation.w;

        this.color = color;
    }
}
