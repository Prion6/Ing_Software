using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{

    public GameObject mainView;
    public List<AvatarSelectionPanel> avatarPanels;
    public GameObject avatarPanelLayout;
    AvatarSelectionPanel selectedPanel;

    public GameObject createView;

    public GameObject searchView;

    public GameObject disclaimer;

    public bool isPlayerSelected(PlayerData data)
    {
        foreach(AvatarSelectionPanel a in avatarPanels)
        {
            if (a.data.Equals(data))
                return true;
        }
        return false;
    }

    public void AddAvatarPanel(PlayerData data)
    {
        if (isPlayerSelected(data)) return;
        selectedPanel.Fill(data);
        foreach(AvatarSelectionPanel p in avatarPanels)
        {
            if(!p.gameObject.activeSelf)
            {
                p.gameObject.SetActive(true);
                p.Empty();
                break;
            }
        }
    }

    public void CreatePlayerOption(AvatarSelectionPanel panel)
    {
        selectedPanel = panel;
        mainView.SetActive(false);
        createView.SetActive(true);
    }

    public void SearchOldOption(AvatarSelectionPanel panel)
    {
        selectedPanel = panel;
        mainView.SetActive(false);
        searchView.SetActive(true);
    }

    public void TurnMainView(bool b)
    {
        mainView.SetActive(b);
    }

    public void Back()
    {
        GameManager.Instance.Data.SaveData();
        GameManager.LoadScene("MainMenu");
    }

    public List<PlayerData> GetAvatars()
    {
        List<PlayerData> datas = new List<PlayerData>();
        foreach(AvatarSelectionPanel a in avatarPanels)
        {
            if (!a.data.name.Equals(""))
                datas.Add(a.data);
        }
        return datas;
    }

    public void StartGame()
    {
        if (GameManager.Instance.SetPlayers(GetAvatars()))
        {
            GameManager.Instance.Data.SaveData();
            GameManager.LoadScene("Game");
        }
        else
        {
            StartCoroutine(Disclaimer());
        }
    }

    IEnumerator Disclaimer()
    {
        disclaimer.SetActive(true);
        yield return new WaitForSeconds(3);
        disclaimer.SetActive(false);
    }
}
