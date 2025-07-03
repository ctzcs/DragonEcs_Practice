using System;

namespace SimpleTurnBased.Logic.Turn
{
    public static class TurnScheduleExt
    {
        public static void ChangeTurn(ref this C_TurnState state,EWhoOperator turn)
        {
            state.turn = turn;
        }

        public static EWhoOperator NextOperator(EWhoOperator curOperator)
        {
            return curOperator switch
            {
                EWhoOperator.None => EWhoOperator.Start,
                EWhoOperator.Start=>EWhoOperator.Player,
                EWhoOperator.Player=>EWhoOperator.AI,
                EWhoOperator.AI => EWhoOperator.End,
                EWhoOperator.End => EWhoOperator.Start,
                _ => throw new ArgumentOutOfRangeException(nameof(curOperator), curOperator, null)
            };
        }
    }
}