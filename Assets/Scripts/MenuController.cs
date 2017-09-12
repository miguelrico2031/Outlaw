using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject tut1;
    public GameObject tut2;
    public GameObject tut3;
    public void Play()
    {
      tut1.SetActive(true);
    }

    public void Next1()
    {
        tut1.SetActive(false);
        tut2.SetActive(true);
    }

    public void Next2()
    {
        tut2.SetActive(false);
        tut3.SetActive(true);
    }

    public void Next3()
    {
        SceneManager.LoadScene("Game");
    }
}
