using System.Text;




namespace PossumScream.Databases
{
	public class CachedSheet<T>
	{
		private readonly T[][] _dataMatrix;
		private readonly int _rows, _cols;




		#region Constructors


			public CachedSheet(int rows, int columns)
			{
				this._rows = rows; this._cols = columns;

				this._dataMatrix = new T[rows][];
				for (int rowIndex = 0; rowIndex < rows; rowIndex++) {
					this._dataMatrix[rowIndex] = new T[columns];
				}
			}


		#endregion




		#region Controls


			public int GetRowIndexOf(T header)
			{
				for (int rowIndex = 0; rowIndex < this._rows; rowIndex++) {
					if (this._dataMatrix[rowIndex][0].Equals(header)) return rowIndex;
				}


				return -1;
			}


			public int GetColumnIndexOf(T header)
			{
				for (int colIndex = 0; colIndex < this._cols; colIndex++) {
					if (this._dataMatrix[0][colIndex].Equals(header)) return colIndex;
				}


				return -1;
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
				T[] row = new T[this.columns];


				for (int colIndex = 0; colIndex < this.columns; colIndex++) {
					row[colIndex] = this._dataMatrix[rowIndex][colIndex];
				}


				return row;
			}


			public T[] GetColumnByIndex(int columnIndex)
			{
				T[] column = new T[this.rows];


				for (int rowIndex = 0; rowIndex < this.rows; rowIndex++) {
					column[rowIndex] = this._dataMatrix[rowIndex][columnIndex];
				}


				return column;
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




			public DynamicSheet<T> ToDynamicSheet()
			{
				DynamicSheet<T> targetSheet = new DynamicSheet<T>();


				for (int rowIndex = 0; rowIndex < this._dataMatrix.Length; rowIndex++) {
					for (int colIndex = 0; colIndex < this._dataMatrix[rowIndex].Length; colIndex++) {
						targetSheet.SetCellByIndexes(rowIndex, colIndex, GetCellByIndexes(rowIndex, colIndex));
					}
				}


				return targetSheet;
			}


		#endregion




		#region Properties


			public T[][] dataMatrix => this._dataMatrix;
			public int cells => (this.rows * this.columns);
			public int columns => this._cols;
			public int rows => this._rows;


			public T this[T row, T column]
			{
				get => GetCellByIndexes(GetRowIndexOf(row), GetColumnIndexOf(column));
				set => SetCellByIndexes(GetRowIndexOf(row), GetColumnIndexOf(column), value);
			}


			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();


				foreach (T[] row in this._dataMatrix) {
					stringBuilder.AppendLine($"· {string.Join(" | ", row)}");
				}


				return stringBuilder.ToString();
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