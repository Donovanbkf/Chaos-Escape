using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAttack : MonoBehaviour
{
    public Transform mjolnir;
    public GoblinMovement goblin;

    bool m_IsGoblinDead;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == mjolnir)
        {
            m_IsGoblinDead = true;
        }
    }

    private void Update()
    {
        if (m_IsGoblinDead)
        {
            Destroy(goblin);
            goblin.Die(true);
        }
    }
}
