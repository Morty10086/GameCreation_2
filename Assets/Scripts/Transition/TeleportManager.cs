using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour 
{
    #region ����
    //����Ϊ����
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

    // ����һ���б���������Ҫ���ٵ���Ϸ����
    List<GameObject> objectsToDestroy = new List<GameObject>();




    //�л���������
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



    //�첽���س��� ����������
    private IEnumerator TransitionToScene(string sceneFrom, string sceneToGO, Vector3 cameraPos)
    {
        //ж�ص�ǰ����
        yield return Fade(1);
        if (sceneFrom != string.Empty)
        {
            PlayerDataManager.Instance.SavePlayerPos();
            UnLoadScene();
        }

        yield return LoadScene(sceneToGO);
        //��ȡ��һ���������λ��
        PlayerDataManager.Instance.LoadPlayerPos();
        //�������λ��
        if(cameraPos!=null)
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = cameraPos;
        }
        
        UpdateInteractDoneLoad();
        yield return Fade(0);
    }






    public IEnumerator LoadScene(string sceneTo)
    {
        //�����³���������ϲ����־û�����
        yield return SceneManager.LoadSceneAsync(sceneTo, LoadSceneMode.Additive);
        //��ȡ�־û��ĳ������³���
        Scene persistentScene = SceneManager.GetSceneByName("Persistent");
        Scene newScene = SceneManager.GetSceneByName(sceneTo);
        //���³����е���Ϸ�����ƶ����־û������������еĶ���洢���б���
        GameObject[] objectsToMove=newScene.GetRootGameObjects();
        foreach(GameObject obj in objectsToMove)
        {
            //���³����е���Ϸ������ӵ��־û�����
            SceneManager.MoveGameObjectToScene(obj,persistentScene);

            //��¼��Ҫ���ٵ���Ϸ����
            objectsToDestroy.Add(obj);
        }
        //���ó־û�����Ϊ�����
        SceneManager.SetActiveScene(persistentScene);
        //ж���³���
        yield return SceneManager.UnloadSceneAsync(newScene);
    }

    public void UnLoadScene()
    {
        //���ٱ�ǵ���Ϸ����
        foreach(GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                GameObject.Destroy(obj);
            }
            
        }
        objectsToDestroy.Clear();
    }


    //����Ч��
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
    //�����³���ǰ�ж��³����������Ƿ��ѱ��浽��Ʒ�����б��У�����ѱ��棬���ѽ���
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
