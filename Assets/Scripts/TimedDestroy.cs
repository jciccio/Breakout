/// TimedDestroy.cs
/// Destroys an object within a second
/// Author: Jose A. Ciccio

using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1f);
	}
}
