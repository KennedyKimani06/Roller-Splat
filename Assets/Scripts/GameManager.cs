using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    private GroundPiece[] allGroundPieces;
    // Start is called before the first frame update
    void Start()
    {
        SetupNewLevel();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
    }
    private void Awake()
    {
        if(singleton == null)
        {
            singleton =  this;
        }else if(singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFnishedLoading;
    }
    private void OnLevelFnishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
    }
    public void CheckComplete()
    {
        bool isFinished = true;

        for(int i = 0; i < allGroundPieces.Length; i++)
        {
            if(allGroundPieces[i].isColoured == false)
            {
                isFinished = false;
                break;
            }
        }
        if(isFinished)
        {
            NextLevel();
        }
    }
    private void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
 