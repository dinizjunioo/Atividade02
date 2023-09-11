using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocationLoader : MonoBehaviour
{

    public GameScene[] mainMenuScenes;
    //
    [Header("Loading Screen")]
    public GameObject loadingInterface;
    public Image loadingProgressBar;
    //
    [Header("Load Event")]
    //[SerializeField] private LoadEvent _loadEvent = default;
    //
    private List<AsyncOperation> _operations = new List<AsyncOperation>();
    private List<Scene> _scenesToUnload = new List<Scene>();
    private GameScene _activeScene;


}
