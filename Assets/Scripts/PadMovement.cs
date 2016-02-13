/// PadMovement.cs
/// Moves pad in X axis
/// Author: Jose A. Ciccio


using UnityEngine;
using System.Collections;

public class PadMovement : MonoBehaviour {


    private GameObject _pad;
    private Transform _padTransform;
    public float _padSpeed = 1f;

    private Renderer _padRenderer;
    public float _worldRadiusSize;
    private float _worldBounds;
    private Vector3 _padSize;
    

	// Use this for initialization
	void Start () {
        _pad = this.gameObject;
        _padTransform = _pad.transform;
        _padRenderer = _pad.GetComponent<Renderer>();
        _padSize = _padRenderer.bounds.size;
        _worldBounds = _worldRadiusSize - (_padSize.x / 2);
        
    }

    // Update is called once per frame
    void Update()
    {       
        float xPos = _padTransform.position.x + (Input.GetAxis("Horizontal") * _padSpeed);   
        _padTransform.position = new Vector3(Mathf.Clamp(xPos, -1* _worldBounds, _worldBounds), _padTransform.position.y, -0.032f);
    }
}
