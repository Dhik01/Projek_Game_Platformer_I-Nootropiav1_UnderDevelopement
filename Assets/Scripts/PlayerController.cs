using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxJumpVelocity;

    private PlayerInputActions inputActions;

    private bool isJumping;
    private bool isGrounded;
    private float horiz;

    public Paperclue[] papers;

    public Button _buttonAbility;
    private bool haflCD;
    public Image SignCD;

    public GameOver gameOver;
    public Vector3 respawnPoint;

    // Add a variable to keep track of the number of jumps
    private int jumpCount;

    // Add a constant to limit the maximum number of jumps
    private const int maxJumps = 2;

    //public Pause pause;

    public static PlayerController InstancePC;

    public GameObject TrapClosePath_1;
    public GameObject HiddenTrap;
    public GameObject Hiddenpapan_1;
    public GameObject Hiddenpapan_2;
    public GameObject _Papertrap_1;
    public GameObject _Papertrap_2;
    public GameObject _Papertrap_3;
    public GameObject _Papertrap_4;
    public int _Level;

    [SerializeField] private AudioSource JumpSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;
    public AudioSource BGMMusic;
    public GameObject GOSCR;
    public int _PCwrong;
    public int _PCLP;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Movement.Enable();

        InstancePC = this;

    }

    void Start()
    {
        Application.targetFrameRate = 75;

        //pause.gameObject.SetActive(false);
        TrapClosePath_1.gameObject.SetActive(false);
        HiddenTrap.gameObject.SetActive(false);
        Hiddenpapan_1.gameObject.SetActive(false);
        Hiddenpapan_2.gameObject.SetActive(false);
        _Papertrap_1.gameObject.SetActive(false);
        _Papertrap_2.gameObject.SetActive(false);
        _Papertrap_3.gameObject.SetActive(false);
        _Papertrap_4.gameObject.SetActive(false);
        GOSCR.SetActive(false);

        InGameManager.Instance.HideFinishPoint();

        rigidBody = GetComponent<Rigidbody2D>();
        // Initialize the jump count to zero
        jumpCount = 0;
        respawnPoint = transform.position;


        papers = FindObjectsOfType(typeof(Paperclue)) as Paperclue[];
        foreach (Paperclue paper in papers)
        {
            paper.TextObj.gameObject.SetActive(false);

        }
    }

    void Update()
    {
        horiz = inputActions.Player.Movement.ReadValue<float>();

        //CheckCDAbilityButton
        if (haflCD == true)
        {
            SignCD.fillAmount += 0.3f * Time.deltaTime;
            if (SignCD.fillAmount == 1)
            {
                haflCD = false;
                _buttonAbility.interactable = true;
                papers = FindObjectsOfType(typeof(Paperclue)) as Paperclue[];
                foreach (Paperclue paper in papers)
                {
                    paper.TextObj.gameObject.SetActive(false);

                }
            }
        }
    }

    public void GameOverScreen()
    {
        BGMMusic.Stop();
        gameOver.setup();
        gameObject.SetActive(false);
    }
    public void Jump()
    {
        // Check if the jump count is less than the maximum

        if (jumpCount < maxJumps)
        {
            // Increment the jump count
            JumpSoundEffect.Play();
            jumpCount++;
            // Set the isJumping flag to true
            isJumping = true;
        }
    }

    public void _abilityButton()
    {

        _buttonAbility.interactable = false;
        SignCD.fillAmount = 0;
        haflCD = true;
    }


    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(movementSpeed * horiz, rigidBody.velocity.y);

        if (isJumping)
        {
            isJumping = false;
            rigidBody.AddForce(new Vector2(0, jumpForce * 10));
        }

        // Limit the player's jump height
        if (rigidBody.velocity.y > maxJumpVelocity)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxJumpVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            // Reset the jump count when the player lands on the ground
            jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("PapanFloating"))
        {
            isGrounded = true;
            // Reset the jump count when the player lands on the ground
            jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("Startpapan"))
        {
            isGrounded = true;
            // Reset the jump count when the player lands on the ground
            jumpCount = 0;

        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_Level == 1)
        {
            if (collision.gameObject.CompareTag("PaperClue"))
            {
                collectSoundEffect.Play();
                InGameManager.Instance.Values.Add(collision.gameObject.GetComponent<Paperclue>().Value);
                InGameManager.Instance.Validation(_Level);
                collision.gameObject.SetActive(false);
            }else if (collision.gameObject.CompareTag("NextCL"))
            {
                InGameManager.Instance.papan.SetActive(false);
            }
        }
        else if (_Level == 2)
        {
            if (collision.gameObject.CompareTag("PaperClue"))
            {
                collectSoundEffect.Play();
                InGameManager.Instance.Values.Add(collision.gameObject.GetComponent<Paperclue>().Value);
                InGameManager.Instance.Validation(_Level);
                collision.gameObject.SetActive(false);
            }else if (collision.gameObject.CompareTag("NextCL"))
            {

                InGameManager.Instance.papan_2.SetActive(false);
            }
        }
        else if (_Level == 3)
        {
            if (collision.gameObject.CompareTag("PaperClue"))
            {
                collectSoundEffect.Play();
                InGameManager.Instance.Values.Add(collision.gameObject.GetComponent<Paperclue>().Value);
                InGameManager.Instance.Validation(_Level);
                collision.gameObject.SetActive(false);
            }
        }
        else if (_Level == 4)
        {
            if (collision.gameObject.CompareTag("PaperClue"))
            {
                collectSoundEffect.Play();
                InGameManager.Instance.Values.Add(collision.gameObject.GetComponent<Paperclue>().Value);
                InGameManager.Instance.Validation(_Level);
                collision.gameObject.SetActive(false);
            }
        }
        else if (_Level == 5)
        {
            if (collision.gameObject.CompareTag("PaperClue"))
            {
                collectSoundEffect.Play();
                InGameManager.Instance.Values.Add(collision.gameObject.GetComponent<Paperclue>().Value);
                InGameManager.Instance.Validation(_Level);
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("PlayGame_2");

        }
        else if (collision.gameObject.CompareTag("Finish_2"))
        {
            SceneManager.LoadScene("EndPlay");
        }
        else if (collision.gameObject.CompareTag("FinishPoint"))
        {
            InGameManager.Instance.HidePlatformPapanFLT();
        }
        else if (collision.gameObject.CompareTag("NextCL"))
        {
            InGameManager.Instance.papan.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("NextCL_2"))
        {
            InGameManager.Instance.papan_2.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Trap"))
        {
            InGameManager.Instance._TriggerTrap();
        }
        else if (collision.gameObject.CompareTag("ClosePath"))
        {
            TrapClosePath_1.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("ActivateTrap"))
        {
            HiddenTrap.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Activatepapan"))
        {
            Hiddenpapan_1.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Activatepapan_2"))
        {
            Hiddenpapan_2.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Level1"))
        {
            _Level = 1;
            InGameManager.Instance.Validation(_Level);
        }
        else if(collision.gameObject.CompareTag("Level2"))
        {
            _Level = 2;
            InGameManager.Instance.Validation(_Level);
        }
        else if (collision.gameObject.CompareTag("Level3"))
        {
            _Level = 3;
            InGameManager.Instance.Validation(_Level);
        }
        else if (collision.gameObject.CompareTag("Level4"))
        {
            _Level = 4;
            InGameManager.Instance.Validation(_Level);
        }
        else if (collision.gameObject.CompareTag("Level5"))
        {
            _Level = 5;
            InGameManager.Instance.Validation(_Level);
        }
        else if (collision.gameObject.CompareTag("Papertrap"))
        {
            _Papertrap_1.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Papertrap_2"))
        {
            _Papertrap_2.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Papertrap_3"))
        {
            _Papertrap_3.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Papertrap_4"))
        {
            _Papertrap_4.gameObject.SetActive(true);
        }
    }
}
