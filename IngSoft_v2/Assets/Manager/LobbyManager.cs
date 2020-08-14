﻿using System.Collections;
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
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Game = new Game();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAvatarPanel(PlayerData data)
    {
        if (!GameManager.Instance.Game.AddPlayer(data)) return;
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

    public void StartGame()
    {
        if (GameManager.Instance.Game.PlayerMinimumReached())
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
