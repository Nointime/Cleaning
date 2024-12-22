using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musor : MonoBehaviour
{
    UIManager UIManager;
    PlayerController PlayerController;

    private Transform musorPlace;
    private bool canTake;

    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        musorPlace = GameObject.Find("MusorPlace").transform;
        PlayerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (canTake && Input.GetKeyDown(KeyCode.Space))
        {
            transform.parent = musorPlace;
            transform.position = musorPlace.position;
            PlayerController.isTake = true;
            UIManager.ShowMassege("", false);
            canTake = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!PlayerController.isTake && other.CompareTag("Player"))
        {
            UIManager.ShowMassege("Нажмите ПРОБЕЛ чтобы взять", true);
            canTake = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.ShowMassege("", false);
            canTake = false;
        }
    }
}
