using System.Collections;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Transform spine;
    private float xAxis = 0f;
    private float yAxis = 0f;
    public Vector2 xLimit = new Vector2(-30f, 30f);
    public Vector2 yLimit = new Vector2(-30f, 30f);

    public Transform weapon;
    public GameObject crosshair;
    private Vector2 aimLoc;

    public void LateUpdate()
    {
        yAxis += Input.GetAxis("Mouse X");
        yAxis = Mathf.Clamp(yAxis, yLimit.x, yLimit.y);
        xAxis -= Input.GetAxis("Mouse Y");
        xAxis = Mathf.Clamp(xAxis, xLimit.x, xLimit.y);
        Vector3 corr = new Vector3(xAxis, yAxis, spine.localEulerAngles.z);
        spine.localEulerAngles = corr;
        RaycastHit hit;
        Vector3 fwd = weapon.TransformDirection(Vector3.forward);

        if(Physics.Raycast(weapon.position, fwd, out hit))
        {
            print(hit.transform.gameObject.name);
            aimLoc = Camera.main.WorldToScreenPoint(hit.point);
            crosshair.SetActive(true);
            crosshair.transform.position = aimLoc;
        } else {
            crosshair.SetActive(false);
        }
        Debug.DrawRay(weapon.position, fwd, Color.red);
    }
}
