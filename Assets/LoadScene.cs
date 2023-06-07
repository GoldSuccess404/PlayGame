using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        // ���������, ���� �� ����������� �������
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            // ���� ����, ��������� ����� ����
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            // ���� ���, �������� ����� ���� � ������� ������
            PlayerPrefs.SetInt("CurrentLevel", 0);
            SceneManager.LoadScene("SampleScene");
        }
    }
}