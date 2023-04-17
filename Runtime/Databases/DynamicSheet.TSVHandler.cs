using PossumScream.Enhancements;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T>
	{
		#region Controls


			public bool TryImportTSV(TextAsset textAsset, string separator = "\t", string delimiter = "\"")
			{
				return TryImportTSV(textAsset.text, separator, delimiter);
			}


			public bool TryImportTSV(string content, string separator = "\t", string delimiter = "\"")
			{
				if (this is not DynamicSheet<string> stringBasedDynamicSheet) return false;


				stringBasedDynamicSheet.Clear();

				string[] contentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				foreach (string line in contentLines) {
					// Append the line directly
					stringBasedDynamicSheet.AddRow(makeCellRow(line, separator, delimiter));
				}


				return true;
			}




			/*public bool TryJoinTSV(TextAsset textAsset, string separator = "\t", string delimiter = "\"", bool updateRowIfExisting = true)
			{
				return TryJoinTSV(textAsset.text, separator, delimiter, updateRowIfExisting);
			}


			public bool TryJoinTSV(string content, string separator = "\t", string delimiter = "\"", bool updateRowIfExisting = true)
			{
				if (this is not DynamicSheet<string> stringBasedDynamicSheet) return false;


				string[] contentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				List<string> headerRow = makeCellRow(contentLines[0], separator, delimiter);
				HLogger.Log($"headerRow: {string.Join("|", headerRow)}");

				foreach (string line in contentLines) {
					HLogger.Log($"	LINE");
					List<string> contentRow = makeCellRow(line, separator, delimiter);
					HLogger.Log($"contentRow: {string.Join("|", contentRow)}");
					int targetRowIndex = stringBasedDynamicSheet.GetRowIndexOf(contentRow[0]);
					HLogger.Log($"targetRowIndex: {targetRowIndex}");


					if (targetRowIndex > -1) {
						// Existing row
						HLogger.Log($"existing row");
						if (!updateRowIfExisting) continue;
					}
					else {
						// New row
						HLogger.Log($"new row");
						targetRowIndex = stringBasedDynamicSheet.AddRow();
					}
					HLogger.Log($"targetRowIndex: {targetRowIndex}");

					// Place each cell in its correct place
					for (int cellIndex = 0; cellIndex < contentRow.Count; cellIndex++) {
						HLogger.Log($"	CELL");
						//var contentCell = contentRow[cellIndex];
						int targetColumnIndex = stringBasedDynamicSheet.GetColumnIndexOf(headerRow[cellIndex]);
						HLogger.Log($"targetColumnIndex: {targetColumnIndex}");


						if (targetColumnIndex == -1) {
							// New (empty) column
							HLogger.Log($"new column");
							targetColumnIndex = stringBasedDynamicSheet.AddColumn();
						}
						HLogger.Log($"targetColumnIndex: {targetColumnIndex}");

						HLogger.Log($"stringBasedDynamicSheet: {stringBasedDynamicSheet.ToString()}");
						HLogger.Log($"SetCellByIndexes: {targetRowIndex}, {targetColumnIndex} <- {contentRow[cellIndex]}");
						stringBasedDynamicSheet.SetCellByIndexes(targetRowIndex, targetColumnIndex, contentRow[cellIndex]);
						HLogger.Log($"stringBasedDynamicSheet: {stringBasedDynamicSheet.ToString()}");
					}
				}


				return true;
			}*/


		#endregion




		#region Actions


			public List<string> makeCellRow(string line, string separator, string delimiter)
			{
				List<string> cellRow = new List<string>();
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
							cellRow.Add(finalCellContentString.Substring(1,
								(finalCellContentString.Length - 2)));
						}
						else {
							cellRow.Add(finalCellContentString);
						}

						cellContentBuffer.Clear();
					}
				}

				// If a delimited cell is unfinished, dump anyways
				if (cellContentBuffer.Length > 0) {
					cellRow.Add(cellContentBuffer.ToString());
				}


				return cellRow;
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