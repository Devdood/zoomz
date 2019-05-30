using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private float x;
    private float y;

    public void ControlCamera()
    {
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");

        player.transform.rotation = Quaternion.Euler(0, x, 0);
        player.Model.transform.localEulerAngles = new Vector3(y, 0, 0);
    }
}
