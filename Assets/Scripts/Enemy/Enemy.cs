using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private int speed;
    [SerializeField] private float distanceToPlayer;

    GameObject player;

    [Header("Movement")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform[] posRodBullet;
    [SerializeField] float timeBetweenBullets;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        InvokeRepeating("Attack", 1, timeBetweenBullets);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) 
        {
            return;
        }

        transform.LookAt(player.transform.position);
        FollowPlayer();
        
    }

    private void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > distanceToPlayer)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        for(int i = 0; i < posRodBullet.Length; i++)
        {
            Instantiate(bulletPrefab, posRodBullet[i].position, posRodBullet[i].rotation);
        }
    }
}
