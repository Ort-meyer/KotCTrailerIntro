using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlowlyUp : MonoBehaviour
{

    Vector3 m_startPos = new Vector3();

    public float m_moveSpeed;
    public float m_stopHeight;


    // Use this for initialization
    void Start()
    {
        m_startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < m_stopHeight)
            transform.position = transform.position + new Vector3(0, m_moveSpeed, 0);
    }
}

