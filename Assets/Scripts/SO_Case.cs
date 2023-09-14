using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Case", order = 1)]
public class SO_Case : ScriptableObject
{
    public string _case;
    public List<string> answer;
}
