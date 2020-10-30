using UnityEngine;

public class GameController : MonoBehaviour {

	private int score; //For count score
	public Text scoreText; //For show score
	public Text newHighScoreText; //For show when player got high score
	public Text gameoverScoreText; //For show score when gameover
	public Text gameoverHighscoreText; //For show highscore when gameover
	public Canvas gameoverGUI; //For show GUI of gameover
	public Canvas ingameGUI;  //For show GUI when play (pause button ,scoreText)
	public Canvas pauseGUI; //For show GUI when pause
	public static GameController instance; //Instance

	void Awake(){
		instance = this;
	}

	public void addScore(){
		score++; //Plus score
		scoreText.text = score.ToString (); //Change scoreText to current score
	}

	public void GameOver(){
		CheckHighScore ();
		gameoverScoreText.text = score.ToString(); //Set score to gameoverScoreText
		gameoverHighscoreText.text = PlayerPrefs.GetInt ("highscore", 0).ToString(); //Set high score to gameoverHighscoreText
		gameoverGUI.gameObject.SetActive(true); //Show gameover's GUI
		ingameGUI.gameObject.SetActive(true); //Hide ingame's GUI
	}

	public void CheckHighScore(){
		if( score > PlayerPrefs.GetInt("highscore",0) ){ //If score > highscore
			PlayerPrefs.SetInt("highscore",score); //Save a new highscore
			newHighScoreText.gameObject.SetActive(true); //Enable newHighScoreText
		}
	}

	public void Pause(){
		Time.timeScale = 0; //Change timeScale to 0
		pauseGUI.gameObject.SetActive (true); //Show pauseGUI
	}

	public void Resume(){
		Time.timeScale = 1; //Change timeScale to 1
		pauseGUI.gameObject.SetActive (false); //Hide pauseGUI
	}
}
