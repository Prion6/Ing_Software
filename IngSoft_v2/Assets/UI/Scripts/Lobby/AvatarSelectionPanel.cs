using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AvatarSelectionPanel : MonoBehaviour
{
    public GameObject emptyPanel;
    public GameObject fullPanel;

    public Image playerIcon;
    public Image playerToken;
    public Text playerName;

    public LobbyManager manager;
    public GameObject disclaimer;
    
    public PlayerData data;

    private void Start()
    {
        Empty();
    }

    public void Empty()
    {
        playerIcon.sprite = null;
        playerToken.sprite = null;
        playerName.text = "";
        fullPanel.gameObject.SetActive(false);
        emptyPanel.gameObject.SetActive(true);
        data = new PlayerData("","","");
    }

    public void TurnOff()
    {
        Empty();
        GameManager.Instance.Game.RemovePlayer(data);
    }

    public void Fill(PlayerData player)
    {
        data = player;
        fullPanel.gameObject.SetActive(true);
        playerIcon.sprite = GameManager.Instance.Data.GetIcon(player.icon);
        playerToken.sprite = GameManager.Instance.Data.GetToken(player.token).icon;
        playerName.text = player.name;
        emptyPanel.gameObject.SetActive(false);
    }

    public void CreateNewPressed()
    {
        manager.CreatePlayerOption(this);
    }

    public void SearchOldPressed()
    {
        if (GameManager.Instance.Data.players.Count != 0)
            manager.SearchOldOption(this);
        else
            StartCoroutine(Disclaimer());
    }

    IEnumerator Disclaimer()
    {
        disclaimer.SetActive(true);
        yield return new WaitForSeconds(3);
        disclaimer.SetActive(false);
    }
}
