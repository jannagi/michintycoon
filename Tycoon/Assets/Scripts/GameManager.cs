using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject goosePrefab;
	public Transform spawnPoint;
	public int eggMoney = 10;
	public TextMeshProUGUI eggText;
	public TextMeshProUGUI warningText;
	public int level = 1;
	public string[] lvName = {"", "초보 거위지기", "열정적인 거위지기", "능숙한 거위지기", "거위의 친구", "거위 목장의 수호자", "거위 전문가", "거위 목장의 지배자", "거위 대목장의 주인", "거위 대통령", "전설의 거위지기"};
	public int exp;
	public int[] nextExp = {0, 20, 40, 80, 140, 220, 320, 440, 580, 740, 920};


	private void Awake()
	{
		instance = this;
	}

	private void Update()
	{
		eggText.text = string.Format("{0:n0}", eggMoney);
	}

	public void SpawnGoose()
	{
		if (eggMoney <= 0)
		{
			StartCoroutine(ShowWarningMessage("재화가 부족합니다", 2f));
		}
		else
		{
			eggMoney--;
			Instantiate(goosePrefab, spawnPoint.position, Quaternion.identity).SetActive(true);
		}
	}

	private IEnumerator ShowWarningMessage(string message, float delay)
    {
        warningText.text = message;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        warningText.gameObject.SetActive(false);
    }

	public void GainExp(int gainExp)
	{
		if (level < 10)
		{
			exp += gainExp;
			
			if (exp >= nextExp[level])
			{
				exp -= nextExp[level];
				level++;

				if (level == 10)
				{
					exp = 920;
				}
			}
		}
	}
}