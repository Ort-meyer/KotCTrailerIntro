using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackUpwards : MonoBehaviour {
    bool started = false;
    public Transform moveTo;
    static float timeToMove = 1.5f;
    float curTime = 0.0f;

    static float rotateAmount =  2.0f * 1.0f / timeToMove;
    float rotated = 0.0f;


    bool startedMoving = false;
    Vector3 startPos;
    // Use this for initialization
    void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S) && started == false)
        {
            started = true;
        }
        if (started == false)
        {
            return;
        }

        curTime += Time.deltaTime;

        // This is added to total time 
        float stopTime = 0.5f;
        if (curTime < stopTime && startedMoving == false)
        {
            return;
        }
        if (startedMoving == false)
        {
            startedMoving = true;
            curTime = 0.0f;
        }

        float alpha = Mathf.Min((curTime) / (timeToMove), 1.0f);

        transform.position = startPos * (1.0f - alpha) + moveTo.position * alpha;

        if (rotated < 180 )
        {
            transform.Rotate(new Vector3(0, -rotateAmount, 0));
            rotated += rotateAmount;
        }
    }
}
