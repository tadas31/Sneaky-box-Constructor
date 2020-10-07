using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    private Renderer r;

    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Renderer>();
        r.sharedMaterial = r.material;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChoseColor()
    {
        ColorPicker.Create(r.sharedMaterial.color, "Choose color!", SetColor, ColorFinished, true);
    }

    private void SetColor(Color currentColor)
    {
        r.sharedMaterial.color = currentColor;
    }

    private void ColorFinished(Color finishedColor)
    {
        //Debug.Log("You chose the color " + ColorUtility.ToHtmlStringRGBA(finishedColor));
    }
}
