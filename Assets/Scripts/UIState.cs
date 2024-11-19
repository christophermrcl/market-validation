using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : MonoBehaviour
{
    public GameObject canvas;

    private void OnEnable()
    {
        canvas.SetActive(true);
    }
}
