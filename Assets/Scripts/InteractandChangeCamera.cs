using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractandChangeCamera : MonoBehaviour
{
    public bool isClicked = false;
    public GameObject Player;
    public GameObject Camera;

    public CameraMouse scriptMouse;
    public float baseSens;

    public Vector3 basePosition;
    public Quaternion baseRotation;

    public Vector3 changedPosition;
    public Quaternion changedRotation;

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

            StartCoroutine(ChangePosForSeconds());
        }
    }

    IEnumerator ChangePosForSeconds()
    {
        baseSens = scriptMouse.mouseSensitivity;

       

        basePosition = Player.transform.position;
        baseRotation = Camera.transform.rotation;

        

        Player.transform.position = changedPosition;
        Camera.transform.rotation = changedRotation;

        scriptMouse.mouseSensitivity = 0;

        yield return new WaitForSeconds(3);

        scriptMouse.mouseSensitivity = baseSens;

        Player.transform.position = basePosition;
        Camera.transform.rotation = baseRotation;

        gameManager.Reset();

        this.gameObject.SetActive(false);
    }
}
