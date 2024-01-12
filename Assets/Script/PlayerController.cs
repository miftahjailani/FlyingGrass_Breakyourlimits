using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    public float speed = 7;
    private float horizontalInput;
    private Rigidbody ballRb;
    public float jumpForce = 14.0f;
    private float gravityModifier = 2.0f;
    private float speedIncreasePerCoins = 0.4f;

    private SpawnRoad spawnRD;
    private bool isSpawning = false;

    private bool onGround = true;
    private bool isGameOver = false;


    public GameObject gameOverText;
    public GameObject restartBtn;
    public GameObject mainMenuBtn;

    [SerializeField] private AudioSource jumpEffect;
    [SerializeField] private AudioSource collectCoins;

    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        spawnRD = FindObjectOfType<SpawnRoad>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            jumpEffect.Play();
            ballRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, -3.9f, 3.9f);
        transform.position = newPosition;

        if (isGameOver) return;

        if (transform.position.y < -3)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isSpawning && other.CompareTag("Trigger"))
        {
            spawnRD.Spawn_Road();
            isSpawning = true;

            // Reset isSpawning dan menambahkan delay untuk menghindari spawn double
            StartCoroutine(ResetSpawnFlagAfterDelay(1f));
        }

        if (other.gameObject.CompareTag("Coins"))
        {
            collectCoins.Play();
            if (speed >= 25.0f)
            {
                speed = 25.0f;
            }
            else
            {
                speed += speedIncreasePerCoins;
            }
            
        }



    }

    public void GameOver()
    {

        gameOverText.SetActive(true);
        restartBtn.SetActive(true);
        mainMenuBtn.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }


    }

    public void Restart()
    {
        Physics.gravity = new Vector3(0, -12f, 0);
        gameOverText.SetActive(false);
        restartBtn.SetActive(false);
        mainMenuBtn.SetActive(false);
        Time.timeScale = 1;
        //Restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        
    }

    IEnumerator ResetSpawnFlagAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isSpawning = false;
    }




}
