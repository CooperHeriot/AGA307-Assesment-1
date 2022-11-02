using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class UITitle : GameBehaiour
{
    public string SceneToGoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneToGoTo);
        _GM.ChangeGameState(GameState.Playing);
        //_GM.UpdateDifficultyOnLoad();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
