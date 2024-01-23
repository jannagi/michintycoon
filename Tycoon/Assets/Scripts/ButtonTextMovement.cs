using UnityEngine;
using UnityEngine.EventSystems; // EventSystems 네임스페이스 추가

public class ButtonTextMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform buttonText; // 버튼의 텍스트 RectTransform
    public Vector2 textMoveOffset; // 텍스트 위치 이동 값
    private Vector2 originalTextPosition; // 원래의 텍스트 위치

    void Start()
    {
        if (buttonText != null)
        {
            originalTextPosition = buttonText.anchoredPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveText();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetTextPosition();
    }

    private void MoveText()
    {
        if (buttonText != null)
        {
            buttonText.anchoredPosition = originalTextPosition + textMoveOffset;
        }
    }

    private void ResetTextPosition()
    {
        if (buttonText != null)
        {
            buttonText.anchoredPosition = originalTextPosition;
        }
    }
}
