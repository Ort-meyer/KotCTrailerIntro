using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFuckingUp : MonoBehaviour {

    Material mat;
    public AnimationCurve m_curve;
    float m_time = 0.0f;
    public float m_endTime = 5.0f;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;	
	}
	
	// Update is called once per frame
	void Update () {
        m_time += Time.deltaTime;

        float alpha = Mathf.Min(m_time / m_endTime, 1.0f);
        float percentageGray = m_curve.Evaluate(alpha);
        mat.SetFloat("_GrayNess", percentageGray);

    }
}
