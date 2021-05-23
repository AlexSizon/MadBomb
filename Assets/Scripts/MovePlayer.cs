using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public Transform player;
	[SerializeField]
	public static float speed = 30f;
	private void OnMouseDrag()
	{
		if (!Player.lose)
		{
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			MousePos.x = MousePos.x > 3.15f ? 3.15f : MousePos.x;
			MousePos.x = MousePos.x < -3.15f ? -3.15f : MousePos.x;
			player.position = Vector3.MoveTowards(player.position, new Vector3(MousePos.x, player.position.y,1), speed * Time.deltaTime);
		}
	}
} 