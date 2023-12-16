using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtol : MonoBehaviour
{
    private const string Sence1 = "Sence1";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load_Game()
    {
        Application.LoadLevel("Sence1");
    }
}
