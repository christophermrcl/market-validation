using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public AudioSource musicSource; // Assign your Audio Source in the inspector
    public GameObject notePrefab; // Assign your Note prefab in the inspector
    public RectTransform spawnPoint; // Define where the notes spawn
    public Transform targetPoint; // Define where the notes converge
    public float bpm = 120; // Set the BPM of the song
    public int score = 0;

    public StateManager gameManager;
    private float beatInterval; // Time between beats
    private bool gameRunning = false;

    public GameObject scoreCanvas;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        beatInterval = 60f / bpm; // Calculate time between beats based on BPM
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        musicSource.Play();
        gameRunning = true;

        while (musicSource.isPlaying)
        {
            SpawnNote();
            yield return new WaitForSeconds(beatInterval);
        }

        EndFunction();
    }

    void SpawnNote()
    {
        // Instantiate the note and assign its target
        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
        Note noteScript = note.GetComponent<Note>();
        noteScript.targetPosition = targetPoint.position;
        noteScript.travelTime = beatInterval; // Match note travel time to the beat
    }

    public void EndFunction()
    {
        scoreCanvas.SetActive(true);
        if (score >= 75)
        {
            scoreText.text = "A+";
        } else if (score >= 65)
        {
            scoreText.text = "A";
        } else if (score >= 40)
        {
            scoreText.text = "B";
        } else{
            scoreText.text = "C";
        }

        gameRunning = false;
        gameManager.Reset();
        this.gameObject.SetActive(false);
    }
}
