using Verse;

namespace ArtificialBeings
{
    // The Ablative Active Armor hediff giver reacts to the amount of health the pawn has.
    public class HediffGiver_AblativeActiveArmor : HediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            float pawnHealthpct = pawn.health.summaryHealth.SummaryHealthPercent;

            // A pawn is dead if they have less than 5% health by the SummaryHealthPercent method.
            if (pawnHealthpct >= 0.05f)
            {
                Hediff activeArmorHediff = pawn.health.hediffSet.GetFirstHediffOfDef(hediff);

                if (activeArmorHediff == null)
                {
                    activeArmorHediff = HediffMaker.MakeHediff(hediff, pawn);
                    pawn.health.AddHediff(activeArmorHediff);
                }

                activeArmorHediff.Severity = pawnHealthpct;
            }
        }
    }
}