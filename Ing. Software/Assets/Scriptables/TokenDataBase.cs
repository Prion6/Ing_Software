using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TokenDataBase : ScriptableObject
{
    public List<Token> tokens;
    public Dictionary<string, Token> dictionary = new Dictionary<string, Token>();

    public void Load()
    {
        foreach (Token t in tokens)
        {
            dictionary.Add(t.name, t);
        }
    }
}

[System.Serializable]
public struct Token
{
    public string name;
    public GameObject token;
    public Image icon;
}
