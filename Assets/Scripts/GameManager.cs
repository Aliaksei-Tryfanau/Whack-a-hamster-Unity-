using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audio;
    public Text buttonText;
    public Button musicButton;
    public Button startGameButton;
    public Button exitGameButton;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            musicButton.enabled = true;
            exitGameButton.enabled = true;
        }
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
        startGameButton.enabled = false;
        musicButton.enabled = false;
        exitGameButton.enabled = false;
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