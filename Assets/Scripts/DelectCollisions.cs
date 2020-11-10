using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelectCollisions : MonoBehaviour
{
    
    public GameObject explosionPrefab;
    private GameManager gameManager;
    public AudioClip explosionSound;
    private AudioSource missileAudio;


    // Start is called before the first frame update
    void Start()
    {
        missileAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        missileAudio.PlayOneShot(explosionSound, 1.0f);
        gameManager.UpdateScore(5);
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        //Destroy(gameObject);
        Destroy(other.gameObject);
        gameObject.transform.position = new Vector3(0,-10,0);


    }


}
