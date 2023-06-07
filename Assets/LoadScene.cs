using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        // Проверяем, есть ли сохраненный уровень
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            // Если есть, загружаем сцену игры
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            // Если нет, начинаем новую игру с первого уровня
            PlayerPrefs.SetInt("CurrentLevel", 0);
            SceneManager.LoadScene("SampleScene");
        }
    }
}