using UnityEngine;
using Zorro.Framework;

namespace Zorro.TestGame.Spaceship
{
    public class SpaceshipGamemode : Gamemode
    {
        public override void PlayerLoadedLevel(Player player)
        {
            base.PlayerLoadedLevel(player);
            
            Debug.Log($"PlayerLoadedLevel: {player}");
            
            Instantiate(Resources.Load<GameObject>("Spaceship"));
        }
    }
}