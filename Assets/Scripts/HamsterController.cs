using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterController : MonoBehaviour {

    public List<HamsterMovement> hamstersList;
    public float timer;
    static public float godTimer;
    public static bool gameIsRunning = true;

    static public float delayTop;
    static public float delayBottom;
    public float setDelayTop;
    public float setDelayBottom;

    public Text scoreText;
    public static float score;

    static public float minSpeed;
    static public float maxSpeed;
    public float setminSpeed;
    public float setmaxSpeed;

    static public float comboMultiplier = 0.9f;

    static public float comboTimerLimitation;
    public float setComboTimerLimitation;

    static public float comboTimer;

    void Awake () {
        godTimer = timer;
        delayTop = setDelayTop;
        delayBottom = setDelayBottom;
        minSpeed = setminSpeed;
        maxSpeed = setmaxSpeed;
        comboTimerLimitation = setComboTimerLimitation;
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

        Debug.Log("ComboTimer" + comboTimer);
    }
}