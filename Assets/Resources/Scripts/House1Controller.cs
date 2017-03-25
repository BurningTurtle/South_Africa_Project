using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House1Controller : MonoBehaviour {

    public int gridRows = 10;
    public int gridCols = 10;
    public int offset = 1;
    public Floor floor0, floor1, floor2, floor3;
    public Floor floorBlocked0, floorBlocked1, floorBlocked2, floorBlocked3;
    public Floor start;

    // Use this for initialization
    void Start () {
        Vector2 startPos = start.transform.position;

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                Floor floor = Instantiate(floor0);
                int id = Random.Range(0, 3);
                switch (id)
                {
                    case 0:
                        if (i == 0 || j == 0 || i == gridCols - 1 || j == gridRows - 1)
                        {
                            floor = Instantiate(floorBlocked0) as Floor;
                        }
                        else
                        {
                            floor = Instantiate(floor0) as Floor;
                        }
                        break;
                    case 1:
                        if (i == 0 || j == 0 || i == gridCols - 1 || j == gridRows - 1)
                        {
                            floor = Instantiate(floorBlocked1) as Floor;
                        }
                        else
                        {
                            floor = Instantiate(floor1) as Floor;
                        }
                        break;
                    case 2:
                        if (i == 0 || j == 0 || i == gridCols - 1 || j == gridRows - 1)
                        {
                            floor = Instantiate(floorBlocked2) as Floor;
                        }
                        else
                        {
                            floor = Instantiate(floor2) as Floor;
                        }
                        break;
                    case 3:
                        if (i == 0 || j == 0 || i == gridCols - 1 || j == gridRows - 1)
                        {
                            floor = Instantiate(floorBlocked3) as Floor;
                        }
                        else
                        {
                            floor = Instantiate(floor3) as Floor;
                        }
                        break;
                }

                float posX = (offset * i) + startPos.x;
                float posY = (offset * j) + startPos.y;
                floor.transform.position = new Vector3(posX, posY, 100);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
