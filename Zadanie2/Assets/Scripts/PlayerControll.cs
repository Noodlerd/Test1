using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private Rigidbody2D rb;

    private int jumpCount=0;

    [SerializeField] private Text score;
    [SerializeField] private GameObject loseText;

    private void Start()
    {
        score.text = "0";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")){
            loseText.SetActive(true);
            ScoreManager.Instance.AddScore(ScoreManager.Instance.score);
            Time.timeScale = 0f;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bonus")){
            score.text = (System.Convert.ToInt64(score.text) + 1).ToString();
            Destroy(collision.gameObject);
            ScoreManager.Instance.score++;
        }
        if (collision.gameObject.CompareTag("Floor")){
            jumpCount = 0;
        }
    }

}
