using RimWorld;
using Verse;

namespace ArtificialBeings
{
    public static class MoteMaker_JuggernautDescent
    {
        public static void MakeMote_JuggernautDescent(IntVec3 cell, Map map)
        {
            Mote mote = (Mote)ThingMaker.MakeThing(ThingDefOf.Mote_Bombardment, null);
            mote.exactPosition = cell.ToVector3Shifted();
            mote.Scale = 5f;
            mote.rotationRate = 0f;
            GenSpawn.Spawn(mote, cell, map);
        }

    }
}
