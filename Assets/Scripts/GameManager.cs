using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audio;
    public Text buttonText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    public void AudioManager()
    {
        if (audio.enabled == true)
        {
            audio.enabled = false;
            buttonText.text = "Music Off";
        }
        else
        {
            audio.enabled = true;
            buttonText.text = "Music On";
        }
    }

    public void ExitProgram()
    {
        Application.Quit();
    }
}