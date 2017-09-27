using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float m_movespeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0, 0, -1) * m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(1, 0, 0) * m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0, 0, 1) * m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(-1, 0, 0) * m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement += new Vector3(0, -1, 0) * m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movement += new Vector3(0, 1, 0) * m_movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            movement *= 10;
        }

        transform.localPosition = transform.localPosition + movement;
    }
}
