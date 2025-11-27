using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float playerJumForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySprinteRenderer;
    //public GameObject Bullet;
    //public GameManager myGameManager;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySprinteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine(WalkCoRutine());
        //myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumForce);
        }
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Instantiate(Bullet, transform.position, Quaternion.identity);
        //}
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySprinteRenderer.sprite = mySprites[index];
        index++;
        if (index == 4){
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}