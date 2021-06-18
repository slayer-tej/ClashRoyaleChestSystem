using UnityEngine;

public class ControllerChestLock : MonoBehaviour
{
    public bool unlocked = false;
    public bool isOpened = false;

    public void Unlock()
    {
        unlocked = true;
    }
    public void Open(bool status)
    {
        isOpened = status;
    }
}

