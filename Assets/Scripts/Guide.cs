using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Guide_1;
    public GameObject Guide_2;
    public GameObject Guide_3;
    public GameObject Guide_4;
    public GameObject Guide_5;
    public GameObject Guide_6;

    public void ButtonToGuide2()
    {
        Guide_1.SetActive(false);
        Guide_3.SetActive(false);
        Guide_4.SetActive(false);
        Guide_5.SetActive(false);
        Guide_6.SetActive(false);
        Guide_2.SetActive(true);
    }
    public void ButtonToGuide3()
    {
        Guide_1.SetActive(false);
        Guide_2.SetActive(false);
        Guide_4.SetActive(false);
        Guide_5.SetActive(false);
        Guide_6.SetActive(false);
        Guide_3.SetActive(true);
    }
    public void ButtonToGuide4()
    {
        Guide_1.SetActive(false);
        Guide_2.SetActive(false);
        Guide_3.SetActive(false);
        Guide_5.SetActive(false);
        Guide_6.SetActive(false);
        Guide_4.SetActive(true);
    }
    public void ButtonToGuide5()
    {
        Guide_1.SetActive(false);
        Guide_2.SetActive(false);
        Guide_3.SetActive(false);
        Guide_4.SetActive(false);
        Guide_6.SetActive(false);
        Guide_5.SetActive(true);
    }
    public void ButtonToGuide6()
    {
        Guide_1.SetActive(false);
        Guide_2.SetActive(false);
        Guide_3.SetActive(false);
        Guide_4.SetActive(false);
        Guide_5.SetActive(false);
        Guide_6.SetActive(true);
    }
    public void ButtonToPlayGame()
    {
        SceneManager.LoadScene("PlayGame");
    }
}
