using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Canvas")]
    public GameObject Production;
    public GameObject Information;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        ClickObjectControl();
    }

    private void ClickObjectControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.tag == "Other")
                {
                    MyInformation hitObject = hit.transform.GetComponent<MyInformation>();
                    ColliderOther(hitObject);
                }
            }
        }
    }

    private void ColliderOther(MyInformation hitObject)
    {
        if (hitObject.locationOK)
        {
            if (Information.activeSelf == false)
                Information.SetActive(true);
            hitObject.InformationSetting(Information.GetComponent<InformationPanel>());
        }
    }


}
