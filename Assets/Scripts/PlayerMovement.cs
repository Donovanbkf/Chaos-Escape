using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour   //MonoBehaviour funciona gracias al using UnityEngine
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    
    Vector3 m_Movement;
    Vector3 m_Direction;
    Quaternion m_Rotation = Quaternion.identity;        //se usa para guardar rotaciones
    
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool Isclick = Input.GetMouseButton(0);
           
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool IsRunning = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsRunning", IsRunning);
  

        if (Input.GetMouseButton(0))                           
        {
            m_Animator.SetBool("IsRunning", false);
            m_Animator.SetBool("IsAttacking", true);
            Debug.Log("Click");
        }
        else
        {
            m_Animator.SetBool("IsAttacking", false);

        }

        if (IsRunning)
        {
            m_Animator.SetBool("IsOpening", false);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Animator.SetBool("IsOpening", true);
            Debug.Log("Espacio");
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
        
    }


    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}
