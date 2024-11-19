using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Vector3 targetPosition;
    public float travelTime;

    private RhythmManager rhythmManager;

    private float timer = 0;
    private bool clicked =false;

    private bool stomp = false;

    private Vector3 dir;
    private float speed = 1.25f;
    private void Start()
    {
        rhythmManager = GameObject.FindGameObjectWithTag("RhythmManager").GetComponent<RhythmManager>();
        dir = (targetPosition - transform.position);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < 60f && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !clicked)
        {
            clicked = true;
            rhythmManager.score += 1;
            Debug.Log("Perfect Hit!");
            Destroy(gameObject); // Destroy the note on a successful hit
        }

        if (!clicked)
        {
            transform.position += dir * speed * Time.deltaTime;
        }

    }
}
