using Photon.Realtime;
using UnityEngine;
using Zorro.Framework;
using Zorro.Framework.Photon;

namespace Zorro.TestGame
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "TestGame/" + nameof(GameSettings))]
    public class TestGameGameSettings : GameSettings, IPhotonAppSettingHolder
    {
        public AppSettings PhotonAppSettings;
        
        public AppSettings GetAppSettings()
        {
            return PhotonAppSettings;
        }
    }
}