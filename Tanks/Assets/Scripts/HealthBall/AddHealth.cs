using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour {

	public float m_HealthAdd = 10;
		
	void OnTriggerEnter(Collider other){
		//Destroy(gameObject);
		gameObject.SetActive (false);
		if (other.tag == "Tank") {
			Rigidbody tank = other.GetComponent<Rigidbody> ();
			TankHealth targetHealth = tank.GetComponent<TankHealth> ();
			targetHealth.addHealth (m_HealthAdd);
		}
	}
}