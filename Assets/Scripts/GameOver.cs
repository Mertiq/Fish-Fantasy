using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public GameObject screenParent;
	public GameObject scoreParent;
	public Text loseText;
	public Text scoreText;
	public Image[] stars;
	bool win = false;

	// Use this for initialization
	void Start () {
		screenParent.SetActive (false);

		for (int i = 0; i < stars.Length; i++) {
			stars [i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowLose()
	{
		win = false;
		screenParent.SetActive (true);
		scoreParent.SetActive (false);

		Animator animator = GetComponent<Animator> ();

		if (animator) {
			animator.Play ("GameOverShow");
		}
	}

	public void ShowWin(int score, int starCount)
	{
		win = true; 
		screenParent.SetActive (true);
		loseText.enabled = false;

		scoreText.text = score.ToString ();
		scoreText.enabled = false;

		Animator animator = GetComponent<Animator> ();

		if (animator) {
			animator.Play ("GameOverShow");
		}

		StartCoroutine (ShowWinCoroutine (starCount));
	}

	private IEnumerator ShowWinCoroutine(int starCount)
	{
		yield return new WaitForSeconds (0.5f);

		if (starCount < stars.Length) {
			for (int i = 0; i <= starCount; i++) {
				stars [i].enabled = true;

				if (i > 0) {
					stars [i - 1].enabled = false;
				}

				yield return new WaitForSeconds (0.5f);
			}
		}

		scoreText.enabled = true;
	}

	public void OnReplayClicked()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void OnDoneClicked()
	{
		int x = Random.Range(0, 10);
		if(x == 0)
		{
			ReklamRewarded.rewardedReklamGosterilecek = true;
		}
		else if(x > 7)
		{
			ReklamInterstitial.interstitialGosterilecek = true;
		}

		if (win)
		{
			if (SceneManager.GetActiveScene().buildIndex != 40)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		
	}
}
