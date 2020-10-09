using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.KeyUp("SelectObject") && !GameManager.Instance.isObjectSelected)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Checks if ray hit something.
            if (Physics.Raycast(ray, out hit))
            {
                // Selects object that ray hit.
                Transform objectHit = hit.transform;

                // Selects object to move and change color.
                objectHit.GetComponent<ObjectMovement>().isPlaced = false;
                objectHit.GetComponent<ObjectColor>().ChoseColor();
                objectHit.tag = "InHand";

                // Disables buttons to create new objects and selection of objects.
                CreateObjects.Instance.DisableButtons();
                GameManager.Instance.isObjectSelected = true;


            }
        }
       
    }
}
