using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlowlyToPosition : MonoBehaviour
{
    bool hasStarted = false;

    public Transform m_targetPosition;
    public float m_moveSpeed;

    Quaternion startRot;
    public float rotTime = 2.0f;
    float startTime = 0.00000000000000f;

    // Use this for initialization
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("CameraSwitcher").GetComponent<CameraSwitcher>().started == false)
        {
            return;
        }
        else if(startTime < 0.0001)
        {
            startTime = Time.time;
        }

        if ((m_targetPosition.position - transform.position).magnitude < 0.01f)
        {
            transform.position = m_targetPosition.position;
            return;
        }

        Vector3 moveDirection = -1 * (transform.position - m_targetPosition.position).normalized;
        transform.position = transform.position + moveDirection * m_moveSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(startRot, m_targetPosition.rotation, Mathf.Min(((Time.time - startTime) / rotTime), 1.0f));

        print(Mathf.Min(((Time.time - startTime) / rotTime), 1.0f).ToString());
    }
}
