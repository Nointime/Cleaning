using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    UIManager UIManager;
    PlayerController PlayerController;
    private AudioEffects AudioEffects;

    [SerializeField] private Animation anim;
    private Transform musorPlace;
    private string Tag;
    bool isOpen;

    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        PlayerController = FindObjectOfType<PlayerController>();
        AudioEffects = FindObjectOfType<AudioEffects>();

        musorPlace = GameObject.Find("MusorPlace").transform;
        //Tag = gameObject.tag;
    }

    void Update()
    {
        if (isOpen && PlayerController.isTake && Input.GetKeyDown(KeyCode.E))
        {
            if(musorPlace.GetChild(0).gameObject.tag == tag)
            {
                AudioEffects.AudioStart(0);
                UIManager.MusorLess();
                print("good");
            }
            else
            {
                AudioEffects.AudioStart(1);
                UIManager.LifeLess();
                UIManager.MusorLess();
                print("bad");

            }

            PlayerController.isTake = false;
            Destroy(musorPlace.GetChild(0).gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerController.isTake && other.CompareTag("Player"))
        {
            anim.Play("OpenLid");
            isOpen = true;
            UIManager.ShowMassege("Нажмите E чтобы выбросить", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("CloseLid");

            isOpen = false;
            UIManager.ShowMassege("", false);

        }
    }

}
