using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int m_Health;

    public int Health { get => m_Health;}

    public void SetUpPlayer()
    {
        // TODO: Make configurable.
        m_Health = 3;
        Debug.Log("Player Constructor");
        RegisterListeners();
    }

    private void RegisterListeners()
    {
        // TODO: Listen to reset timer conditions Event.
        Debug.Log("Player RegisterListeners()");

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter Player: " + other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            int.TryParse(other.name, out int enemyID);
            PlayerHitEvent.Instance.Invoke(enemyID);
        }
    }

    public void ReduceHealth()
    {
        m_Health -= 1;
        Debug.Log("Reduced Player Health to: " + m_Health);

        if (m_Health == 0)
        {
            GameOverEvent.Instance.Invoke();
        }
    }
}
