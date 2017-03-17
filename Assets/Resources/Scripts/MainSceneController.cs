using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour {

	public int gridRows = 10;
	public int gridCols = 10;
	public int offset = 1;
	public Grass grass0, grass1, grass2, grass3;
	public Grass grassBlocked0, grassBlocked1, grassBlocked2, grassBlocked3;

	// Use this for initialization
	void Start () {
		Vector2 startPos = new Vector2(0,0);

		for (int i = 0; i < gridRows; i++) {
			for (int j = 0; j < gridCols; j++) {
				Grass grass = Instantiate (grass0);
				int id = Random.Range (0, 3);
				switch (id) {
				case 0:
					if (i == 0 || j == 0 || i == gridCols-1 || j == gridRows-1) {
						grass = Instantiate (grassBlocked0) as Grass;
					} else {
						grass = Instantiate (grass0) as Grass;
					}
					break;
				case 1:
					if (i == 0 || j == 0 || i == gridCols-1 || j == gridRows-1) {
						grass = Instantiate (grassBlocked1) as Grass;
					} else {
						grass = Instantiate (grass1) as Grass;
					}
					break;
				case 2:
					if (i == 0 || j == 0 || i == gridCols-1 || j == gridRows-1) {
						grass = Instantiate (grassBlocked2) as Grass;
					} else {
						grass = Instantiate (grass2) as Grass;
					}
					break;
				case 3:
					if (i == 0 || j == 0 || i == gridCols-1 || j == gridRows-1) {
						grass = Instantiate (grassBlocked3) as Grass;
					} else {
						grass = Instantiate (grass3) as Grass;
					}
					break;
				}
				
				float posX = (offset * i) + startPos.x;
				float posY = (offset * j) + startPos.y;
				grass.transform.position = new Vector3 (posX, posY, 100);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
