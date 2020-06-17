using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{

    private GameObject _spawnSoldier;

    [Header("Child")]
    public GameObject imageObject;
    public GameObject soldierButton;
    public GameObject soldier;

    [Header("Image")]
    public List<Sprite> images;

    [Header("Image names")]
    public Text imageName;

    private Vector2 soldierTarget;

    public void ImageBarrack()
    {
        imageObject.GetComponent<Image>().sprite = images[0];
        imageName.text = "BARRACKS";

        soldierButton.SetActive(true);
        soldierButton.GetComponent<Image>().sprite = images[2];

    }

    public void ImagePower()
    {
        imageObject.GetComponent<Image>().sprite = images[1];
        imageName.text = "Power Plant";

        soldierButton.SetActive(false);
    }


    public void SoldierLocation(GameObject _spawn)
    {
        _spawnSoldier = _spawn;
    }

    public void SoldierTarget(Vector2 _soldierTarget)
    {
        soldierTarget = _soldierTarget;
    }

    public void CreateSoldier()
    {
        Instantiate(soldier, _spawnSoldier.transform.position, Quaternion.identity);
    }
}
