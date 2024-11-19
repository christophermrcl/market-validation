using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencySoundFX : MonoBehaviour
{
    public Image image;
    public GameObject objectWithNormalized;
    private float normalizedLoudness;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalizedLoudness = objectWithNormalized.GetComponent<PlaySound>().normalizedLoudness;
        image.color = new Color(image.color.r, image.color.g, image.color.b, normalizedLoudness*0.1f);
    }
}
