using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfiniteScroll : MonoBehaviour,IDragHandler
{
    public float cellSizeY; /* max high button */
    public float paddingY; /* distance between buttons */
    public float upperLimit; /* top of the rect transform */

    private float tempLocation;

    public List<GameObject> childs = new List<GameObject>(); 

    void Start()
    {
        upperLimit = transform.position.y;

        paddingY = GetComponent<GridLayoutGroup>().spacing.y;
        cellSizeY = GetComponent<GridLayoutGroup>().cellSize.y;

        for(int i = 0; i < transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i).gameObject);
        }

    }

    private void Scroller(int _index, float _location)
    {
        if (_location > 0)
        {
            childs[_index].GetComponent<RectTransform>().anchoredPosition = new Vector2(childs[_index].GetComponent<RectTransform>().anchoredPosition.x,
                childs[_index].GetComponent<RectTransform>().anchoredPosition.y + _location);

            RemoveChildList(childs[_index]);

        }
        else if (_location < 0)
        {
            childs[_index].GetComponent<RectTransform>().anchoredPosition = new Vector2(childs[_index].GetComponent<RectTransform>().anchoredPosition.x,
                childs[_index].GetComponent<RectTransform>().anchoredPosition.y + _location);
            RemoveChildList(childs[_index]);
        }
        //if (GetComponent<RectTransform>().anchoredPosition.y > upperLimit)
        //{
        //    transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
        //    Debug.Log("burada");
        //    GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, 0);
        //}
    }

    private void RemoveChildList(GameObject _object)
    {
        childs.RemoveAt(childs.IndexOf(_object));
        childs.Add(_object);
        _object.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (childs[0].transform.position.y > upperLimit + paddingY)
        {
            tempLocation = 0 - cellSizeY - paddingY;
            for (var i = 0; i < 2; i++)
            {
                Scroller(i, tempLocation);
            }
        }
        else if (childs[childs.Count - 1].transform.position.y < -2)
        {
            tempLocation = cellSizeY + paddingY;
            for (var i = 1; i > -1; i--)
            {
                Scroller(i, tempLocation);
            }
        }
    }
}

