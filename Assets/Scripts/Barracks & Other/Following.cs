using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public bool isLocationOk = false;

    private Vector2 _mousePosition;

    private GameObject gridSystem;

    public List<GameObject> tileObjects;

    private void Start()
    {
        gridSystem = GameObject.FindGameObjectWithTag("Grid");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && LocationState())
        {
            isLocationOk = true;
            FollowOk();
        } 

        if (!isLocationOk)
            FollowingMouse();
    }

    private void FollowingMouse()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (gridSystem.GetComponent<GridSystem>().ObjectLocation(_mousePosition))
            transform.position = _mousePosition;
    }

    private bool LocationState()
    {
        bool stateTrue = true;

        for (int i = 0; i < tileObjects.Count; i++)
        {
            if (tileObjects[i].GetComponent<GridTileScript>().isState == false)
            {
                stateTrue = false;
                break;
            }
            else
                tileObjects[i].GetComponent<GridTileScript>().isState = false;
        }

        return stateTrue;
    }

    private void FollowOk()
    {
        if (transform.name == "barrack")
        {
            GetComponent<MyInformation>().locationOK = true;
        }
        else if (transform.name == "powerplant")
        {
            GetComponent<MyInformation>().locationOK = true;
        }
        else if(transform.name == "flag")
        {
            MyInformation _parent = transform.parent.GetComponent<MyInformation>();
            _parent.TargetPosition(transform.position);
            _parent.InformationOpen(GameManager.instance.Information.GetComponent<InformationPanel>());
        }
    }
}
