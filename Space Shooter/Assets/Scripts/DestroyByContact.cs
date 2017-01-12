using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject exposion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start (){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary"){
			return;
		}

		if (gameObject.tag == "Asteroid") {
			Instantiate(exposion, transform.position, transform.rotation);

			if (other.tag == "Player"){
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver();
			}
			gameController.AddScore (scoreValue);
			Destroy(other.gameObject);
			Destroy(gameObject);
		} else if (gameObject.tag == "Power Up") {
			if (other.tag == "Player"){
				Destroy(gameObject);
				GameObject[] asteroids;
				asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
				foreach (GameObject asteroid in asteroids) {
					Destroy(asteroid);
					Instantiate(exposion, asteroid.transform.position, asteroid.transform.rotation);
				}
				gameController.AddScore (scoreValue * asteroids.Length);
			}
			if (other.tag == "Bolt"){
				Destroy(other.gameObject);
			}
		} else {
			// impossible
		}
	}
}
