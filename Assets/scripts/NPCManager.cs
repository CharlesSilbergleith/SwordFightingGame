using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance;

    private Dictionary<NPC, Transform> npcLocations = new Dictionary<NPC, Transform>();

    void Awake()
    {
        Instance = this;
    }

    public void RegisterNPC(NPC npc, Transform location)
    {
        if (!npcLocations.ContainsKey(npc))
        {
            npcLocations.Add(npc, location);
        }
    }

    public void UpdateLocation(NPC npc, Transform newLocation)
    {
        if (npcLocations.ContainsKey(npc))
        {
            npcLocations[npc] = newLocation;
        }
    }

    public Transform GetLocation(NPC npc)
    {
        npcLocations.TryGetValue(npc, out Transform loc);
        return loc;
    }

    public void RemoveNPC(NPC npc)
    {
        npcLocations.Remove(npc);
    }
}
