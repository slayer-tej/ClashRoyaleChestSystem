using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerChest: MonoBehaviour
{
    [SerializeField] private Button _generatorChestButton;
    private int _numOfSlots = 4;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        _generatorChestButton.onClick.AddListener(GenerateRandomChest);
    }

    private void GenerateRandomChest()
    {
        while(_numOfSlots <= 0)
        {
            int RandomChest = UnityEngine.Random.Range(-1, 4);
            Debug.Log(RandomChest);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct Chest
{
    private ChestType Type;
    private int Coins;
    private int Gems;
}

public enum ChestType
{
    Common,
    Rare,
    Epic,
    Legendary
}
