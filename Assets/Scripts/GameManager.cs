﻿using Assets.Scripts.car;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private CarController player;
    public GameObject gameoverGUI;
    public GameObject winnerGUI;
    public Text scoreGUI;
    public bool isGameOver;
    public AudioClip crashSound;
    public AudioClip wrongSound;
    public AudioClip correctSound;
    public AudioClip seatbeltSound;
    public AudioClip applauseSound;

    public enum Errors
    {
        RanRed,
        HitCurb,
        HitPedestrian,
        MaxDemerits,
        TooFast
    };

    public Errors currentError;

    //Get Components
    public static GameManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
        if ((instance) && (instance.GetInstanceID() != GetInstanceID()))
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Variables
    private static GameManager instance = null;
    public static int currentDemerits;


    public bool hasSentFeedback = false;

    // Use this for initialization
    void Start()
    {
        gameoverGUI = GameObject.FindGameObjectWithTag("Gameover");
        winnerGUI = GameObject.FindGameObjectWithTag("Winner");
        isGameOver = false;
        currentDemerits = 0;
        player = FindObjectOfType<CarController>();
        scoreGUI = GameObject.FindGameObjectWithTag("Demerits").GetComponent<Text>();
        scoreGUI.text = currentDemerits.ToString();
    }


    public void Update()
    {
        if (isGameOver)
        {
            if (Input.GetButtonDown("Pay Respects"))
            {
                RestartGame();
            }
        }
    }

    public void AddDemerit(int amount)
    {
        GUI.enabled = true;
        currentDemerits += amount;
        AudioSource.PlayClipAtPoint(wrongSound, player.transform.position);
        if (currentDemerits >= 15)
        {
            GameOverMenu(GameManager.Errors.MaxDemerits);
        }
        scoreGUI.text = currentDemerits.ToString();
    }

    public void GameOverMenu(Errors error)
    {
        GUI.enabled = true;
        isGameOver = true;
        AudioSource.PlayClipAtPoint(crashSound, player.transform.position);

        foreach (Transform t in gameoverGUI.transform)
        {
            t.gameObject.SetActive(true);
        }

        Text errorMessage = GameObject.FindGameObjectWithTag("ErrorMessage").GetComponent<Text>();

        if (error == Errors.HitCurb)
        {
            errorMessage.text =
                "You hit the curb! Looks like you need to take another trip to the DMV. Press X to restart.";
        }
        else if (error == Errors.HitPedestrian)
        {
            errorMessage.text =
                "You have to stop when the pedestrian is crossing! He is going to sue you for all you're worth! Press X to restart.";
        }
        else if (error == Errors.RanRed)
        {
            errorMessage.text = "You ran a red light! This is illegal, you know... Press X to restart.";
        }
        else if (error == Errors.TooFast)
        {
            errorMessage.text = "You were too fast and three furious. Press X to restart.";
        }
        else
        {
            errorMessage.text =
                "You got over 15 demerits! Looks like you need to take another trip to the DMV. Press X to restart.";
        }
    }

    public void PlayCorrectSound()
    {
        AudioSource.PlayClipAtPoint(correctSound, player.transform.position);
    }

    public void WinnerMenu()
    {
        winnerGUI = GameObject.FindGameObjectWithTag("Winner");

        GUI.enabled = true;
        isGameOver = true;
        AudioSource.PlayClipAtPoint(applauseSound, player.transform.position);

        foreach (Transform t in winnerGUI.transform)
        {
            t.gameObject.SetActive(true);
        }
    }


    public void ClickSeatBelt()
    {
        AudioSource.PlayClipAtPoint(seatbeltSound, player.transform.position);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLevelWasLoaded()
    {
        gameoverGUI = GameObject.FindGameObjectWithTag("Gameover");
        winnerGUI = GameObject.FindGameObjectWithTag("Winner");
        currentDemerits = 0;
        isGameOver = false;
        player = FindObjectOfType<CarController>();
        scoreGUI = GameObject.FindGameObjectWithTag("Demerits").GetComponent<Text>();
    }

}

