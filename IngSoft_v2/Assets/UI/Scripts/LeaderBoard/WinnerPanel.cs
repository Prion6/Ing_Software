using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerPanel : MonoBehaviour
{
    public Image playerIcon;
    public Text playerName;
    public Image tokenIcon;

    public void Init(PlayerData player)
    {
        playerIcon.sprite = GameManager.Instance.Data.GetIcon(player.icon);
        tokenIcon.sprite = GameManager.Instance.Data.GetToken(player.token).icon;
        playerName.text = player.name;
    }
}
