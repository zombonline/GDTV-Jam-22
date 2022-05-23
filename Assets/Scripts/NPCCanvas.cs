using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCCanvas : MonoBehaviour
{
    Canvas canvas;
    public bool dead = false;
    [SerializeField] TextAsset bulletPoints;
    [SerializeField] TextMeshProUGUI bulletPointsText;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();

        bulletPointsText.text = "." + GetRandomLine();
    }

    string GetRandomLine()
    {
        var lines = bulletPoints.text.Split('/');
        return lines[Random.Range(0, lines.Length)];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && dead)
        {
            canvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.enabled = false;
        }
    }
}
