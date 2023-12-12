using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GoblinMovement goblin;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {

        if (other.transform == player)
        {        
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            goblin.SeenPlayer(true);
        } else
        {
            goblin.SeenPlayer(false);
        }
    }
}