using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMain()
    {
        SceneManager.LoadScene(1);
        Physics.gravity = new Vector3(0, -12f, 0);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        AudioPause();

    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        AudioPlay();
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void AudioPlay()
    { 
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.Play(0);
        }
    }

    public void AudioPause()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }

    }





}
