using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [Header("Текст подсказки")]
    [TextArea(3, 10)]
    [SerializeField] private string message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TipsManager.displayTipEvent?.Invoke(message);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TipsManager.disabeTipEvent?.Invoke();
        }
    }
}
