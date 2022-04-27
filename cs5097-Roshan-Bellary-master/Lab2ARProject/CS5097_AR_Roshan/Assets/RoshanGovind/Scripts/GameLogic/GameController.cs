using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameController : MonoBehaviour
{
    [SerializeField] private int m_CountdownTime;
    [SerializeField] private int m_IncreaseEnemySpeedAfter;
    [SerializeField] private float m_IncreaseSpeedBy;

    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private int m_TotalEnemiesCount;
    [SerializeField] private Player m_Player;
    [SerializeField] private Transform m_ARSessionOrigin;
    [SerializeField] private ARPlaneManager m_ARPlaneManager;

    private GameLogic m_GameLogic;

    private ARPlane m_CurrentPlane;

    private void Start()
    {
        StartGameEvent.Instance.AddListener(StartGame);
        PlayerHitEvent.Instance.AddListener(OnPlayerHit);
        GameOverEvent.Instance.AddListener(OnGameOver);

        m_ARPlaneManager.planesChanged += OnPlaneChanged;

        GUIStateModel.SetGUIState(GUIStateModel.GUIState.TitleScreen);
    }

    private void OnPlaneChanged(ARPlanesChangedEventArgs obj)
    {
        if (obj.added.Count > 0)
        {
            m_CurrentPlane = obj.added[0];
        }
    }

    private void StartGame()
    {
        List<GameObject> m_Enemies = new List<GameObject>();

        if (m_CurrentPlane != null)
        {
            for (int i = 0; i < m_TotalEnemiesCount; i++)
            {
                GameObject enemy = Instantiate(m_Enemy, m_ARSessionOrigin);
                enemy.SetActive(true);
                enemy.name = i.ToString();
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
                enemyComponent.SetUpEnemy(m_Player.transform);
                m_Enemies.Add(enemy);
            }
        }
        else
        {
            return;
        }

        if (m_Enemies.Count > 0)
        {
            m_Player.SetUpPlayer();

            if (m_GameLogic != null)
            {
               GameLogic.Instance.Reset();
            }

            m_GameLogic = new GameLogic(m_TotalEnemiesCount, m_Enemies, m_Player);
            PositionEnemies();
            StartCoroutine(BeginCountdown(m_CountdownTime));
        }
        else
        {
            Debug.Log("Waiting to find Plane.");
            UpdateCountdownEvent.Instance.Invoke("Waiting to detect plane.");
        }
    }

    IEnumerator BeginCountdown(int countdownSeconds)
    {
        for (int i = 0; i <= countdownSeconds; i++)
        {
            UpdateCountdownEvent.Instance.Invoke((countdownSeconds - i) + "");
            yield return new WaitForSeconds(1f);
        }

        UpdateCountdownEvent.Instance.Invoke("-1");
        OnCountdownEnd();
    }

    private void PositionEnemies()
    {
        List<GameObject> enemies = GameLogic.Instance.Enemies;
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].transform.position = m_CurrentPlane.transform.position + new Vector3((float)(0.5 * i), 0 , (float)(0.5 * i));
        }
    }

    private void OnCountdownEnd()
    {
        StartChaseEvent.Instance.Invoke();

        StartCoroutine(IncreaseSpeed(m_IncreaseEnemySpeedAfter));

        GameLogic.Instance.AliveTime = 0;
        StartAliveTimerEvent.Instance.Invoke();
    }

    IEnumerator IncreaseSpeed(int increaseEnemySpeedAfter)
    {
        for (;;)
        {
            yield return new WaitForSeconds(increaseEnemySpeedAfter);

            if (GameLogic.Instance.Enemies.Count > 0)
            {
                IncreaseEnemySpeedEvent.Instance.Invoke(m_IncreaseSpeedBy);
            }
        }
    }

    private void OnPlayerHit(int enemyID)
    {
        if (GameLogic.Instance.Enemies[enemyID].activeInHierarchy)
        {
            GameLogic.Instance.Enemies[enemyID].SetActive(false);
            GameLogic.Instance.Player.ReduceHealth();
        }
    }

    private void OnGameOver()
    {
        GUIStateModel.SetGUIState(GUIStateModel.GUIState.GameOverScreen);

        StopCoroutine("IncreaseSpeed");
    }
}
