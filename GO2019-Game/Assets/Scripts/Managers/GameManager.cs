using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float soundFloat;
    public bool invertedY;

    // Start is called before the first frame update
    void Start()
    {
        DefaultSettings();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void DefaultSettings()
    {
        soundFloat = 1f;
        invertedY = false;
    }
}
