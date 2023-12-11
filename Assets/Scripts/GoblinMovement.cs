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

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    public void SeenPlayer(bool isSeen)
    {
        Debug.Log("Seen");
        m_IsPlayerSeen = isSeen;
        m_Animator.SetBool("IsRunning", isSeen);
    }

    public void AttackPlayer(bool isAttack)
    {
        Debug.Log("Seen2");
        m_IsPlayerAttack = isAttack;
        m_Animator.SetBool("IsAttacking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsPlayerSeen)
        {
            //m_Animator.SetBool("IsRunning", true);
            m_CurrentWaypointIndex = 0;
            navMeshAgent.SetDestination(waypointStart.position);
        }
        else
        {
            
            
            if (m_IsPlayerAttack)
            {
                Debug.Log("visto y ataco");
                stats.TakeDamage(1);
                //m_Animator.SetBool("IsRunning", false);
                m_Animator.SetBool("IsAttacking", true);
            } else
            {
                Debug.Log("visto y corro");
                //m_Animator.SetBool("IsAttacking", false);
                //m_Animator.SetBool("IsRunning", true);
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }


        }
    }
}
