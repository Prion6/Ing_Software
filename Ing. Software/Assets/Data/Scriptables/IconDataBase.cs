using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IconDataBase : ScriptableObject
{
    public List<Icon> icons;
    public Dictionary<string,Image> dictionary = new Dictionary<string, Image>();

    public void Load()
    {
        foreach(Icon i in icons)
        {
            dictionary.Add(i.name, i.icon);
        }
    }
}

[System.Serializable]
public struct Icon
{
    public string name;
    public Image icon;
}

