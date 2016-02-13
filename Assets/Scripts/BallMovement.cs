/// BallMovement.cs
/// Controls ball adhoc physics
/// Author: Jose A. Ciccio

using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {


    public GameObject _ball;
    public Vector3 _direction;
    private Transform _ballTransform;
    private float lockRotation = 0f;
    private CollisionPoint _collisionPoint;

    // Use this for initialization
    void Start()
    {
        // Generate X coordinate random
        this.transform.parent = null;
        _direction = new Vector3(0.0f, -0.1f, -0f);
        _ball = this.gameObject;
        _ballTransform = this.gameObject.transform;
        _collisionPoint = this.GetComponent("CollisionPoint") as CollisionPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction.z = 0;
        _ballTransform.Translate ( _direction);
        if (GameManager.instance.IsLevelWon)
        {
            PlayOutro();
        }
    }

    // Goes back to pad
    void PlayOutro()
    {
        MonoBehaviour script = this.GetComponent("BallMovement") as MonoBehaviour;
        script.enabled = false;
        Transform parent = GameObject.Find("Pad").transform;
        gameObject.transform.parent = parent;
        Hashtable ht = new Hashtable();
        ht.Add("time", 1);
        ht.Add("position", new Vector3(parent.position.x, parent.position.y +0.3f, parent.position.z));
        ht.Add("oncomplete", "OnBallOutroCompleted");
        ht.Add("oncompletetarget", this.gameObject);
        iTween.MoveTo(this.gameObject, ht);
    }

    void OnBallOutroCompleted()
    {
        Debug.Log("Outro Completed");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Pad")
        {
            // Depending on the point where the collision was made, the ball will rebound to different positions
            Vector3 point = _collisionPoint.getCollisionPoint(col);
            _direction = new Vector3(-0.1f * Mathf.Clamp(point.x, -1f, 1f), Mathf.Abs(_direction.y), _direction.z);
        }
        else if (col.gameObject.name == "Left" || col.gameObject.name == "Right")
        {
            // Change X axis
            _direction = new Vector3(-1 * _direction.x, _direction.y, _direction.z);
        }
        else if (col.gameObject.name == "Up" || col.gameObject.name == "Down")
        {
            // Change Y axis
            _direction = new Vector3(_direction.x, _direction.y * -1, _direction.z);
        }
        else if (col.gameObject.name == "Block")
        {
            GameObject block = col.gameObject; //Block Game Object
            Transform blockTransform = block.transform; // Block transform
            Vector3 point = col.contacts[0].point; // Block Object
            Vector3 collisionPoint = _ballTransform.position - point;
            float absX = Mathf.Abs(collisionPoint.x);
            float absY = Mathf.Abs(collisionPoint.y);
            if (absX > absY)
            {
                _direction = new Vector3(_direction.x * -1, _direction.y, _direction.z);
            }
            else if (absX < absY)
            {
                _direction = new Vector3(_direction.x, _direction.y * -1, _direction.z);
            }
            else
            {
                _direction = new Vector3(_direction.x * -1, _direction.y * -1, _direction.z);
            }
        }
        
    }
}
