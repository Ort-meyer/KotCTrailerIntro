using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirldFoward : MonoBehaviour {

    public Transform endpos;
    Vector3 startPos;

    float rotated = 0;



    bool started = false;
    static float laps = 1.0f;
    static float timeToMove = 0.5f;
    static float rotateAmount = laps*6.0f*1.0f/timeToMove;
    float curTime = 0.0f;
    Animation anim;

    bool hasDoneStuff = false;
	// Use this for initialization
	void Start () {
        anim = GameObject.Find("TrailerSceneIntroPushbutton").GetComponent<Animation>();
        anim["TrailerSceneIntro_Pushbutton"].speed = 1.5f;
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.S) && started == false)
        {
            started = true;
            anim.Play();
        }
        if (started == false)
        {
            return;
        }
        var clipTime = anim["TrailerSceneIntro_Pushbutton"].time;




        curTime += Time.deltaTime;

        float alpha = Mathf.Min(curTime / timeToMove, 1.0f);
        if (clipTime > 0.2f && anim.isPlaying && hasDoneStuff == false)
        {
            hasDoneStuff = true;
            anim["TrailerSceneIntro_Pushbutton"].speed = 0;
        }
        if (alpha > 0.8f)
        {
            anim["TrailerSceneIntro_Pushbutton"].speed = 1.5f;
        }



        transform.position = startPos * (1.0f - alpha) + endpos.position * alpha;
        if (rotated < 360* laps)
        {
            transform.Rotate(new Vector3(0, 0, rotateAmount));
            rotated += rotateAmount;
        }
        

    }
}
