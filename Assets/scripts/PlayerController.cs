using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public float xInput, yInput;
    public int score = 0;

    [SerializeField]  TextMeshProUGUI scoreText;
    [SerializeField]  TextMeshProUGUI winText; 

    public float coinsCollected = 0;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("Game");
        }

        if (coinsCollected == 5)
        {
            winText.gameObject.SetActive(true); 
        }
    }

    public void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * Speed, 0, yInput * Speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 10;
            coinsCollected++;
            Destroy(other.gameObject);
            UpdateScoreUI();
            print(scoreText.text);
        }
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
