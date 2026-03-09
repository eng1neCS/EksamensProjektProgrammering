using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int doorCount = 2;
    private int currentDoorsOpened = 0;
    [SerializeField] private string levelToLoad = "Levels";
    public void DoorOpened(int val)
    {
        currentDoorsOpened += val;
        if (currentDoorsOpened == doorCount)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
