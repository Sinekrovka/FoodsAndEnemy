using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int timeGame;
    private GameObject _failScreen;
    private GameObject _winScreen;

    private void Awake()
    {
        Instance = this;
        _failScreen = GameObject.Find("FailScreen");
        _winScreen = GameObject.Find("WinScreen");
        _failScreen.SetActive(false);
        _winScreen.SetActive(false);
        StartCoroutine(Timer());
    }

    private void WinGame()
    {
        _winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void FailGame()
    {
        StopAllCoroutines();
        _failScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private IEnumerator Timer()
    {
        yield return  new WaitForSeconds(timeGame);
        WinGame();
    }

    public int TimeGame
    {
        get => timeGame;
        set => timeGame = value;
    }
}
