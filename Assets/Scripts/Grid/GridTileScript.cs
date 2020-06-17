using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileScript : MonoBehaviour
{
    public bool isState = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Other") || other.CompareTag("Flag"))
        {
            Following component = other.GetComponent<Following>();
            component.tileObjects.Add(transform.gameObject);
        }
                
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Other") || other.CompareTag("Flag"))
        {
            Following component = other.GetComponent<Following>();
            component.tileObjects.RemoveAt(component.tileObjects.IndexOf(transform.gameObject));
        }
    }
}
