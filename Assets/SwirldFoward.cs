using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirldFoward : MonoBehaviour {

    public Transform endpos;

    bool started = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.S))
        {
            started = true;
        }
        if (started == false)
        {
            return;
        }


        Vector3 moveDirection = -1 * (transform.position - endpos.position).normalized;
        transform.position = transform.position + moveDirection * Time.deltaTime;

    }
}
