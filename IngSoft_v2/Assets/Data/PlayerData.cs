using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerData
{
    public PlayerData(string _name, string _icon, string _token)
    {
        name = _name;
        icon = _icon;
        token = _token;
    }

    public string name;
    public string icon;
    public string token;
}
