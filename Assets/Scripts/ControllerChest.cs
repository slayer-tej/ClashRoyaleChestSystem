using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControllerChest : MonoBehaviour
{
    [SerializeField]
    private ChestType Type;
    [SerializeField]
    private int Coins;
    [SerializeField]
    private int Gems;
    [SerializeField]
    private int TimetoOpen;
    public bool locked = true;
    public bool isUnlocking = false;
    public bool isCollected = false;
    [SerializeField]
    private Button _buttonChest;
    [SerializeField]
    private GameObject _optionsPanel;
    [SerializeField]
    private Button _buttonStartUnlocking;
    [SerializeField]
    private Button _buttonUnlockWithGems;


    public void InitializeValues(Chest random)
    {
        Type = random.Type;
        Coins = random.coins;
        Gems = random.gems;
        TimetoOpen = random.timetoOpen;
    }

    private void Start()
    {
        _buttonChest.onClick.AddListener(OnClick);
        _buttonStartUnlocking.onClick.AddListener(UnlockChest);
    }

    private void UnlockChest()
    {
        _optionsPanel.SetActive(false);
        ServiceChestsSystem.Instance.StartUnlocking(this);
    }

    private void OnClick()
    {
        Debug.Log("Button Clicked");
        if (locked)
        {
            _optionsPanel.SetActive(true);
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
    }

    public void Unlock()
    {
        locked = false;
    }

    public void Open(bool status)
    {
        isCollected = status;
    }
}

