using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameoverGUI;
    public bool isGameOver;

    public enum Errors
    {
        RanRed,
        HitCurb,
        HitPedestrian,
        MaxDemerits
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
    public static int maxDemerits;


    public bool hasSentFeedback = false;

    // Use this for initialization
    void Start()
    {
        gameoverGUI = GameObject.FindGameObjectWithTag("Gameover");
        isGameOver = false;
        currentDemerits = 0;
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

    public void addDemerit(int amount)
    {
        currentDemerits += amount;
        if (currentDemerits >= 15)
        {
            GameOverMenu(GameManager.Errors.MaxDemerits);
        }
    }

    public void GameOverMenu(Errors error)
    {
        GUI.enabled = true;
        isGameOver = true;
         
        foreach (Transform t in gameoverGUI.transform)
        {
            t.gameObject.SetActive(true);
        }

        Text errorMessage = GameObject.FindGameObjectWithTag("ErrorMessage").GetComponent<Text>();

        if (error == Errors.HitCurb)
        {
            errorMessage.text = "You hit the curb! Looks like you need to take another trip to the DMV. Press X to restart";
        }
        else if (error == Errors.HitPedestrian)
        {
            errorMessage.text = "You have to stop when the pedestrians crossing! He is going to sue you for all you're worth. Press X to restart";
        }
        else if (error == Errors.RanRed)
        {
            errorMessage.text = "You ran a red light! This is illegal you know. Press X to restart";
        }
        else
        {
            errorMessage.text = "You got over 15 demerits! Looks like you need to take another trip to the DMV. Press X to restart";
        }
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLevelWasLoaded()
    {
        gameoverGUI = GameObject.FindGameObjectWithTag("Gameover");
        currentDemerits = 0;
    }
}
