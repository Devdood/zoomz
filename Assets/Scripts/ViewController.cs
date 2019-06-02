using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Transform camera;

    private float x;
    private float y;

    public void ControlCamera()
    {
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");

        player.transform.rotation = Quaternion.Euler(0, x, 0);
        player.Model.transform.localEulerAngles = new Vector3(y, 0, 0);

        camera.transform.rotation = player.Model.rotation;
        camera.transform.position = player.Model.position;
    }
}
