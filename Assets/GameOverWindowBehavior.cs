using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindowBehavior : MonoBehaviour
{
    private Button retryButton;
    private void Awake()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();        
        retryButton.onClick.AddListener(Retry);
    }

    private void Start()
    {
        gameObject.SetActive(true);
        GameEventsBehavior.Current.OnGameOver += OnGameOver;
        gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        gameObject.SetActive(true);
        retryButton.Select();
    }

    private void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
