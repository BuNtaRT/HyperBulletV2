namespace Vault
{
    public enum ObjLayer
    {
        Default = 0,
        TransparentFX = 1,
        Ignore_Raycast = 2,
        UI = 5,
    }

    public enum GameStatus
    {
        None,
        Pause,
        PickPerk,
        Action,
    }

    public static class GameTag
    {
        public const string ENEMY = "Enemy";
        public const string PLAYER = "Player";
    }
}