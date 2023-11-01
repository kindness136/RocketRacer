using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    GameObject MainCamera;
    public GameObject rockPrefab;
    public GameObject bigrockPrefab;
    float rockspan = 0.9f;
    float bigrockspan = 2.1f;
    float rockdelta = 0;
    float bigrockdelta = 0;

    public void SetParameter(float rockspan, float bigrockspan)
    {
        this.rockspan = rockspan;
        this.bigrockspan = bigrockspan;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.MainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        this.rockdelta += Time.deltaTime;

        //岩（小）の出方
        if (this.rockdelta > this.rockspan)
        {
            this.rockdelta = 0;
            GameObject go = Instantiate(rockPrefab);
            float px = Random.Range(-3.0f, 3.1f);
            float yrange = this.MainCamera.transform.position.y + 12.0f;
            go.transform.position = new Vector3(px, yrange);
        }

        this.bigrockdelta += Time.deltaTime;

        //岩（大）の出方
        if (this.bigrockdelta > this.bigrockspan)
        {
            this.bigrockdelta = 0;
            GameObject go = Instantiate(bigrockPrefab);
            float px = Random.Range(-3.0f, 3.1f);
            float yrange = this.MainCamera.transform.position.y + 12.0f;
            go.transform.position = new Vector3(px, yrange);
        }
    }
}
