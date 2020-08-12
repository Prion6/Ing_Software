using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour
{
    public Image icon;
    public Image token;
    public Text playerName;
    int index;

    public LobbyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill(int i)
    {
        PlayerData p = GameManager.Instance.Data.players[i];
        icon.sprite = GameManager.Instance.Data.GetIcon(p.icon);
        token.sprite = GameManager.Instance.Data.GetToken(p.token).icon;
        playerName.text = p.name;
    }

    public void Next()
    {
        index++;
        index = index % GameManager.Instance.Data.players.Count;
        Fill(index);
    }

    public void Prev()
    {
        index--;
        if (index < 0) index = index + GameManager.Instance.Data.players.Count;
        Fill(index);
    }

    public void Back()
    {
        manager.TurnMainView(true);
        gameObject.SetActive(false);
    }

    public void Done()
    {
        manager.AddAvatarPanel(GameManager.Instance.Data.players[index]);
        Back();
    }
}
