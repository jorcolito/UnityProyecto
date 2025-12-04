using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySprinteRenderer;
    
    public GameObject bulletPrefab; 

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySprinteRenderer = GetComponent<SpriteRenderer>();
        
        StartCoroutine(WalkCoRutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumForce);
        }
        
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        
        if(mySprites.Length > 0)
        {
            mySprinteRenderer.sprite = mySprites[index];
            index++;
            if (index >= mySprites.Length){
                index = 0;
            }
        }
        
        StartCoroutine(WalkCoRutine());
    }
}