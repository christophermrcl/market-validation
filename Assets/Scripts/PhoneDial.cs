using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDial : MonoBehaviour
{
    [SerializeField] private Button[] numberButtons = new Button[10]; // 10 buttons for numbers 0-9
    [SerializeField] private Button deleteButton;                     // Delete button
    [SerializeField] private Button dialButton;                       // Dial button
    [SerializeField] private TextMeshProUGUI displayText;             // Text to display dialed numbers

    public InteracttoUI interacttoUI;

    private string dialedNumber = "";

    public StateManager gameManager;

    public GameObject thisState;

    public CameraMouse scriptMouse;
    public float baseSens;

    private void Start()
    {
        baseSens = scriptMouse.mouseSensitivity;

        // Assign click listeners to each number button
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int number = i; // Local copy for closure
            numberButtons[i].onClick.AddListener(() => AddNumberToDial(number));
        }

        // Assign listener to the delete button
        deleteButton.onClick.AddListener(DeleteLastDigit);

        // Assign listener to the dial button
        dialButton.onClick.AddListener(DialNumber);
    }
    private void Update()
    {
        if(this.enabled == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    // Adds the clicked number to the dialed number and updates the display
    private void AddNumberToDial(int number)
    {
        if (dialedNumber.Length < 10) // Optional limit for 10 digits
        {
            dialedNumber += number.ToString();
            UpdateDisplay();
        }
    }

    // Deletes the last entered digit
    private void DeleteLastDigit()
    {
        if (dialedNumber.Length > 0)
        {
            dialedNumber = dialedNumber.Substring(0, dialedNumber.Length - 1);
            UpdateDisplay();
        }
    }

    // Simulates dialing the number
    private void DialNumber()
    {
        if (!string.IsNullOrEmpty(dialedNumber))
        {
            if(dialedNumber == "112")
            {
                gameManager.Reset();
                thisState.SetActive(false);
            }
        }
    }

    // Updates the displayed text
    private void UpdateDisplay()
    {
        displayText.text = dialedNumber;
    }
}
