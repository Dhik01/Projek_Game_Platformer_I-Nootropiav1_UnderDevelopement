using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Push_button;
    public GameObject _BallonClue;

    float SwitchSizeY;
    float SwitchSpeed = 1f;
    Vector3 SwitchDownPos;
    public bool _isPressed;
    private Vector3 initialPosition;


    void Awake()
    {
        SwitchSizeY = 0.25f;
        SwitchDownPos = new Vector3(transform.position.x, transform.position.y - SwitchSizeY, transform.position.z);
        initialPosition = transform.position;

    }
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    void Start()
    {
        _BallonClue.SetActive(false);
    }

    void MoveSwitchDown()
    {
        if (transform.position != SwitchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, SwitchDownPos, SwitchSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (_isPressed)
        {
            MoveSwitchDown();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPressed = true;
            _BallonClue.SetActive(true);
        }
    }
}
