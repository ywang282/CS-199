using System.Collections;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {

	public float lifetime;
	void Start () {
		Destroy (gameObject, lifetime);
	}
}
