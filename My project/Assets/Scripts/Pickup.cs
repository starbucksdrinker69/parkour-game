using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 initPos;
    public GameObject coin;

    public int value;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().AddGold(value);

        Destroy(coin);
    }
}
