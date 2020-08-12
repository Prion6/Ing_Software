using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VotingPanel : MonoBehaviour
{
    public Image icon;
    public Text playerName;

    public void Init(PlayerData data)
    {
        icon = GameManager.Instance.Data.GetIcon(data.icon);
        playerName.text = data.name;
    }
}
