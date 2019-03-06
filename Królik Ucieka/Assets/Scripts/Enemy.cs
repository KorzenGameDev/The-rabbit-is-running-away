using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour
{

    [SerializeField] int damage=1;
    [SerializeField] AudioClip audioBoom;
    public GameObject boomParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player!=null)
        {
            player.TakeDamage(damage);
            Boom();
        }
        if(collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void Boom()
    {
        FindObjectOfType<GameMenager>().audioSource.PlayOneShot(audioBoom);
        CameraShaker.Instance.ShakeOnce(1f, 1f, .1f, 1);
        GameObject effect = Instantiate(boomParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, 2.5f);
        Destroy(gameObject);
    }
}
