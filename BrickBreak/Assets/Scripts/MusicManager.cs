using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
        // singleton
    public static MusicManager instance = null;

    void Awake ()
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
	
}
