using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Win_Canvas;
    private int doorCount = 2;
    private int currentDoorsOpened = 0;
    [SerializeField] private string levelToLoad = "Levels";
    public bool winCanvasActive = false;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }
    public void DoorOpened(int val)
    {
        currentDoorsOpened += val;
        if (currentDoorsOpened == doorCount)
        {
            Win_Canvas.SetActive(true);
            winCanvasActive = true;
        }
    }
}
