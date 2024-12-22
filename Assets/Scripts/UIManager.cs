using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private AudioEffects AudioEffects;

    [SerializeField] private Text massegeText;
    [SerializeField] private Text LifeText;
    [SerializeField] private Text MusorText;
    [SerializeField] private GameObject massegePanel;
    [SerializeField] private GameObject EndPanel;
    [SerializeField] private Text EndText;

    private int life = 3;
    private int musor = 12;

    void Start()
    {
        AudioEffects = FindObjectOfType<AudioEffects>();
    }

    private void EndGame(int a, string text)
    {

        EndPanel.SetActive(true);
        EndText.text = text;
        AudioEffects.AudioStart(a);
    }

    public void LifeLess()
    {
        life--;
        LifeText.text = "Жизни: " + life.ToString();

        if (life <= 0)
        {
            EndGame(3, "Вы проиграли!!!");
        }
    }

    public void MusorLess()
    {
        musor--;
        MusorText.text = "Отходы: " + musor.ToString();

        if (musor == 0)
        {
            EndGame(2, "Победа!!!");
        }
    }

    public void ShowMassege(string mas, bool onOff)
    {
        massegePanel.SetActive(onOff);
        massegeText.text = mas;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
