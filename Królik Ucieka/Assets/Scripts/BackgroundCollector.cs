using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour
{
    GameObject[] backgrounds;
    GameObject[] frontgrounds;
    float lastBGX;
    float lastFGX;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("BG");
        lastBGX = 0f;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].transform.position.x > lastBGX) lastBGX = backgrounds[i].transform.position.x;
        }
        frontgrounds = GameObject.FindGameObjectsWithTag("FG");
        lastFGX = 0f;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (frontgrounds[i].transform.position.x > lastFGX) lastFGX = frontgrounds[i].transform.position.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BG"))
        {
            Vector3 temp = collision.gameObject.transform.position;
            temp.x = lastBGX + 2f* collision.gameObject.GetComponent<BoxCollider2D>().size.x;
            collision.gameObject.transform.position = temp;
            lastBGX = temp.x;
        }
        if (collision.CompareTag("FG"))
        {
            Vector3 temp = collision.gameObject.transform.position;
            temp.x = lastFGX + 2f * collision.gameObject.GetComponent<BoxCollider2D>().size.x;
            collision.gameObject.transform.position = temp;
            lastFGX = temp.x;
        }
    }
}
