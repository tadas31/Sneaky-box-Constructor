using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ObjectMovement>().isPlaced && InputManager.Instance.KeyDown("DeleteObject"))
        {
            ColorPicker.Done();
            GameManager.Instance.isObjectSelected = false;
            CreateObjects.Instance.EnableButtons();
            Destroy(gameObject);
            
        }
    }
}
