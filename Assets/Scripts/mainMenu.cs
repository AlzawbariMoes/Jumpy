using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public GameObject DeveloperPage;
    public GameObject InstructionPage;
    public GameObject MainMenu;
    public GameObject CountdownAnimation;
    private AudioSource MenuSoundTrack;
    public GameObject GameSoundtrackHolder;
    public GameObject LeftPhoneButton;
    public GameObject RightPhoneButton;
    public GameObject UpPhoneButton;



    private void Awake()
    {
     }
    private void Start()
    {
        MenuSoundTrack = GetComponent<AudioSource>();
        MenuSoundTrack.Play();
        Time.timeScale = 0;
        GameSoundtrackHolder.SetActive(false);
    }

    public void OnClickPlay()
    {
        MenuSoundTrack.Stop();

        CountdownAnimation.SetActive(true);
        StartCoroutine(StartDelayBeforeGameplay());
        InstructionPage.SetActive(false);
        DeveloperPage.SetActive(false);
        MainMenu.SetActive(false);
    }
    IEnumerator StartDelayBeforeGameplay()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        CountdownAnimation.SetActive(false);
        GameSoundtrackHolder.SetActive(true);

        LeftPhoneButton.SetActive(true);
        RightPhoneButton.SetActive(true);
        UpPhoneButton.SetActive(true);

    }
    public void OnClickInstruction()
    {

        Time.timeScale = 0;
        InstructionPage.SetActive(true);
        DeveloperPage.SetActive(false);
        MainMenu.SetActive(false);
    }
    public void OnClickInstructionBack()
    {

        Time.timeScale = 0;
        MainMenu.SetActive(true);
        DeveloperPage.SetActive(false);
        InstructionPage.SetActive(false);
    }

    public void OnClickDevelopers()
    {

        Time.timeScale = 0;
        InstructionPage.SetActive(false);
        DeveloperPage.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OnClickDevelopersBck()
    {
        Time.timeScale = 0;
        InstructionPage.SetActive(false);
        DeveloperPage.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnClickQuit()
    {
         Application.Quit();
    }

    public void Restart()
    {
       // SceneManager.LoadScene("GameScene");
        Application.LoadLevel("GameScene");
    }
}
