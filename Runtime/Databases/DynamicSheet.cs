using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T>
	{
		private int _maxCols = 0;
		private readonly List<List<T>> _dataMatrix = new();




		#region Controls


			public T GetCellByIndexes(int rowIndex, int columnIndex)
			{
				return this._dataMatrix[rowIndex][columnIndex];
			}


			public void SetCellByIndexes(int rowIndex, int columnIndex, T value)
			{
				this._dataMatrix[rowIndex][columnIndex] = value;
			}




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




			public int AddRow()
			{
				return AddRow(new List<T>());
			}


			public int AddRow(IEnumerable<T> row)
			{
				return AddRow(new List<T>(row));
			}


			public int AddRow(List<T> row)
			{
				this._dataMatrix.Add(row);
				padDataMatrix();

				return (this.rows - 1);
			}


			public int AddColumn()
			{
				padDataMatrix(1);
				return (this.columns - 1);
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


				for (var rowIndex = 0; rowIndex < this._dataMatrix.Count; rowIndex++) {
					for (var colIndex = 0; colIndex < this._dataMatrix[rowIndex].Count; colIndex++) {
						targetSheet.SetCellByIndexes(rowIndex, colIndex, GetCellByIndexes(rowIndex, colIndex));
					}
				}


				return targetSheet;
			}


		#endregion




		#region Actions


			[Button(enabledMode:EButtonEnableMode.Editor)]
			private void updateMaxColCount()
			{
				this._maxCols = 0;
				foreach (List<T> row in this._dataMatrix.Where(row => (row.Count > this._maxCols))) {
					this._maxCols = row.Count;
				}
			}


			[Button(enabledMode:EButtonEnableMode.Editor)]
			private void padDataMatrix(int offset = 0)
			{
				updateMaxColCount();

				foreach (List<T> row in this._dataMatrix) {
					while (row.Count < (this.columns + offset)) {
						row.Add(default);
					}
				}

				this._maxCols += offset;
			}


		#endregion




		#region Properties


			public List<List<T>> dataMatrix => this._dataMatrix;
			public int columns => this._maxCols;
			public int rows => this._dataMatrix.Count;


			public T this[T row, T column]
			{
				get => this._dataMatrix[GetRowIndexOf(row)][GetColumnIndexOf(column)];
				set => this._dataMatrix[GetRowIndexOf(row)][GetColumnIndexOf(column)] = value;
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