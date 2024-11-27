using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContentPooling : Singleton<CardContentPooling>
{
    //[SerializeField] private Monster monster;
    //[SerializeField] private Spell spell;

    private List<Monster> monsterList = new();
    private List<Spell> spellList = new();

    public void ReturnToPool(ACardContent content)
    {
        switch (content)
        {
            case Monster monster:
                monsterList.Add(monster);
                break;

            case Spell spell:
                spellList.Add(spell);
                break;

            default:
                break;
        }
    }

    public ACardContent GetCardContent(Card card, ACardContent cardContent, Vector2 spawnPos)
    {
        switch (cardContent)
        {
            case Monster monster:
                if (monsterList.Count == 0 || !monsterList.Contains(monster))
                {
                    Monster _monster = Instantiate(monster, spawnPos, Quaternion.identity);
                    _monster.SetInstance(card, spawnPos);
                    return _monster;
                }

                foreach(Monster _monster in monsterList)
                {
                    if(_monster == monster)
                    {
                        _monster.SetInstance(card, spawnPos);
                        return _monster;
                    }
                }

                return null;

            case Spell spell:
                if (spellList.Count == 0 || !spellList.Contains(spell))
                {
                    Spell _spell = Instantiate(spell, spawnPos, Quaternion.identity);
                    _spell.SetInstance(card, spawnPos);
                    return _spell;
                }

                foreach (Spell _spell in spellList)
                {
                    if(_spell == spell)
                    {
                        _spell.SetInstance(card, spawnPos);
                        return _spell;
                    }
                }

                return null;

            default:
                return null;
        }
    }

    //public void GetMonster(Vector2 spawnPos)
    //{
    //    if(monsterQueue.Count == 0)
    //    {
    //        Monster _monster = Instantiate(monster, spawnPos, Quaternion.identity);
    //        monsterQueue.Enqueue(_monster);
    //    }

    //    //monsterQueue.Dequeue().SetInstance();
    //}

    //public void GetSpell(Vector2 spawnPos)
    //{
    //    if (spellQueue.Count == 0)
    //    {
    //        Spell _spell = Instantiate(spell, spawnPos, Quaternion.identity);
    //        spellQueue.Enqueue(_spell);
    //    }

    //    //spellQueue.Dequeue().SetInstance();
    //}
}
