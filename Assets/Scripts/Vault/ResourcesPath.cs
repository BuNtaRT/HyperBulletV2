namespace Vault
{
    public static class ResourcesPath
    {
        public static string BulletSO(string bulletPath) => $"Ammo/Bullet/SO/{bulletPath}";

        public static string PerkSO(string perkPath) => $"Bonus/Perks/{perkPath}SO";

        public static string SpellSO(string spellPath) => $"Bonus/Spells/{spellPath}";
    }
}