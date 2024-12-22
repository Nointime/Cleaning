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
        //�������� ������ � ����������
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animation>();
    }

    void Update()
    {
        x += Input.GetAxisRaw("Horizontal") * rotateSpeed; // ������ �� ������� �����, ������ ,A ,D

        float z = Input.GetAxis("Vertical"); // ������ �� ������� �����, ����, W, S

        if (z != 0) anim.Play();
        else anim.Stop();
        transform.rotation = Quaternion.Euler(0, x, 0);
        moveVector = transform.forward * z; // ������ ����������� ��������

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * speed; // �������� �������

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) // ���� ������ ������� ���������� �� ��������
        {
            rb.MoveRotation(Quaternion.LookRotation(rb.velocity)); // ������� � ������� ��������
        }
    }
}
