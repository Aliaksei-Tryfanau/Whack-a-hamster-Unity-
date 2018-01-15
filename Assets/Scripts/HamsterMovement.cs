using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HamsterMovement : MonoBehaviour
{
    AudioSource scoreSound;
    [SerializeField] ParticleSystem explosion;
    public float limitations_y;
    public float speed_y;
    float currentTime;
    bool timeToStop = false;
    float timer;
    Vector3 newPos;
    bool hamsterIsClickable = true;

    void Start()
    {
        scoreSound = GetComponent<AudioSource>();
    }

    public void Move()
    {
        newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (timeToStop == false)
        {
            transform.position = newPos + new Vector3(0.0f, speed_y, 0.0f) * Time.deltaTime;
        }

        if (transform.position.y >= limitations_y)
        {
            StopAtTop();
        }

        if (transform.position.y <= -limitations_y)
        {
            StopAtBottom();
            if (hamsterIsClickable == false)
                hamsterIsClickable = true;
        }

        currentTime = Time.time;
        if (currentTime > HamsterController.godTimer && timeToStop == false)
        {
            timeToStop = true;
        }
    }

    public void StopAtTop()
    {
        timer += Time.deltaTime;
        timeToStop = true;
        if (timer >= HamsterController.delayTop)
        {
            speed_y *= -1;
            timer = 0f;
            timeToStop = false;
        }
    }

    public void StopAtBottom()
    {
        timer += Time.deltaTime;
        timeToStop = true;
        if (timer >= HamsterController.delayBottom)
        {
            speed_y *= -1;
            timer = 0f;
            timeToStop = false;
        }
    }

    private void OnMouseDown()
    {
        if (hamsterIsClickable == true)
        {
            scoreSound.Play();
            explosion.Play();
            HamsterController.score += 10;
            hamsterIsClickable = false;
        }
    }
}