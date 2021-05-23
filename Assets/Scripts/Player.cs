using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
//using GoogleMobileAds.Api;
using System;


public class Player : MonoBehaviour
{
	public static bool lose = false;
	public Sprite sprite;
	public GameObject Restart;
	public GameObject RebornMe;
	public GameObject MainMenu;
	public GameObject Hat;
	private SpriteRenderer spriteRenderer;
	public Text CoinCounter;
	public Text BestScore;
	//public static BannerView bannerView;
	private Animator animator;
	public static bool train = false;
	string adUnitId = "ca-app-pub-5120590992757211/7229685150";
	public void Start()
	{
		
		//RequestBanner();
		CoinCounter.text = UIManager.player.Coins.ToString();
		if (!train)
		{
			BestScore.text = UIManager.player.BestScore.ToString();
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Coin")
		{
			UIManager.player.Coins++;
			CoinCounter.text = UIManager.player.Coins.ToString();
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "Bomb" || other.gameObject.tag == "Rocket")
		{
			animator = GetComponent<Animator>();
			animator.enabled = false;
			spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = sprite;
			Hat.transform.position = new Vector3(Hat.transform.position.x, Hat.transform.position.y, -1);
			lose = true;
			Restart.SetActive(true);
			MainMenu.SetActive(true);
			RebornMe.SetActive(true);
			if (UIManager.player.BestScore < SpawnBombs.count)
			{
				UIManager.player.BestScore = SpawnBombs.count;
			}
		}
	}	//private void RequestBanner()
	//{
	//	bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
	//	AdRequest request = new AdRequest.Builder().Build();
	//	bannerView.LoadAd(request);
	//}

}