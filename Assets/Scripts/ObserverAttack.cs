using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverAttack : MonoBehaviour
{
    public Transform player;
    public GoblinMovement goblin;
    public HeartParent hearts;
    bool m_IsPlayerInRange;

    private float timer = 0f;
    private float duration = 1.2f;

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
            timer += Time.deltaTime;
            goblin.AttackPlayer(true);

            if (timer >= duration)
            {
                bool muerto = goblin.IsDead();
                if (muerto == false)
                {
                    hearts.DesactivarVida();
                    timer = 0f;
                }
            }

        } else
        {
            goblin.AttackPlayer(false);
        }
    }
}