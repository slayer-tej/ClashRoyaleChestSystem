using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceChestsSystem: MonoSingletonGeneric<ServiceChestsSystem>
{
    [SerializeField] private Button _generatorChestButton;
    private int _numOfSlots = 4;
    [SerializeField]
    private GameObject _chestPrefab;
    [SerializeField]
    private List<ControllerChest> chestsList = new List<ControllerChest>();
    // Start is called before the first frame update
    void Start()
    {
        _generatorChestButton.onClick.AddListener(GenerateRandomChest);
    }

    private void GenerateRandomChest()
    {
       while(_numOfSlots > 0)
        {
            int RandomChest = UnityEngine.Random.Range(0, 4);
            LoadChest(RandomChest);
            _numOfSlots--;
        }
    }

    internal void StartUnlocking(ControllerChest controller)
    {
        foreach(ControllerChest chest in chestsList)
        {
            if(chest.GetInstanceID() == controller.GetInstanceID())
            {
            }
        }
    }

    private void LoadChest(int randomChest)
    {
        Chest Randomchest = new Chest(randomChest);
        Debug.Log("ChestType: " + Randomchest.Type + " Coins: " + Randomchest.coins + " Gems: " + Randomchest.gems);
        GameObject Loot =  Instantiate(_chestPrefab,gameObject.transform);
        ControllerChest controllerChest = Loot.GetComponent<ControllerChest>();
        controllerChest.InitializeValues(Randomchest);
        chestsList.Add(controllerChest);
        Debug.Log("Chest Added to List");
        Debug.Log("Total Chests Added : " + chestsList.Count);
    }
}

public struct Chest
{
    public ChestType Type;
    public int coins;
    public int gems;
    public int timetoOpen;

    public Chest(int Randomnumber)
    {
        Type = (ChestType)Randomnumber;
        coins = 0;
        gems = 0;
        timetoOpen = 0;
        switch (Type)
        {
            case ChestType.Common:
                coins = UnityEngine.Random.Range(100, 201);
                gems = UnityEngine.Random.Range(10, 21);
                timetoOpen = 300;
                break;
            case ChestType.Rare:
                coins = UnityEngine.Random.Range(300, 501);
                gems = UnityEngine.Random.Range(20, 41);
                timetoOpen = 600;
                break;
            case ChestType.Epic:
                coins = UnityEngine.Random.Range(600, 801);
                gems = UnityEngine.Random.Range(45, 61);
                timetoOpen = 900;
                break;
            case ChestType.Legendary:
                coins = UnityEngine.Random.Range(1000, 1201);
                gems = UnityEngine.Random.Range(80, 100);
                timetoOpen = 1200;
                break;
        }
    }
}

public enum ChestType
{
    Common,
    Rare,
    Epic,
    Legendary
}
