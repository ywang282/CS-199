using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject powerUp;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText highScoreText;

	private bool gameover;
	private bool restart;
	private int score;

	static int highscore;

	void Start () {
		gameover = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		highScoreText.text = "Highscore: " + highscore;
		highScoreText.color = Color.grey;
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{

			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

				if (i == hazardCount / 2) {
					Vector3 powerUpPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion powerupRotation = Quaternion.identity;
					Instantiate (powerUp, powerUpPosition, powerupRotation);
					yield return new WaitForSeconds (spawnWait);
				}
			}

			yield return new WaitForSeconds (waveWait);

			if (gameover) {
				restartText.text = "Press 'R' for restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore (){
		scoreText.text = "Score: " + score;
		if (score > highscore) {
			highscore = score;
			highScoreText.text = "Highscore: " + highscore;
			highScoreText.color = Color.green;
		}
	}

	public void GameOver(){
		gameover = true;
		gameOverText.text = "Game Over";
	}

	void Update (){
		if (restart){
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene( SceneManager.GetActiveScene().name );
			}
		}
	}

}
