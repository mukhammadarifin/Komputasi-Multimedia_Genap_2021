using System.Collections;
using UnityEngine;

public class AddProp : MonoBehaviour
{
    public GameObject prop;
    public Transform targetBone;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public bool destroyTrigger = true;

    void OnTriggerEnter(Collider collision)
    {
        if(targetBone.IsChildOf(collision.transform))
        {
            bool checkProp = false;
            foreach(Transform child in targetBone)
            {
                if(child.name == prop.name)
                    checkProp = true;
            }

            if(!checkProp)
            {
                GameObject newprop;
                newprop = Instantiate(prop, targetBone.position, targetBone.rotation) as GameObject;
                newprop.name = prop.name;
                newprop.transform.parent = targetBone;
                newprop.transform.localPosition += positionOffset;
                newprop.transform.localEulerAngles += rotationOffset;
                
                if(destroyTrigger)
                    Destroy(gameObject);
            }
        }
    }
}
