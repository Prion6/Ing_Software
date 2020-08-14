using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public List<PlayerData> players;
    public TokenDataBase tokens;
    public IconDataBase icons;
    public List<string> concepts;
    public int version;

    public void Start()
    {
        players = DataManager.NewData<List<PlayerData>>("Data");
        icons.Load();
        tokens.Load();
        GameManager.Instance.Data = this;
    }

    public void SaveData()
    {
        DataManager.SaveData<List<PlayerData>>(players,"Data");
    }

    public Token GetToken(string name)
    {
        return tokens.dictionary[name];
    }

    public Token GetToken(int index)
    {
        return tokens.tokens[index];
    }

    public Sprite GetIcon(string name)
    {
        return icons.dictionary[name];
    }
    
    public Icon GetIcon(int index)
    {
        return icons.icons[index];
    }

    public int IconAmount()
    {
        return icons.dictionary.Count;
    }
    public int TokenAmount()
    {
        return tokens.dictionary.Count;
    }
}

