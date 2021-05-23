using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine.Purchasing;
//using GoogleMobileAds.Api;

namespace Assets.Scripts
{
	public class UIManager : MonoBehaviour
	{
		public static PlayerInfo player = new PlayerInfo();
		public static int RebornCount = 0;
		string appId = "ca-app-pub-5120590992757211~3644118778";
		public void Start()
		{
			//MobileAds.Initialize(appId);
			//PurchaseManager.OnPurchaseConsumable += PurchaseManager_OnPurchaseConsumable;
		}

		private void PurchaseManager_OnPurchaseConsumable(PurchaseEventArgs args)
		{
			Debug.Log("Puchase My First:" + args.purchasedProduct.definition.id);
			player.Coins += 100;
		}
		public void UserLogin()
		{
			//PlayCloudDataManager.Instance.Login();
		}
		public void Restart()
		{
			if (Player.train)
			{
				SceneManager.LoadScene("Train");
				TrainBombsSpawner.count = 0;
			}
			else
			{
				//Player.bannerView.Destroy();
				SceneManager.LoadScene("MainGame");
			}
			RebornCount = 0;
			SpawnBombs.count = 0;
			BombFallDown.FallSpeed = 8f;
			Player.lose = false;
		}

		public void MainMenu()
		{
			SceneManager.LoadScene("MainMenu");
			SpawnBombs.count = 0;
			BombFallDown.FallSpeed = 8f;
			TrainBombsSpawner.count = 0;
			Player.train = false;
			Player.lose = false;
		}
		public void StartGame()
		{
			SceneManager.LoadScene("MainGame");
		}
		public void SelectStage()
		{
			SceneManager.LoadScene("Stages");
		}
		public void SelectStageTrain(int i)
		{
			Player.train = true;
			PlayerPrefs.SetInt("TrainingStage", i);
			SceneManager.LoadScene("Train");
		}
		public void RebornMe()
		{
			if (RebornCount == 0)
			{
				if (player.Coins >= 30)
				{
					player.Coins -= 30;
					if (Player.train)
					{
						SceneManager.LoadScene("Train");
					}
					else
					{
						SceneManager.LoadScene("MainGame");
					}
					RebornCount++;
					Player.lose = false;
				}
			}
		}
		public void IAPMenu()
		{
			PlayerPrefs.SetInt("SceneId", SceneManager.GetActiveScene().buildIndex);
			SceneManager.LoadScene("IAPMenu");
		}
		public void BackButton()
		{
			int IdScene = PlayerPrefs.GetInt("SceneId");
			if (Player.lose)
			{
				Player.lose = false;
				SpawnBombs.count = 0;
			}
			SceneManager.LoadScene(IdScene);
		}
		public void Shop()
		{
			PlayerPrefs.SetInt("SceneId", SceneManager.GetActiveScene().buildIndex);
			SceneManager.LoadScene("Shop");
		}
		public void LoadSettingsScene()
		{
			SceneManager.LoadScene("Settings");
		}
		public void ShowPrivacyPolicy()
		{
			Application.OpenURL("https://docs.google.com/document/d/12q5vSCJItPvbtAPmsO_s6W1O2fCUsvLp_QYcMzWJE0c/edit?usp=sharing");
		}
	}
}
