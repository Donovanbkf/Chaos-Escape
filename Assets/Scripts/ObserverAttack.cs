using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverAttack : MonoBehaviour
{
    public Transform player;
    public GoblinMovement goblin;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {

        if (other.transform == player)
        {
            //Debug.Log("Attack1");
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
            goblin.AttackPlayer(true);
            Debug.Log("Attack");
            /*Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    Debug.Log("ObserverAttack visto");
                    
                }
            }*/
        }
    }
}