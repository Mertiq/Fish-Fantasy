﻿using UnityEngine;
using System.Collections;

public class MovablePiece : MonoBehaviour {

	private GamePiece piece;
	private IEnumerator moveCoroutine;

	void Awake() {
		piece = GetComponent<GamePiece> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(int newX, int newY, float time)
	{
		if (moveCoroutine != null) {
			StopCoroutine (moveCoroutine);
		}

		moveCoroutine = MoveCoroutine (newX, newY, time);
		StartCoroutine (moveCoroutine);
	}

	public IEnumerator MoveCoroutine(int newX, int newY, float time)
	{
		piece.X = newX;
		piece.Y = newY;

		Vector3 startPos = transform.position;
		Vector3 endPos = piece.GridRef.GetWorldPosition (newX, newY);

		for (float t = 0; t <= 1 * time; t += Time.deltaTime) {
			piece.transform.position = Vector3.Lerp (startPos, endPos, t / time);
			yield return 0;
		}

		piece.transform.position = piece.GridRef.GetWorldPosition (newX, newY);
	}
}
