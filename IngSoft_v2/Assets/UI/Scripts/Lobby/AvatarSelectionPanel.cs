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

    public void Empty()
    {
        playerIcon = null;
        playerToken = null;
        playerName.text = "";
        fullPanel.gameObject.SetActive(false);
        emptyPanel.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        Empty();
        gameObject.SetActive(false);
    }

    public void Fill(PlayerData player)
    {
        playerIcon.sprite = GameManager.Instance.Data.GetIcon(player.icon);
        playerToken.sprite = GameManager.Instance.Data.GetToken(player.token).icon;
        playerName.text = player.name;
        emptyPanel.gameObject.SetActive(false);
        fullPanel.gameObject.SetActive(true);
    }

    public void CreateNewPressed()
    {
        manager.CreatePlayerOption(this);
    }

    public void SearchOldPressed()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
