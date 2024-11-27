using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Deck deck;
    //[SerializeField] private Vector2 deckPos;
    [SerializeField] private float handSize;
    [SerializeField] private float normalCardSpace;

    private List<Card> cardOnHand = new();

    public void DrawCardToHand(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (deck.cardContents.Count > 0)
            {
                Card newCard = CardPooling.Instance.DrawCard(deck.card, deck.cardContents[0], transform.position);
                deck.cardContents.RemoveAt(0);
                cardOnHand.Add(newCard);
                UpdateCardPos();
            }
            else
            {
                Debug.Log("No more card");
                break;
            }
        }
    }

    private void UpdateCardPos()
    {
        float spaceBetweenCard = Mathf.Min(normalCardSpace, handSize / (cardOnHand.Count - 1));

        if (cardOnHand.Count <= 1)
        {
            if (cardOnHand.Count == 1)
            {
                cardOnHand[0].transform.position = transform.position;
            }
        }
        else
        {
            for (int i = 0; i < cardOnHand.Count; i++)
            {
                if ((cardOnHand.Count & 2) == 1)
                {
                    cardOnHand[i].transform.position = i == 0 ?
                        new Vector2(transform.position.x - cardOnHand.Count * spaceBetweenCard / 2, cardOnHand[i].transform.position.y) :
                        new Vector3(cardOnHand[i - 1].transform.position.x + spaceBetweenCard, cardOnHand[i].transform.position.y, cardOnHand[i - 1].transform.position.z + 2);
                }
                else
                {
                    cardOnHand[i].transform.position = i == 0 ?
                        new Vector2(transform.position.x - (cardOnHand.Count - 1) * spaceBetweenCard / 2, cardOnHand[i].transform.position.y) :
                        new Vector3(cardOnHand[i - 1].transform.position.x + spaceBetweenCard, cardOnHand[i].transform.position.y, cardOnHand[i - 1].transform.position.z + 2);
                }
            }
        }
    }

    public void RemoveCardFromHand(Card card)
    {

    }

    public void OnClickOnCard(Card card)
    {
        //switch (card.CardStatus)
        //{
        //    case ECardStatus.OnHand:
        //        break;

        //    case ECardStatus.OnField:
        //        break;

        //    default:
        //        break;
        //}

    }

    private void FixedUpdate()
    {
        //UpdateCardPos();
    }
}

[System.Serializable]
public class Deck
{
    public Card card;
    public List<ACardContent> cardContents;
}
