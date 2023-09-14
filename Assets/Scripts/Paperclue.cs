using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paperclue : MonoBehaviour
{
    [SerializeField] private string value;
    [SerializeField] private TextMeshProUGUI textValue;
    public int level;

    public string Value { get { return value; } }
    public TextMeshProUGUI TextObj { get { return textValue; } }


    void Start()
    {
        textValue.text = value;
    }
}
