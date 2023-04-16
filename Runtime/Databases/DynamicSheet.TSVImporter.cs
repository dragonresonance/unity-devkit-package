using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T>
	{
		#region Controls


			public bool TryImportTSV(TextAsset textAsset, string separator = "	", string delimiter = "\"")
			{
				return TryImportTSV(textAsset.text, separator, delimiter);
			}


			public bool TryImportTSV(string content, string separator = "	", string delimiter = "\"")
			{
				if (this._dataMatrix is not List<List<string>> stringMatrix) return false;


				// Clear matrix content
				{
					stringMatrix.Clear();
				}


				// Dump content lines as lists of separated cells
				{
					// Get all raw lines
					string[] contentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


					foreach (string line in contentLines) {
						List<string> finalCells = new List<string>();
						StringBuilder cellContentBuffer = new StringBuilder();
						bool inDelimiter = false;


						// Every cell is strictly separated first
						foreach (string cell in line.Split(separator)) {
							// Check the beginning of a delimiter
							if (!inDelimiter && cell.StartsWith(delimiter)) {
								inDelimiter = true;
							}

							// Add the content to the buffer
							cellContentBuffer.Append(cell);

							// Check the ending of a delimiter
							if (inDelimiter && cell.EndsWith(delimiter)) {
								inDelimiter = false;
							}

							if (inDelimiter) {
								// If still in delimiter, add the usual separator
								cellContentBuffer.Append(separator);
							}
							else {
								// If (no)/(end of) delimiter, dump the content of the buffer to the cell
								string finalCellContentString = cellContentBuffer.ToString();


								// A cell should no have both starting and ending delimiters
								if (finalCellContentString.StartsWith(delimiter) &&
								    finalCellContentString.EndsWith(delimiter)) {
									finalCells.Add(finalCellContentString.Substring(1,
										(finalCellContentString.Length - 2)));
								}
								else {
									finalCells.Add(finalCellContentString);
								}

								cellContentBuffer.Clear();
							}
						}

						// If a delimited cell is unfinished, dump anyways
						if (cellContentBuffer.Length > 0) {
							finalCells.Add(cellContentBuffer.ToString());
						}

						// Add the row of cells to the matrix
						stringMatrix.Add(finalCells);
					}
				}


				return true;
			}


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