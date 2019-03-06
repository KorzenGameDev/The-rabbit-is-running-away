using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    float multiple = 2f;
    int vIndex = 1;
    int playerLive = 3;
    public bool canFast = true;
    [SerializeField] AudioClip audioJump;

    Rigidbody2D rb;
    Transform[] target = new Transform[3];
    public GameObject jumpParticle;
    GameMenager gameMenager;

    //Public
    public float GetSpeed() { return (speed + 100f); }
    public void TakeDamage(int damage)
    {
        playerLive -= damage;
        if (playerLive <= 0) Dead();
        GetComponent<UI>().SetLiveUI(playerLive);
    }

    //Private
    private void Awake()
    {
        target[0] = GameObject.Find("SpawnerPoint (0)").transform;
        target[1] = GameObject.Find("SpawnerPoint (1)").transform;
        target[2] = GameObject.Find("SpawnerPoint (2)").transform;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameMenager = FindObjectOfType<GameMenager>();
    }
    private void Update()
    {
        VerticalMove();
    }
    private void FixedUpdate()
    {
        HorizontalMove();
    }
    private void HorizontalMove()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        if (hMove == 0 || !canFast)
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        else if(canFast)
            rb.velocity = Vector2.right * speed * Time.deltaTime * hMove * multiple;
    }
    private void VerticalMove()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            vIndex++;
            if (vIndex > target.Length - 1) vIndex = target.Length - 1;
            else
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, target[vIndex].position.y);
                Jump();
            }
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            vIndex--;
            if (vIndex < 0) vIndex = 0;
            else
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, target[vIndex].position.y);
                Jump();
            }
        }
    }
    private void Jump()
    {
        gameMenager.audioSource.PlayOneShot(audioJump);
        GameObject effect = Instantiate(jumpParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, 2f);
    }
    private void Dead()
    {
        GameMenager gameMenager = FindObjectOfType<GameMenager>();
        gameMenager.Lose();
    }
}
