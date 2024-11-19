using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceinCanvas : MonoBehaviour
{
    public StateManager gameManager;

    public GameObject choiceA;
    public GameObject choiceB;

    public GameObject canvas;

    public GameObject buttonA;
    public GameObject buttonB;

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
        choiceA.SetActive(true);
        buttonA.SetActive(false);
        scene.SetActive(false);
        canvas.SetActive(false);
    }

    public void OnClickChoiceB() 
    {
        choiceB.SetActive(true);
        buttonB.SetActive(false);
        scene.SetActive(false);
        canvas.SetActive(false);
    }

    public void Wrong()
    {
        return;
    }
}
