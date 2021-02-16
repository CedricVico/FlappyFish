using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The GameManager is null");
            }
            return _instance;
        }
    }
    public enum GameState
    {
        InGame,
        Pause,
        Death,
    }
    private GameState _gameState;
    public GameState State
    {
        get
        {
            return _gameState;
        }
    }
    public void Awake()
    {
        _instance = this;
    }
    public void Start()
    {
        Time.timeScale = 0;
    }

    bool pause = false;
    bool init = true;
    bool mort = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            ChangeState(GameState.Pause);
        }
        if (init == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UIManager.instance.UIStart();
                ChangeState(GameState.InGame);
                init = false;
            }
        }
        if (mort == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                mort = false;
            }
        }
    }

    public void ChangeState(GameState state)
    {
        _gameState = state;
        switch (_gameState)
        {
            case GameState.InGame:
                this.Game();
                Debug.Log("Game");
                break;
            case GameState.Pause:
                this.Pause();
                Debug.Log("Pause");
                break;
            case GameState.Death:
                this.Death();
                Debug.Log("Death");
                break;
        }
    }
    void Death()
    {
        Time.timeScale = 0;
        UIManager.instance.UIPanel();
        mort = true;
    }
    void Pause()
    {
        if (pause == true)
        {
            Time.timeScale = 0;
            UIManager.instance.UIPause();
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void Game()
    {
        Time.timeScale = 1;
    }
    public void Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
