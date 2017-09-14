using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{


    public float[] segmentBreakPoints;

    public Camera[] cameras;

    int m_currentSegment = 0;
    float m_time = 0;

    public bool started = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            started = true;
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Play();
        }

        if (started == false)
        {
            return;
        }

        m_time += Time.deltaTime;

        
        if (m_currentSegment < segmentBreakPoints.Length)
        {
            if (m_time > segmentBreakPoints[m_currentSegment])
            {
                Debug.Log("switch");
                m_currentSegment++;
                m_time = 0;
                cameras[m_currentSegment-1].gameObject.SetActive(false);
                cameras[m_currentSegment].gameObject.SetActive(true);

                //cameras[m_currentSegment - 1].enabled = false;
                //cameras[m_currentSegment].enabled = true;

            }
        }
    }
}
