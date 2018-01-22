using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterController : MonoBehaviour {

    public List<HamsterMovement> hamstersList;
    public float timer;
    static public float godTimer;
    bool gameIsRunning = true;
    static public float delayTop;
    static public float delayBottom;
    public float setDelayTop;
    public float setDelayBottom;
    public Text scoreText;
    public static int score;

    static public float minSpeed;
    static public float maxSpeed;
    public float setminSpeed;
    public float setmaxSpeed;

    void Start () {
        godTimer = timer;
        delayTop = setDelayTop;
        delayBottom = setDelayBottom;
        minSpeed = setminSpeed;
        maxSpeed = setmaxSpeed;
    }
	
	void Update () {
        for (int i = 0; i < hamstersList.Count; i++)
        {
            if (gameIsRunning == true)
                    hamstersList[i].Move();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            gameIsRunning = !gameIsRunning;

        scoreText.text = "Score: " + score.ToString();
    }
}