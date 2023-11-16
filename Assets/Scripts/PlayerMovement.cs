using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour   //MonoBehaviour funciona gracias al using UnityEngine
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    //AudioSource m_AudioSource;
    Vector3 m_Movement;
    Vector3 m_Direction;
    Quaternion m_Rotation = Quaternion.identity;        //se usa para guardar rotaciones
    
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        //m_AudioSource = GetComponent<AudioSource>();
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
        //m_Animator.SetBool("IsAttacking", Isclick);

  

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

        //float targetAngle = Mathf.Atan2(m_Movement.x, m_Movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        //transform.rotation = Quaternion.Euler(0, angle, 0);

        //Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

    }


    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}
