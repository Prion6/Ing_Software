using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteManager : MonoBehaviour
{
    public List<VotingPanel> votePanels;
    public PlayerInfo actualPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < GameManager.Instance.Game.PlayersCount(); i++)
        {
            if (i != GameManager.Instance.Game.actualTurn)
                votePanels[i].gameObject.SetActive(true);
            else
                actualPlayer.Init(GameManager.Instance.Game.players[i].data);
            votePanels[i].Init(GameManager.Instance.Game.players[i].data);
        }
    }

    public void Vote(int i)
    {
        GameManager.Instance.Vote(i);
        GameManager.Instance.NextTurn();
    }

    public void EndTurn()
    {
        GameManager.Instance.NextTurn();
    }

    public void AbortGame()
    {
        GameManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
