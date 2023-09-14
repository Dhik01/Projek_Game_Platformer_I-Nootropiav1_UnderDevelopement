using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject _buttonpause;
    public GameObject _buttonleft;
    public GameObject _buttonright;
    public GameObject _buttonjump;
    public GameObject _buttonabilty;
    public GameObject _InfoScreen;
    public void setup()
    {

        gameObject.SetActive(true);
        _buttonabilty.SetActive(false);
        _buttonjump.SetActive(false);
        _buttonleft.SetActive(false);
        _buttonright.SetActive(false);
        _buttonpause.SetActive(false);
        _InfoScreen.SetActive(false);
    }

    public void RestartButton()
    {
            SceneManager.LoadScene("PlayGame");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
