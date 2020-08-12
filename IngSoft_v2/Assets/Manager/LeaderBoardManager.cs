using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
    public List<TokenController> tokens;
    TokenController toMove;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        int votes = 0;
        for(int i = 0; i < GameManager.Instance.Game.PlayersCount(); i++)
        {
            Player p = GameManager.Instance.Game.players[i];
            if (p.votes > votes)
            {
                votes = p.votes;
                toMove = tokens[i];
            }
            tokens[i].gameObject.SetActive(true);
            tokens[i].Init(GameManager.Instance.Data.GetToken(p.data.token).token);
        }
    }

    // Update is called once per frame
    void Update()
    {
        toMove.Move(toMove.GetStep());
    }

    public void NextRound()
    {
        GameManager.Instance.SetVotesToZero();
        GameManager.LoadScene("Game");
    }

    public void AbortGame()
    {
        GameManager.LoadScene("MainMenu");
    }
}
