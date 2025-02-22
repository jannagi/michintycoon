using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, LvName }
    public InfoType type;

    Slider mySlider;
    TextMeshProUGUI myTextLevel;
    TextMeshProUGUI myTextLvName;
    

    private void Awake() {
        mySlider = GetComponent<Slider>();
        myTextLevel = GetComponent<TextMeshProUGUI>();
        myTextLvName = GetComponent<TextMeshProUGUI>();
    }

    private void LateUpdate() {
        switch (type) {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myTextLevel.text = string.Format("Lv.{0:F0}", GameManager.instance.level);
                break;
            case InfoType.LvName:
                myTextLvName.text = GameManager.instance.lvName[GameManager.instance.level];
                break;
        }
    }
}
