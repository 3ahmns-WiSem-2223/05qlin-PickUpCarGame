using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!pickedUp && col.tag == "PickUp")
        {
            pickedUp = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "DropZone" && pickedUp == true)
        {
            pickedUp = false;
            Countdown.instance.Count();
        }
    }

}
