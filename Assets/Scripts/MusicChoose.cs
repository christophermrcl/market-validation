using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChoose : MonoBehaviour
{
    public GameObject scene;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        scene.SetActive(true);
        canvas.SetActive(false);
    }
}
