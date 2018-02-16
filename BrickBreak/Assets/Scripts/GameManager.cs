using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)           //if instance is not assigned
        {                               //then assign instance to this object
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);   //then destroy this object
        }

        DontDestroyOnLoad(this.gameObject);
    }


    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);

    }


}
