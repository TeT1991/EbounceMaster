using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinCellHolder : MonoBehaviour
{
    [SerializeField] private SkinManager _skinManager;

    [SerializeField] private Image _skinIcon;
    public BallJumper _skin;
   

    public int _skinIndex;
    private Button _button;

    public void Initialization(int value)
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }

        if (_skinManager == null)
        {
            _skinManager = FindObjectOfType<SkinManager>(); 
        }

        _button.onClick.AddListener(HandleClickButton);

        _skinIndex = value;
        _skin = _skinManager.GetSkin(value);
    }

    private void HandleClickButton()
    {
        Debug.Log("!!!!!!!!!!!!!!!!!!!!");
        _skinManager.SetCurrentSkin(_skin);
    }
}
