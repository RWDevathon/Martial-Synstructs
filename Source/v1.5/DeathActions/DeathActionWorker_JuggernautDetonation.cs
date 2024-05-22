using RimWorld;
using Verse.AI.Group;
using Verse;

namespace ArtificialBeings
{
    public class DeathActionWorker_JuggernautDetonation : DeathActionWorker
    {
        public override RulePackDef DeathRules => RulePackDefOf.Transition_DiedExplosive;

        public override bool DangerousInMelee => true;

        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            GenExplosion.DoExplosion(radius: 16.9f, center: corpse.Position, map: corpse.Map, damType: DamageDefOf.Bomb, preExplosionSpawnThingDef: ThingDefOf.Shell_AntigrainWarhead, preExplosionSpawnChance: 0.01f, instigator: corpse.InnerPawn);
        }
    }
}
