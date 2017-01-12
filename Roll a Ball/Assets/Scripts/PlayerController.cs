using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 100;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start(){
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate(){
		float  moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}

		if (other.gameObject.CompareTag ("Stop Pill")) {
			other.gameObject.SetActive (false);
			rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		}

		if (other.gameObject.CompareTag ("Speed Up")) {
			rb.velocity *= 3;
		}

		if (other.gameObject.CompareTag ("Warp1")) {
			rb.position = new Vector3 (-17f, 1f, 17f);
		}

		if (other.gameObject.CompareTag ("Warp2")) {
			rb.position = new Vector3 (0f, 0f, 0f);
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12){
			winText.text = "You Win!";
		}
	}
}  
