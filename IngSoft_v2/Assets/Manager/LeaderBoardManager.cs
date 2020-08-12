using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public List<TokenController> tokens;
    TokenController toMove;

    public WinnerPanel panel;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        int votes = 0;
        Player winner = GameManager.Instance.Game.players[0];
        for (int i = 0; i < GameManager.Instance.Game.PlayersCount(); i++)
        {
            Player p = GameManager.Instance.Game.players[i];
            if (p.votes > votes)
            {
                votes = p.votes;
                toMove = tokens[i];
                winner = p;
            }
            tokens[i].gameObject.SetActive(true);
            tokens[i].Init(GameManager.Instance.Data.GetToken(p.data.token).token);
            tokens[i].transform.position = tokens[i].transform.forward * p.score;
        }
        winner.score++;
        if(winner.score >= 10)
        {
            button.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            panel.Init(winner.data);
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

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
