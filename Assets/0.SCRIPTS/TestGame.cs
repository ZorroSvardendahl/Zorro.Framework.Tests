using System.Collections;
using System.Linq;
using Unity.Multiplayer.Playmode;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zorro.Core.CLI;
using Zorro.Framework;

namespace Zorro.TestGame
{
    public class TestGame : Game
    {
        public override void Initialize()
        {
            base.Initialize();
            
            // time to try to connect

            var tags = CurrentPlayer.ReadOnlyTags();

            if (tags.Contains("Host"))
            {
                StartCoroutine(HostWhenReady());

                IEnumerator HostWhenReady()
                {
                    float time = 10;

                    while (time > 0)
                    {
                        time -= Time.unscaledDeltaTime;
                        yield return null;

                        if (NetworkHandler.IsNetworkedGame && NetworkHandler.Instance.NetworkProvider.ReadyToConnect())
                        {
                            Game.Host(new SceneName(SceneManager.GetActiveScene().name));
                            yield break;
                        }
                    }
                    
                    Debug.LogError("Was not ready to host, timeout");
                }
            }
            else if (tags.Contains("Client"))
            {
                StartCoroutine(JoinWhenReady());

                IEnumerator JoinWhenReady()
                {
                    float time = 10;

                    while (time > 0)
                    {
                        time -= Time.unscaledDeltaTime;
                        yield return null;

                        if (NetworkHandler.IsNetworkedGame && NetworkHandler.Instance.NetworkProvider.ReadyToConnect())
                        {
                            yield return new WaitForSecondsRealtime(2.0f);
                            
                            Game.Join();
                            yield break;
                        }
                    }
                    
                    Debug.LogError("Was not ready to join, timeout");
                } 
            }
        }
    }
}