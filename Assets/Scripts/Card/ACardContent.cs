using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACardContent : MonoBehaviour
{
    [SerializeField] protected string cardName;
    [SerializeField, TextArea(minLines: 3, maxLines: 5)] protected string description;

    public string CardName { get { return cardName; } }
    public string Description { get { return description; } }

    public virtual void SetInstance(Card card, Vector2 spawnPos)
    {
        gameObject.SetActive(true);
        transform.position = spawnPos;
        transform.SetParent(card.transform, true);
    }

    public void ReturnToPool()
    {
        transform.SetParent(null, true);

        gameObject.SetActive(false);

        CardContentPooling.Instance.ReturnToPool(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
