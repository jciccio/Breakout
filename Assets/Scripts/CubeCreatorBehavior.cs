/// CubeCreatorBehavior.cs
/// gets a collision point between a reference object and a second object
/// Author: Jose A. Ciccio
using UnityEngine;
using System.Collections;

public class CubeCreatorBehavior : MonoBehaviour {


    public GameObject cubePrefab;
    public ArrayList createdObjects;

	// Use this for initialization
	void Start () {
        createdObjects = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // The Idea is to create a Cube if C key was pressed.
            // To achieve this, we should have the Cube as a prefab (so it will have the crate texture).
            GameObject createdObject = (GameObject)Instantiate(cubePrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            createdObjects.Add(createdObject);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            destroyCube();
        }
    }

    void destroyCube()
    {
        int lastElement = this.createdObjects.Count -1;
        if (lastElement >= 0)
        {
            Debug.Log(lastElement);
            GameObject element = (GameObject)createdObjects[lastElement];
            createdObjects.RemoveAt(lastElement);
            Destroy(element);
        }
    }
}
