﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayerPanel : MonoBehaviour
{
    public Image icon;
    public Image token;
    public InputField playerName;

    int iconIndex;
    int tokenIndex;

    public LobbyManager manager;

    public GameObject disclaimer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.Instance);
        Debug.Log(GameManager.Instance.Data);
        icon.sprite = GameManager.Instance.Data.GetIcon(0).icon;
        token.sprite = GameManager.Instance.Data.GetToken(0).icon;
    }

    public void NextIcon()
    {
        iconIndex++;
        iconIndex = iconIndex % GameManager.Instance.Data.IconAmount();
        Debug.Log(GameManager.Instance);
        Debug.Log(GameManager.Instance.Data);
        icon.sprite = GameManager.Instance.Data.GetIcon(iconIndex).icon;
    }

    public void PrevIcon()
    {
        iconIndex--;
        if (iconIndex < 0) iconIndex = iconIndex + GameManager.Instance.Data.IconAmount();
        icon.sprite = GameManager.Instance.Data.GetIcon(iconIndex).icon;
    }

    public void NextToken()
    {
        tokenIndex++;
        tokenIndex = tokenIndex % GameManager.Instance.Data.TokenAmount();
        token.sprite = GameManager.Instance.Data.GetToken(tokenIndex).icon;
    }

    public void PrevToken()
    {
        tokenIndex--;
        if (tokenIndex < 0) tokenIndex = tokenIndex + GameManager.Instance.Data.TokenAmount();
        token.sprite = GameManager.Instance.Data.GetToken(tokenIndex).icon;
    }

    public void Back()
    {
        manager.TurnMainView(true);
        gameObject.SetActive(false);
    }

    public void Done()
    {
        PlayerData p = new PlayerData(playerName.text, GameManager.Instance.Data.GetIcon(iconIndex).name, GameManager.Instance.Data.GetToken(tokenIndex).name);
        if(GameManager.Instance.AddPlayerData(p))
        {
            manager.AddAvatarPanel(p);
            Back();
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
