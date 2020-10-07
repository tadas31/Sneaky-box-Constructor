using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    // True if objects is selected to move.
    public bool isObjectSelected
    {
        get { return _isObjectSelected; }
        set { _isObjectSelected = value; }
    }
    private bool _isObjectSelected;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        _isObjectSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
