using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int timeGame;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(Timer());
    }

    private void WinGame()
    {
        
    }

    public void FailGame()
    {
        StopAllCoroutines();
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
