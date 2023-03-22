using PossumScream.SickScripts.Logging;
using System.Collections.Generic;
using UnityObject = UnityEngine.Object;




namespace PossumScream.SickScripts.Databases
{
	public class CSVBook
	{
		private HashSet<CSVSheet> _sheets = null;




		#region Constructors


			public CSVBook()
			{
				reset();
			}


			public CSVBook(CSVSheet sheet) : this()
			{
				this._sheets.Add(sheet);
			}


			public CSVBook(IEnumerable<CSVSheet> sheets) : this()
			{
				foreach (CSVSheet sheet in sheets) {
					this._sheets.Add(sheet);
				}
			}


		#endregion




		#region Controls


			public bool add(CSVSheet item)
			{
				return this._sheets.Add(item);
			}


			public bool remove(CSVSheet item)
			{
				return this._sheets.Remove(item);
			}




			public bool tryQuery(string header, string key, out string value)
			{
				value = null;


				foreach (CSVSheet sheet in this._sheets) {
					if (!sheet.tryQuery(header, key, out string temporaryValue)) continue;

					value = temporaryValue;
					return true;
				}


				return false;
			}




			public void clear()
			{
				this._sheets.Clear();
			}


			public void reset()
			{
				this._sheets = new HashSet<CSVSheet>();
			}


		#endregion




		#region Actions


			//


		#endregion




		#region Getters and Setters


			public HashSet<CSVSheet> sheets => this._sheets;


		#endregion
	}
}




/*                                                                                            */
/*            ____                                 _____                                      */
/*           / __ \____  ____________  ______ ___ / ___/_____________  ____ _____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ `__ \\__ \/ ___/ ___/ _ \/ __ `/ __ `__ \        */
/*         / ____/ /_/ (__  |__  ) /_/ / / / / / /__/ / /__/ /  /  __/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\__,_/_/ /_/ /_/____/\___/_/   \___/\__,_/_/ /_/ /_/         */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        https://gitlab.com/possumscream                          All rights reserved        */
/*                                                                                            */
/*                                                                                            */