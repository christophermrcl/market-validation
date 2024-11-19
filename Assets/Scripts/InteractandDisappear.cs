using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractandDisappear : MonoBehaviour
{
    public bool isClicked = false;

    public StateManager gameManager;

    public GameObject toDisappear;
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

            toDisappear.SetActive(false);

            this.gameObject.SetActive(false);
        }
    }
}
