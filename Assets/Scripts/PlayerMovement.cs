using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour   //MonoBehaviour funciona gracias al using UnityEngine
{
    public float speed = 20f;
    public float turnSpeed = 20f;
    public Transform cameraTransform;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Transform m_Transform;
    
    Vector3 m_Movement;
    Vector3 m_Direction;
    Quaternion m_Rotation = Quaternion.identity;        //se usa para guardar rotaciones
    
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private Vector3 Movement(float vertical, float horizontal, float speed)
    {
        Vector3 forward = Vector3.Normalize(m_Transform.position - cameraTransform.position);
        Vector3 right = Vector3.Cross(Vector3.up, forward);
        Vector3 displacement = Vector3.Normalize((forward * vertical) + (right * horizontal));
        return displacement * speed;
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

        //bool IsRunning = hasHorizontalInput || hasVerticalInput;
        bool IsRunning = hasVerticalInput;
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

            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Animator.SetBool("IsOpening", true);
            Debug.Log("Espacio");
        }
        m_Transform.Rotate(new Vector3(0f, horizontal * turnSpeed * Time.fixedDeltaTime, 0f));
        //Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        //m_Rotation = Quaternion.LookRotation(desiredForward);

        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Transform.forward * vertical * speed * Time.fixedDeltaTime);
        //m_Rigidbody.MoveRotation(m_Transform.rotation);
    }


    void OnAnimatorMove()
    {
        //m_Rigidbody.MovePosition(m_Rigidbody.position + m_Transform.forward * m_Animator.deltaPosition.magnitude);
        //m_Rigidbody.MoveRotation(m_Transform.rotation);
    }

}
