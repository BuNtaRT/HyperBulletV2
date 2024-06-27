using Bonus.Perk;
using Bonus.Spells;
using Lib;
using Runtime.Touch;
using UnityEngine;
using UnityEngine.Events;
using Vault;

namespace Runtime
{
    public static class GlobalEventsManager
    {
        //---------------------------------------------------------------------------------------------------
        public static GameStatus LastGameStatus = new GameStatus();
        public static UnityEvent<GameStatus> OnGameStatus = new UnityEvent<GameStatus>();
        public static void InvokGameStatus(GameStatus status) {
            LastGameStatus = status;
            OnGameStatus.Invoke(status);
        }
        //---------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------
        public static UnityEvent<TypeObj, Vector3> OnSpawnObject = new UnityEvent<TypeObj, Vector3>();
        public static void InvokSpawnObject(TypeObj type, Vector3 position) => OnSpawnObject.Invoke(type, position);
        //---------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------
        public static EventTouch LastTouch = new EventTouch();
        public static UnityEvent<EventTouch> OnTouch = new UnityEvent<EventTouch>();
        public static void InvokTouch(EventTouch touch) {
            LastTouch = touch;
            OnTouch.Invoke(touch);
        } 
        //---------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------
        public static EventSwipe LastSwipe = new EventSwipe();
        public static UnityEvent<EventSwipe> OnSwipe = new UnityEvent<EventSwipe>();
        public static void InvokSwipe(EventSwipe swipe)
        {
            LastSwipe = swipe;
            OnSwipe.Invoke(swipe);
        }
        //---------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------
        public static SpellSO LastPickupSpell = new SpellSO();
        public static UnityEvent<SpellSO> OnPickupSpell = new UnityEvent<SpellSO>();
        public static void InvokPickupSpell(SpellSO spell)
        {
            LastPickupSpell = spell;
            OnPickupSpell.Invoke(spell);
        }
        //---------------------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------------------
        public static PerkSO LastPickupPerk = new PerkSO();
        public static UnityEvent<PerkSO> OnPickupPerk = new UnityEvent<PerkSO>();
        public static void InvokPickupPerk(PerkSO perk)
        {
            LastPickupPerk = perk; 
            OnPickupPerk.Invoke(perk);
        }
        //---------------------------------------------------------------------------------------------------

    }

    public struct EventTouch
    {
        public Vector2 Position;
        public Transform Collision;
    }

    public struct EventSwipe
    {
        public Vector2 Start;
        public Vector2 Current;
        public TouchState Status;
    }
}