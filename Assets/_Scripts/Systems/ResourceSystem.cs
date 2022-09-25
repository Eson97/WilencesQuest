
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceSystem : Singleton<ResourceSystem>
{
    public List<EnemySO> Enemies { get; private set; }
    public List<EventSO> Events { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        Enemies = Resources.LoadAll<EnemySO>("Enemies").ToList();
        Events = Resources.LoadAll<EventSO>("Events").ToList();
    }

    public List<EnemySO> GetEnemiesOfRank(int levelMin,int levelMax) => Enemies.Where(el => el.Level >= levelMin && el.Level <= levelMax).ToList();

    public EventSO GetRandomEvent(int level)
    {
        var events = Events.Where(el => el.Level == level).ToList();
        return events.ElementAt(Random.Range(0, events.Count-1));
    }
}
