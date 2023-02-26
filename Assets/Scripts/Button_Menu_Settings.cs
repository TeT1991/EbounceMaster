using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Menu_Settings : MonoBehaviour
{
    private Button _button;
    [SerializeField] private Image _statusButtonIcon;

    private void Start()
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }
        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        Debug.Log("Pressed");
    }
}
