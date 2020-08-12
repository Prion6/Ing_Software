using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(menuName = "DataBase/Icon")]
public class IconDataBase : ScriptableObject
{
    public List<Icon> icons;
    public Dictionary<string,Sprite> dictionary = new Dictionary<string, Sprite>();

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
    public Sprite icon;
}

