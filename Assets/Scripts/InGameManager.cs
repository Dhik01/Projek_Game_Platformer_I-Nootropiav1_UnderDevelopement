using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance { get; private set; }
    [SerializeField] public GameObject papan;
    [SerializeField] public GameObject papan_2;
    [SerializeField] public GameObject papan_3;
    [SerializeField] private SO_Case _Cases;
    [SerializeField] private SO_Case _Cases_2;
    [SerializeField] private SO_Case _Cases_3;
    [SerializeField] private SO_Case _Cases_4;
    [SerializeField] private SO_Case _Cases_5;
    [SerializeField] private List<string> values;

    private int valuesCount;
    public Paperclue[] papers;
    public PlayerController playerController;
    public Switch _switch;
    public Switch _switch_2;
    public Switch _switch_3;
    public Switch _switch_4;
    public Switch _switch_5;
    public bool areGameObjectsEnabled;
    public GameObject _ParentPaperClue;
    public GameObject _ParentPaperClue_2;
    public GameObject _ParentPaperClue_3;
    public GameObject _ParentPaperClue_4;
    public GameObject _ParentPaperClue_5;
    public GameObject _ParentPapanFloating;
    public GameObject _ParentStartPapan;

    public GameObject _ParentFinishPoint;

    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] private AudioSource CorrectAnswerSoundEffect;

    //Screeen Score
    public int Score;
    public bool ResetScore;
    [SerializeField] private TMP_Text ScoreDisplay;
    [SerializeField] private TMP_Text WrongDisplay;
    public int wrong;
    public int WrongValues;
    [SerializeField] private TMP_Text LifePointDisplay;
    public int LifePoint;
    private int LPValues;

    //Getter And Setter
    public List<string> Values { get { return values; } set { values = value; } }

    void Start()
    {
        papan.SetActive(false);
        papan_2.SetActive(false);
        papan_3.SetActive(true);

    }

    void Awake()
    {
        Instance = this;

    }


    void Update()
    {
        if (!areGameObjectsEnabled)
        {
            for (int i = 0; i < _ParentPaperClue.transform.childCount; i++)
            {
                // Get the child at the specified index
                Transform child = _ParentPaperClue.transform.GetChild(i);

                // Do something with the child GameObject
                GameObject childObject = child.gameObject;

                // Example: Disable each child GameObject
                childObject.SetActive(true);
            }
            for (int i = 0; i < _ParentPaperClue_2.transform.childCount; i++)
            {
                // Get the child at the specified index
                Transform child_2 = _ParentPaperClue_2.transform.GetChild(i);

                // Do something with the child GameObject
                GameObject childObject_2 = child_2.gameObject;

                // Example: Disable each child GameObject
                childObject_2.SetActive(true);
            }
            for (int i = 0; i < _ParentPaperClue_3.transform.childCount; i++)
            {
                // Get the child at the specified index
                Transform child_3 = _ParentPaperClue_3.transform.GetChild(i);

                // Do something with the child GameObject
                GameObject childObject_3 = child_3.gameObject;

                // Example: Disable each child GameObject
                childObject_3.SetActive(true);
            }
            for (int i = 0; i < _ParentPaperClue_4.transform.childCount; i++)
            {
                // Get the child at the specified index
                Transform child_4 = _ParentPaperClue_4.transform.GetChild(i);

                // Do something with the child GameObject
                GameObject childObject_4 = child_4.gameObject;

                // Example: Disable each child GameObject
                childObject_4.SetActive(true);
            }
            for (int i = 0; i < _ParentPaperClue_5.transform.childCount; i++)
            {
                // Get the child at the specified index
                Transform child_5 = _ParentPaperClue_5.transform.GetChild(i);

                // Do something with the child GameObject
                GameObject childObject_5 = child_5.gameObject;

                // Example: Disable each child GameObject
                childObject_5.SetActive(true);
            }
            values.Clear();
            valuesCount = 0;
            areGameObjectsEnabled = true;
            Score = 0;
            WrongScore(WrongValues);
            PlayerController.InstancePC.Hiddenpapan_1.SetActive(false);
            PlayerController.InstancePC.Hiddenpapan_2.SetActive(false);
            PlayerController.InstancePC.HiddenTrap.SetActive(false);
            PlayerController.InstancePC._Papertrap_1.SetActive(false);
            PlayerController.InstancePC._Papertrap_2.SetActive(false);
            PlayerController.InstancePC._Papertrap_3.SetActive(false);
            PlayerController.InstancePC._Papertrap_4.SetActive(false);

        }


    }

    public void DeactiveText()
    {
        papers = FindObjectsOfType(typeof(Paperclue)) as Paperclue[];
        foreach (Paperclue paper in papers)
        {
            paper.TextObj.gameObject.SetActive(true);

        }
    }

    public void Validation(int level)
    {
        if (level == 1)
        {
            for (int i = valuesCount; i < values.Count; i++)
            {
                if (!values[i].Equals(_Cases.answer[i]))
                {
                    if (wrong >= 4)
                    {
                        if (LifePoint == 0)
                        {
                            playerController.GameOverScreen();
                        }
                        else
                        {
                            DeathSoundEffect.Play();
                            LifePoint -= 1;
                            playerController.transform.position = playerController.respawnPoint;
                            _switch._isPressed = false;
                            _switch.ResetPosition();
                            _switch._BallonClue.SetActive(false);
                            areGameObjectsEnabled = false;
                        }

                    }
                    else
                    {
                        DeathSoundEffect.Play();
                        playerController.transform.position = playerController.respawnPoint;
                        _switch._isPressed = false;
                        _switch.ResetPosition();
                        _switch._BallonClue.SetActive(false);
                        areGameObjectsEnabled = false;
                        WrongValues = 1;
                    }
                }
                else
                {
                    valuesCount++;
                }
                if (valuesCount == _Cases.answer.Count)
                {
                    CorrectAnswerSoundEffect.Play();
                    papan.SetActive(true);
                    LPValues = 1;
                    LPScore(LPValues);
                    Score = 0;
                    ResetScore = true;
                    values.Clear();
                    valuesCount = 0;
                    PlayerController.InstancePC._Level = 0;
                }
            }
        }
        else if (level == 2)
        {
            for (int i = valuesCount; i < values.Count; i++)
            {

                if (!values[i].Equals(_Cases_2.answer[i]))
                {
                    if (wrong >= 4)
                    {
                        if (LifePoint == 0)
                        {
                            playerController.GameOverScreen();
                        }
                        else
                        {
                            DeathSoundEffect.Play();
                            LifePoint -= 1;
                            playerController.transform.position = playerController.respawnPoint;
                            _switch_2._isPressed = false;
                            _switch_2.ResetPosition();
                            _switch_2._BallonClue.SetActive(false);
                            areGameObjectsEnabled = false;
                        }

                    }
                    else
                    {
                        DeathSoundEffect.Play();
                        playerController.transform.position = playerController.respawnPoint;

                        _switch_2._isPressed = false;
                        _switch_2.ResetPosition();
                        _switch_2._BallonClue.SetActive(false);
                        areGameObjectsEnabled = false;
                        WrongValues = 1;
                    }
                }
                else
                {
                    valuesCount++;
                }
                if (valuesCount == _Cases_2.answer.Count)
                {
                    CorrectAnswerSoundEffect.Play();
                    LPValues = 1;
                    LPScore(LPValues);
                    Score = 0;
                    ResetScore = true;
                    values.Clear();
                    valuesCount = 0;
                    papan_2.SetActive(true);
                    PlayerController.InstancePC._Level = 0;
                }
            }
        }else if (level == 3)
        {
            for (int i = valuesCount; i < values.Count; i++)
            {

                if (!values[i].Equals(_Cases_3.answer[i]))
                {
                    if (wrong >= 4)
                    {
                        if (LifePoint == 0)
                        {
                            playerController.GameOverScreen();
                        }
                        else
                        {
                            DeathSoundEffect.Play();
                            LifePoint -= 1;
                            playerController.transform.position = playerController.respawnPoint;
                            _switch_3._isPressed = false;
                            _switch_3.ResetPosition();
                            _switch_3._BallonClue.SetActive(false);
                            areGameObjectsEnabled = false;
                        }

                    }
                    else
                    {
                        DeathSoundEffect.Play();
                        playerController.transform.position = playerController.respawnPoint;

                        _switch_3._isPressed = false;
                        _switch_3.ResetPosition();
                        _switch_3._BallonClue.SetActive(false);
                        areGameObjectsEnabled = false;
                        WrongValues = 1;
                    }
                }
                else
                {
                    valuesCount++;
                }
                if (valuesCount == _Cases_3.answer.Count)
                {
                    CorrectAnswerSoundEffect.Play();
                    LPValues = 1;
                    LPScore(LPValues);
                    ResetScore = true;
                    Score = 0;
                    values.Clear();
                    valuesCount = 0;
                    PlayerController.InstancePC._Level = 0;
                    ShowFinishPoint();
                }
            }
        }
        else if (level == 4)
        {
            for (int i = valuesCount; i < values.Count; i++)
            {

                if (!values[i].Equals(_Cases_4.answer[i]))
                {
                    if (wrong >= 4)
                    {
                        if (LifePoint == 0)
                        {
                            playerController.GameOverScreen();
                        }
                        else
                        {
                            DeathSoundEffect.Play();
                            LifePoint -= 1;
                            playerController.transform.position = playerController.respawnPoint;
                            _switch_4._isPressed = false;
                            _switch_4.ResetPosition();
                            _switch_4._BallonClue.SetActive(false);
                            areGameObjectsEnabled = false;
                        }

                    }
                    else
                    {
                        DeathSoundEffect.Play();
                        playerController.transform.position = playerController.respawnPoint;

                        _switch_4._isPressed = false;
                        _switch_4.ResetPosition();
                        _switch_4._BallonClue.SetActive(false);
                        areGameObjectsEnabled = false;
                        WrongValues = 1;
                    }
                }
                else
                {
                    valuesCount++;
                }
                if (valuesCount == _Cases_4.answer.Count)
                {
                    CorrectAnswerSoundEffect.Play();
                    LPValues = 1;
                    LPScore(LPValues);
                    ResetScore = true;
                    Score = 0;
                    values.Clear();
                    valuesCount = 0;
                    PlayerController.InstancePC._Level = 0;
                    ShowFinishPoint();
                    papan_3.SetActive(false);
                }
            }
        }
        else if (level == 5)
        {
            for (int i = valuesCount; i < values.Count; i++)
            {

                if (!values[i].Equals(_Cases_5.answer[i]))
                {
                    if (wrong >= 4)
                    {
                        if (LifePoint == 0)
                        {
                            playerController.GameOverScreen();
                        }
                        else
                        {
                            DeathSoundEffect.Play();
                            LifePoint -= 1;
                            playerController.transform.position = playerController.respawnPoint;
                            _switch_5._isPressed = false;
                            _switch_5.ResetPosition();
                            _switch_5._BallonClue.SetActive(false);
                            areGameObjectsEnabled = false;
                        }

                    }
                    else
                    {
                        DeathSoundEffect.Play();
                        playerController.transform.position = playerController.respawnPoint;

                        _switch_5._isPressed = false;
                        _switch_5.ResetPosition();
                        _switch_5._BallonClue.SetActive(false);
                        areGameObjectsEnabled = false;
                        WrongValues = 1;
                    }
                }
                else
                {
                    valuesCount++;
                }
                if (valuesCount == _Cases_5.answer.Count)
                {
                    CorrectAnswerSoundEffect.Play();
                    LPValues = 1;
                    LPScore(LPValues);
                    ResetScore = true;
                    Score = 0;
                    values.Clear();
                    valuesCount = 0;
                    PlayerController.InstancePC._Level = 0;
                    ShowFinishPoint();
                }
            }
        }

    }

    public void _TriggerTrap()
    {
        if (LifePoint == 0)
        {
            playerController.GameOverScreen();
        }
        else
        {
            DeathSoundEffect.Play();
            LifePoint -= 1;
            playerController.transform.position = playerController.respawnPoint;
            _switch._isPressed = false;
            _switch.ResetPosition();
            _switch._BallonClue.SetActive(false);

            _switch_2._isPressed = false;
            _switch_2.ResetPosition();
            _switch_2._BallonClue.SetActive(false);

            _switch_3._isPressed = false;
            _switch_3.ResetPosition();
            _switch_3._BallonClue.SetActive(false);

            _switch_4._isPressed = false;
            _switch_4.ResetPosition();
            _switch_4._BallonClue.SetActive(false);

            _switch_5._isPressed = false;
            _switch_5.ResetPosition();
            _switch_5._BallonClue.SetActive(false);

            areGameObjectsEnabled = false;
            Score = 0;
        }

    }
    private void OnGUI()
    {
        ScoreDisplay.text = Score.ToString();
        WrongDisplay.text = wrong.ToString();
        LifePointDisplay.text = LifePoint.ToString();
    }

    public void ChangeScore(int amount)
    {
        if (ResetScore == true)
        {
            Score *= amount;
        }
        else
        {
            Score += amount;
        }

    }

    public void WrongScore(int WrongAmount)
    {
        wrong += WrongAmount;
    }

    public void LPScore(int LPAmount)
    {
        LifePoint += LPAmount;
    }

    //level 4-5
    public void HidePlatformPapanStart()
    {
        for (int i = 0; i < _ParentStartPapan.transform.childCount; i++)
        {
            // Mengambil child pada indeks yang ditentukan
            Transform childpapanstart = _ParentStartPapan.transform.GetChild(i);

            // Menonaktifkan child GameObject
            childpapanstart.gameObject.SetActive(false);
        }
    }
    public void HidePlatformPapanFLT()
    {
        for (int i = 0; i < _ParentPapanFloating.transform.childCount; i++)
        {
            // Mengambil child pada indeks yang ditentukan
            Transform childpapanFLT = _ParentPapanFloating.transform.GetChild(i);

            // Menonaktifkan child GameObject
            childpapanFLT.gameObject.SetActive(false);
        }
    }

    public void ShowFinishPoint()
    {
        for (int i = 0; i < _ParentFinishPoint.transform.childCount; i++)
        {
            // Mengambil child pada indeks yang ditentukan
            Transform childfinishpoint = _ParentFinishPoint.transform.GetChild(i);

            // Menonaktifkan child GameObject
            childfinishpoint.gameObject.SetActive(true);
        }
    }
    public void HideFinishPoint()
    {
        for (int i = 0; i < _ParentFinishPoint.transform.childCount; i++)
        {
            // Mengambil child pada indeks yang ditentukan
            Transform childfinishpoint = _ParentFinishPoint.transform.GetChild(i);

            // Menonaktifkan child GameObject
            childfinishpoint.gameObject.SetActive(false);
        }
    }
}

