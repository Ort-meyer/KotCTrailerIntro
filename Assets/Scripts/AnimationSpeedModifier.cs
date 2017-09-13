using UnityEngine;
using System.Collections;

public class AnimationSpeedModifier : MonoBehaviour {
    public float speedIncrease = 1.5f;
    public bool thisOnly = false;
    // Use this for initialization
    void Start()
    {
        foreach (AnimationState state in GetComponent<Animation>())
        {
            state.speed = speedIncrease;
            if(thisOnly)
            {
                break;
            }
        }

    }

    void Awake()
    {
        foreach (AnimationState state in GetComponent<Animation>())
        {
            state.speed = speedIncrease;
            if (thisOnly)
            {
                break;
            }
        }

    }

    public void ChangeSpeed(float newspeed)
    {
        foreach (AnimationState state in GetComponent<Animation>())
        {
            state.speed = newspeed;
            if (thisOnly)
            {
                break;
            }
        }
    }

}
