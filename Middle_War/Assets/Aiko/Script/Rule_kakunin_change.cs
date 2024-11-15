using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//using UnityEditor;
//using UnityEditor.SceneManagement;
//public static class OnPlayState
//{
//    [InitializeOnLoadMethod]
//    static void Initialize()
//    {
//        EditorApplication.playModeStateChanged -= OnChangedPlayMode;
//        EditorApplication.playModeStateChanged += OnChangedPlayMode;
//    }
//    static void OnChangedPlayMode(PlayModeStateChange state)
//    {
//        if (state == PlayModeStateChange.ExitingEditMode)
//        {
//            // 再生前にシーンセーブ
//            EditorSceneManager.SaveOpenScenes();
//        }
//    }
//}
public static class Scene_Num
{
    public static int load_num;

}

public class Rule_kakunin_change : MonoBehaviour
{
    // public GameObject panel;
    public string load_scene;
    public  int scene_num;

   

    // Start is called before the first frame update
    void Start()
    {
         Scene_Num.load_num=scene_num;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rule_change()
    {
       // if (panel.activeSelf)
       // {
       //     panel.SetActive(false);
       //}else
       // {
       //     panel.SetActive(true);
       // }
       
        SceneManager.LoadScene(load_scene);
        Debug.Log(scene_num);

    }
}
