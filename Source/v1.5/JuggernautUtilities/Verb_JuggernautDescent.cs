using Verse.AI;
using Verse;

namespace ArtificialBeings
{
    public class Verb_JuggernautDescent : Verb_CastBase
    {
        protected override bool TryCastShot()
        {
            if (currentTarget.HasThing && currentTarget.Thing.Map != caster.Map)
            {
                return false;
            }
            OrbitalStrike_JuggernautDescent mechfall = (OrbitalStrike_JuggernautDescent)GenSpawn.Spawn(ABF_ThingDefOf.ABF_JuggernautDescentBeam, currentTarget.Cell, caster.Map);
            mechfall.duration = DurationTicks;
            mechfall.instigator = caster;
            mechfall.weaponDef = EquipmentSource?.def;
            mechfall.StartStrike();
            ReloadableCompSource?.UsedOnce();
            return true;
        }

        public override float HighlightFieldRadiusAroundTarget(out bool needLOSToCenter)
        {
            needLOSToCenter = false;
            return 2f;
        }

        private const int DurationTicks = 450;
    }
}
