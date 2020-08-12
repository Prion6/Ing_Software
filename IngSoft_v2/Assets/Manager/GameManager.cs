using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance { get { if (instance == null) { instance = new GameManager(); } return instance; } }

    public GameData Data;

    public Game Game;

    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public bool AddPlayerData(PlayerData p)
    {
        if (Data.players.Contains(p)) return false;
        Data.players.Add(p);
        return true;
    }

    public List<string> FetchConcepts(int amount)
    {
        if (amount > Data.concepts.Count) return null;
        List<string> list = new List<string>();
        string c = "";
        for (int i = 0; i < amount; i++)
        {
            do
            {
                c = Data.concepts[Random.Range(0, Data.concepts.Count)];
            } while (list.Contains(c));
            list.Add(c);
        }
        return list;
    }

    public PlayerData GetPlayerInTurn()
    {
        return (Game.players[Game.actualTurn]).data;
    }

    public void NextTurn()
    {
        Game.actualTurn++;
        if(Game.actualTurn >= Game.players.Count)
        {
            Game.actualTurn = 0;
            if (Game.round == Round.GAME)
            {
                Game.round = Round.VOTE;
                LoadScene("Voting");
            }
            else
            {
                Game.round = Round.GAME;
                LoadScene("LeaderBoard");
            }
        }
        else
        {
            if (Game.round == Round.VOTE)
            {
                LoadScene("Voting");
            }
            else
            {
                LoadScene("Game");
            }
        }
    }

    public void SetVotesToZero()
    {
        foreach(Player p in Game.players)
        {
            p.votes = 0;
        }
    }

    public void Vote(int i)
    {
        Game.players[i].votes++;
    }

}
