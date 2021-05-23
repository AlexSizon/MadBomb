using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFallDown : MonoBehaviour
{
	public static float FallSpeed = 6;
	void Update()
	{
		if (transform.position.y < -6)
		{
			Destroy(gameObject);
		}
		transform.position -= new Vector3(0, FallSpeed * Time.deltaTime, 0);
	}
}