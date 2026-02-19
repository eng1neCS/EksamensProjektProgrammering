using UnityEngine;

public class PlateButton : MonoBehaviour
{
    public DoorMoveV linkedDoorV;
    public DoorMoveH linkedDoorH;
    private bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            PressButton();
        }
    }

    void PressButton()
    {
        isPressed = true;
        linkedDoorV.MoveDoorV();
        linkedDoorH.MoveDoorH();

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, 1);

        Debug.Log("Spiller trådte på knappen!");
    }
}