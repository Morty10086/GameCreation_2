using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour 
{
    #region 单例
    //声明为单例
    private static TeleportManager instance;
    private TeleportManager() { }
    public static TeleportManager Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //public GameObject camera;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    private bool isFade;

    // 创建一个列表来保存需要销毁的游戏对象
    List<GameObject> objectsToDestroy = new List<GameObject>();




    //切换场景函数
    public void ToScene(string sceneFrom,string sceneToGO,Vector3 cameraPos)
    {

        if (!isFade)
        {
            StartCoroutine(TransitionToScene(sceneFrom, sceneToGO, cameraPos));
            //PlayerDataManager.Instance.SavePlayerPos();

            //UpdateInteractDoneLoad();
            //SceneManager.LoadScene(sceneToGO);
            //if (cameraPos != null)
            //{
            //    GameObject.FindGameObjectWithTag("MainCamera").transform.position = cameraPos;
            //}
            //StartCoroutine(TestTrans(sceneFrom, sceneToGO, cameraPos));
        }
    }


    private IEnumerator TestTrans(string sceneFrom, string sceneToGO, Vector3 cameraPos)
    {
        PlayerDataManager.Instance.SavePlayerPos();
        SceneManager.LoadScene(sceneToGO);
        yield return null;
        PlayerDataManager.Instance.LoadPlayerPos();
        if (cameraPos != null)
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = cameraPos;
        }
    }



    //异步加载场景 迭代器函数
    private IEnumerator TransitionToScene(string sceneFrom, string sceneToGO, Vector3 cameraPos)
    {
        //卸载当前场景
        yield return Fade(1);
        if (sceneFrom != string.Empty)
        {
            PlayerDataManager.Instance.SavePlayerPos();
            UnLoadScene();
        }

        yield return LoadScene(sceneToGO);
        //读取上一次玩家所在位置
        PlayerDataManager.Instance.LoadPlayerPos();
        //调整相机位置
        if(cameraPos!=null)
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = cameraPos;
        }
        
        UpdateInteractDoneLoad();
        yield return Fade(0);
    }






    public IEnumerator LoadScene(string sceneTo)
    {
        //加载新场景并将其合并到持久化场景
        yield return SceneManager.LoadSceneAsync(sceneTo, LoadSceneMode.Additive);
        //获取持久化的场景和新场景
        Scene persistentScene = SceneManager.GetSceneByName("Persistent");
        Scene newScene = SceneManager.GetSceneByName(sceneTo);
        //将新场景中的游戏对象移动到持久化场景，将其中的对象存储到列表中
        GameObject[] objectsToMove=newScene.GetRootGameObjects();
        foreach(GameObject obj in objectsToMove)
        {
            //将新场景中的游戏对象添加到持久化场景
            SceneManager.MoveGameObjectToScene(obj,persistentScene);

            //记录需要销毁的游戏对象
            objectsToDestroy.Add(obj);
        }
        //设置持久化场景为激活场景
        SceneManager.SetActiveScene(persistentScene);
        //卸载新场景
        yield return SceneManager.UnloadSceneAsync(newScene);
    }

    public void UnLoadScene()
    {
        //销毁标记的游戏对象
        foreach(GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                GameObject.Destroy(obj);
            }
            
        }
        objectsToDestroy.Clear();
    }


    //过渡效果
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
        while(!Mathf.Approximately(fadeCanvasGroup.alpha,targetAlpha))
        {
            fadeCanvasGroup.alpha=Mathf.MoveTowards(fadeCanvasGroup.alpha,targetAlpha, speed*Time.deltaTime);
            yield return null;
        }
        fadeCanvasGroup.blocksRaycasts=false;
        isFade=false;
    }
    //加载新场景前判断新场景中物体是否已保存到物品数据列表中，如果已保存，则已交互
    private void UpdateInteractDoneLoad()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if(ItemDataManager.Instance.itemList.Contains(item))
            {
                item.talkDone= true;
            }
            else
            {
                item.talkDone = false;
            }
        }
    }

}
