using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsScript : MonoBehaviour
{
    [SerializeField] private Text answerText;
    [SerializeField] private Text resultText;
    [SerializeField] private Text levelText;
    [SerializeField] private Sprite[] images; // Массив спрайтов с изображениями
    [SerializeField] private string[] answers; // Массив правильных ответов
    [SerializeField] private Image image; // Массив правильных ответов
    [SerializeField] private InputField answerInputField;
    private int currentLevel = 0;

    void Start()
    {
        // Загружаем сохраненный уровень (если есть)
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        levelText.text = "Уровень: " + (currentLevel + 1).ToString();

        // Отображаем первую картинку и сбрасываем текст
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
            resultText.text = "Правильно!";
            currentLevel++;
            answerInputField.text = "";

            if (currentLevel >= images.Length - 1)
            {
                resultText.text = "Вы выиграли!";
                levelText.text = "";
                SetImage(currentLevel);
                return;
            }
            // Сохраняем текущий уровень
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            levelText.text = "Уровень: " + (currentLevel + 1).ToString();

            SetImage(currentLevel);
        }
        else
        {
            resultText.text = "Неправильно! Попробуйте еще раз.";
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
        levelText.text = "Уровень: " + (currentLevel + 1).ToString();
    }
}
