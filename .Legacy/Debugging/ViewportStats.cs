using PossumScream.BlazingBehaviours;
using System.Text;




namespace PossumScream.CoolComponents.Debugging
{
	public class ViewportStats : ScriptableSceneSingleton<ViewportStats>
	{
		private StringBuilder _toStringOutput = new StringBuilder();




		#region Utilities


			private static bool tryRetrieveViewportBatches(out int batches)
			{
				#if UNITY_EDITOR
				{
					batches = UnityEditor.UnityStats.batches;
					return true;
				}
				#else
				{
					batches = -1;
					return false;
				}
				#endif
			}


			private static bool tryRetrieveViewportTriangles(out int triangles)
			{
				#if UNITY_EDITOR
				{
					triangles = UnityEditor.UnityStats.triangles;
					return true;
				}
				#else
				{
					triangles = -1;
					return false;
				}
				#endif
			}


		#endregion




		#region Overrides


			public override string ToString()
			{
				#if UNITY_EDITOR
				{
					this._toStringOutput.Clear();
					{
						tryRetrieveViewportBatches(out int batches);
						tryRetrieveViewportTriangles(out int triangles);

						this._toStringOutput.AppendLine($"Batches:    {batches:#,##0}");
						this._toStringOutput.AppendLine($"Triangles:  {triangles:#,##0}");
					}


					return this._toStringOutput.ToString();
				}
				#else
				{
					return "Unable to retrieve stats in the release version.";
				}
				#endif
			}


		#endregion
	}
}




/*                                                                                */
/*        David Tabernero M. @ PossumScream          Copyright © 2021-2022        */
/*        https://gitlab.com/possumscream             All rights reserved.        */
/*                                                                                */