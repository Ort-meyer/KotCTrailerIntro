using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class LightFlickerScript : MonoBehaviour
{

    public enum LightFlickerType
    {
        Sin, Tri, Square, Saw, Inv, Noise
    };
    // Use this for initialization
    public LightFlickerType m_type = LightFlickerType.Sin;
    public float m_base = 0.0f;
    public float m_amplitude = 1.0f;

    public float m_phase = 0.0f;
    public float m_frequency = 0.5f;
    private Color originalColor;
    private Light m_light;
    void Start()
    {
        m_light = GetComponent<Light>();
        originalColor = m_light.color;
    }



    void Update()
    {
        float x = (Time.time + m_phase) + m_frequency;

        m_light.color = originalColor * (Flicker());
    }

    private float Flicker()
    {
		float outVal = 0.0f;
		float modifier = (Time.time+m_phase)*m_frequency;
		modifier = modifier - Mathf.Floor(modifier);
        switch (m_type)
        {
            case LightFlickerType.Sin: 
			{
				outVal = Mathf.Sin(modifier*2*Mathf.PI);
				break;
			}
			case LightFlickerType.Tri: 
			{
				if(modifier < 0.5)
					outVal = 4.0f * modifier - 1.0f;
				else
					outVal= -4.0f * modifier + 3.0f;
				break;
			}
			case LightFlickerType.Square: 
			{
				if(modifier < 0.5)
					outVal = 1.0f;
				else
					outVal = -1.0f;
				break;
			}
			case LightFlickerType.Saw: 
			{
				outVal = modifier;
				break;
			}
			case LightFlickerType.Inv: 
			{
				outVal = 1.0f - modifier;
				break;
			}
			case LightFlickerType.Noise: 
			{
				outVal = 1 - (Random.value * m_frequency);
				break;
			}

        }
		return (outVal*m_amplitude)+m_base;
    }
	
}
