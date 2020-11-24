using System.Threading;
using UnityEngine;

namespace JCiOSSDK
{
    public class JCiOSSDKSynchronizationContext : MonoBehaviour
    {
        protected static JCiOSSDKSynchronizationContext instance = null;

        public static JCiOSSDKSynchronizationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Object.FindObjectOfType<JCiOSSDKSynchronizationContext>();
                }

                if (instance == null)
                {
                    var obj = new GameObject(typeof(JCiOSSDKSynchronizationContext).Name);
                    DontDestroyOnLoad(obj);
                    instance = obj.AddComponent<JCiOSSDKSynchronizationContext>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
        }

        private void Update()
        {
            OneThreadSynchronizationContext.Instance.Update();
        }
    }
}
