using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFallDown : MonoBehaviour
{
	public static float FallSpeed = BombFallDown.FallSpeed*2;
	void Update()
    {
		if (transform.position.y < -6)
		{
			Destroy(gameObject);
		}
		transform.position -= new Vector3(0, FallSpeed * Time.deltaTime, 0);
	}
}
