using System.Collections;
using UnityEngine;

public class LeftMover : MonoBehaviour {

	public float speed;
	private Rigidbody rb; 

	void Start(){
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * -speed;
	}
}
