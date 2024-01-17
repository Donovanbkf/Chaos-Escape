using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    Animator m_Animator;
    bool m_IsPlayerSeen = false;
    bool m_IsPlayerAttack = false;
    public PlayerStats stats;

    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform waypointStart;
    // Start is called before the first frame update
    int m_CurrentWaypointIndex;
    bool isDead = false;

    private float timer = 0f;
    private float duration = 0.6f;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SeenPlayer(bool isSeen)
    {
        if (isDead == false)
        {
            m_IsPlayerSeen = isSeen;
            m_Animator.SetBool("IsRunning", isSeen);
        }
    }

    public void AttackPlayer(bool isAttack)
    {
        if (isDead == false)
        {
            m_IsPlayerAttack = isAttack;
            m_Animator.SetBool("IsAttacking", isAttack);
        }
    }

    public void Die(bool Dead)
    {
        if (m_IsPlayerAttack)
        {
            Debug.Log("muerto");
            isDead = true;
            Debug.Log(isDead);
            m_Animator.SetBool("IsDead", Dead);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsPlayerSeen)
        {
            m_CurrentWaypointIndex = 0;
            navMeshAgent.SetDestination(waypointStart.position);
        }
        else
        {
            
            if (m_IsPlayerAttack)
            {
                if (isDead == false)
                {
                    m_Animator.SetBool("IsAttacking", true);
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer >= duration)
                    {
                        m_Animator.SetBool("IsDead", true);
                    }
                }
            } else
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }

        }
    }
}
