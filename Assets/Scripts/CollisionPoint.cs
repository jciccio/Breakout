/// CollisionPoint.cs
/// gets a collision point between a reference object and a second object
/// Author: Jose A. Ciccio

using UnityEngine;
using System.Collections;

public class CollisionPoint : MonoBehaviour {


    public GameObject _objectReference;
    public GameObject _otherObject;

    private Transform _objectReferenceTransform;
    private Transform _otherObjectTransform;

	// Use this for initialization
	void Start () {
        _objectReferenceTransform = _objectReference.transform;
        _otherObjectTransform = _otherObject.transform;
	}


    public Vector3 getCollisionPoint(Collision col)
    {
        Vector3 point = col.contacts[0].point;
        Vector3 collisionPoint = _objectReferenceTransform.position - point;
        return collisionPoint;
    }

}
