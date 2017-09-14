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
        if (GameObject.Find("CameraSwitcher").GetComponent<CameraSwitcher>().started == false)
        {
            return;
        }

        if ((m_targetPosition.position - transform.position).magnitude < 0.01f)
        {
            transform.position = m_targetPosition.position;
            return;
        }

        Vector3 moveDirection = -1 * (transform.position - m_targetPosition.position).normalized;
        transform.position = transform.position + moveDirection * m_moveSpeed * Time.deltaTime;
    }
}
