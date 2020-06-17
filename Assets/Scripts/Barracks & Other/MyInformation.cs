using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInformation : MonoBehaviour
{
    public bool locationOK = false;

    public GameObject doorCreated;
    public GameObject flag;
    private GameObject flagObject;

    private Vector2 targetPosition;

    // yalnızca information objesini almaktadır!
    public void InformationSetting(InformationPanel information)
    {
        if (transform.name == "barrack")
        {
            if (flagObject == null)
            {
                flagObject = Instantiate(flag,transform);
                flagObject.name = "flag";
            }
            else
            {
                InformationOpen(information);
            }
        }
        if (transform.name == "powerplant")
        {
            print("nedne");
            information.ImagePower();
        }
    }

    public void InformationOpen(InformationPanel information)
    {
        information.SoldierTarget(targetPosition);

        information.ImageBarrack();
        information.SoldierLocation(doorCreated);
    }

    public void TargetPosition(Vector2 _target)
    {
        targetPosition = _target;
    }


}
