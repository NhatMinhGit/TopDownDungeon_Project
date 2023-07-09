using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
    private int roomNumber;
    private bool spawnedBoss;
	public GameObject boss;
	public GameObject portal;
	private GameObject IsBossAlive;

	void Update(){

		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					roomNumber = i;
					spawnedBoss = true;
				}
				/*IsBossAlive = GameObject.FindGameObjectWithTag("Boss");
				if (IsBossAlive == null)
				{
					Instantiate(portal, rooms[roomNumber].transform.position, Quaternion.identity);
				}*/
			}
		} else {
			waitTime -= Time.deltaTime;
		}
		
	}
	
}
