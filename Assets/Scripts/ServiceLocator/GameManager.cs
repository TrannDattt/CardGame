using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public List<CardSlot> slots;
    public List<Player> players;

    [SerializeField] private Animator drawBtnAnimator;

    public void StartGame()
    {
        //StartCoroutine(DrawCard());
        //foreach (Player player in players)
        //{
        players[0].DrawCardToHand(1);
        //}
    }

    private void Update()
    {
        
    }
}

[System.Serializable]
public class CardSlot
{
    public Transform slotPosition;
    public bool hasCardInSlot;
}
