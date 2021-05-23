using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainBombsSpawner : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject SmallBomb;
    public GameObject Rocket;
	public Text BombsCounter;
	public static int count = 0;
    void Start()
    {
        Player.train = true;
        int trainlevel = PlayerPrefs.GetInt("TrainingStage");
        switch (trainlevel)
        {
            case 1: StartCoroutine(StageOne()); break;
            case 2: StartCoroutine(StageTwo()); break;
            case 3: StartCoroutine(StageThree()); break;
            case 4: StartCoroutine(StageFour()); break;
            case 5: StartCoroutine(StageFive()); break;
            case 6: StartCoroutine(StageSix()); break;
        }
    }
    public IEnumerator StageOne()
    {
        while (!Player.lose)
        {
            if (count % 10 == 0)
            {
				BombFallDown.FallSpeed += 0.5f;
            }
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 1), Quaternion.identity);
            count++;
			BombsCounter.text = count.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator StageTwo()
    {
        while (!Player.lose)
        {
            if (count % 10 == 0)
            {
				BombFallDown.FallSpeed += 0.5f;
            }
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            count++;
			BombsCounter.text = count.ToString();
			yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator StageThree()
    {
        while (!Player.lose)
        {
            if (count % 10 == 0)
            {
                BombFallDown.FallSpeed += 0.5f;
            }
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            Instantiate(SmallBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            count++;
			BombsCounter.text = count.ToString();
			yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator StageFour()
    {
        BombFallDown.FallSpeed = 5;
        while (!Player.lose)
        {
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            Instantiate(Bomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            count++;
			BombsCounter.text = count.ToString();
			yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator StageFive()
    {
        while (!Player.lose)
        {
            Instantiate(Rocket, new Vector3(Random.Range(-3.15f, 3.15f), 5.5f, 2), Quaternion.identity);
            Instantiate(Rocket, new Vector3(Random.Range(-3.15f, 3.15f), 5.5f, 2), Quaternion.identity);
            count++;
			BombsCounter.text = count.ToString();
			yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator StageSix()
    {
		BombFallDown.FallSpeed = 8;
        while (!Player.lose)
        {
            if (count % 10 == 0)
            {
				BombFallDown.FallSpeed += 0.5f;
            }
            Instantiate(SmallBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            Instantiate(SmallBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            Instantiate(SmallBomb, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 2), Quaternion.identity);
            count++;
			BombsCounter.text = count.ToString();
			yield return new WaitForSeconds(0.5f);
        }
    }
}
