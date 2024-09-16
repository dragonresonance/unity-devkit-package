using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using UnityEngine;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T> // CSV Handler
	{
		#region Publics


			public bool TryImportCSV(TextAsset textAsset, string separator = ";", string delimiter = "\"", Formatting formatting = null)
			{
				return TryImportCSV(textAsset.text, separator, delimiter, formatting);
			}


			public bool TryImportCSV(string content, string separator = ";", string delimiter = "\"", Formatting formatting = null)
			{
				if (this is not DynamicSheet<string> stringBasedDynamicSheet) return false;


				stringBasedDynamicSheet.Clear();

				////string[] contentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				string[] contentLines = content.Split("\r\n".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);


				if (contentLines.Length == 0) return true;


				// Append the header line with no repeating items
				stringBasedDynamicSheet.AddRow(MakeCellRow(contentLines[0], separator, delimiter, null, true));

				////for (int lineIndex = 1; lineIndex < contentLines.Length; lineIndex++) {
				////	// Append the line directly
				////	stringBasedDynamicSheet.AddRow(makeCellRow(contentLines[lineIndex], separator, delimiter));
				////}
				////
				////
				////return true;


				return TryJoinCSV(content, separator, delimiter, formatting);
			}




			public bool TryJoinCSV(TextAsset textAsset, string separator = ";", string delimiter = "\"", Formatting formatting = null)
			{
				return TryJoinCSV(textAsset.text, separator, delimiter, formatting);
			}


			public bool TryJoinCSV(string content, string separator = ";", string delimiter = "\"", Formatting formatting = null)
			{
				if (this.cells == 0) return TryImportCSV(content, separator, delimiter, formatting); // At least one cell is necessary
				if (this is not DynamicSheet<string> stringBasedDynamicSheet) return false;


				string[] joiningContentLines = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				List<string> sheetHeadersRow = stringBasedDynamicSheet._dataMatrix[0];


				// Join the row of -new- headers without repeating items
				List<string> joiningHeadersRow = MakeCellRow(joiningContentLines[0], separator, delimiter, null, true);


				foreach (string header in joiningHeadersRow.Where(header => !sheetHeadersRow.Contains(header))) {
					sheetHeadersRow.Add(header);
				}

				stringBasedDynamicSheet.updateMaxColCount();
				stringBasedDynamicSheet.padDataMatrix();


				// Join the rows of content
				for (int joiningRowIndex = 1; joiningRowIndex < joiningContentLines.Length; joiningRowIndex++) {
					List<string> joiningRow = MakeCellRow(joiningContentLines[joiningRowIndex], separator, delimiter, formatting);


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




		#region Privates


			private List<string> MakeCellRow(string line, string separator, string delimiter, Formatting formatting, bool skipRepeatingItems = false)
			{
				List<string> cellRow = new();
				StringBuilder cellContentBuffer = new();
				bool inDelimiter = false;


				// Every cell is strictly separated first
				foreach (string cell in line.Split(separator)) {
					// Check the beginning of a delimiter
					if (!inDelimiter && cell.StartsWith(delimiter)) {
						inDelimiter = true;
					}

					// Add the content to the buffer
					cellContentBuffer.Append((formatting == null) ? cell : formatting(cell));

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




/*       ________________________________________________________________       */
/*           _________   _______ ________  _______  _______  ___    _           */
/*           |        \ |______/ |______| |  _____ |       | |  \   |           */
/*           |________/ |     \_ |      | |______| |_______| |   \__|           */
/*           ______ _____ _____ _____ __   _ _____ __   _ _____ _____           */
/*           |____/ |____ [___  |   | | \  | |___| | \  | |     |____           */
/*           |    \ |____ ____] |___| |  \_| |   | |  \_| |____ |____           */
/*       ________________________________________________________________       */
/*                                                                              */
/*           David Tabernero M.  <https://github.com/davidtabernerom>           */
/*           Dragon Resonance    <https://github.com/dragonresonance>           */
/*                  Copyright © 2021-2024. All rights reserved.                 */
/*                Licensed under the Apache License, Version 2.0.               */
/*                         See LICENSE.md for more info.                        */
/*       ________________________________________________________________       */
/*                                                                              */