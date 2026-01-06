using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuObj ; 
    [SerializeField] private GameObject settingMenuObj; 

    [SerializeField] private Button backBtn ; 
    [SerializeField]private Button  openSettingbtn ; 
     [SerializeField] private Button playBtn ; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backBtn.onClick.AddListener( CLoseSettingMenu ); 
        playBtn.onClick.AddListener(Play); 
        openSettingbtn.onClick.AddListener(OpenSettingMenu);
    }

    private void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void CLoseSettingMenu()
    {
        settingMenuObj.SetActive(false);
        mainMenuObj.SetActive(true);
    }

    private void OpenSettingMenu()
    {
        mainMenuObj.SetActive(false);
        settingMenuObj.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
