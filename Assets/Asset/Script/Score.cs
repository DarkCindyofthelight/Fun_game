using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof (Text))]
public class Score : MonoBehaviour
{
    public class Person
    {
        private string _name;

        public Person(string name) => _name = name;

        // Person has one method, called WriteName.
        public void WriteName()
        {
            System.Console.WriteLine(_name);
        }
    }


    public RacketController racket;
    Text text;

    void Start()
    {

        text = GetComponent<Text>();


    }

    void Update()
    {
        text.text = racket.score.ToString();

    }


   

}


      


