using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HamsterMovement : MonoBehaviour
{
    AudioSource scoreSound;
    [SerializeField] ParticleSystem explosion;
    public float limitations_y;
    float speed_y;
    float currentTime;
    bool timeToStop = false;
    float timer;
    Vector3 newPos;
    bool hamsterIsClickable = true;
    float cycleDelta_y;

    void Start()
    {
        scoreSound = GetComponent<AudioSource>();
        speed_y = UnityEngine.Random.Range(HamsterController.minSpeed, HamsterController.maxSpeed);

        timeToStop = true;
        timer = UnityEngine.Random.Range(0, HamsterController.delayBottom);
        transform.position = new Vector3(transform.position.x, -limitations_y, transform.position.z);
    }

    public void Move()
    {
        newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (timeToStop == false)
        {
            transform.position = newPos + new Vector3(0.0f, speed_y, 0.0f) * Time.deltaTime;
            cycleDelta_y = speed_y * Time.deltaTime;
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
            transform.position += new Vector3(0.0f, -cycleDelta_y, 0.0f);
        }
    }

    public void StopAtBottom()
    {
        timer += Time.deltaTime;
        timeToStop = true;
        if (timer >= HamsterController.delayBottom)
        {
            speed_y = UnityEngine.Random.Range(HamsterController.minSpeed, HamsterController.maxSpeed);
            timer = 0f;
            timeToStop = false;
            transform.position += new Vector3(0.0f, -cycleDelta_y, 0.0f);
        }
    }

    private void OnMouseDown()
    {
        if (hamsterIsClickable == true && HamsterController.gameIsRunning == true)
        {
            HamsterController.comboTimer += Time.deltaTime;                 // тут он должен начать отсчет, но этого не происходит
            scoreSound.Play();
            explosion.Play();
            hamsterIsClickable = false;
            if (HamsterController.comboTimer < HamsterController.comboTimerLimitation)
            {
                HamsterController.comboMultiplier += 0.1f;
                HamsterController.comboMultiplier = Mathf.Clamp(HamsterController.comboMultiplier, 1.0f, 2.0f);
                HamsterController.score += 10 * HamsterController.comboMultiplier;
                HamsterController.comboTimer = 0;   
            }
            else
            {
                HamsterController.comboMultiplier = 0.9f;
                HamsterController.score += 10;
                HamsterController.comboTimer = 0;                           
            }
        }
    }
}