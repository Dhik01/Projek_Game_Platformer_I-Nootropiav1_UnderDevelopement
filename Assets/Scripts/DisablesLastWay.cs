using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablesLastWay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _LastPapanWay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InGameManager.Instance.HidePlatformPapanStart();
        }
    }

}
