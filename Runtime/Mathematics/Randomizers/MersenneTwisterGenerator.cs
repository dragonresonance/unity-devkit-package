using System;




namespace PossumScream.Mathematics.Randomizers
{
	public class MersenneTwisterGenerator : IPseudorandomNumberGenerator
	{
		// Period parameters
		private const int N = 624;
		private const int M = 397;
		private const uint MATRIX_A   = 0x9908_b0dfu; // constant vector a
		private const uint UPPER_MASK = 0x8000_0000u; // most significant w-r bits
		private const uint LOWER_MASK = 0x7fff_ffffu; // least significant r bits

		// Tempering parameters
		private const uint TEMPERING_MASK_B = 0x9d2c_5680u;
		private const uint TEMPERING_MASK_C = 0xefc6_0000u;

		// Real numbers
		private const double FINAL_CONSTANT = 2.3283064365386963e-10d;

		// Other parameters
		private const uint BEST_MULTIPLIER = 69069u; // proposed by George Marsaglia as a "candidate for the best of all multipliers"
		private const uint DEFAULT_SEED    = 4357u;  // default seed used in the original code




		private readonly ulong[] _mt = new ulong[625]; // the array for the state vector
		private int _mti             = N + 1;          // mti==N+1 means mt[N] is not initialized
		private uint _seed           = DEFAULT_SEED;   // the source seed




		#region Constructors


			public MersenneTwisterGenerator() : this(DEFAULT_SEED) {}

			public MersenneTwisterGenerator(uint seed)
			{
				Initialize(seed);
			}


		#endregion




		#region Controls


			/// <summary>
			/// Initialize the generator with a seed.
			/// </summary>
			/// <param name="seed">The NONZERO seed.</param>
			public void Initialize(uint seed)
			{
				this._seed = (seed > 0) ? seed : DEFAULT_SEED;
				this._mt[0] = this._seed & 0xffffffff;
				for (this._mti = 1; this._mti < N; this._mti++)
					this._mt[this._mti] = (BEST_MULTIPLIER * this._mt[this._mti - 1]) & 0xffffffff;
			}


			/// <summary>
			/// Generates random number between 0 (inclusive) and 1 (exclusive).
			/// </summary>
			/// <returns>The generated number.</returns>
			public double Generate()
			{
				ulong y;
				ulong[] mag01 = { 0x0, MATRIX_A };


				if (this._mti >= N) {
					int kk;


					if (this._mti == N + 1)
						Initialize(DEFAULT_SEED);

					for (kk = 0; kk < N - M; kk++) {
						y = (this._mt[kk] & UPPER_MASK) | (this._mt[kk + 1] & LOWER_MASK);
						this._mt[kk] = this._mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1];
					}

					for (; kk < N - 1; kk++) {
						y = (this._mt[kk] & UPPER_MASK) | (this._mt[kk + 1] & LOWER_MASK);
						this._mt[kk] = this._mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1];
					}

					y = (this._mt[N - 1] & UPPER_MASK) | (this._mt[0] & LOWER_MASK);
					this._mt[N - 1] = this._mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1];

					this._mti = 0;
				}

				y = this._mt[this._mti++];
				y ^= temperShiftU(y);
				y ^= temperShiftS(y) & TEMPERING_MASK_B;
				y ^= temperShiftT(y) & TEMPERING_MASK_C;
				y ^= temperShiftL(y);


				return ((double)y * FINAL_CONSTANT);
			}


			public int Generate(int minInclusive, int maxInclusive)
			{
				return (int)(Math.Floor(Generate((double)minInclusive, (double)maxInclusive)));
			}


			public double Generate(double minInclusive, double maxExclusive)
			{
				return (this.Generate() * (maxExclusive - minInclusive)) + minInclusive;
			}


		#endregion




		#region Actions


			private ulong temperShiftU(ulong y)
			{
				return (y >> 11);
			}


			private ulong temperShiftS(ulong y)
			{
				return (y << 7);
			}


			private ulong temperShiftT(ulong y)
			{
				return (y << 15);
			}


			private ulong temperShiftL(ulong y)
			{
				return (y >> 18);
			}


		#endregion




		#region Properties


			public uint seed => this._seed;


		#endregion
	}
}




/*                                                                                            */
/*                      |>  Based on the script of MarcAlx @ GitHub.  <|                      */
/*           |>  Inspired in the work of Makoto Matsumoto and Takuji Nishimura.  <|           */
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