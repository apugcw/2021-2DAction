using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;//LoadSceneを使うために必要!!


public class MyButton : MonoBehaviour {
    public void ButtonClick() {
        switch (transform.name) {
            //移りたいシーンを入れる
        case "Button1":
            SceneManager.LoadScene("NewScene1");
            break;
        case "Button2":
            SceneManager.LoadScene("NewScene2");
            break;
        case "Button3":
            SceneManager.LoadScene("NewScene3");
            break;
        default:
            break;
        }
    }
}