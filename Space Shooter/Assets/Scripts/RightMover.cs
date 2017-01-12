using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMover : MonoBehaviour {

	public float speed;
	private Rigidbody rb; 

	void Start(){
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * speed;
	}
}
