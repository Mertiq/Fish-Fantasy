using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour {

	[System.Serializable]
	public struct ButtonPlayerPrefs
	{
		public GameObject gameObject;
		public string playerPrefKey;
	}

	public ButtonPlayerPrefs[] buttons;


	public static bool delete;
	// Use this for initialization
	private void Update()
	{
		if (delete)
		{
			PlayerPrefs.DeleteKey("LastIndex");
			for (int i = 0; i < buttons.Length; i++)
			{
				PlayerPrefs.DeleteKey(buttons[i].playerPrefKey);
			}
			delete = false;

			for (int i = 0; i < buttons.Length; i++)
			{

				Debug.Log(PlayerPrefs.GetInt("LastIndex"));
				if (i <= PlayerPrefs.GetInt("LastIndex"))
				{
					buttons[i].gameObject.SetActive(true);
				}
				else
				{
					buttons[i].gameObject.SetActive(false);
				}
				int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);

				for (int starIdx = 1; starIdx <= 3; starIdx++)
				{
					Transform star = buttons[i].gameObject.transform.Find("star" + starIdx);

					if (starIdx <= score)
					{
						star.gameObject.SetActive(true);
					}
					else
					{
						star.gameObject.SetActive(false);
					}
				}
			}
		}
		delete = false;
	}
	void Start () {
		
		if (delete)
		{
			PlayerPrefs.DeleteKey("LastIndex");
			for (int i = 0; i < buttons.Length; i++)
			{
				PlayerPrefs.DeleteKey(buttons [i].playerPrefKey);
			}
			delete = false;
		}
		
		for (int i = 0; i < buttons.Length; i++)
		{
			
			Debug.Log(PlayerPrefs.GetInt("LastIndex"));
			if(i <= PlayerPrefs.GetInt("LastIndex"))
			{
				buttons[i].gameObject.SetActive(true);
			}
			else
			{
				buttons[i].gameObject.SetActive(false);
			}
			
			int score = PlayerPrefs.GetInt (buttons [i].playerPrefKey, 0);

			for (int starIdx = 1; starIdx <= 3; starIdx++) {
				Transform star = buttons [i].gameObject.transform.Find ("star" + starIdx);

				if (starIdx <= score) {
					star.gameObject.SetActive (true);
				} else {
					star.gameObject.SetActive (false);
				}
			}
		}		
	}


	public void OnButtonPress(string levelName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (levelName);
	}

	public GameObject[] panels;
	
	public void PanelChange(GameObject p)
	{
		foreach (var panel in panels)
		{
			if(p == panel)
			{
				panel.SetActive(true);
			}
			else
			{
				panel.SetActive(false);
			}
		}
	}

	
	
}
