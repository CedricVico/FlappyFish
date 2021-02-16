using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The UIManager is null");
            }
            return _instance;
        }
    }
    public Text scoreTxt;
    public Text scoreFinal;
    public int score;
    public GameObject Panel;
    public GameObject Start;
    public GameObject MenuPause;
    private void Awake()
    {
        _instance = this;
        score = 0;
        scoreTxt.text = "Score: " + score;
        scoreFinal.text = "Score: " + score;
        Panel.SetActive(false);
        Start.SetActive(true);
        MenuPause.SetActive(false);
    }
    public void UpdateScore()
    {
        _instance.score += 1;
        _instance.scoreTxt.text = "Score: " + _instance.score;
        _instance.scoreFinal.text = "Score: " + _instance.score;
    }
    public void UIPanel ()
    {
        Panel.SetActive(true);
    }
    public void UIStart()
    {
        Start.SetActive(false);
    }
    public void UIPause()
    {
        MenuPause.SetActive(true);
    }
    public void Continue()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1;
    }
}
