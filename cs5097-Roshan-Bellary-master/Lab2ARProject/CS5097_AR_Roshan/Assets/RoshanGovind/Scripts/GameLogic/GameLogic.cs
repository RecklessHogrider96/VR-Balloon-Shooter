using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    static public GameLogic Instance;

    private int m_EnemiesCount;
    private List<GameObject> m_Enemies;
    private Player m_Player;

    private float m_AliveTime;

    public GameLogic(int totalEnemiesCount, List<GameObject> enemies, Player player)
    {
        Instance = this;

        m_EnemiesCount = totalEnemiesCount;
        m_Enemies = enemies;
        m_Player = player;
    }

    public void Reset()
    {
        Instance = new GameLogic(0, null, null);
    }

    public int EnemiesCount { get => m_EnemiesCount; }
    public List<GameObject> Enemies { get => m_Enemies; }
    public Player Player { get => m_Player; }
    public float AliveTime { get => m_AliveTime; set => m_AliveTime = value; }
}
