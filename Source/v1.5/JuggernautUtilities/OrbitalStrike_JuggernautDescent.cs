using Verse;
using RimWorld;

namespace ArtificialBeings
{
    [StaticConstructorOnStartup]
    public class OrbitalStrike_JuggernautDescent : OrbitalStrike
    {
        public override void StartStrike()
        {
            base.StartStrike();
            MoteMaker_JuggernautDescent.MakeMote_JuggernautDescent(Position, Map);
        }

        public override void Tick()
        {
            if (TicksLeft == 0)
            {
                SpawnPawn();
            }
            else if (TicksLeft == 15)
            {
                CreateExplosion();
            }
            else if (TicksLeft == 160)
            {
                CreatePod();
            }
            base.Tick();
        }

        private void CreateExplosion()
        {
            GenExplosion.DoExplosion(Position, Map, 20, DamageDefOf.EMP, instigator, 100, -1f, null, weaponDef, def);
            GenExplosion.DoExplosion(Position, Map, 10, DamageDefOf.Bomb, instigator, 100, -1f, null, weaponDef, def, chanceToStartFire: 0.25f, damageFalloff: true, screenShakeFactor: 2);
        }

        private void CreatePod()
        {
            ActiveDropPodInfo info = new ActiveDropPodInfo
            {
                openDelay = 10,
                leaveSlag = true
            };
            DropPodUtility.MakeDropPodAt(Position, Map, info);
        }

        public void SpawnPawn()
        {
            PawnGenerationRequest request = new PawnGenerationRequest(ABF_PawnKindDefOf.ABF_PawnKind_Synstruct_Juggernaut_Calldown, instigator.Faction, PawnGenerationContext.NonPlayer);
            Pawn pawn = PawnGenerator.GeneratePawn(request);
            FilthMaker.TryMakeFilth(Position, Map, ThingDefOf.Filth_RubbleBuilding, 30);

            // There is a chance the unit will be permanently hostile and try to murder everything it can find.
            if (Rand.Chance(0.2f))
            {
                pawn.SetFactionDirect(Faction.OfAncientsHostile);
                pawn.mindState.mentalStateHandler.TryStartMentalState(ABF_MentalStateDefOf.ABF_MentalState_Synstruct_Exterminator, transitionSilently: true);

                Hediff hediff = HediffMaker.MakeHediff(ABF_HediffDefOf.ABF_Hediff_Synstruct_RemainingCharge, pawn, null);
                hediff.Severity = 1f;
                pawn.health.AddHediff(hediff, null, null);

                Messages.Message("ABF_HostileJuggernaut".Translate(), MessageTypeDefOf.ThreatBig);
            }

            GenSpawn.Spawn(pawn, Position, Map);

            // Player controlled mechs should immediately draft for combat.
            if (pawn.Faction == Faction.OfPlayer)
            {
                pawn.drafter.Drafted = true;
            }
        }
    }
}
