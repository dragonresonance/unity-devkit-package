using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T> // CSV Handler
	{
		#region Controls


			public bool TryImportCSV(TextAsset textAsset, string separator = ";", string delimiter = "\"")
			{
				return TryImportCSV(textAsset.text, separator, delimiter);
			}


			public bool TryImportCSV(string content, string separator = ";", string delimiter = "\"")
			{
				if (this is not DynamicSheet<string> stringBasedDynamicSheet) return false;


				stringBasedDynamicSheet.Clear();

				////string[] contentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				string[] contentLines = content.Split("\r\n".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);


				if (contentLines.Length == 0) return true;


				// Append the header line with no repeating items
				stringBasedDynamicSheet.AddRow(makeCellRow(contentLines[0], separator, delimiter, true));

				////for (int lineIndex = 1; lineIndex < contentLines.Length; lineIndex++) {
				////	// Append the line directly
				////	stringBasedDynamicSheet.AddRow(makeCellRow(contentLines[lineIndex], separator, delimiter));
				////}
				////
				////
				////return true;


				return TryJoinCSV(content, separator, delimiter);
			}




			public bool TryJoinCSV(TextAsset textAsset, string separator = ";", string delimiter = "\"")
			{
				return TryJoinCSV(textAsset.text, separator, delimiter);
			}


			public bool TryJoinCSV(string content, string separator = ";", string delimiter = "\"")
			{
				if (this.cells == 0) return TryImportCSV(content, separator, delimiter); // At least one cell is necessary
				if (this is not DynamicSheet<string> stringBasedDynamicSheet) return false;


				string[] joiningContentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				List<string> sheetHeadersRow = stringBasedDynamicSheet._dataMatrix[0];


				// Join the row of -new- headers without repeating items
				List<string> joiningHeadersRow = makeCellRow(joiningContentLines[0], separator, delimiter, true);


				foreach (string header in joiningHeadersRow.Where(header => !sheetHeadersRow.Contains(header))) {
					sheetHeadersRow.Add(header);
				}

				stringBasedDynamicSheet.updateMaxColCount();
				stringBasedDynamicSheet.padDataMatrix();


				// Join the rows of content
				for (int joiningRowIndex = 1; joiningRowIndex < joiningContentLines.Length; joiningRowIndex++) {
					List<string> joiningRow = makeCellRow(joiningContentLines[joiningRowIndex], separator, delimiter);


					// Check if row header exist and create it if not
					int targetRowIndex;
					string joiningHeader = joiningRow[0];
					if ((targetRowIndex = stringBasedDynamicSheet.GetRowIndexOf(joiningHeader)) <= 0) { // Row does not exist or is copy of header (first row)
						// Create the row with the target header
						targetRowIndex = stringBasedDynamicSheet.AddRow(joiningHeader);
					}

					stringBasedDynamicSheet.updateMaxColCount();
					stringBasedDynamicSheet.padDataMatrix();


					// Insert cell data in its correct place, only if has col header
					for (int joiningCellIndex = 1; joiningCellIndex < joiningHeadersRow.Count; joiningCellIndex++) {
						int targetColIndex = stringBasedDynamicSheet.GetColumnIndexOf(joiningHeadersRow[joiningCellIndex]);


						if (targetColIndex > 0) {
							stringBasedDynamicSheet.SetCellByIndexes(targetRowIndex, targetColIndex, joiningRow[joiningCellIndex]);
						}
					}
				}


				return true;
			}


		#endregion




		#region Actions


			public List<string> makeCellRow(string line, string separator, string delimiter, bool skipRepeatingItems = false)
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
							finalCellContentString = finalCellContentString.Substring(1, (finalCellContentString.Length - 2));
						}

						if (!skipRepeatingItems || !cellRow.Contains(finalCellContentString)) {
							cellRow.Add(finalCellContentString);
						}

						cellContentBuffer.Clear();
					}
				}

				// If a delimited cell is unfinished and does not exist, dump anyways
				if ((cellContentBuffer.Length > 0) && (!skipRepeatingItems || !cellRow.Contains(cellContentBuffer.ToString()))) {
					cellRow.Add(cellContentBuffer.ToString());
				}


				return cellRow;
			}


		#endregion
	}
}




/*                                                                                            */
/*          ______                               _______                                      */
/*          \  __ \____  ____________  ______ ___\  ___/_____________  ____  ____ ___         */
/*          / /_/ / __ \/ ___/ ___/ / / / __ \__ \\__ \/ ___/ ___/ _ \/ __ \/ __ \__ \        */
/*         / ____/ /_/ /__  /__  / /_/ / / / / / /__/ / /__/ /  / ___/ /_/ / / / / / /        */
/*        /_/    \____/____/____/\____/_/ /_/ /_/____/\___/_/   \___/\__/_/_/ /_/ /__\        */
/*                                                                                            */
/*        Licensed under the Apache License, Version 2.0. See LICENSE.md for more info        */
/*        David Tabernero M. @ PossumScream                      Copyright © 2021-2023        */
/*        GitLab - GitHub: possumscream                            All rights reserved        */
/*        -------------------------                                  -----------------        */
/*                                                                                            */