using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float bounds = 4.0f;
    public float minWaitTime = 0.2f;
    public float maxWaitTime = 2.0f;
    private SpriteRenderer spriteRenderer;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private float stoppedTime = 0f;
    public GeneralQuest eggSpawner; // GeneralQuest 스크립트 참조

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MoveRandomly());
    }

    private void Update()
    {
        // 거위가 멈춰있는지 체크
        if (isMoving)
        {
            stoppedTime = 0f;
        }
        else
        {
            stoppedTime += Time.deltaTime;
            if (stoppedTime >= minWaitTime)
            {
                eggSpawner.SpawnEgg(transform.position); // 알 생성 메서드 호출
                stoppedTime = 0f; // 시간 초기화
            }
        }
    }

    IEnumerator MoveRandomly()
    {
        while(true)
        {
            SetRandomTarget();
            isMoving = true;

            while(isMoving)
            {
                MoveTowardsTarget();
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    void SetRandomTarget()
    {
        float randomX = Random.Range(-bounds, bounds);
        float randomY = Random.Range(-bounds, bounds);
        targetPosition = new Vector2(randomX, randomY);
    }

    void MoveTowardsTarget()
    {
        float xDirection = targetPosition.x - transform.position.x;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        FlipSpriteDirection(xDirection);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }

    void FlipSpriteDirection(float xDirection)
    {
        if (xDirection < 0) // 왼쪽으로 이동하는 경우
        {
            spriteRenderer.flipX = true; // 스프라이트를 좌우 반전
        }
        else if (xDirection > 0) // 오른쪽으로 이동하는 경우
        {
            spriteRenderer.flipX = false; // 스프라이트 반전 해제
        }
    }
}
