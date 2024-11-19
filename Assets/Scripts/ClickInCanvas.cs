using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInCanvas : MonoBehaviour
{
    public StateManager gameManager;
    public GameObject canvas;
    public GameObject scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickChoiceA()
    {
        gameManager.Reset();
        scene.SetActive(false);
        canvas.SetActive(false);
       
    }
}
