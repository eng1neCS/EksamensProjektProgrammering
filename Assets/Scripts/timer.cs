using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class timer : MonoBehaviour
{
    public GameObject Win_Canvas;
    [SerializeField] TextMeshProUGUI Timertext;
    float elapsedTime;
    

    void Update()
    {
        //        Invoke("Timer", 0f);
        //Hvis wincanvas er aktiv, så stop timeren.
        if (GameManager.Instance != null && !GameManager.Instance.winCanvasActive)
        {
            Timer();
            //CancelInvoke("Timer");
        }
    }

    public void Timer()
    {
        Debug.Log("Timer is running");
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        Timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
