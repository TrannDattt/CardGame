using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //public bool hasBeenDrawed;
    public bool isFaceUp;
    public ECardStatus CardStatus { get; private set; }

    private ACardContent cardContent;
    [SerializeField] private Transform contentPos;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private CardManager cardManager;
    //[SerializeField] private SpriteRenderer cardFront;
    //[SerializeField] private SpriteRenderer cardBack;

    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardDescription;
    [SerializeField] private TextMeshProUGUI monsterAttack;
    [SerializeField] private TextMeshProUGUI monsterHealth;

    public void SetInstance(ACardContent _cardContent, Vector2 drawPos)
    {
        gameObject.SetActive(true);

        CardStatus = ECardStatus.OnHand;
        transform.position = drawPos;
        cardContent = CardContentPooling.Instance.GetCardContent(this, _cardContent, contentPos.position);

        cardName.text = cardContent.CardName;
        cardDescription.text = cardContent.Description;
        if(cardContent is Monster)
        {
            monsterAttack.gameObject.SetActive(true);
            monsterHealth.gameObject.SetActive(true);
        }

        //StartCoroutine(OnDrawCard());
    }
    private IEnumerator OnDrawCard()
    {
        animator.SetTrigger("Draw");
        yield return new WaitForSeconds(0.5f);
    }

    public void ReturnToPool(ECardStatus returnPlace)
    {
        CardStatus = returnPlace;

        monsterAttack.gameObject.SetActive(false);
        monsterHealth.gameObject.SetActive(false);

        cardContent.ReturnToPool();
        cardContent = null;

        gameObject.SetActive(false);

        CardPooling.Instance.ReturnToPool(this);
    }

    private void UpdateCardDes()
    {
        if (cardContent != null && cardContent is Monster _monster)
        {
            monsterAttack.text = _monster.CurDamage.ToString();
            monsterHealth.text = _monster.CurHealth.ToString();
        }
    }

    private void UpdateFlippedCard()
    {
        //if (isFaceUp)
        //{
        //    cardBack.sortingOrder = 0;
        //}
        //else
        //{
        //    cardBack.sortingOrder = cardFront.sortingOrder + 2;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        CardStatus = ECardStatus.InDeck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdateCardDes();
        //UpdateFlippedCard();
    }
}
