using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionsDorpdown;
    public Toggle windowModeToggle;

    private List<Resolution> resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToList();
        //resolutions = Screen.resolutions.ToList();
        foreach (Resolution r in resolutions)
        {
            Debug.Log(r.width + "x" + r.height);
            resolutionsDorpdown.options.Add(new TMP_Dropdown.OptionData() { text = r.width + "x" + r.height });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
