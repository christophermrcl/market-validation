using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMouse : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    public GameObject currentSelected;

    public Sprite crosshairUIEmpty;
    public Sprite crosshairUIInteractable;

    public Image crosshairUI;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(mouseSensitivity != 0)
        {
            HandleMouseLook();  // Call function for mouse look
        }
    }

    void HandleMouseLook()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate base rotation from mouse input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply vertical and horizontal rotation to the camera (mouse + recoil)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Subtracting recoilOffsetX to make recoil go up

        // Rotate the player body horizontally
        playerBody.Rotate(Vector3.up * mouseX);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                currentSelected = hit.transform.gameObject;
            }
            else
            {
                currentSelected = null;
            }
        }
        else
        {
            currentSelected = null;
        }

        if(Input.GetMouseButtonDown(0) && currentSelected != null)
        {
            if (currentSelected.GetComponent<InteractedObject>())
            {
                currentSelected.GetComponent<InteractedObject>().Clicked();
            }
            if (currentSelected.GetComponent<InteractandChangeCamera>())
            {
                currentSelected.GetComponent<InteractandChangeCamera>().Clicked();
            }
            if (currentSelected.GetComponent<InteracttoUI>())
            {
                currentSelected.GetComponent<InteracttoUI>().Clicked();
            }
        }

        if (currentSelected)
        {
            crosshairUI.sprite = crosshairUIInteractable;
        }
        else
        {
            crosshairUI.sprite = crosshairUIEmpty;
        }
    }

    
}
