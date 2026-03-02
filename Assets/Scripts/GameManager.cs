using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int doorCount = 2;
    private int currentDoorsOpened = 0;
    public void DoorOpened(int val)
    {
        currentDoorsOpened += val;
        if (currentDoorsOpened == doorCount)
        {
            Debug.Log("all doors are opened");
        }
    }
}
