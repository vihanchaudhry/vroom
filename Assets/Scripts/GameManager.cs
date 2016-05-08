using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameoverGUI;
    public bool isGameOver;

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

    public void addDemerit(int amount)
    {
        currentDemerits += amount;
        if (currentDemerits >= 15)
        {
            GameOverMenu();
        }
    }

    public void GameOverMenu()
    {
        GUI.enabled = true;
        isGameOver = true;

        foreach (Transform t in gameoverGUI.transform)
        {
            t.gameObject.SetActive(true);
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
