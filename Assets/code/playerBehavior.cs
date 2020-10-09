﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    private int currentCheckPoint = 0;
    private Vector3 currentRespawnLocation = new Vector3(0, 10, 0);


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<PluginTester>().setTheFilePath();
        gameObject.GetComponent<PluginTester>().loadTheValues();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.GetComponent<PluginTester>().callTheInfo(0)[0]);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * 7.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * 7.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * 7.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * 7.0f;
        }

        Physics.gravity = new Vector3(0, Physics.gravity.y, 0);
    }

    public void respawnThePlayer()
    {
        //getCheckpointandcheckpointLocation
        transform.position = currentRespawnLocation;
    }

    public void updateRespawn(Vector3 newRespawnPoint)
    {
        currentRespawnLocation = newRespawnPoint;
        currentRespawnLocation.y += 10;
        gameObject.GetComponent<PluginTester>().saveTheCheckpoint(currentCheckPoint);
        currentCheckPoint++;
    }

    public void startTimer()
    {
        gameObject.GetComponent<PluginTester>().startTheTimer();
    }

    public void updateEnd()
    {
        gameObject.GetComponent<getPlayerRecordInfo>().updateTheInfo();
    }
}
