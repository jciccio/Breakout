/// Block.cs
/// Controls Block behavoiur
/// Author: Jose A. Ciccio

using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public GameObject _BrickParticle;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {
        // Debug.Log("Destruyendo bloque");
        
        Instantiate(_BrickParticle, new Vector3 (transform.position.x, transform.position.y, -1f), Quaternion.Euler(90f, 0, 0));
        Destroy(this.gameObject);
        GameManager.instance.BlocksLeft = GameManager.instance.BlocksLeft - 1;
    }

}
