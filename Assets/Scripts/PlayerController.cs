using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private int missileAway = 2;
    private float xBound = 50.0f;
    private float yBound = 5.0f;
    private float zBound = 25.0f;
    private GameManager gameManager;
    private AudioSource playerAudio;
   

    public float moveForce = 10;
    public GameObject projectilePrefab;
    public ParticleSystem explosionParticle;
    public GameObject engagePrefab;
    public AudioClip engageSound;
    public AudioClip missileSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        explosionParticle.Stop(); 
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.isGameActive)
        {

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerRb.AddForce(Vector3.forward * moveForce, ForceMode.Impulse);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerRb.AddForce(Vector3.left * moveForce, ForceMode.Impulse);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                playerRb.AddForce(Vector3.back * moveForce, ForceMode.Impulse);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerRb.AddForce(Vector3.right * moveForce, ForceMode.Impulse);
            }

            // Lauch a projectile from the player 
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerAudio.PlayOneShot(missileSound, 1.0f);
                Vector3 direction = new Vector3(0, 0, missileAway);
                projectilePrefab.transform.rotation = Quaternion.LookRotation(direction);
                Instantiate(projectilePrefab, transform.position + direction, projectilePrefab.transform.rotation);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerAudio.PlayOneShot(missileSound, 1.0f);
                Vector3 direction = new Vector3(-missileAway, 0, 0);
                projectilePrefab.transform.rotation = Quaternion.LookRotation(direction);
                Instantiate(projectilePrefab, transform.position + direction, projectilePrefab.transform.rotation);


            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerAudio.PlayOneShot(missileSound, 1.0f);
                Vector3 direction = new Vector3(0, 0, -missileAway);
                projectilePrefab.transform.rotation = Quaternion.LookRotation(direction);
                Instantiate(projectilePrefab, transform.position + direction, projectilePrefab.transform.rotation);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerAudio.PlayOneShot(missileSound, 1.0f);
                Vector3 direction = new Vector3(missileAway, 0, 0);
                projectilePrefab.transform.rotation = Quaternion.LookRotation(direction);
                Instantiate(projectilePrefab, transform.position + direction, projectilePrefab.transform.rotation);

            }

            if (transform.position.x > xBound || transform.position.x < -xBound || transform.position.y > yBound || transform.position.y < -yBound || transform.position.z > zBound || transform.position.z < -zBound)
            {

                transform.position = new Vector3(0, 0, 0);
                gameManager.UpdateScore(-5);
                gameManager.UpdateHealth(-5);
                playerAudio.PlayOneShot(engageSound, 1.0f);
            }
        }
           


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // explosionParticle.Play(); // question: this does not triger, player does not explode
            // Debug.Log("Lost!");
            // transform.position = new Vector3(0, 0, 0);
            Instantiate(engagePrefab, transform.position, engagePrefab.transform.rotation);
            gameManager.UpdateScore(-5);
            gameManager.UpdateHealth(-5);
            playerAudio.PlayOneShot(engageSound, 1.0f);

        }
     
    }
}
