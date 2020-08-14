using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public List<Player> players;

    public int maxPlayers;
    public int minPlayers;

    public int turnLength;

    public int actualTurn;

    public Round round;

    public Game()
    {
        maxPlayers = 5;
        minPlayers = 3;
        turnLength = 60;
        actualTurn = 0;
        players = new List<Player>();
        round = Round.GAME;
    }

    public bool IsFull()
    {
        return !(players.Count < maxPlayers);
    }

    public bool PlayerMinimumReached()
    {
        return (players.Count >= minPlayers);
    }

    public int PlayersCount()
    {
        return players.Count;
    }

    public bool AddPlayer(PlayerData data)
    {
        foreach(Player p in players)
        {
            if(p.data.Equals(data))
            {
                return false;
            }
        }
        players.Add(new Player(data));
        return true;
    }

    public void RemovePlayer(PlayerData data)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (players[i].data.Equals(data))
            {
                players.RemoveAt(i);
                return;
            }
        }
    }
}

public enum Round
{
    GAME,
    VOTE
}
