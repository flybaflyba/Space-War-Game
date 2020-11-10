using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    //public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        //explosionParticle.Stop();question: every time a new enemy appear, particle plays
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized; // normolize the vector's maganitite
        transform.Translate(direction * Time.deltaTime * speed);
        transform.rotation = Quaternion.LookRotation(direction);

    }

}
