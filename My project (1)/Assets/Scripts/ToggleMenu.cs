using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ToggleMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject topBar;
    [SerializeField] private GameObject retryMenu;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject[] hearts = new GameObject[5];
    private int health = 1;
    public VideoPlayer healthbar;
    public Button menuButton;
    public Button retryButton;
    public Button startButton;
    public Button replayButton;
    public Slider healthSlider;
    public Slider retryHealthSlider;
    public Slider winHealthSlider;
    public Text healthText;
    public Text retryHealthText;
    public Text winHealthText;

    Boolean resetting = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuButton.onClick.AddListener(OnMenuButtonClick);
        startButton.onClick.AddListener(OnStartButtonClick);
        retryButton.onClick.AddListener(OnRetryButtonClick);
        replayButton.onClick.AddListener(OnReplayButtonClick);
        menu.SetActive(false);
        retryMenu.SetActive(false);
        topBar.SetActive(false);
        startMenu.SetActive(true);
        winMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        retryHealthText.text = "Lives: " + retryHealthSlider.value;
        healthText.text = "Lives: " + healthSlider.value;
        winHealthText.text = "Lives: " + winHealthSlider.value;

        for (int i = 0; i < hearts.Length; i++) //Hearts display
        {
            hearts[i].SetActive(health > i);
        }

        if (health <= 0) { // GameOver screen
            healthbar.Pause();
            retryMenu.SetActive(true);
            menu.SetActive(false); // Make it invisible
            resetting = true;
        }

        if (!healthbar.isPlaying && !resetting)
        {
            winMenu.SetActive(true);
        }

    }

    void OnMenuButtonClick()
    {
        if (!menu.activeSelf)
        {
            menu.SetActive(true); // Make it visible

            health--;
        } else
        {
            menu.SetActive(false); // Make it invisible
        }
    }

    void OnRetryButtonClick()
    {
        retryMenu.SetActive(false);
        health = (int) retryHealthSlider.value;
        topBar.SetActive(false);
        StartCoroutine(wait(5.0f)); // You're not allowed to js do wait(5.0f) bc you can't call an a return of IEnumerator like that.
    }

    void OnStartButtonClick()
    {
        startMenu.SetActive(false);
        health = (int) healthSlider.value;
        topBar.SetActive(false);
        StartCoroutine(wait(5.0f));
    }

    void OnReplayButtonClick()
    {
        resetting = true;
        winMenu.SetActive(false);
        health = (int)winHealthSlider.value;
        topBar.SetActive(false);
        StartCoroutine(wait(5.0f));
    }

    IEnumerator wait(float seconds) //Wait funtion: 
    {
        yield return new WaitForSeconds(seconds); // This actually lets time pass
        topBar.SetActive(true);
        healthbar.time = 0;
        healthbar.Play();
        resetting = false;
    }
}
