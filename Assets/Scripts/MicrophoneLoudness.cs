using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneLoudness : MonoBehaviour
{
    public string microphoneName = null;  // Leave null to use the default microphone
    public int sampleWindow = 128;        // Number of audio samples to analyze
    public float loudnessThreshold = 0.1f; // The threshold to trigger the bool
    public bool isLoud = false;           // The bool that becomes true when loudness is high

    private AudioClip microphoneClip;
    private int minFreq;
    private int maxFreq;

    public StateManager gameManager;
    void Start()
    {
        // Get the frequency range supported by the microphone
        Microphone.GetDeviceCaps(microphoneName, out minFreq, out maxFreq);

        // Start the microphone input
        microphoneClip = Microphone.Start(microphoneName, true, 10, maxFreq);
    }

    void Update()
    {
        // Get the loudness from the microphone input
        float loudness = GetLoudnessFromMicrophone();

        // Check if loudness exceeds the threshold
        if (loudness > loudnessThreshold)
        {
            isLoud = true;
        }
        else
        {
            isLoud = false;
        }

        if (isLoud)
        {
            gameManager.Reset();
            this.gameObject.SetActive(false);
        }

        Debug.Log("Loudness: " + loudness + " | Is Loud: " + isLoud);
    }

    // Method to calculate loudness
    private float GetLoudnessFromMicrophone()
    {
        float[] samples = new float[sampleWindow];
        int microphonePosition = Microphone.GetPosition(microphoneName) - sampleWindow + 1;
        if (microphonePosition < 0) return 0;

        // Get the audio data from the microphone clip
        microphoneClip.GetData(samples, microphonePosition);

        // Compute the average loudness
        float sum = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        return sum / sampleWindow;
    }

    void OnDisable()
    {
        // Stop the microphone when the object is disabled
        Microphone.End(microphoneName);
    }
}
