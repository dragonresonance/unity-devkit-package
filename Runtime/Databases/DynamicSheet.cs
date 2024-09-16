using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T>
	{
		private int _maxCols = 0;
		private readonly List<List<T>> _dataMatrix = new();


		public delegate string Formatting(string data);




		#region Publics


			public int GetRowIndexOf(T header)
			{
				for (int rowIndex = 0; rowIndex < this.rows; rowIndex++) {
					if (this._dataMatrix[rowIndex][0].Equals(header)) return rowIndex;
				}


				return -1;
			}


			public int GetColumnIndexOf(T header)
			{
				return this._dataMatrix[0].IndexOf(header);
			}




			public bool ContainsRowHeader(T header)
			{
				return (GetRowIndexOf(header) > -1);
			}


			public bool ContainsColumnHeader(T header)
			{
				return (GetColumnIndexOf(header) > -1);
			}




			public T[] GetRowByIndex(int rowIndex)
			{
				return this._dataMatrix[rowIndex].ToArray();
			}


			public T[] GetColumnByIndex(int columnIndex)
			{
				return this._dataMatrix.Select(row => row[columnIndex]).ToArray();
			}


			public T[] GetHeadersRow()
			{
				return GetRowByIndex(0);
			}


			public T[] GetHeadersColumn()
			{
				return GetColumnByIndex(0);
			}




			public T GetCellByIndexes(int rowIndex, int columnIndex)
			{
				return this._dataMatrix[rowIndex][columnIndex];
			}


			public void SetCellByIndexes(int rowIndex, int columnIndex, T value)
			{
				this._dataMatrix[rowIndex][columnIndex] = value;
			}




			public int AddRow()
			{
				return AddRow(new List<T>());
			}


			public int AddRow(T header)
			{
				return AddRow(new List<T>() { header });
			}


			public int AddRow(IEnumerable<T> row)
			{
				return AddRow(new List<T>(row));
			}


			public int AddRow(List<T> row)
			{
				this._dataMatrix.Add(row);
				updateMaxColCount();
				padDataMatrix();

				return (this.rows - 1);
			}


			public int AddColumn()
			{
				padDataMatrix(1, true);
				return (this.columns - 1);
			}


			public int AddColumn(T header)
			{
				return AddColumn(new[] { header });
			}


			public int AddColumn(IEnumerable<T> column)
			{
				int itemIndex = 0;
				foreach (T item in column) {
					// Add a row per each column without one
					if (itemIndex == this.rows) {
						AddRow();
					}

					this._dataMatrix[itemIndex].Add(item);

					itemIndex++;
				}

				updateMaxColCount();
				return (this.columns - 1);
			}


			public void Clear()
			{
				this._dataMatrix.Clear();
				updateMaxColCount();
			}




			public CachedSheet<T> ToCachedSheet()
			{
				CachedSheet<T> targetSheet = new CachedSheet<T>(this.rows, this.columns);


				for (int rowIndex = 0; rowIndex < this._dataMatrix.Count; rowIndex++) {
					for (int colIndex = 0; colIndex < this._dataMatrix[rowIndex].Count; colIndex++) {
						targetSheet.SetCellByIndexes(rowIndex, colIndex, GetCellByIndexes(rowIndex, colIndex));
					}
				}


				return targetSheet;
			}


		#endregion




		#region Privates


			[ContextMenu(nameof(updateMaxColCount))]
			private void updateMaxColCount()
			{
				this._maxCols = 0;
				foreach (List<T> row in this._dataMatrix.Where(row => (row.Count > this._maxCols))) {
					this._maxCols = row.Count;
				}
			}


			[ContextMenu(nameof(padDataMatrix))]
			private void padDataMatrix()
			{
				padDataMatrix(0, false); // The updateMaxColCount param REALLY SHOULD be specified
			}


			private void padDataMatrix(int offset, bool updateMaxColCount)
			{
				foreach (List<T> row in this._dataMatrix) {
					while (row.Count < (this.columns + offset)) {
						row.Add(default);
					}
				}

				if (updateMaxColCount) {
					this._maxCols += offset;
				}
			}


		#endregion




		#region Properties


			public List<List<T>> dataMatrix => this._dataMatrix;
			public int cells => (this.rows * this.columns);
			public int columns => this._maxCols;
			public int rows => this._dataMatrix.Count;


			public T this[T row, T column]
			{
				get => GetCellByIndexes(GetRowIndexOf(row), GetColumnIndexOf(column));
				set => SetCellByIndexes(GetRowIndexOf(row), GetColumnIndexOf(column), value);
			}


			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();


				foreach (List<T> row in this._dataMatrix) {
					stringBuilder.AppendLine($"· {string.Join(" | ", row)}");
				}


				return stringBuilder.ToString();
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