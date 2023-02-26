using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _shopWindow;
    [SerializeField] private GameObject _menu;

    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _settingsButton;

    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _closeShopButton;

    [SerializeField] private Button _noADSButton;

    [SerializeField] private GameManager _gameManager;


    private void Start()
    {
        _gameManager.GameStarted.AddListener(HideMenu);
        _gameManager.GameFinished.AddListener(ShowMenu);

        ///
        if (_soundButton == null)
        {
            _soundButton = GetComponent<Button>();
        }
        if (_musicButton == null)
        {
            _musicButton = GetComponent<Button>();
        }
        if (_settingsButton == null)
        {
            _settingsButton = GetComponent<Button>();
        }

        /////
        if (_shopButton == null)
        {
            _shopButton = GetComponent<Button>();
        }
        if (_closeShopButton == null)
        {
            _closeShopButton = GetComponent<Button>();
        }

        ////
        if (_noADSButton == null)
        {
            _noADSButton = GetComponent<Button>();
        }

        _soundButton.onClick.AddListener(OnSoundButtonClick);
        _musicButton.onClick.AddListener(OnMusicButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);


        _shopButton.onClick.AddListener(OnShopButtonClick);
        _closeShopButton.onClick.AddListener(OnCloseShopButtonClick);

        _noADSButton.onClick.AddListener(OnNoADSClickButtonClick);
    }

    public void OnSoundButtonClick()
    {
        Debug.Log("Вкл/Выкл звуки");
    }
    public void OnMusicButtonClick()
    {
        Debug.Log("Вкл/Выкл музыку");
    }
    public void OnSettingsButtonClick()
    {
        _settingsWindow.SetActive(!_settingsWindow.activeSelf);
    }


    public void OnShopButtonClick()
    {
        _shopWindow.SetActive(true);
        _gameManager.gameObject.SetActive(false);
    }
    public void OnCloseShopButtonClick()
    {
        _gameManager.gameObject.SetActive(true);
        _shopWindow.SetActive(false);
    }


    public void OnNoADSClickButtonClick()
    {
        Debug.Log("Вкл/Выкл рекламу");
    }

    private void HideMenu()
    {
        _menu.SetActive(false);   
    }
    private void ShowMenu()
    {
        _menu.SetActive(true);
    }
}
