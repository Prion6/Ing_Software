using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance { get { if (instance == null) { instance = new GameManager(); } return instance; } }

    public GameData Data;

    public Game game;

    public static int maxPlayers = 4;
    public static int minPlayers = 3;

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

}
