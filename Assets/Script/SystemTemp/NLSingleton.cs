using UnityEngine;
using System.Collections;

namespace PW
{    
	/// <summary>
	/// シングルトン
	/// ※Awakeを使用する場合はbase.Awake()を呼び出してください
	/// </summary>
	public class NLSingleton<T> : SystemBaseManager where T : SystemBaseManager
    {
       
        protected static T instance;

		public static T Instance
		{
			get {
				if (instance == null) {
					instance = (T)FindObjectOfType (typeof(T));
					if (instance == null) {
						Debug.LogError ("Singleton Error:" + typeof(T));
					}
				}

				return instance;
			}
		}

		protected void Awake()
		{
			if (this != Instance) {
				Destroy (this);
				return;
			}
		}

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

    }

	/// <summary>
	/// シングルトン（DontDestroyOnLoad)
	/// ※Awakeを使用する場合はbase.Awake()を呼び出してください
	/// </summary>
	public class NLSingletonDontDestroy<T> : MonoBehaviour where T : MonoBehaviour {

		protected static T instance;

		public static T Instance
		{
			get {
				if (instance == null) {
					instance = (T)FindObjectOfType (typeof(T));
					if (instance == null) {
						Debug.LogError ("Singleton Error:" + typeof(T));
					}
				}

				return instance;
			}
		}

		protected void Awake()
		{
			if (this != Instance) {
				Destroy (this);
				return;
			}
			DontDestroyOnLoad (this.gameObject);
		}

	}

	public class NLSingletonObject<T> : MonoBehaviour where T : MonoBehaviour {

		protected static T instance;

		public static T Instance
		{
			get {
				if (instance == null) {
					instance = (T)FindObjectOfType (typeof(T));
					if (instance == null) {
						Debug.LogError ("Singleton Error:" + typeof(T));
					}
				}

				return instance;
			}
		}

		protected void Awake()
		{
			if (this != Instance) {
				Destroy (this.gameObject);
				return;
			}
		}

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

	}

	public class NLSingletonDontDestroyObject<T> : SystemBaseManager where T : SystemBaseManager
    {

		protected static T instance;

		public static T Instance
		{
			get {
				if (instance == null) {
					instance = (T)FindObjectOfType (typeof(T));
					if (instance == null) {
						Debug.LogError ("Singleton Error:" + typeof(T));
					}
				}

				return instance;
			}
		}

		protected void Awake()
		{
			if (this != Instance) {
				Destroy (this.gameObject);
				return;
			}
            this.gameObject.transform.parent = null;
            DontDestroyOnLoad (this.gameObject);
		}

	}

}
