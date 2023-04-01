using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    [SerializeField] private Sprite regularSprite;
    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite stunnedSprite;

    public Rigidbody2D myRigidBody;
    public float flapStrenght;      
    public LogicScript logic;
    private bool birdIsAlive = true;
    private int targetFPS = 60;

      void Start()
    {
        Application.targetFrameRate = targetFPS;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (((Input.touchCount > 0) || Input.GetKeyDown(KeyCode.Space)) && birdIsAlive)
        {
            Jump();
        }
    }

    public void Jump()
    {
        GetComponent<SpriteRenderer>().sprite = jumpSprite;
        myRigidBody.velocity = Vector2.up * 10;
        StartCoroutine(ResetSprite());

    }

    private IEnumerator ResetSprite()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = regularSprite;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = stunnedSprite;
        logic.gameOver();
        birdIsAlive = false;

    }
}
