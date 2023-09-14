using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject _buttonpause;
    public GameObject _buttonleft;
    public GameObject _buttonright;
    public GameObject _buttonjump;
    public GameObject _buttonabilty;
    public GameObject _InfoScreen;
    public bool _isPaused;
    public AudioSource _BGMMusic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _BGMMusic.Stop();
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        _buttonabilty.SetActive(false);
        _buttonjump.SetActive(false);
        _buttonleft.SetActive(false);
        _buttonright.SetActive(false);
        _buttonpause.SetActive(false);
        _InfoScreen.SetActive(false);
    }

    public void ResumeGame()
    {
        _BGMMusic.Play();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
        _buttonabilty.SetActive(true);
        _buttonjump.SetActive(true);
        _buttonleft.SetActive(true);
        _buttonright.SetActive(true);
        _buttonpause.SetActive(true);
        _InfoScreen.SetActive(true);
    }
    public void MainMenuPage()
    {
        SceneManager.LoadScene("MainMenu");
        _isPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
