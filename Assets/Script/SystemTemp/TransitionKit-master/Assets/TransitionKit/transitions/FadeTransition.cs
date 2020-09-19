using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;
using TW.GameSetting;

namespace Prime31.TransitionKit
{
	public class FadeTransition : TransitionKitDelegate
    {
		public Color fadeToColor = Color.black;
		public float duration = 0.5f;
		/// <summary>
		/// the effect looks best when it pauses before fading back. When not doing a scene-to-scene transition you may want
		/// to pause for a breif moment before fading back.
		/// </summary>
		public float fadedDelay = 0f;
		public int nextScene = -1;
        public SceneType sceneType;
        public Dictionary<string, object> data_hash;

        #region TransitionKitDelegate

        public Shader shaderForTransition()
		{
			return Shader.Find( "prime[31]/Transitions/Fader" );
		}


		public Mesh meshForDisplay()
		{
			return null;
		}


		public Texture2D textureForDisplay()
		{
			return null;
		}


		public IEnumerator onScreenObscured( TransitionKit transitionKit )
		{
			transitionKit.transitionKitCamera.clearFlags = CameraClearFlags.Nothing;
			transitionKit.material.color = fadeToColor;

            SceneManager.LoadScene(sceneType.ToString());
            TWManger.Instance.ChangeScene(sceneType, data_hash);

            yield return transitionKit.StartCoroutine( transitionKit.tickProgressPropertyInMaterial( duration ) );

			transitionKit.makeTextureTransparent();

			if( fadedDelay > 0 )
				yield return new WaitForSeconds( fadedDelay );

            yield return transitionKit.StartCoroutine( transitionKit.tickProgressPropertyInMaterial( duration, true ) );
		}

		#endregion

	}
}