using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    private List<GameObject> _menus = new List<GameObject>();

    private void Awake()
    {
        _menus.Add(game);
        _menus.Add(pause);
        _menus.Add(win);
        _menus.Add(lose);
    }

    public void SetGame()
    {
        EnableSelected(game);
    }

    public void SetPause()
    {
        EnableSelected(pause);
    }

    public void SetWin()
    {
        EnableSelected(win);
    }

    public void SetLose()
    {
        EnableSelected(lose);
    }

    private void EnableSelected(GameObject selection)
    {
        foreach (var item in _menus)
        {
            item.SetActive(false);
        }

        selection.SetActive(true);
    }

}
