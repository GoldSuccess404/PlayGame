using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsScript : MonoBehaviour
{
    [SerializeField] private Text answerText;
    [SerializeField] private Text resultText;
    [SerializeField] private Text levelText;
    [SerializeField] private Sprite[] images; // ������ �������� � �������������
    [SerializeField] private string[] answers; // ������ ���������� �������
    [SerializeField] private Image image; // ������ ���������� �������
    [SerializeField] private InputField answerInputField;
    private int currentLevel = 0;

    void Start()
    {
        // ��������� ����������� ������� (���� ����)
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        levelText.text = "�������: " + (currentLevel + 1).ToString();

        // ���������� ������ �������� � ���������� �����
        SetImage(currentLevel);
        answerText.text = "";
        resultText.text = "";
    }
    
    public void CheckAnswer()
    {
        string playerAnswer = answerInputField.text.ToLower();
        string correctAnswer = answers[currentLevel].ToLower();

        if (playerAnswer == correctAnswer)
        {
            resultText.text = "���������!";
            currentLevel++;
            answerInputField.text = "";

            if (currentLevel >= images.Length - 1)
            {
                resultText.text = "�� ��������!";
                levelText.text = "";
                SetImage(currentLevel);
                return;
            }
            // ��������� ������� �������
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            levelText.text = "�������: " + (currentLevel + 1).ToString();

            SetImage(currentLevel);
        }
        else
        {
            resultText.text = "�����������! ���������� ��� ���.";
            PlayerPrefs.DeleteKey("CurrentLevel");
            answerInputField.text = "";
        }
        UpdateLevelText();
    }

    private void SetImage(int level)
    {
        image.sprite = images[level];
    }

    private void UpdateLevelText()
    {
        levelText.text = "�������: " + (currentLevel + 1).ToString();
    }
}
