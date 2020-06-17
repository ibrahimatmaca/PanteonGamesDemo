using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour 
{
    private float tileSize;

    [Header("Grid Sytem")]
    public int Row;
    public int Column;
    private float maxRowX;
    private float minRowX;
    private float maxColumnY;
    private float minColumnY;

    [Header("Object")]
    public GameObject createTile;

    [Header("List")]
    public List<GameObject> gridSystem = new List<GameObject>();

    void Start()
    {
        CreateFlatHexGridStart();
        MaxAndMin();
    }

    /*It is a function that aligns according to the x and y values ​​of the object to be used. */
    private void CreateFlatHexGridStart()
    {
        MeasureFlatHexTile();

        for (int xRow = 0; xRow < Row; xRow++)
        {
            for (int yColumn = 0; yColumn < Column; yColumn++)
            {

                GameObject gridTile = Instantiate(createTile, transform);

                float posX = yColumn * tileSize;
                float posY = xRow * -tileSize;

                gridTile.transform.position = new Vector2(posX,posY);
                gridTile.name = xRow.ToString() +" : "+ yColumn.ToString();
                gridSystem.Add(gridTile);
            }
        }
        float gridW = Column * tileSize;
        float gridH = Row * tileSize;
        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }

    /*Using the height or width of the Tile.*/
    private void MeasureFlatHexTile()
    {
        tileSize = createTile.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void MaxAndMin()
    {
        minRowX = gridSystem[0].transform.position.x+ tileSize;
        maxColumnY = gridSystem[0].transform.position.y- tileSize;
        maxRowX = gridSystem[gridSystem.Count - 1].transform.position.x- tileSize;
        minColumnY = gridSystem[gridSystem.Count - 1].transform.position.y+ (tileSize*2.5f);
    }

    public bool ObjectLocation(Vector2 _mouse)
    {
        bool locationIsTrue = false;
        if ((_mouse.x > minRowX && _mouse.y < maxColumnY) && (_mouse.x < maxRowX && _mouse.y > minColumnY))
            locationIsTrue = true;

        return locationIsTrue;
    }

}
