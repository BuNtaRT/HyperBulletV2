using Bonus.Perk;
using Bonus.Spells;
using UnityEngine;
using UnityEngine.Events;
using Vault;

namespace Runtime
{
    public static class GlobalEventsManager
    {
        //--------------------------------------------------------------------------------------------------- Текущий статус игры
        public static GameStatus LastGameStatus = new GameStatus();
        public static readonly UnityEvent<GameStatus> OnGameStatus = new UnityEvent<GameStatus>();

        public static void InvokeGameStatus(GameStatus status)
        {
            LastGameStatus = status;
            OnGameStatus.Invoke(status);
        }

        //---------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------- Касания по экарану
        public static EventTouch LastTouch = new EventTouch();
        public static readonly UnityEvent<EventTouch> OnTouch = new UnityEvent<EventTouch>();

        public static void InvokeTouch(EventTouch touch)
        {
            LastTouch = touch;
            OnTouch.Invoke(touch);
        }

        //---------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------- Свайпы по экрану
        public static EventSwipe LastSwipe = new EventSwipe();
        public static readonly UnityEvent<EventSwipe> OnSwipe = new UnityEvent<EventSwipe>();

        public static void InvokeSwipe(EventSwipe swipe)
        {
            LastSwipe = swipe;
            OnSwipe.Invoke(swipe);
        }

        //---------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------- Поднятие способности
        public static SpellSO LastPickupSpell;
        public static readonly UnityEvent<SpellSO> OnPickupSpell = new UnityEvent<SpellSO>();

        public static void InvokePickupSpell(SpellSO spell)
        {
            LastPickupSpell = spell;
            OnPickupSpell.Invoke(spell);
        }

        //---------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------- Поднятие перка
        public static PerkSO LastPickupPerk;
        public static readonly UnityEvent<PerkSO> OnPickupPerk = new UnityEvent<PerkSO>();

        public static void InvokePickupPerk(PerkSO perk)
        {
            LastPickupPerk = perk;
            OnPickupPerk.Invoke(perk);
        }

        //---------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------- Перемещение игрока
        public static readonly UnityEvent<EventMovePlayer> OnPlayerMove =
            new UnityEvent<EventMovePlayer>();

        public static void InvokePlayerMove(EventMovePlayer movement) =>
            OnPlayerMove.Invoke(movement);

        //---------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------- Уничтожение противника
        public static readonly UnityEvent<Vector2> OnEnemyDie = new UnityEvent<Vector2>();

        public static void InvokeEnemyDie(Vector2 enemyPosition) =>
            OnEnemyDie.Invoke(enemyPosition);

        //---------------------------------------------------------------------------------------------------
    }

    public struct EventMovePlayer
    {
        public Vector2[] Points;
        public ProgressStage Stage;
    }

    public struct EventSwipe
    {
        public Vector2 Start;
        public Vector2 Current;
        public ProgressStage Status;
    }

    public struct EventTouch
    {
        public Vector2 Position;
        public Transform Collision;
    }

    public enum ProgressStage
    {
        Started,
        Progress,
        Ended,
    }
}
