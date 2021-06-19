using System;
using UnityEngine;
using UnityEngine.UI;

public class ControllerChest : MonoBehaviour
{
    public bool locked = true;
    public bool isOpened = false;
    [SerializeField]
    private Button _chestButton;
    [SerializeField]
    private GameObject _optionsPanel;

    private void Start()
    {
        _chestButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Button Clicked");
        if (locked)
        {
            _optionsPanel.SetActive(true);
        }
    }

    public void Unlock()
    {
        locked = false;
    }
    public void Open(bool status)
    {
        isOpened = status;
    }
}

