using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBombs : MonoBehaviour
{
	public GameObject Bomb;
	public GameObject LittleBomb;
	public GameObject Rocket;
	public GameObject Coin;
	public static int count;
	public Text text;
	private float RocketFrequrency = 6f;
	void Start()
	{
		StartCoroutine(BombSpawner());
		StartCoroutine(RocketSpawner());
		StartCoroutine(CoinSpawner());
	}

	public IEnumerator BombSpawner()
	{
		while (!Player.lose)
		{
			if (count % 10 == 0 && count != 0) BombFallDown.FallSpeed += 1; //speed up
			if (count < 60) StageOne(); //stage 1
			if (count > 60 && count < 130) StageTwo(); // stage 2
			if (count == 100) BombFallDown.FallSpeed = 8; //set default speed
			if (count > 130 && count < 150) StageThree(); //stage 3
			if (count > 200 && count < 250) StageFour(); //stage 4
			if (count > 250 && count < 300) StageSix(); //stage 6
			count++;
			text.text = count.ToString();
			yield return new WaitForSeconds(0.5f);
		}
	}
	public IEnumerator RocketSpawner()
	{
		while (!Player.lose)
		{
			if (count>1)
			{
				Instantiate(Rocket, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
				if (count > 200 && count < 250)
				{
					RocketFrequrency = 0.5f;
					Instantiate(Rocket, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity,transform);
				}
			}
			yield return new WaitForSeconds(RocketFrequrency);
		}
	}
	public IEnumerator CoinSpawner()
	{
		while (!Player.lose)
		{
			if (count > 0)
			{
				Instantiate(Coin, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
			}
			yield return new WaitForSeconds(5.5f);
		}
	}
	private void StageOne()
	{
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
	}
	private void StageTwo()
	{
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
	}
	private void StageThree()
	{
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
		Instantiate(LittleBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
	}
	private void StageFour()
	{
		BombFallDown.FallSpeed = 3;
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
		Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
	}
	private void StageSix()
	{
		BombFallDown.FallSpeed = 4;
		Instantiate(LittleBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
		Instantiate(LittleBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
		Instantiate(LittleBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0), Quaternion.identity, transform);
	}
}