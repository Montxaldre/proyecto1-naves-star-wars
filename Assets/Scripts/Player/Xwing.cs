using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xwing : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private int speed;
    [SerializeField] private float turnSpeed;

    [Header("Attack")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] posRodBullet;

    AudioSource shootAudio;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shootAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Turning();
        Attack();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.Translate(direction.normalized * speed * Time.deltaTime); 
    }

    private void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

    Vector3 rotation = new Vector3(-yMouse, xMouse, 0);
        transform.Rotate(rotation.normalized * speed * Time.deltaTime);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootAudio.Play();

            for (int i = 0; i < posRodBullet.Length; i++)
            {
                Instantiate(bulletPrefab, posRodBullet[i].position, posRodBullet[i].rotation);
            }
        }
    }
}
