using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGame : MonoBehaviour
{
    public GameObject ball;
    public float startHeight = 10.0f;
    public float fireInteval = 5f;

    private float nextBallTime = 0.0f;
    private GameObject activeBall;
    private Transform head;
    private AudioSource audio;
    
    void Start()
    {
        head = Camera.main.transform;
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime = Time.time + fireInteval;
            audio.Play();
            Vector3 position = new Vector3(head.position.x, startHeight, head.position.z + 0.2f);
            activeBall = Instantiate(ball, position, Quaternion.identity);
        }
    }
}
