using System.Collections.Generic;
using System.Text;




namespace PossumScream.Databases
{
	public partial class DynamicSheet<T>
	{
		private readonly List<List<T>> _dataMatrix = new();




		#region Constructors


			public DynamicSheet() {}


		#endregion




		#region Controls


			public T GetCell(int row, int col)
			{
				return this._dataMatrix[row][col];
			}




			public int GetRowIndexOf(T header)
			{
				for (int rowIndex = 0; rowIndex < this._dataMatrix.Count; rowIndex++) {
					if (this._dataMatrix[rowIndex][0].Equals(header)) return rowIndex;
				}


				return -1;
			}


			public int GetColumnIndexOf(T header)
			{
				return this._dataMatrix[0].IndexOf(header);
			}




			public void AddRow(IEnumerable<T> row)
			{
				AddRow(new List<T>(row));
			}


			public void AddRow(List<T> row)
			{
				this._dataMatrix.Add(row);
			}


			public void AddColumn(IEnumerable<T> column)
			{
				int itemIndex = 0;
				foreach (T item in column) {
					this._dataMatrix[itemIndex++].Add(item);
				}
			}




			public CachedSheet<T> ToCachedSheet()
			{
				CachedSheet<T> targetSheet = new CachedSheet<T>(this.rows, this.columns);


				for (var rowIndex = 0; rowIndex < this._dataMatrix.Count; rowIndex++) {
					for (var colIndex = 0; colIndex < this._dataMatrix[rowIndex].Count; colIndex++) {
						targetSheet.SetCell(rowIndex, colIndex, GetCell(rowIndex, colIndex));
					}
				}


				return targetSheet;
			}


		#endregion




		#region Properties


			public List<List<T>> dataMatrix => this._dataMatrix;
			public int columns => this._dataMatrix[0].Count;
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
					stringBuilder.AppendLine(string.Join("|", row));
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