using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public int numOfState;
    public int curState = 0;
    public bool started = false;
    public bool ended = false;

    public AudioSource audioSource;
    public AudioClip[] speech;

    public GameObject[] states;
    // Start is called before the first frame update
    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            audioSource.clip = speech[curState];
            audioSource.Play();
        }

        if(audioSource.isPlaying && GetNormalizedAudioTime(audioSource) >= 0.99f && !ended)
        {
            ended = true;
            states[curState].SetActive(true);
        }


    }

    public void Reset()
    {
        Cursor.lockState = CursorLockMode.Locked;

        curState++;
        started = false;
        ended = false;
    }

    private float GetNormalizedAudioTime(AudioSource source)
    {
        // Avoid division by zero if the clip is not assigned or has a length of zero
        if (source.clip == null || source.clip.length == 0) return 0;

        return source.time / source.clip.length;
    }
}
