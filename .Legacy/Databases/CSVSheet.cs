//using PossumScream.SickScripts.Logging;
using PossumScream.ExtremeExtensions;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;




namespace PossumScream.SickScripts.Databases
{
	public class CSVSheet
	{
		private List<string> _headerFields = null;
		private List<string> _lines = null;
		private string _separator = null;




		#region Constructors


			public CSVSheet(TextAsset textAsset, string separator) : this(textAsset.text, separator) {}

			public CSVSheet(string textContent, string separator)
			{
				reset();
				import(textContent, separator);
			}


		#endregion




		#region Controls


			public void import(TextAsset textAsset, string separator)
			{
				import(textAsset.text, separator);
			}


			public void import(string textContent, string separator)
			{
				this._separator = separator;

				import(textContent);
			}


			public void import(TextAsset textAsset)
			{
				import(textAsset.text);
			}


			public void import(string textContent)
			{
				this._lines.AddRange(textContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
				this._headerFields.AddRange(this._lines[0].Split(this._separator));
			}




			public bool tryQuery(string header, string key, out string value)
			{
				value = null;


				int columnIndex = -1;
				if ((columnIndex = this._headerFields.IndexOf(header)) == -1) return false;
				//HLogger.log($"Found column index {columnIndex}");


				int rowIndex = -1;
				for (int currentRowIndex = 0; currentRowIndex < this._lines.Count; currentRowIndex++) {
					if (key.Length > this._lines[currentRowIndex].Length) continue;
					if (this._lines[currentRowIndex].Substring(0, key.Length) != key) continue;

					rowIndex = currentRowIndex;
					break;
				}
				if (rowIndex == -1) return false;
				//HLogger.log($"Found row index {rowIndex}");


				int startingSeparatorIndex = this._lines[rowIndex].IndexOfOccurrence(this._separator, 0, columnIndex);
				int endingSeparatorIndex = this._lines[rowIndex].IndexOf(this._separator, (startingSeparatorIndex + 1), StringComparison.Ordinal);
				//HLogger.log($"Set separators at {startingSeparatorIndex} and {endingSeparatorIndex}");


				int startingCharacterIndex = startingSeparatorIndex + 1;
				int endingCharacterIndex = (endingSeparatorIndex > startingCharacterIndex) ? endingSeparatorIndex : this._lines[rowIndex].Length;
				//HLogger.log($"Set field between {startingCharacterIndex} and {endingCharacterIndex}");


				value = this._lines[rowIndex].Substring(startingCharacterIndex, (endingCharacterIndex - startingCharacterIndex));
				//HLogger.log($"Found field: \"{value}\"");


				return true;
			}




			public void clear()
			{
				this._headerFields.Clear();
				this._lines.Clear();
				this._separator = "";
			}


			public void reset()
			{
				this._headerFields = new List<string>();
				this._lines = new List<string>();
				this._separator = null;
			}


		#endregion




		#region Getters and Setters


			public List<string> headerFields => this._headerFields;
			public List<string> lines => this._lines;
			public string separator => this._separator;


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