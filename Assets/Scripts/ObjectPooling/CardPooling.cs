using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPooling : Singleton<CardPooling>
{
    //[SerializeField] private Card card;

    private Queue<Card> cardQueue = new();

    public void ReturnToPool(Card card)
    {
        cardQueue.Enqueue(card);
    }

    public Card DrawCard(Card card, ACardContent cardContent, Vector2 drawPos)
    {
        if (cardQueue.Count == 0)
        {
            Card _card = Instantiate(card, drawPos, Quaternion.identity);
            _card.SetInstance(cardContent, drawPos);
            return _card;
        }

        Card newCard = cardQueue.Dequeue();
        newCard.SetInstance(cardContent, drawPos);

        return newCard;
    }
}
