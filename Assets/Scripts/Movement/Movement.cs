using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = 10.0f;

    private Rigidbody _rb;
    private GameManager _gameManager;

	// Use this for initialization
	void Awake () {
        _rb = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_gameManager != null && !_gameManager.IsCurrentPlayer(gameObject) || Input.GetButton("ShapeSelect"))
            return;


        float x = Input.GetAxis("Horizontal") * Speed;
        float y = Input.GetAxis("Vertical") * Speed;

        _rb.velocity = new Vector3(x, 0, y);
    }
}
