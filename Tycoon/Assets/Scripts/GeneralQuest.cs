using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralQuest : MonoBehaviour
{
    public GameObject[] overlayImages; // 띄울 이미지들의 배열
    public float probability = 0.1f; // 이미지가 나타날 확률 (0.1은 10% 확률을 의미)
    public int[] questExp = {5, 10, 10, 10};
    public GameObject eggPrefab; // 알 프리팹
    public float spawnProbability = 0.01f; // 알이 생성될 확률
    private float timer = 0f;
    private float updateInterval = 5.0f; // 업데이트 주기를 5초로 설정
    private bool isImageActive = false; // 이미지 활성화 여부
    private float imageDuration = 10.0f; // 이미지가 활성화된 상태를 유지할 시간
    private int activeImageIndex = -1; // 현재 활성화된 이미지의 인덱스


    void Update()
    {
        if (!isImageActive)
        {
            timer += Time.deltaTime;

            if (timer >= updateInterval)
            {
                timer = 0f; // 타이머 초기화
                
                if (Random.Range(0f, 1f) < probability)
                {
                    ShowRandomImage();
                }
            }
        }
        else
        {
            imageDuration -= Time.deltaTime;

            if (imageDuration <= 0f)
            {
                HideImage();
            }
        }
        
        // 이미지 클릭 처리
        if (isImageActive && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("ClickableImage"))
            {
                AddExpForImageClick();
                HideImage();
            }
        }
    }

    void ShowRandomImage()
    {
        activeImageIndex = Random.Range(0, overlayImages.Length);
        overlayImages[activeImageIndex].SetActive(true);

        isImageActive = true;
        imageDuration = 10.0f;
    }

    void HideImage()
    {
        overlayImages[activeImageIndex].SetActive(false);
        isImageActive = false; // 이미지가 비활성화됨
        activeImageIndex = -1;
    }

    void AddExpForImageClick()
    {
        if (activeImageIndex >= 0 && activeImageIndex < questExp.Length)
        {
            GameManager.instance.GainExp(questExp[activeImageIndex]);
        }
    }

    public void SpawnEgg(Vector3 position)
    {
        if (Random.Range(0f, 1f) < spawnProbability)
        {
            Instantiate(eggPrefab, position, Quaternion.identity);
        }
    }
}
