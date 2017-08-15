using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public int seconds;
    public GameObject GOPanel;
    public static UIController Instance;
    public Text winner;

    void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver(int playerID)
    {
        StartCoroutine(Wait(playerID));
    }

    public void Rematch()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Wait(int playerID)
    {
        print("Empezó la corrutina");
        yield return new WaitForSeconds(seconds);
        print("Esperó 1 segundo");
        print("Game Over");
        GOPanel.SetActive(true);
        playerID = (playerID % 2) + 1;
        winner.text = "Player " + playerID + " Wins";
    }
}