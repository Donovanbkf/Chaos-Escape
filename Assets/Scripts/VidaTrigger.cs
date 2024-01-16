using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaTrigger : MonoBehaviour
{
    public GameObject player;
    public PlayerStats stats;

    bool m_IsPlayerAtChest;
    bool m_ChestOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtChest = true;
        }
    }

    private void Update()
    {
        if (m_IsPlayerAtChest)
        {
            if (!m_ChestOpened)
            {
                stats.Heal(1);
                m_ChestOpened = true;
            }
        }
    }
}
