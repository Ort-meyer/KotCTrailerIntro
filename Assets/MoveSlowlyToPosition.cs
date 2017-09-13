using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlowlyToPosition : MonoBehaviour
{

    public Transform m_targetPosition;
    public float m_moveSpeed;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (transform.position - m_targetPosition.position).normalized;
        transform.position = transform.position + moveDirection * m_moveSpeed * Time.deltaTime;
    }
}
