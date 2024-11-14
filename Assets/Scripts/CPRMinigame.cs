using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPRMinigame : MonoBehaviour
{
    public Image cueImage; // The image that shrinks
    public Image targetImage; // The static reference image
    public AudioSource audioSource; // Audio source with 1 beat audio
    public float bpm = 120f; // 120 BPM
    public float gameDuration = 10f; // How long the game lasts
    private float beatDuration;
    private bool isPlaying = false;
    private float timer = 0f;
    private Vector2 initialCueSize;
    private Vector2 targetSize;

    void Start()
    {
        beatDuration = 60f / bpm; // Time between each beat
        initialCueSize = cueImage.rectTransform.sizeDelta; // Get initial size of the cue image
        targetSize = targetImage.rectTransform.sizeDelta;  // Get size of the target image

        StartGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        timer = gameDuration; // Set the game duration
        PlayBeat();
    }

    void Update()
    {
        if (!isPlaying) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isPlaying = false;
            return;
        }

        HandleVisualCue();

        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            CheckTiming();
        }
    }

    void PlayBeat()
    {
        audioSource.Play(); // Play the beat sound
        Invoke("PlayBeat", beatDuration); // Repeat after the beat duration
    }

    void HandleVisualCue()
    {
        // Shrink the image over time
        float scale = Mathf.PingPong(Time.time, beatDuration) / beatDuration;
        cueImage.rectTransform.sizeDelta = Vector2.Lerp(initialCueSize, targetSize, scale);
    }

    void CheckTiming()
    {
        float currentScale = cueImage.rectTransform.sizeDelta.x;
        float targetScale = targetImage.rectTransform.sizeDelta.x;

        // Check if the size is close to the target size (timing match)
        if (Mathf.Abs(currentScale - targetScale) < 5f) // Adjust the threshold if needed
        {
            Debug.Log("Perfect Timing!");
            // You can add scoring or other feedback here
        }
        else
        {
            Debug.Log("Missed!");
        }
    }
}
