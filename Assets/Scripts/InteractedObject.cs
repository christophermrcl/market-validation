using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractedObject : MonoBehaviour
{

    public bool isClicked = false;

    public StateManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        if (!isClicked)
        {
            isClicked = true;

            gameManager.Reset();

            this.gameObject.SetActive(false);
        }
    }
}
