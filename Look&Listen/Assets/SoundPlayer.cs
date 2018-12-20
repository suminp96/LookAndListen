using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        ClipHolder clipHolder;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if ((clipHolder = hit.transform.gameObject.GetComponent<ClipHolder>()))
            {
                clipHolder.Play();
            }
        }
	}
}
