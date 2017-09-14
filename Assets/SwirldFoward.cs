using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirldFoward : MonoBehaviour {

    public Transform endpos;
    Vector3 startPos;

    float rotated = 0;
    float rotateAmount = 5.0f;


    bool started = false;
    float timeToMove = 1.0f;
    float curTime = 0.0f;
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GameObject.Find("TrailerSceneIntroPushbutton").GetComponent<Animation>();
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


        if (clipTime > 0.5f && anim.isPlaying)
        {
            anim.enabled = false;
        }
        if (curTime > 0.8f && anim.isPlaying == false)
        {
            anim.enabled = true;
        }

        float alpha = Mathf.Min(curTime / timeToMove, 1.0f);

        transform.position = startPos * (1.0f - alpha) + endpos.position * alpha;
        if (rotated < 360)
        {
            transform.Rotate(new Vector3(0, 0, rotateAmount));
            rotated += rotateAmount;
        }
        

    }
}
