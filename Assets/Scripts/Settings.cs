using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioSource backgroundAudio;
    public Slider audioSlider;
    public GameObject retry;
    public GameObject prev;
    private void Start()
    {
        audioSlider.value = backgroundAudio.volume;
    }

    public void ChangeVolume()
    {
        backgroundAudio.volume = audioSlider.value;
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
        GameManager.gameManager?.PauseTime(false);
    }

    public void OpenPanel()
    {
        this.gameObject.SetActive(true);
        GameManager.gameManager?.PauseTime(true);

        if (SceneManager.GetActiveScene().name != "StartScene")
            prev.SetActive(true);

        if (SceneManager.GetActiveScene().name == "MainStage")
            retry.SetActive(true);
    }

    public void GoToPrev()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
