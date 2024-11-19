using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public float normalizedLoudness; // Normalized loudness (0 to 1)

    public StateManager gameManager;
    public float smoothingFactor = 0.1f;  // Smoothing factor for low-pass filtering (lower = smoother)
    public float sensitivity = 0.05f;     // Base sensitivity to sound levels

    private float smoothedLoudness = 0f;  // Internal smoothed loudness value
    private float velocity = 0f;          // Used for smooth damping

    public GameObject scene;
    void OnEnable()
    {

        if (audioSource != null && audioSource.clip != null)
        {
            // Play the audio clip
            audioSource.Play();
            // Start monitoring the playback
            StartCoroutine(MonitorAudio());
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing.");
        }
    }

    private System.Collections.IEnumerator MonitorAudio()
    {
        float[] sampleData = new float[256]; // Array to store audio samples

        while (audioSource.isPlaying)
        {
            // Retrieve current audio samples from the AudioSource
            audioSource.GetOutputData(sampleData, 0);

            // Calculate the RMS (Root Mean Square) value of the samples
            float sum = 0f;
            for (int i = 0; i < sampleData.Length; i++)
            {
                sum += sampleData[i] * sampleData[i];
            }
            float rms = Mathf.Sqrt(sum / sampleData.Length);

            // Normalize the RMS value to a range of 0 to 1, applying sensitivity
            float targetLoudness = Mathf.Clamp01(rms / sensitivity);

            // Smooth transitions between target and current loudness using a low-pass filter
            smoothedLoudness = Mathf.Lerp(smoothedLoudness, targetLoudness, smoothingFactor);

            // Apply additional curve smoothing with SmoothDamp for natural ease
            normalizedLoudness = Mathf.SmoothDamp(normalizedLoudness, smoothedLoudness, ref velocity, smoothingFactor);

            yield return null; // Wait until the next frame
        }

        // Once the audio finishes playing, call EndClipFunction
        EndClipFunction();
    }

    private void EndClipFunction()
    {
        gameManager.Reset();
        scene.SetActive(false);
    }
}
