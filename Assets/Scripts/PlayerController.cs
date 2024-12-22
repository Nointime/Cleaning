using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animation anim;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotateSpeed = 0.2f;
    
    private Vector3 moveVector;
    float x = 0f;

    public bool isTake;

    void Start()
    {
        //привязка ссылки к компоненту
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animation>();
    }

    void Update()
    {
        x += Input.GetAxisRaw("Horizontal") * rotateSpeed; // нжатие на клавиши влево, вправо ,A ,D

        float z = Input.GetAxis("Vertical"); // нжатие на клавиши вверх, вниз, W, S

        if (z != 0) anim.Play();
        else anim.Stop();
        transform.rotation = Quaternion.Euler(0, x, 0);
        moveVector = transform.forward * z; // вектор направления движения

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * speed; // движение объекта

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) // если нажаты клавижи отвечкющие за движение
        {
            rb.MoveRotation(Quaternion.LookRotation(rb.velocity)); // поворот в сторону движения
        }
    }
}
