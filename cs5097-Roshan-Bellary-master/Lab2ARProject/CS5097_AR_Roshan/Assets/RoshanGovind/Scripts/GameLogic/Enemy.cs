using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform m_WayPoint;
    private Vector3 m_WayPointPosition;
    public float m_Speed = 0.05f;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetUpEnemy(Transform player)
    {
        Debug.Log("Enemy Set up Enemy: " + this.gameObject.name);

        RegisterListeners();
        SetWaypoint(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter In: " + gameObject.name);
    }

    private void SetWaypoint(Transform player)
    {
        m_WayPoint = player;
    }

    private void RegisterListeners()
    {
        StartChaseEvent.Instance.AddListener(OnStartChase);
        IncreaseEnemySpeedEvent.Instance.AddListener(OnIncreaseSpeed);
    }

    private void OnStartChase()
    {
        StartCoroutine(StartChase());
    }

    IEnumerator StartChase()
    {
        for (;;)
        {
            //m_WayPointPosition = new Vector3(m_WayPoint.position.x, transform.position.y, m_WayPoint.position.z);

            //this.gameObject.transform.rotation = new Quaternion(0, - m_WayPoint.rotation.y, 0, transform.rotation.w);
            this.gameObject.transform.LookAt(m_WayPoint);
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, m_WayPoint.position, m_Speed * Time.deltaTime);

            yield return new WaitForSeconds(0.25f);
            Debug.Log("(COROUTINE) Enemy StartChase: " + this.gameObject.name);
        }
    }

    private void OnIncreaseSpeed(float increaseSpeedBy)
    {
        m_Speed += increaseSpeedBy;
        Debug.Log("Enemy OnIncreaseSpeed: " + this.gameObject.name + "; New Speed: " + m_Speed);
    }
}
