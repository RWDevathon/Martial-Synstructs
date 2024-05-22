using Verse;
using RimWorld.Planet;

namespace ArtificialBeings
{
    public class DownedJellymanComp : DownedRefugeeComp
    {
        protected override string PawnSaveKey
        {
            get
            {
                return "jellyman";
            }
        }

        protected override void RemovePawnOnWorldObjectRemoved()
        {
            pawn.ClearAndDestroyContents(DestroyMode.Vanish);
        }

        public override string CompInspectStringExtra()
        {
            return null;
        }
    }
}