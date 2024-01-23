using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggClick : MonoBehaviour
{
    public int moneyValue = 1; // 이 알이 클릭될 때 증가할 금액

    void OnMouseDown()
    {
        GameManager.instance.eggMoney += moneyValue; // eggMoney 증가
        Destroy(gameObject); // 알 게임 오브젝트 파괴
    }
}
