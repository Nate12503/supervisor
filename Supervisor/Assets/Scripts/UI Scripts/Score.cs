﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    //variables n stuff, check the inspector
    private float startScore = 0f;
    private float currentScore = 0f;

    //drag & drop employee + supervisor game objects in the inspector for this to work
    public GameObject[] employees;
    public GameObject supervisor;
    [SerializeField]
    Text scoreDisplay;
    private Color employeeColor;
    [SerializeField]
    public string sceneName;
    //public Text ScoreText;
    

    void Start()
    {
        scoreDisplay.text = startScore.ToString("Score: ");
    }

    void Update()
    {
        //rounds the float to an integer so the score can only be whole numbers
        scoreDisplay.text = "Score: " + Mathf.RoundToInt(currentScore);  //currentScore.ToString("Score: " + Mathf.RoundToInt(currentScore));
        
        EmployeeProductivity();
        
        //stops the score from going below 0
        if (currentScore <= 0f)
        {
            currentScore = 0f;
        }

        if (currentScore >= 125f)
        {
            Congrats();
        }
    }

    void Congrats()
    {
        SceneManager.LoadScene(sceneName);
        //ScoreText.text = "You Win";
        //Time.timeScale = 0f;
    }

    void EmployeeProductivity()
    {
        foreach (GameObject employee in employees)
        {

            //gets the employee color
            employeeColor = employee.gameObject.GetComponent<MeshRenderer>().material.color;

            //checks if the supervisor is within distance to add to score
            if (Vector3.Distance(supervisor.transform.position, employee.transform.position) < 5)
            {
                //score increases if employee is cheerful
                if (employeeColor == Color.green)
                {
                    Debug.Log("Score is increasing based on productivity.");
                    currentScore = currentScore + 0.03f;
                    Debug.Log(currentScore);
                }
                
                //score decreases if employee is annoyed
                else if (employeeColor == Color.magenta)
                {
                    Debug.Log("Score is decreasing based on productivity.");
                    currentScore = currentScore - 0.03f;
                    Debug.Log(currentScore);
                }
            }
        }
    }
}
