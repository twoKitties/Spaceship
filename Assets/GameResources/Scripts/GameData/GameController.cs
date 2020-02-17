using UnityEngine;

public class GameController : MonoBehaviour, IGameEventListener<Health>
{    
    [SerializeField] private LevelController levelController;
    [SerializeField] private Player player;
    [SerializeField] private HealthEvent playerDeathEvent;
    [SerializeField] private PointsController pointsController;
    [SerializeField] private UIController uiController;
    private LevelData _levelData;

    private void Awake()
    {
        if (LevelDataController.Instance)
        {
            _levelData = LevelDataController.Instance.CurrentData;
        }
        else
        {
            Debug.LogError("LevelDataController isn't present in the scene");
            return;
        }
        playerDeathEvent.Register(this);
        pointsController.onPointsUpdated += CheckPointsCount;
    }

    private void Start()
    {
        if(LevelDataController.Instance == null)
        {
            return;
        }

        StartGame();
        uiController.SetGame();
    }

    private void OnDestroy()
    {
        playerDeathEvent.Unregister(this);
        pointsController.onPointsUpdated -= CheckPointsCount;
    }

    public void StartGame()
    {
        player.ResetPlayer();
        pointsController.ResetPoints();
        levelController.StartSpawn(_levelData);
        uiController.SetGame();
    }

    private void OnGameEnd()
    {
        levelController.StopSpawn();
        player.DisableInput();
    }

    private void OnLost()
    {
        uiController.SetLose();
    }

    private void OnWin()
    {
        uiController.SetWin();
        var nextLevel = LevelDataController.Instance.GetNextLevel();
        if (nextLevel != null)
            nextLevel.State = LevelState.Open;
    }

    public void OnEventRaised(Health data)
    {
        OnGameEnd();
        OnLost();
    }

    private void CheckPointsCount(int points)
    {
        if (points >= _levelData.PointsToPass)
        {
            OnGameEnd();
            OnWin();
        }
    }
}
